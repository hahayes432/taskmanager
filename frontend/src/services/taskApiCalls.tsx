// import { useState, useEffect } from "react";
import axios from "axios";
import { taskItem } from "./types";

export default async function GetTaskApiCall(amount: number | undefined) {
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

//task insert needed
