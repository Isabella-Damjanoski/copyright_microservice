// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { uuidv4 } from "../lib/k6-utils/index.js";
import { settings } from "../config/index.ts";

export const getDefaultHeaders = (token?: string): Record<string, string> => {
    const { appUrl, contactCenterId } = settings;
    return {
        accept: `*/*`,
        authorization: `Bearer ${token}`,
        "cache-control": `no-cache`,
        "content-type": `application/json`,
        "user-agent": `Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36`,
        origin: appUrl,
        "X-ContactCenterId": contactCenterId ?? uuidv4(),
    };
};
