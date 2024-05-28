import ActivityList from "../components/activityList";
import { useState, useEffect } from "react";
import { activityItem } from "../services/types";
import {
    GetActivityApiCall,
    CreateActivityApiCall,
} from "../services/activityApiCalls";
import ActivityCreationForm from "../components/activityCreationForm";

export default function ActivityPage() {
    const [activityInfo, setActivityInfo] = useState({
        id: 1,
        title: "",
        description: "",
        url: "",
        startDate: new Date(),
        endDate: new Date(),
        tags: 1,
        status: Number,
        activityType: Number,
    });

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

    function handleSubmit() {
        // console.log(activityInfo);
        CreateActivityApiCall(activityInfo);
        getActivityData();
    }

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
                <div className="w-fit mx-auto mt-4 text-center">
                    <h2 className="w-fit m-auto mt-5 text-4xl font-bold">
                        Activities
                    </h2>
                    <h3 className="text-lg font-semibold">
                        You can click the activity row's to click the activity
                        url and to be able to see the full description if it is
                        too long to display normally
                    </h3>
                </div>
            </div>
            <ActivityList activityArray={apiActivityData} />
            <ActivityCreationForm
                activityInfo={activityInfo}
                setActivityInfo={setActivityInfo}
                handleSubmit={handleSubmit}
            />
        </>
    );
}
