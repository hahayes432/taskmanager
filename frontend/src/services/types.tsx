export interface taskItem {
    id: number;
    name: string;
    content: string;
    startDate: Date;
    endDate: Date;
    tags: number[];
    status: number;
    activityId: number;
}
