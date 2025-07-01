import { Threshold } from "k6/options";

export const thresholds: { [name: string]: Threshold[] } = {
    http_req_duration: ["p(95) < 1000"],
    http_req_failed: ["rate<0.01"], // Less than 1% of requests should fail
    checks: ["rate>0.99"], // 99% of checks should pass
};
