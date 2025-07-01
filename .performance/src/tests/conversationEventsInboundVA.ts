import { sleep } from "k6";
import { Options } from "k6/options";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { randomIntBetween } from "../lib/k6-utils/index.js";
import { thresholds, workload } from "../config/index.ts";
import conversationCreatedEvent from "./events/conversationCreatedEvent.ts";
import conversationUpdatedEvent from "./events/conversationUpdatedEvent.ts";
import conversationSessionCreatedEvent from "./events/conversationSessionCreatedEvent.ts";
import conversationEndedEvent from "./events/conversationEndedEvent.ts";
import conversationSessionAnsweredEvent from "./events/conversationSessionAnsweredEvent.ts";
import v2GetInteractions from "./apis/v2GetInteractions.ts";
import loginClientCredentials from "../helpers/loginClientCredentials.ts";
import conversationSessionEndedEvent from "./events/conversationSessionEndedEvent.ts";
import v2CreateInteraction from "./apis/v2CreateInteraction.ts";
import v2InteractionClassification from "./apis/v2InteractionClassification.ts";
import callCreatedEvent from "./events/callCreatedEvent.ts";
import callAnsweredEvent from "./events/callAnsweredEvent.ts";
import callEndedEvent from "./events/callEndedEvent.ts";
import callClassifiedEvent from "./events/callClassifiedEvent.ts";
export { handleSummary } from "../helpers/handleSummary.ts";

// k6 options
export const options: Options = {
    scenarios: {
        conversationEventsInboundVA: {
            // For event based tests, we want a constant flow so we set the executor to constant-arrival-rate
            // This way we can check how many messages we can handle per second over a period of time.
            // For example, if we want to verify we can handle 15,000 conversations over 10 minutes,
            // to accomplish this, duration should be 10m and vus should be 25 (15,000 / 10m = 25 per second)
            executor: "constant-arrival-rate",
            duration: workload.maxDuration ?? "5s",
            rate: workload.vus ?? 1,
            timeUnit: "1s",
            preAllocatedVUs: (workload.vus ?? 1) * 3,
            // this should be at least the rate * the amount of sleep time
            // for example if we have a rate of 25 per second and we sleep for 10 second, we need to have a maxVUs of at least 250
            // this test sleeps for a max of 9 seconds
            maxVUs: (workload.vus ?? 1) * 45,
            // how long after the last iteration do we wait before stopping the test
            // this should be at least the p(95) of how long a iteration takes
            gracefulStop: "60s",
        },
    },
    thresholds,
};

export async function setup(): Promise<string> {
    return loginClientCredentials();
}

export default async function (token: string): Promise<void> {
    const interaction = await v2CreateInteraction(token);
    // Created event has dependencies
    // - calls monolith to fill the TenantName, leave TenantId empty so this is not triggered
    // - calls PCS to fill the OrgNodeId, not yet implemented
    // - calls monolith to fill the Campaign, leave TenantId empty so this is not triggered
    const createdEvent = await conversationCreatedEvent(interaction);

    // CallUpdated - Created event to mimic the monolith event
    const callCreatedMsg = await callCreatedEvent(createdEvent);

    // Updated event, no dependencies
    await conversationUpdatedEvent(createdEvent);
    sleep(1);

    // Session created event, for inbound call, no dependencies
    await conversationSessionCreatedEvent(createdEvent);
    sleep(randomIntBetween(1, 8));

    // Session answered event has dependencies
    // - calls VA service to get VA's name
    await conversationSessionAnsweredEvent(createdEvent);
    // Call Answered event
    const callAnsweredMsg = await callAnsweredEvent(callCreatedMsg);
    sleep(randomIntBetween(10, 30));

    // Ended event, no dependencies
    await conversationSessionEndedEvent(createdEvent);
    await conversationEndedEvent(createdEvent);
    // Send Call Ended event
    const callEndedMsg = await callEndedEvent(callAnsweredMsg);
    sleep(1);

    // Send Call Classified event
    await callClassifiedEvent(callEndedMsg);
    sleep(1);

    // get interaction by sid to ensure it exists and validate CallId
    await v2GetInteractions(token, `&channelids=${createdEvent.conversation.sid}`, {
        "v2GetInteractions channelDetails callId is set": (data) => {
            if (!data?.items || data.items.length === 0) {
                return false;
            }

            const interaction = data.items[0];
            const expectedCallId = callCreatedMsg.changes.updatedValues["Id"];
            const actualCallId = interaction.channelDetails?.callId;

            return actualCallId === expectedCallId;
        },
    });

    await v2InteractionClassification({
        token,
        interactionId: interaction!.id,
    });
}
