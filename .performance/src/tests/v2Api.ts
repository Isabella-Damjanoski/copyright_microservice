import { Options } from "k6/options";
import { workload, thresholds } from "../config/index.ts";
import loginClientCredentials from "../helpers/loginClientCredentials.ts";
import v2CreateInteraction from "./apis/v2CreateInteraction.ts";
import v2GetInteractionById from "./apis/v2GetInteractionById.ts";
import v2GetInteractions from "./apis/v2GetInteractions.ts";
import { sleep } from "k6";
import v2InteractionClassification from "./apis/v2InteractionClassification.ts";
import v2UpdateInteraction from "./apis/v2UpdateInteraction.ts";

export { handleSummary } from "../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        v2Api: workload,
    },
    thresholds: {
        ...thresholds,
        "http_req_duration{name:v2GetInteractions}": ["p(90) < 800"],
        "http_req_duration{name:v2CreateInteraction}": ["p(90) < 150"],
        "http_req_duration{name:v2UpdateInteraction}": ["p(90) < 150"],
        "http_req_duration{name:v2InteractionClassification}": ["p(90) < 1000"],
        "http_req_duration{name:v2GetInteractionById}": ["p(90) < 150"],
    },
};

export async function setup(): Promise<string> {
    return loginClientCredentials();
}

export default async function (token: string): Promise<void> {
    const interaction = await v2CreateInteraction(token);
    sleep(1);

    await v2InteractionClassification({ token, interactionId: interaction!.id });
    await v2UpdateInteraction({ token, interactionId: interaction!.id });
    await v2GetInteractionById({ token, interactionId: interaction!.id });

    sleep(1);

    // Conversation History Open Tab
    await v2GetInteractions(
        token,
        `&statuses=Open&channelClassificationTypeIds=1&channelClassificationTypeIds=4&channelCompleted=YES&pageSortOrder=-startedAt`
    );

    // Conversation History Open Count
    await v2GetInteractions(
        token,
        `&statuses=Open&channelClassificationTypeIds=1&channelClassificationTypeIds=4&channelCompleted=YES`
    );

    // Conversation History Closed Tab
    await v2GetInteractions(token, `&statuses=Completed&pageSortOrder=-startedAt`);

    sleep(1);
}
