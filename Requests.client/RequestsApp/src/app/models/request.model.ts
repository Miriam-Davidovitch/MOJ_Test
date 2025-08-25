export interface Request {
    requestID: number;
    requestorName: string;
    requestDescription: string | null;
    requestTopic: string | null;
    requestCreatedAt: Date | null;
}