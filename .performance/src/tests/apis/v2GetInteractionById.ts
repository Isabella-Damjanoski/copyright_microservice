import http from "k6/http";
import { Options } from "k6/options";
import { settings, workload, thresholds } from "../../config/index.ts";
import { getDefaultHeaders } from "../../helpers/defaultHeaders.ts";
import { check } from "k6";
import loginClientCredentials from "../../helpers/loginClientCredentials.ts";
import v2CreateInteraction from "./v2CreateInteraction.ts";
import { TestParameters } from "../../types/TestParameters.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        v2GetInteractionById: workload,
    },
    thresholds: {
        ...thresholds,
        "http_req_duration{name:v2GetInteractionById}": ["p(90) < 150"],
    },
};

export async function setup(): Promise<TestParameters> {
    const token = loginClientCredentials();
    const interaction = await v2CreateInteraction(token);
    return { token, interactionId: interaction!.id };
}

export default async function ({ token, interactionId }: TestParameters): Promise<void> {
    // Arrange
    const { apiUrl } = settings;
    const defaultHeaders = getDefaultHeaders(token);

    // Act
    const getInteractionById = http.get(`${apiUrl}/v2/interactions/${interactionId}`, {
        headers: defaultHeaders,
        tags: { name: "v2GetInteractionById", url: `${apiUrl}/v2/interactions` },
    });

    // Assert
    check(getInteractionById, {
        "v2GetInteractionById status=200": (r) => r.status === 200,
    });
}
