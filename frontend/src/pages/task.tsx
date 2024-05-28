import { useState, useEffect } from "react";
import TaskList from "../components/tasklist";
import { GetTaskApiCall } from "../services/taskApiCalls";
import { taskItem } from "../services/types";
import CreateTaskForm from "../components/taskCreationForm";
import { CreateTaskApiCall } from "../services/taskApiCalls";

export default function Task() {
    //used with the create task form
    const [taskInfo, setTaskInfo] = useState({
        id: 1,
        name: "",
        content: "",
        startDate: new Date(),
        endDate: new Date(),
        tags: 1,
        status: Number,
        activityId: Number,
    });
    //Temp data to be displayed while getting the actual data if it exists
    const tempLoadingData: taskItem = {
        id: 1,
        name: "loading",
        content: "loading",
        startDate: new Date(Date.now()),
        endDate: new Date(Date.now()),
        activityId: 1,
        status: 1,
        tags: 1,
    };
    const [apiData, setApiData] = useState<taskItem[]>([tempLoadingData]);
    const handleSubmit = () => {
        // console.log(taskInfo);
        CreateTaskApiCall(taskInfo);
        getApiData();
    };

    useEffect(() => {
        getApiData();
    }, []);

    const getApiData = async () => {
        try {
            const response = await GetTaskApiCall(undefined);
            const data = await response;
            setApiData((e) => data);
            // console.log(data.data);
        } catch (error) {
            console.log(error);
        }
    };
    // console.log(apiData);
    return (
        <>
            <div className="flex flex-col w-full h-full">
                <div className="w-fit mx-auto mt-4 text-center">
                    <h2 className="text-2xl font-bold">Tasks Page</h2>
                    <h3 className="text-lg font-semibold">
                        You can expand the content on each row by clicking the
                        row you want to expand
                    </h3>
                </div>
                <TaskList setData={setApiData} data={apiData} />
                <CreateTaskForm
                    taskInfo={taskInfo}
                    setTaskInfo={setTaskInfo}
                    handleSubmit={handleSubmit}
                />
            </div>
        </>
    );
}
