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
        callEndedEvent: workload,
    },
    thresholds,
};

export default async function (callAnsweredEvent: CallUpdatedMessage): Promise<CallUpdatedMessage> {
    // Arrange
    const { tenantId } = settings;

    // Get the callId from the previous event
    const callId = callAnsweredEvent.changes.updatedValues["Id"];

    const payload: CallUpdatedMessage = {
        sid: callAnsweredEvent.sid,
        callService: CallService.Kazoo2600,
        changes: {
            state: TelecomDataState.Updated,
            tenantId: Number(tenantId),
            originalValues: {
                Status: CallStatus.Answered,
            },
            updatedValues: {
                Status: CallStatus.Completed,
                Id: callId,
            },
        },
    };

    // Act
    publishAsbMessage("callchanged_queue", JSON.stringify(payload));

    return payload;
}
