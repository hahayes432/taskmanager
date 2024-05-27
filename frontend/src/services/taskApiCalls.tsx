// import { useState, useEffect } from "react";
import axios from "axios";
import { taskItem } from "./types";

export default async function GetTaskApiCall() {
    const response = await axios.get<taskItem>(
        "https://localhost:7296/TaskManager/GetTasks"
    );
    if (!response.data) {
        console.error("There was an error fetching the data");
    }
    // console.log(response.data);
    return response.data;
}

//task insert needed
