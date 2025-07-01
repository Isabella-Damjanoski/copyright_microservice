import { Options } from "k6/options";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { uuidv4 } from "../../lib/k6-utils/index.js";
import { settings, thresholds, workload } from "../../config/index.ts";
import publishAsbMessage from "../../helpers/publishAsbMessage.ts";
import { ConversationEvent } from "../../types/ConversationEvent.ts";
import conversationCreatedEvent from "./conversationCreatedEvent.ts";
import { calculateTimeSpan } from "../../helpers/dataHelpers.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        conversationSessionCreatedEvent: workload,
    },
    thresholds,
};

export async function setup(): Promise<ConversationEvent> {
    return await conversationCreatedEvent();
}

export default async function (createdEvent: ConversationEvent): Promise<void> {
    const { vaSettingsId } = settings;

    const timestamp = Date.now();
    const duration = calculateTimeSpan(createdEvent.metadata.timestamp, timestamp);
    const payload = {
        ...createdEvent,
        metadata: {
            id: uuidv4(),
            timestamp: Date.now(),
            category: "conversation.session",
            type: "ended",
        },
        session: {
            id: uuidv4(),
            type: "VirtualAgent",
            direction: "Inbound",
            baseVaSettingsId: vaSettingsId,
        },
        data: {
            endedBy: "Callee",
            type: "Hangup",
            duration,
            reason: "Goodbye",
            message: "Virtual agent requested goodbye hangup",
        },
    } as ConversationEvent;

    publishAsbMessage("conversation_event_topic", JSON.stringify(payload));
}
