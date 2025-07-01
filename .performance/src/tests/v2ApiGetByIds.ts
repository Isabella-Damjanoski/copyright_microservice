import { Options } from "k6/options";
import { workload, thresholds } from "../config/index.ts";
import loginClientCredentials from "../helpers/loginClientCredentials.ts";
import v2GetInteractions from "./apis/v2GetInteractions.ts";
import { sleep } from "k6";

export { handleSummary } from "../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        v2Api: workload,
    },
    thresholds: {
        ...thresholds,
        "http_req_duration{name:v2GetInteractions}": ["avg < 1500"],
    },
};

export async function setup(): Promise<string> {
    return loginClientCredentials();
}

export default async function (token: string): Promise<void> {
    const results = await v2GetInteractions(token, "&pageSize=100");
    const interactionIds = results.items.map((interaction) => "&ids=" + interaction.id).join("");
    await v2GetInteractions(token, interactionIds);
    sleep(1);
}
