type Environment = "local" | "qa" | "stage";
interface Settings {
    apiUrl: string;
    appUrl: string;
    tokenUrl: string;
    clientId: string;
    clientSecret?: string;
    tenantId: number;
    contactCenterId: string;
    accountId: string;
    pcsUserId: string;
    vaSettingsId: string;
    azureServiceBusUrls?: { url: string; key?: string }[];
}

export const EnvConfig: Record<Environment, Settings> = {
    local: {
        apiUrl: "http://localhost:5297",
        appUrl: "https://app.qa.devtest.contactcenter.srv.st.dev/",
        tokenUrl: "https://login-qa-telecom.st.dev/connect/token",
        clientId: "cid.NJ3WP1Ykp2V656lxsFKrMT",
        tenantId: 8082974,
        contactCenterId: "87a0b788-f4e2-4ea6-9b2f-f97619ef0f86",
        accountId: "34e43a67-55e0-4a48-8bf7-3baf92b189b9",
        pcsUserId: "05b8cb97-2d00-4dc5-a167-18f0426e536e",
        vaSettingsId: "CSE-fe573fd1-2c6d-40c1-96f1-8bef6b6fe2d7",
    },
    qa: {
        apiUrl: "https://interactions.wus2-01.qa.devtest.contactcenter.srv.st.dev",
        appUrl: "https://app.qa.devtest.contactcenter.srv.st.dev/",
        tokenUrl: "https://login-qa-telecom.st.dev/connect/token",
        clientId: "cid.NJ3WP1Ykp2V656lxsFKrMT",
        tenantId: 8082974,
        contactCenterId: "87a0b788-f4e2-4ea6-9b2f-f97619ef0f86",
        accountId: "34e43a67-55e0-4a48-8bf7-3baf92b189b9",
        pcsUserId: "05b8cb97-2d00-4dc5-a167-18f0426e536e",
        vaSettingsId: "CSE-fe573fd1-2c6d-40c1-96f1-8bef6b6fe2d7",
    },
    stage: {
        apiUrl: "http://localhost:8080",
        appUrl: "https://ccpro-stage.servicetitan.com/",
        tokenUrl: "https://login-stage.servicetitan.com/connect/token",
        clientId: "cid.mJI75Cmcc4DzeuyoPQa5T7",
        tenantId: 260275465,
        contactCenterId: "f9248570-05d2-4654-868b-fc5d1dc2b671",
        accountId: "",
        pcsUserId: "",
        vaSettingsId: "",
    },
};

let envConfig = {};
try {
    envConfig = JSON.parse(open("../../k6.env.json"));
} catch (e) {
    console.warn("Could not find k6.env.json file.", e);
}

export const config = {
    ...(EnvConfig[globalThis.__ENV.ENVIRONMENT as Environment] || EnvConfig.local),
    ...envConfig,
};
export const settings = config;

export default config;
