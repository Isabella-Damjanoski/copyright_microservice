export interface ConversationEvent {
    metadata: {
        id: string;
        timestamp: number;
        category: "conversation" | "conversation.session";
        type: "created" | "updated" | "ended" | "answered";
    };
    conversation: {
        sid: string;
        direction: "Inbound" | "Outbound";
        channel: "Phone";
        accountId: string;
        contactCenterId: string;
        tenantId?: number;
    };
    session?: {
        id: string;
        type: "User" | "VirtualAgent";
        direction: "Inbound";
        userId?: string;
        baseVaSettingsId?: string;
    };
    data?: {
        callService?: "Kazoo2600Hz";
        from?: string;
        to?: string;
        traits?: string[];
    };
}
