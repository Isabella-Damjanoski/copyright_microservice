import { check } from "k6";
import http from "k6/http";
import { vu } from "k6/execution";
import { config } from "../config/settings.ts";
import { login } from "./login.ts";
import { TokenInfo, User } from "../types/index.ts";
import { SharedArray } from "k6/data";
import { BrowserContext, Page } from "k6/browser";

export const users = new SharedArray("users", function () {
    return JSON.parse(open("../users.json"));
}) as User[];

let tokens: TokenInfo[] = [];

export async function refreshToken(incomingTokens?: TokenInfo[]): Promise<{
    tokenInfo?: TokenInfo;
    browserPage?: Page;
    browserContext?: BrowserContext;
}> {
    if (incomingTokens && tokens.length === 0) {
        tokens = incomingTokens;
    }

    const vuID = vu.idInTest - 1;
    const userIndex = vuID % users.length;

    console.log("ITERATION", vu.iterationInScenario, "VU", vuID, "USER", userIndex);

    const now = Date.now() / 1000; // in seconds
    const tokenInfo = tokens[userIndex];

    if (!tokenInfo?.access_token) {
        console.log("LOGIN START FOR VU", vuID);
        const { tokenInfo } = await login(users, userIndex);
        tokens[userIndex] = tokenInfo;
        console.log("UPDATED tokens");
        return { tokenInfo };
    }
    console.log("NEW LOGIN NOT REQUIRED");
    const proactiveRefreshTime = 120; // 2 minutes
    if (tokenInfo.expires_in - (now - tokenInfo.issued_at) > proactiveRefreshTime) {
        // token is still valid for 1 minute
        console.log(
            "TOKEN REFRESH NOT REQUIRED. TOKEN is VALID FOR the next",
            tokenInfo.expires_in - (now - tokenInfo.issued_at),
            "seconds"
        );
        return { tokenInfo };
    }

    const refreshToken = tokenInfo.refresh_token;
    console.log("EXECUTING TOKEN REFRESH");
    const payload = `grant_type=refresh_token&client_id=${config.clientId}&redirect_uri=${encodeURIComponent(config.appUrl)}%2Fsignin-oidc&refresh_token=${refreshToken}`;
    const params = {
        headers: {
            "Content-Type": "application/x-www-form-urlencoded",
        },
    };

    const res = http.post(config.tokenUrl, payload, params);
    check(res, {
        "is status 200": (r) => r.status === 200,
    });
    if (res.status === 200 && res.body) {
        const data = JSON.parse(res.body.toString());
        data.issued_at = now; // refresh token response does not have issued_at
        console.log("REFRESH TOKEN COMPLETED FOR " + vuID, data);
        tokens[userIndex] = data;
        return data;
    } else {
        console.error(`Failed to refresh token: ${res.status} ${res.body} ${res}`);
        return {};
    }
}
