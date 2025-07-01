import { check } from "k6";
import { createHMAC } from "k6/crypto";
import http from "k6/http";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { randomItem } from "../lib/k6-utils/index.js";
import { settings } from "../config/index.ts";

function getAsbAuthorizationHeader(uri: string, saName: string, saKey: string): string {
    if (!uri || !saName || !saKey) {
        throw new Error("Missing required parameter");
    }
    const encoded = encodeURIComponent(uri);
    const now = new Date();
    const week = 60 * 60 * 24 * 7;
    const ttl = Math.round(now.getTime() / 1000) + week;
    const signature = encoded + "\n" + ttl;
    const hasher = createHMAC("sha256", saKey);
    hasher.update(signature);
    const hash = hasher.digest("base64");

    return (
        "SharedAccessSignature sr=" +
        encoded +
        "&sig=" +
        encodeURIComponent(hash) +
        "&se=" +
        ttl +
        "&skn=" +
        saName
    );
}

export default function publishAsbMessage(topic: string, payload: string): void {
    const { azureServiceBusUrls } = settings;

    // since each environment has 2 service buses, we will randomly pick one to distribute load
    const asb = randomItem(azureServiceBusUrls);
    const { url, key } = asb;
    console.log(`Publishing message to ${url}${topic}/messages`);

    const sasToken = getAsbAuthorizationHeader(
        `${url}${topic}`,
        "RootManageSharedAccessKey",
        key ?? ""
    );
    const asbHeaders = {
        "Content-Type": "application/json",
        Authorization: sasToken,
    };
    const res = http.post(`${url}${topic}/messages`, payload, {
        headers: asbHeaders,
        tags: { name: "publishAsbMessage", url: `${url}${topic}/messages` },
    });

    check(res, {
        "messages published": (r) => r.status === 201,
    });
}
