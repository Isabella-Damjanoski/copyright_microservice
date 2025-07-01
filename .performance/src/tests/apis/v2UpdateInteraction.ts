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
        v2UpdateInteraction: workload,
    },
    thresholds: {
        ...thresholds,
        "http_req_duration{name:v2UpdateInteraction}": ["p(90) < 150"],
    },
};

export { setup, handleSummary };

export default async function ({ token, interactionId }: TestParameters): Promise<void> {
    // Arrange
    const { apiUrl } = settings;
    const defaultHeaders = getDefaultHeaders(token);

    // Act
    const updateInteraction = http.patch(
        `${apiUrl}/v2/interactions/${interactionId}`,
        JSON.stringify({
            customer: {
                customerId: 1,
                customerName: "John Doe",
            },
            status: "Completed",
        }),
        {
            headers: defaultHeaders,
            tags: { name: "v2UpdateInteraction", url: `${apiUrl}/v2/interactions` },
        }
    );

    // Assert
    check(updateInteraction, {
        "v2UpdateInteraction status=200": (r) => r.status === 200,
    });
}
