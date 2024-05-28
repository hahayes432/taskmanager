import ActivityList from "../components/activityList";
import { useState, useEffect } from "react";
import { activityItem } from "../services/types";
import {
    GetActivityApiCall,
    CreateActivityApiCall,
    DeleteActivityApiCall,
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
    //selected row for delete function
    const [selectedRow, setSelectedRow] = useState({});
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
        // evil way to get the list to update when the first page isnt full
        if (apiActivityData.length < 6) {
            setApiActivityData((old) => {
                setActivityInfo((i) => (i.id = old[old.length - 1].id + 1));
                return [...old].concat(activityInfo);
            });
        }
        // going to keep this here since it works after the first page is full
        getActivityData();
    }
    function handleDelete() {
        DeleteActivityApiCall(selectedRow[0].id);
        setApiActivityData((e) => {
            const filtered = e.filter((item) => item.id !== selectedRow[0].id);
            return filtered;
        });
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
            <ActivityList
                setSelectedRow={setSelectedRow}
                activityArray={apiActivityData}
            />
            <div className="flex flex-row w-3/4 mx-auto">
                <ActivityCreationForm
                    activityInfo={activityInfo}
                    setActivityInfo={setActivityInfo}
                    handleSubmit={handleSubmit}
                />
                <button
                    className="p-1 border border-black/25 rounded-md bg-red-400 hover:bg-red-500 w-fit h-fit"
                    onClick={handleDelete}
                >
                    Delete Selected
                </button>
            </div>
        </>
    );
}
