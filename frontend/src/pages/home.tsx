import Box from "../components/box";
import { taskItem } from "../services/types.js";
import TaskElementConstructor from "../components/taskElement.js";
import { useState, useEffect } from "react";
import GetTaskApiCall from "../services/taskApiCalls.js";

export default function Home() {
    const task: taskItem = {
        id: 1,
        name: "loading",
        content: "loading",
        startDate: new Date(),
        endDate: new Date(),
        tags: [2, 3, 4],
        status: 2,
        activityId: 3,
    };
    const [apiTasks, setApiTasks] = useState<taskItem[]>([task]);
    const elementType = "task";
    const getApiTasks = async () => {
        try {
            const res = await GetTaskApiCall(3);
            setApiTasks((e) => res);
        } catch (error) {
            console.error(error);
        }
    };

    useEffect(() => {
        getApiTasks();
    }, []);

    // const aaa: taskItem[] = [...Array(3)].fill(task);

    return (
        <>
            <div className="w-full h-fit flex flex-row py-5">
                <h1 className="font-bold text-lg mx-auto">Home page</h1>
            </div>
            {/* Edit this div to adjust size of task boxes */}
            <div className="flex flex-col w-3/4">
                {apiTasks.map((item, index) => {
                    return (
                        <div className="min-h-fit max-w-fit" key={index}>
                            <Box
                                setApiTasks={setApiTasks}
                                elementtype={elementType}
                                item={item.id}
                            >
                                <TaskElementConstructor data={item} />
                            </Box>
                        </div>
                    );
                })}
            </div>
        </>
    );
}
