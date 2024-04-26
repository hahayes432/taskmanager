import { useState, useEffect } from "react";
import axios from "axios";

export default function TaskApiCall() {
    const [taskData, setTaskData] = useState(null);

    useEffect(() => {
        axios
            .get("https://localhost:7296/")
            .then((response) => {
                setTaskData(response.data);
            })
            .catch((error) => {
                console.error("Fetch failed: ", error);
            });
    }, []);

    return taskData;
}
