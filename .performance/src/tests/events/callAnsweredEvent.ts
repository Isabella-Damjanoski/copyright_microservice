import { Options } from "k6/options";
import { settings, thresholds, workload } from "../../config/index.ts";
import publishAsbMessage from "../../helpers/publishAsbMessage.ts";
import {
    CallService,
    CallStatus,
    CallUpdatedMessage,
    TelecomDataState,
} from "../../types/CallUpdatedEvent.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        callAnsweredEvent: workload,
    },
    thresholds,
};

export default async function (callCreatedEvent: CallUpdatedMessage): Promise<CallUpdatedMessage> {
    // Arrange
    const { tenantId } = settings;

    // Get the callId from the created event
    const callId = callCreatedEvent.changes.updatedValues["Id"];

    const payload: CallUpdatedMessage = {
        sid: callCreatedEvent.sid,
        callService: CallService.Kazoo2600,
        changes: {
            state: TelecomDataState.Updated,
            tenantId: Number(tenantId),
            originalValues: {
                Status: callCreatedEvent.changes.updatedValues["Status"],
            },
            updatedValues: {
                Status: CallStatus.Answered,
                Id: callId,
            },
        },
    };

    // Act
    publishAsbMessage("callchanged_queue", JSON.stringify(payload));

    return payload;
}
