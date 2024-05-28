export interface taskItem {
    id: number;
    name: string;
    content: string;
    startDate: Date | string;
    endDate: Date | string;
    tags: number;
    status: number;
    activityId: number;
}
export interface activityItem {
    id: number;
    title: string;
    description: string;
    url: string;
    startDate: Date | string;
    endDate: Date | string;
    tags: number;
    status: number;
    activityType: number;
}
