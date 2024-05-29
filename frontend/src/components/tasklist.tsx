import { Dispatch, SetStateAction, useState } from "react";
import { taskItem } from "../services/types.js";
import DataTable from "react-data-table-component";
import CreateTaskForm from "./taskCreationForm.js";
import {
    CreateTaskApiCall,
    DeleteTaskApiCall,
} from "../services/taskApiCalls.js";

export default function TaskList({
    data,
    getApiData,
    setApiData,
}: {
    data: taskItem[];
    getApiData: CallableFunction;
    setApiData: Dispatch<SetStateAction<taskItem[]>>;
}) {
    //selected row for the delete function
    const [selected, setSelected] = useState({});
    //used with the create task form
    const [taskInfo, setTaskInfo] = useState({
        id: 1,
        name: "",
        content: "",
        startDate: new Date(),
        endDate: new Date(),
        tags: 1,
        status: 1,
        activityId: 1,
    });

    const paginationOptions = {
        noRowsPerPage: true,
    };

    async function handleSubmit() {
        //create the new item from the form
        await CreateTaskApiCall(taskInfo);
        //should update the data
        getApiData();
        //Reset the form
        setTaskInfo(() => {
            return {
                id: 1,
                name: "",
                content: "",
                startDate: new Date(),
                endDate: new Date(),
                tags: 1,
                status: 1,
                activityId: 1,
            };
        });
    }
    const handleDelete = () => {
        const ids: number[] = [];
        selected.forEach((item) => {
            ids.push(item.id);
        });
        DeleteTaskApiCall(ids);
        setApiData((old) => {
            const newData = old.filter((item) => {
                for (let i = 0; i < ids.length; i++) {
                    //if deleted id is the same as the same dont return it with the new data
                    if (item.id === ids[i]) return false;
                }
                //if the item id isn the same as one of the deleted ones keep it in the new data
                return true;
            });
            return newData;
        });
    };

    const columns = [
        {
            name: "id",
            selector: (row) => row.id,
            sortable: true,
        },
        {
            name: "name",
            selector: (row) => row.name,
            sortable: true,
        },
        {
            name: "content",
            selector: (row) => row.content,
            sortable: true,
            width: "300px",
        },
        {
            name: "startDate",
            selector: (row) => row.startDate.slice(0, 10),
            sortable: true,
        },
        {
            name: "endDate",
            selector: (row) => row.endDate.slice(0, 10),
            sortable: true,
        },
        {
            name: "tags",
            selector: (row) => row.tags,
            sortable: true,
        },
        {
            name: "status",
            selector: (row) => row.status,
            sortable: true,
        },
        {
            name: "activityId",
            selector: (row) => row.activityId,
            sortable: true,
        },
    ];
    const Expanded = ({ data }) => {
        return <div className="h-fit text-center">{data.content}</div>;
    };

    return (
        <>
            <div className="w-3/4 h-min mx-auto mt-16 min-h-fit overflow-y-auto">
                <DataTable
                    keyField="id"
                    columns={columns}
                    data={data}
                    pagination
                    selectableRows
                    onSelectedRowsChange={(e) => {
                        setSelected(() => e.selectedRows);
                    }}
                    expandableRows
                    expandableRowsComponent={Expanded}
                    expandableRowsHideExpander
                    expandOnRowClicked
                    paginationPerPage={6}
                    paginationComponentOptions={paginationOptions}
                />
            </div>
            <div className="flex flex-row w-3/4 mx-auto">
                <CreateTaskForm
                    taskInfo={taskInfo}
                    setTaskInfo={setTaskInfo}
                    handleSubmit={handleSubmit}
                />
                <button
                    className="p-1 border border-black/25 rounded-md bg-red-400 hover:bg-red-500 w-fit h-fit"
                    onClick={handleDelete}
                >
                    Delete selected
                </button>
            </div>
        </>
    );
}
