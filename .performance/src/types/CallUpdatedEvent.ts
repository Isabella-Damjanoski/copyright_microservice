export enum CallService {
    Twilio = 0,
    Bandwidth = 1,
    Incontact = 2,
    Dialpad = 3,
    SignalWire = 4,
    Kazoo2600 = 5,
}

export enum TelecomDataState {
    None = 0,
    Added = 1,
    Updated = 2,
    Removed = 3,
}

export enum CallStatus {
    Ringing = 0,
    Answered = 1,
    Completed = 2,
    Initiated = 3,
}

export enum CallType {
    Abandoned = 0,
    Unbooked = 1,
    Excused = 2,
    Booked = 3,
    NotLead = 4,
}

export interface TelecomDataChanges {
    state: TelecomDataState;
    tenantId?: number;
    originalValues: Record<string, unknown>;
    updatedValues: Record<string, unknown>;
}

export interface CallUpdatedMessage {
    sid: string;
    callService: CallService;
    changes: TelecomDataChanges;
}
