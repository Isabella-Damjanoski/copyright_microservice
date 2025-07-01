import { Options } from "k6/options";
import { settings, thresholds, workload } from "../../config/index.ts";
import publishAsbMessage from "../../helpers/publishAsbMessage.ts";
import { ConversationEvent } from "../../types/ConversationEvent.ts";
import {
    CallService,
    CallStatus,
    CallUpdatedMessage,
    TelecomDataState,
} from "../../types/CallUpdatedEvent.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        callCreatedEvent: workload,
    },
    thresholds,
};

export default async function (conversationEvent: ConversationEvent): Promise<CallUpdatedMessage> {
    // Arrange
    const { tenantId } = settings;
    const callId = Math.floor(Math.random() * 1_000_000_000); // Random ID for the call
    const isInbound = conversationEvent.conversation.direction === "Inbound";

    const payload: CallUpdatedMessage = {
        sid: conversationEvent.conversation.sid,
        callService: CallService.Kazoo2600,
        changes: {
            state: TelecomDataState.Added,
            tenantId: Number(tenantId),
            originalValues: {},
            updatedValues: {
                Status: isInbound ? CallStatus.Ringing : CallStatus.Initiated,
                Direction: isInbound ? 0 : 1, // 0 = Inbound, 1 = Outbound in PostCallDirection
                CreatedOn: new Date().toISOString(),
                From: conversationEvent.data?.from,
                To: conversationEvent.data?.to,
                Id: callId,
            },
        },
    };

    // Act
    publishAsbMessage("callchanged_queue", JSON.stringify(payload));

    return payload;
}
