import { Options } from "k6/options";
import { settings, thresholds, workload } from "../../config/index.ts";
import publishAsbMessage from "../../helpers/publishAsbMessage.ts";
import {
    CallService,
    CallType,
    CallUpdatedMessage,
    TelecomDataState,
} from "../../types/CallUpdatedEvent.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        callClassifiedEvent: workload,
    },
    thresholds,
};

export default async function (callEndedEvent: CallUpdatedMessage): Promise<CallUpdatedMessage> {
    // Arrange
    const { tenantId } = settings;

    // Get the callId from the previous event
    const callId = callEndedEvent.changes.updatedValues["Id"];

    const payload: CallUpdatedMessage = {
        sid: callEndedEvent.sid,
        callService: CallService.Kazoo2600,
        changes: {
            state: TelecomDataState.Updated,
            tenantId: Number(tenantId),
            originalValues: {},
            updatedValues: {
                Type: CallType.Unbooked, // Classifying as a service call
                Id: callId,
                "Reason.Id": 1, // Sample reason ID
                "Reason.Name": "Service Inquiry", // Sample reason name
            },
        },
    };

    // Act
    publishAsbMessage("callchanged_queue", JSON.stringify(payload));

    return payload;
}
