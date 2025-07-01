export interface Data {
    root_group: Group;
    state: State;
    metrics: Record<string, Metric>;
}
export interface Group {
    name: string;
    checks: Check[];
}
export interface Check {
    name: string;
    passes: number;
    fails: number;
}
export interface State {
    testRunDurationMs: number;
    isStdOutTTY: boolean;
    isStdErrTTY: boolean;
}
export interface Metric {
    type: string;
    contains: string;
    values: MetricValues;
    thresholds?: Record<string, Threshold>;
}
export interface MetricValues {
    value?: number;
    rate?: number;
    passes?: number;
    fails?: number;
    avg?: number;
    min?: number;
    med?: number;
    max?: number;
    count?: number;
    "p(90)"?: number;
    "p(95)"?: number;
}
export interface Threshold {
    ok: boolean;
}
