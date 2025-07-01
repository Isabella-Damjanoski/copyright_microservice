import { Options } from "k6/options";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { uuidv4 } from "../../lib/k6-utils/index.js";
import { thresholds, workload } from "../../config/index.ts";
import publishAsbMessage from "../../helpers/publishAsbMessage.ts";
import { ConversationEvent } from "../../types/ConversationEvent.ts";
import conversationCreatedEvent from "./conversationCreatedEvent.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        conversationUpdatedEvent: workload,
    },
    thresholds,
};

export async function setup(): Promise<ConversationEvent> {
    return await conversationCreatedEvent();
}

export default async function (createdEvent: ConversationEvent): Promise<void> {
    const payload = {
        ...createdEvent,
        metadata: {
            id: uuidv4(),
            timestamp: Date.now(),
            category: "conversation",
            type: "updated",
        },
        data: {
            ...createdEvent.data,
            traits: ["External"],
        },
    } as ConversationEvent;

    publishAsbMessage("conversation_event_topic", JSON.stringify(payload));
}
