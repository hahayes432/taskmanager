/* eslint-disable @typescript-eslint/no-explicit-any */
export interface todo {
    jotai: any;
}

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
