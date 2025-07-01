import http from "k6/http";
import { Options } from "k6/options";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { uuidv4 } from "../../lib/k6-utils/index.js";
import { settings, workload, thresholds } from "../../config/index.ts";
import { getDefaultHeaders } from "../../helpers/defaultHeaders.ts";
import { check } from "k6";
import loginClientCredentials from "../../helpers/loginClientCredentials.ts";
import { InteractionV2 } from "../../types/InteractionV2.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        v2CreateInteraction: workload,
    },
    thresholds: {
        ...thresholds,
        "http_req_duration{name:v2CreateInteraction}": ["p(90) < 100"],
    },
};

export async function setup(): Promise<string> {
    return loginClientCredentials();
}

export default async function (token: string): Promise<InteractionV2 | undefined> {
    // Arrange
    const { apiUrl, tenantId, contactCenterId } = settings;
    const defaultHeaders = getDefaultHeaders(token);

    let createdInteraction: InteractionV2 | undefined;
    const channelId = "LOAD-" + uuidv4();
    const interaction = {
        contactCenterId,
        channelId,
        orgNode: {
            tenantId,
        },
    };

    // Act
    const createInteraction = http.post(`${apiUrl}/v2/interactions`, JSON.stringify(interaction), {
        headers: defaultHeaders,
        tags: { name: "v2CreateInteraction", url: `${apiUrl}/v2/interactions` },
    });

    // Assert
    check(createInteraction, {
        "v2CreateInteraction status=201": (r) => r.status === 201,
        "v2CreateInteraction id exists": (r) => {
            try {
                const data = r.json() as unknown as InteractionV2;
                if (data.id) {
                    createdInteraction = data;
                    return true;
                }
                return false;
            } catch (e) {
                console.error(e);
                console.log(r.body);
                return false;
            }
        },
    });

    return createdInteraction;
}
