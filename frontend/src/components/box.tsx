import { useEffect } from "react";
import GetTaskApiCall, { DeleteTaskApiCall } from "../services/taskApiCalls";
import "./component.css";

export default function Box({
    children,
    elementtype,
    item,
    setApiTasks,
}: {
    children: any;
    elementtype: string;
    item: number;
    setApiTasks: VoidFunction;
}) {
    function handleClick() {
        if (elementtype === "task") {
            DeleteTaskApiCall(item);
            const getNewTaskData = async () => {
                const res = await GetTaskApiCall();
                setApiTasks((old) => res);
            };
            getNewTaskData();
        }
    }
    return (
        <div className="box min-h-fit h-3/4 w-full p-4 border-4 bg-white ml-5 mb-1 ">
            {children}
            <button
                onClick={handleClick}
                item={item}
                elementtype={elementtype}
                setApiTasks={setApiTasks}
                className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded-full -ml-1 mt-2"
            >
                Complete
            </button>
        </div>
    );
}
