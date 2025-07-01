import { PerVUIterationsScenario } from "k6/options";

type WorkloadType = "smoke" | "average" | "stress";

const iterations =
    __ENV.ITERATIONS && Number(__ENV.ITERATIONS) ? Number(__ENV.ITERATIONS) : undefined;
const users = __ENV.USERS && Number(__ENV.USERS) ? Number(__ENV.USERS) : undefined;
const duration = __ENV.DURATION ? String(__ENV.DURATION) : undefined;

const WorkloadConfig: Record<WorkloadType, PerVUIterationsScenario> = {
    smoke: {
        executor: "per-vu-iterations",
        iterations: iterations ?? 1,
        options: {
            browser: {
                // This is a mandatory parameter that instructs k6 to launch and
                // connect to a chromium-based browser, and use it to run UI-based
                // tests.
                type: "chromium",
            },
        },
        vus: users ?? 3,
        maxDuration: duration,
    },
    average: {
        executor: "per-vu-iterations",
        iterations: iterations ?? 5,
        options: {
            browser: {
                type: "chromium",
            },
        },
        vus: users ?? 10,
        maxDuration: duration,
    },
    stress: {
        executor: "per-vu-iterations",
        iterations: iterations ?? 100,
        options: {
            browser: {
                type: "chromium",
            },
        },
        vus: users ?? 1000,
        maxDuration: duration,
    },
};
export const workload =
    WorkloadConfig[globalThis.__ENV.WORKLOAD as WorkloadType] || WorkloadConfig["smoke"];

export default workload;
