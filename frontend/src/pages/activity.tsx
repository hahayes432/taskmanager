import ActivityList from "../components/activityList";
import { useState, useEffect } from "react";
import { activityItem } from "../services/types";
import GetActivityApiCall from "../services/activityApiCalls";

export default function ActivityPage() {
    //Loading activity item while fetching actual data
    const tempLoadingActivityItem: activityItem = {
        id: 1,
        title: "Loading",
        description: "Loading",
        url: "Loading",
        startDate: new Date(Date.now()),
        endDate: new Date(Date.now()),
        tags: 1,
        status: 1,
        activityType: 1,
    };
    //usestate for the data
    const [apiActivityData, setApiActivityData] = useState<activityItem[]>([
        tempLoadingActivityItem,
    ]);

    const getActivityData = async () => {
        try {
            const response = await GetActivityApiCall();
            setApiActivityData((e) => response);
        } catch (error) {
            console.error(error);
        }
    };

    useEffect(() => {
        getActivityData();
    }, []);

    return (
        <>
            <div className=" w-full h-auto">
                <h2 className="w-fit m-auto mt-5 text-4xl">Activities</h2>
            </div>
            <ActivityList activityArray={apiActivityData} />
        </>
    );
}
