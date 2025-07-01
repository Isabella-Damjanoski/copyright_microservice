import { Options } from "k6/options";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { uuidv4 } from "../../lib/k6-utils/index.js";
import { thresholds, workload } from "../../config/index.ts";
import publishAsbMessage from "../../helpers/publishAsbMessage.ts";
import { ConversationEvent } from "../../types/ConversationEvent.ts";
import conversationCreatedEvent from "./conversationCreatedEvent.ts";
import { calculateTimeSpan } from "../../helpers/dataHelpers.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        conversationEndedEvent: workload,
    },
    thresholds,
};

export async function setup(): Promise<ConversationEvent> {
    return await conversationCreatedEvent();
}

export default async function (createdEvent: ConversationEvent): Promise<void> {
    const startTimeStamp = createdEvent.metadata.timestamp;
    const timestamp = Date.now();
    const duration = calculateTimeSpan(startTimeStamp, timestamp);
    const payload = {
        ...createdEvent,
        metadata: {
            id: uuidv4(),
            timestamp: timestamp,
            category: "conversation",
            type: "ended",
        },
        data: {
            duration,
        },
    } as ConversationEvent;

    publishAsbMessage("conversation_event_topic", JSON.stringify(payload));
}
