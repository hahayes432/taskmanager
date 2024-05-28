import { useCallback, useState } from "react";
import { activityItem } from "../services/types";
import DataTable from "react-data-table-component";
import { DeleteActivityApiCall } from "../services/activityApiCalls";

export default function ActivityList({
    activityArray,
    setApiActivityData,
    setSelectedRow,
}: {
    activityArray: activityItem[];
    setApiActivityData: VoidFunction;
    setSelectedRow: VoidFunction;
}) {
    const rows: activityItem[] = [];
    activityArray.forEach((item) => {
        rows.push({
            ...item,
            startDate: item.startDate.toString().slice(0, 10),
            endDate: item.endDate.toString().slice(0, 10),
        });
    });

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
            width: "500px",
        },
        {
            name: "url",
            selector: (row) => row.url,
            sortable: true,
            width: "150px",
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
                    columns={columns}
                    data={rows}
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
        </>
    );
}
