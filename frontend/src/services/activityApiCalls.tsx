import axios from "axios";
import { activityItem } from "./types";

export async function GetActivityApiCall() {
    const response = await axios.get<activityItem[]>(
        "https://localhost:7296/TaskManager/GetActivities"
    );
    if (!response.data) {
        console.error("There was an error fetching the data");
    }
    // console.log(response.data);
    return response.data;
}

export async function CreateActivityApiCall(activityInfo: activityItem) {
    const response = await axios.post(
        `https://localhost:7296/TaskManager/InsertActivity?title=${activityInfo.title}&description=${activityInfo.description}&url=${activityInfo.url}&startDate=${activityInfo.startDate}&endDate=${activityInfo.endDate}&status=${activityInfo.status}&tags=${activityInfo.tags}&activityType=${activityInfo.activityType}`
    );
    if (response.status !== 200) {
        console.error(response.statusText);
    }
}

export async function DeleteActivityApiCall(id: number) {
    const response = await axios.delete(
        `https://localhost:7296/TaskManager/DeleteActivity?id=${id}`
    );
    if (response.status !== 200) {
        console.error(response.statusText);
    }
}
//activity insert needed
