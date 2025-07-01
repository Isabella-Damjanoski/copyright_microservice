import http from "k6/http";
import { Options } from "k6/options";
import { settings, workload, thresholds } from "../../config/index.ts";
import { getDefaultHeaders } from "../../helpers/defaultHeaders.ts";
import { check } from "k6";
import loginClientCredentials from "../../helpers/loginClientCredentials.ts";
import { InteractionV2 } from "../../types/InteractionV2.ts";
import { PagedResult } from "../../types/PagedResult.ts";

export { handleSummary } from "../../helpers/handleSummary.ts";

export const options: Options = {
    scenarios: {
        v2GetInteractions: workload,
    },
    thresholds: {
        ...thresholds,
        "http_req_duration{name:v2GetInteractions}": ["p(90) < 700"],
    },
};

export async function setup(): Promise<string> {
    return loginClientCredentials();
}

export type ValidationChecks = Record<string, (data: PagedResult<InteractionV2>) => boolean>;

export default async function (
    token: string,
    query?: string,
    validations?: ValidationChecks
): Promise<PagedResult<InteractionV2>> {
    // Arrange
    const { apiUrl, tenantId, contactCenterId } = settings;
    const defaultHeaders = getDefaultHeaders(token);

    // Act
    const getInteractions = http.get(
        `${apiUrl}/v2/interactions?tenantids=${tenantId}&contactCenterIds=${contactCenterId}${query ?? ""}`,
        {
            headers: defaultHeaders,
            tags: { name: "v2GetInteractions", url: `${apiUrl}/v2/interactions` },
        }
    );

    // Prepare checks
    const checks: Record<string, (r: http.Response) => boolean> = {
        "v2GetInteractions status=200": (r: http.Response): boolean => r.status === 200,
        "v2GetInteractions should have at least 1 interaction": (r: http.Response): boolean => {
            try {
                const data = r.json() as unknown as PagedResult<InteractionV2>;
                if (data && data.items.length > 0) {
                    return true;
                }
                return false;
            } catch (e) {
                console.error(e);
                console.log(r.body);
                return false;
            }
        },
    };

    // Add custom validations if provided
    if (validations && Object.keys(validations).length > 0) {
        try {
            const data = getInteractions.json() as unknown as PagedResult<InteractionV2>;

            // Add each validation to the checks
            Object.entries(validations).forEach(([name, validate]) => {
                checks[name] = (): boolean => validate(data);
            });
        } catch (e) {
            console.error("Failed to run validations:", e);
            Object.keys(validations).forEach((name) => {
                checks[name] = (): boolean => false;
            });
        }
    }

    // Assert
    check(getInteractions, checks);

    return getInteractions.json() as unknown as PagedResult<InteractionV2>;
}
