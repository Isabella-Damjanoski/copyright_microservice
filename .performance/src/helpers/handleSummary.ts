// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { htmlReport } from "../lib/k6-reporter/index.js";
// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-expect-error
import { textSummary, humanizeValue } from "../lib/k6-summary/index.js";
import { Data } from "../types/k6Data.js";

const mdSummary = (data: Data): string => {
    let output = "# Performance Test Summary\n\n";

    data.root_group.checks.forEach((check) => {
        if (check.fails === 0) {
            output += `✅ ${check.name}\n\n`;
        } else {
            output += `❌ ${check.name}\n\n`;
            output += `- ${check.passes / check.fails}% = ✅ ${check.passes} / ❌ ${check.fails}\n\n`;
        }
    });

    output += "|Threshold|Metric|||||||\n";
    output += "|:---|:---|:---|:---|:---|:---|:---|:---|\n";

    Object.keys(data.metrics)
        .sort((a, b) => a.localeCompare(b))
        .forEach((key: string) => {
            const metric = data.metrics[key];
            const thresholds = metric.thresholds || {};
            let passed: boolean | undefined = undefined;
            Object.keys(thresholds).forEach((thresholdKey) => {
                const threshold = thresholds[thresholdKey];
                passed = threshold.ok && (passed === undefined || passed);
            });
            let passFail = "";
            if (passed === true) {
                passFail = "✅";
            } else if (passed === false) {
                passFail = "❌";
            }
            const avg =
                metric.values.avg != undefined ? humanizeValue(metric.values.avg, metric) : "";
            const min =
                metric.values.min != undefined ? humanizeValue(metric.values.min, metric) : "";
            const med =
                metric.values.med != undefined ? humanizeValue(metric.values.med, metric) : "";
            const max =
                metric.values.max != undefined ? humanizeValue(metric.values.max, metric) : "";
            const p90 =
                metric.values["p(90)"] != undefined
                    ? humanizeValue(metric.values["p(90)"], metric)
                    : "";
            const p95 =
                metric.values["p(95)"] != undefined
                    ? humanizeValue(metric.values["p(95)"], metric)
                    : "";
            const count =
                metric.values.count != undefined ? humanizeValue(metric.values.count, metric) : "";
            const value =
                metric.values.value != undefined ? humanizeValue(metric.values.value, metric) : "";
            const rate =
                metric.values.rate != undefined ? humanizeValue(metric.values.rate, metric) : "";
            const passes = metric.values.passes ?? 0;
            const fails = metric.values.fails ?? 0;
            switch (metric.type) {
                case "trend":
                    output += `|${passFail}|${key}|avg=${avg}|min=${min}|med=${med}|max=${max}|p(90)=${p90}|p(95)=${p95}|\n`;
                    break;
                case "gauge":
                    output += `|${passFail}|${key}|${value}|min=${min}|max=${max}|\n`;
                    break;
                case "counter":
                    output += `|${passFail}|${key}|value=${count}|rate=${rate}/s|\n`;
                    break;
                case "rate":
                    output += `|${passFail}|${key}|value=${rate}|✅ ${passes}|❌ ${fails}|\n`;
                    break;
                default:
                    output += `|${passFail}|${key}|unknown metric type|\n`;
                    break;
            }
        });

    return output;
};

export function handleSummary(data: Data): Record<string, string> {
    return {
        "summary.json": JSON.stringify(data),
        [`summary_${Date.now()}.md`]: mdSummary(data),
        [`summary_${Date.now()}.html`]: htmlReport(data),
        stdout: textSummary(data),
    };
}
