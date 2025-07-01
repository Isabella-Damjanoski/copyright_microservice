export interface InteractionV2 {
    id: string;
    channelId: string;
    channelDetails: {
        completedAt: string;
        isInternal: boolean;
        durationInSeconds?: number;
        callId?: number;
    };
    sessions: {
        sessionId: string;
    }[];
    completedAt?: string;
    primaryUser?: {
        userId: string;
        userName?: string;
    };
}
