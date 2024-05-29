import { Dispatch, SetStateAction, useState } from "react";
import { activityItem } from "../services/types";
import DataTable from "react-data-table-component";
import ActivityCreationForm from "./activityCreationForm";
import {
    CreateActivityApiCall,
    DeleteActivityApiCall,
} from "../services/activityApiCalls";

export default function ActivityList({
    activityArray,
    getActivityData,
    setApiActivityData,
}: {
    activityArray: activityItem[];
    getActivityData: CallableFunction;
    setApiActivityData: Dispatch<SetStateAction<activityItem[]>>;
}) {
    //selected row for delete function
    const [selectedRow, setSelectedRow] = useState({});

    const [activityInfo, setActivityInfo] = useState({
        id: 1,
        title: "",
        description: "",
        url: "",
        startDate: new Date().toString(),
        endDate: new Date().toString(),
        tags: 1,
        status: 1,
        activityType: 1,
    });
    async function handleSubmit() {
        //create new activity in the database with the form data and call for all the new data to be displayed
        await CreateActivityApiCall(activityInfo);
        //get new data to be displayed
        getActivityData();
        //reset form fields
        setActivityInfo(() => {
            return {
                id: 1,
                title: "",
                description: "",
                url: "",
                startDate: new Date().toString(),
                endDate: new Date().toString(),
                tags: 1,
                status: 1,
                activityType: 1,
            };
        });
    }
    function handleDelete() {
        //Delete selected row set the new filtered data to display
        DeleteActivityApiCall(selectedRow[0].id);
        setApiActivityData((e) => {
            const filtered = e.filter((item) => item.id !== selectedRow[0].id);
            return filtered;
        });
    }

    const paginationOptions = {
        noRowsPerPage: true,
    };

    const ExpandedComponent = ({ data }) => {
        return (
            <div className="py-1 flex flex-row justify-evenly h-fit">
                <p className="pb-1">Description: {data.description}</p>
                <p>
                    Url:{" "}
                    <a
                        className="text-blue-500 hover:text-blue-700"
                        href={data.url}
                    >
                        {data.url}
                    </a>
                </p>
            </div>
        );
    };

    const columns = [
        {
            name: "id",
            selector: (row) => row.id,
            sortable: true,
            width: "60px",
        },
        {
            name: "title",
            selector: (row) => row.title,
            sortable: true,
        },
        {
            name: "description",
            selector: (row) => row.description,
            sortable: true,
            width: "400px",
        },
        {
            name: "url",
            selector: (row) => row.url,
            sortable: true,
            width: "125px",
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
            width: "90px",
        },
        {
            name: "status",
            selector: (row) => row.status,
            sortable: true,
            width: "90px",
        },
        {
            name: "activityType",
            selector: (row) => row.activityType,
            sortable: true,
            width: "90px",
        },
    ];

    return (
        <>
            <div className="mt-10 w-3/4 h-3/4 m-auto">
                <DataTable
                    keyField="id"
                    columns={columns}
                    data={activityArray}
                    pagination
                    selectableRows
                    selectableRowsSingle
                    onSelectedRowsChange={(e) => {
                        setSelectedRow(() => e.selectedRows);
                    }}
                    expandableRows
                    expandOnRowClicked
                    expandableRowsHideExpander
                    expandableRowsComponent={ExpandedComponent}
                    paginationPerPage={6}
                    paginationComponentOptions={paginationOptions}
                />
            </div>
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
