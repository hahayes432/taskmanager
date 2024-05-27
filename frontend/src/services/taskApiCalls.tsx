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

export async function DeleteTaskApiCall(id) {
    const response = await axios.delete(
        `https://localhost:7296/TaskManager/DeleteTask?id=${id}`
    );
    console.log(response);
}

//task insert needed
