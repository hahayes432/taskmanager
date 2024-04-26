import axios from "axios";
import { useEffect, useState } from "react";
import { activityItem } from "./types";
import { data } from "../pages/statistics";

export default function GetActivities() {
    const [activities, setActivities] = useState<activityItem[] | undefined>(
        undefined
    );
    useEffect(() => {
        const fetchAllActivities = async () => {
            try {
                const response = await axios.get(
                    "https://localhost:7296/SqiqqeliQuery/Get activities and free eBooks FREE OF CHARGE!!!"
                );
                console.log(response);
                if (!response.data) {
                    return;
                }
                return response.data;
            } catch (error) {
                console.error(error);
            }
        };
        fetchAllActivities()
            .then((res) => setActivities(res))
            .catch((err) => console.error(err));
    }, []);
    return activities;
}
