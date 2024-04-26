import { useState, useEffect } from "react";
import axios from "axios";

export default async function GetTasks() {
    const [taskData, setTaskData] = useState();

    useEffect(() => {
        const fetchTaskData = async () => {
            await axios
                .get(
                    "https://localhost:7296/SqiqqeliQuery/Get tasks plus free eBooks for free"
                )
                .then((response) => {
                    setTaskData(response.data);
                })
                .catch((error) => {
                    console.error("Fetch failed: ", error);
                });
        };
        fetchTaskData();
    }, []);

    return taskData;
}
