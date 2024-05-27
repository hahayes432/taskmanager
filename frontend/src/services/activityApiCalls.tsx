import axios from "axios";
import { activityItem } from "./types";

export default async function GetActivityApiCall() {
    const response = await axios.get<activityItem[]>(
        "https://localhost:7296/TaskManager/GetActivities"
    );
    if (!response.data) {
        console.error("There was an error fetching the data");
    }
    // console.log(response.data);
    return response.data;
}

//activity insert needed
