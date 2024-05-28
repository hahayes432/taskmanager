import { useState } from "react";
import { taskItem } from "../services/types.js";
import DataTable from "react-data-table-component";
import { DeleteTaskApiCall } from "../services/taskApiCalls.js";

export default function TaskList({
    data,
    setData,
}: {
    data: taskItem[];
    setData: VoidFunction;
}) {
    const [selected, setSelected] = useState({});
    const rows: taskItem[] = [];
    // doing this because table needs to display date objects as strings
    data.forEach((item) => {
        rows.push({
            id: item.id,
            name: item.name,
            content: item.content,
            startDate: item.startDate.toString().slice(0, 10),
            endDate: item.endDate.toString().slice(0, 10),
            tags: item.tags,
            status: item.status,
            activityId: item.activityId,
        });
    });
    const paginationOptions = {
        noRowsPerPage: true,
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
            selector: (row) => row.startDate,
            sortable: true,
        },
        {
            name: "endDate",
            selector: (row) => row.endDate,
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

    const handleDelete = () => {
        DeleteTaskApiCall(selected[0].id);
        setData((old) => {
            const newData = old.filter((item) => item.id !== selected[0].id);
            return newData;
        });
    };

    return (
        <>
            <div className="w-3/4 h-min mx-auto mt-16 min-h-fit overflow-y-auto">
                <DataTable
                    columns={columns}
                    data={rows}
                    pagination
                    selectableRows
                    selectableRowsSingle
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
                <button onClick={handleDelete}>Delete selected</button>
            </div>
        </>
    );
}
