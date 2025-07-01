import http from "k6/http";
import { Options } from "k6/options";
import { settings, workload, thresholds } from "../../config/index.ts";
import { getDefaultHeaders } from "../../helpers/defaultHeaders.ts";
import { check } from "k6";
import { TestParameters } from "../../types/TestParameters.ts";
import { setup } from "./v2GetInteractionById.ts";
import { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        v2InteractionClassification: workload,
    },
    thresholds: {
        ...thresholds,
        "http_req_duration{name:v2InteractionClassification}": ["p(90) < 150"],
    },
};

export { setup, handleSummary };

export default async function ({ token, interactionId }: TestParameters): Promise<void> {
    // Arrange
    const { apiUrl } = settings;
    const defaultHeaders = getDefaultHeaders(token);

    // Act
    const updateInteraction = http.patch(
        `${apiUrl}/v2/interactions/${interactionId}/ChannelClassifications`,
        JSON.stringify({
            typeId: 4,
            reasonId: 1,
            reasonName: "Test",
            initialDispositionNote: "Test Initial Disposition Note",
        }),
        {
            headers: defaultHeaders,
            tags: {
                name: "v2InteractionClassification",
                url: `${apiUrl}/v2/interactions/{interactionId}/channelclassifications`,
            },
        }
    );

    // Assert
    check(updateInteraction, {
        "v2InteractionClassification status=200": (r) => r.status === 200,
    });
}
