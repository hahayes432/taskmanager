export interface taskItem {
    id: number;
    name: string;
    content: string;
    startDate: string;
    endDate: string;
    tags: number;
    status: number;
    activityId: number;
}
export interface activityItem {
    id: number;
    title: string;
    description: string;
    url: string;
    startDate: string;
    endDate: string;
    tags: number;
    status: number;
    activityType: number;
}
