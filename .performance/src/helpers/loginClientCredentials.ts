import http from "k6/http";
import { settings } from "../config/index.ts";

export default function loginClientCredentials(): string {
    console.log("Getting m2m token for test...");
    const { clientId, clientSecret } = settings;

    const payload: Record<string, string> = {
        grant_type: "client_credentials",
        client_id: clientId,
        client_secret: clientSecret ?? "",
        scope: "ccpro.interactions_service.all st.account_service.all eh.service_account.read",
    };

    const formBody = Object.keys(payload)
        .map((key) => `${encodeURIComponent(key)}=${encodeURIComponent(payload[key])}`)
        .join("&");

    const tokenResponse = http.post(settings.tokenUrl, formBody, {
        headers: {
            Accept: "*/*",
            "Content-Type": "application/x-www-form-urlencoded",
            "User-Agent": "k6",
        },
    });
    const tokenData = tokenResponse.json() as { access_token: string };
    console.log("Got token for test...", tokenData.access_token ? "****" : "ERROR");
    return tokenData.access_token;
}
