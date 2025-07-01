import { Options } from "k6/options";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { uuidv4 } from "../../lib/k6-utils/index.js";
import { settings, thresholds, workload } from "../../config/index.ts";
import publishAsbMessage from "../../helpers/publishAsbMessage.ts";
import { generateRandomPhoneNumber } from "../../helpers/dataHelpers.ts";
import { ConversationEvent } from "../../types/ConversationEvent.ts";
import { InteractionV2 } from "../../types/InteractionV2.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        conversationCreatedEvent: workload,
    },
    thresholds,
};

export default async function (interaction?: InteractionV2): Promise<ConversationEvent> {
    // Arrange
    const { contactCenterId, accountId, tenantId } = settings;
    const channelId = interaction?.channelId ?? `LOAD-${uuidv4()}`;
    const fromNumber = generateRandomPhoneNumber();
    const toNumber = generateRandomPhoneNumber();

    console.log(`Channel ID: ${channelId}`);
    const payload = {
        metadata: {
            id: uuidv4(),
            timestamp: Date.now(),
            category: "conversation",
            type: "created",
        },
        conversation: {
            sid: channelId,
            direction: "Inbound",
            channel: "Phone",
            accountId: accountId,
            contactCenterId: contactCenterId,
            tenantId,
        },
        data: {
            callService: "Kazoo2600Hz",
            from: fromNumber,
            to: toNumber,
            traits: [],
        },
    } as ConversationEvent;

    // Act
    publishAsbMessage("conversation_event_topic", JSON.stringify(payload));

    return payload;
}
