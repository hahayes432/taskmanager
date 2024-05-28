// import { useState, useEffect } from "react";
import axios from "axios";
import { taskItem } from "./types";

export async function GetTaskApiCall(amount: number | undefined) {
    if (amount === undefined) {
        const response = await axios.get<taskItem>(
            "https://localhost:7296/TaskManager/GetTasks"
        );
        if (!response.data) {
            console.error("There was an error fetching the data");
        }
        return response.data;
    }
    const response = await axios.get(
        `https://localhost:7296/TaskManager/GetTasksFrontpage?amount=${amount}`
    );
    if (!response.data) {
        console.error("There was an error fetching the data");
    }
    return response.data;
    // console.log(response.data);
}

export async function DeleteTaskApiCall(id) {
    const response = await axios.delete(
        `https://localhost:7296/TaskManager/DeleteTask?id=${id}`
    );
    console.log(response);
}

export async function CreateTaskApiCall(taskObj: taskItem) {
    console.log(taskObj);
    const response = await axios.post(
        `https://localhost:7296/TaskManager/InsertTask?name=${taskObj.name}&content=${taskObj.content}&startDate=${taskObj.startDate}&endDate=${taskObj.endDate}&activityId=${taskObj.activityId}&status=${taskObj.status}&tags=${taskObj.tags}`
    );
    if (response.status != 200) {
        console.log(response.statusText);
    }
}
//task insert needed
