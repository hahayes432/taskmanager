import { useState } from "react";
import { v4 as uuidv4 } from "uuid"; // fix warnings by generating unique keys in table mapping
import CreateTaskForm from "../components/taskCreationForm.jsx";
import { taskItem } from "../services/types.js";

export default function TaskList({
    data,
    getApiData,
}: {
    data: taskItem[];
    getApiData: () => Promise<void>;
}) {
    const [page, setPage] = useState<number>(0);
    const [startIndex, setStartIndex] = useState<number>(0);
    const [endIndex, setEndIndex] = useState<number>(6);

    // console.log(data);
    const itemsPerPage = 6;
    const buttonLabels: number[] = [];
    for (let i = 0; i < data.length / itemsPerPage; i++) {
        buttonLabels.push(i + 1);
    }
    function changePage(e) {
        const buttonPressed = e.currentTarget.value;
        let newPage = page; //Couldnt get it to work with just the useState but this sort of works
        // console.log(newPage);
        if (buttonPressed === "prev" && newPage > 0) {
            // previous page unless we are already at the first one
            newPage = page - 1;
            setPage((old) => old - 1); // update states for next time
            setStartIndex((old) => old - itemsPerPage);
            setEndIndex((old) => old - itemsPerPage);
        } else if (
            buttonPressed === "next" &&
            newPage < data.length / itemsPerPage - 1
        ) {
            //next page if there still is one
            newPage = page + 1;
            setPage((old) => old + 1); // update states for next time
            setStartIndex((old) => old + itemsPerPage);
            setEndIndex((old) => old + itemsPerPage);
        } else {
            return;
        }
        // console.log(page);
        for (let i = 0; i < data.length; i++) {
            const row = document.getElementById(`${i}row`); //a row of the table
            row?.classList.toggle("hidden", i < startIndex || i > endIndex); //set class to hidden if row is out of range
            console.log(row);
            console.log(startIndex, endIndex);
        }
    }

    return (
        <>
            <div className="w-3/4 h-min mx-auto mt-16 min-h-fit overflow-y-auto what">
                <table className="mx-auto w-full h-11/12 bg-neutral-400/50">
                    <thead>
                        <tr>
                            <th className="w-1/12 border border-black/25">
                                ID
                            </th>
                            <th className="w-1/12 border border-black/25">
                                Name
                            </th>
                            <th className="w-1/12 border border-black/25">
                                Content
                            </th>
                            <th className="w-1/12 border border-black/25">
                                Start Date
                            </th>
                            <th className="w-1/12 border border-black/25">
                                End Date
                            </th>
                            <th className="w-1/12 border border-black/25">
                                status
                            </th>
                            <th className="w-1/12 border border-black/25">
                                tags
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {data.map((item, index) => {
                            if (index < itemsPerPage) {
                                return (
                                    <tr
                                        id={index.toString() + "row"}
                                        key={uuidv4()}
                                    >
                                        {/* 
                                        toString because id cant be type number 
                                        possibly used to make pages
                                        */}
                                        <td
                                            className=" h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.id}
                                        </td>
                                        <td
                                            className="h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.name}
                                        </td>
                                        <td
                                            className=" h-6 border border-black/25 px-2 text-center text-wrap overflow-hidden max-w-40"
                                            key={uuidv4()}
                                            title={item.content}
                                        >
                                            {item.content.length >= 50
                                                ? item.content.slice(0, 50) +
                                                  "..."
                                                : item.content}
                                        </td>
                                        <td
                                            key={uuidv4()}
                                            className=" h-6 border border-black/25 px-2 text-center"
                                        >
                                            <time
                                                key={uuidv4()}
                                                dateTime={item.startDate}
                                            >
                                                {item.startDate
                                                    .toString()
                                                    .slice(0, 10)}
                                            </time>
                                        </td>
                                        <td
                                            key={uuidv4()}
                                            className=" h-6 border border-black/25 px-2 text-center"
                                        >
                                            <time
                                                key={uuidv4()}
                                                dateTime={item.endDate}
                                            >
                                                {item.endDate
                                                    .toString()
                                                    .slice(0, 10)}
                                            </time>
                                        </td>
                                        <td
                                            className=" h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.status}
                                        </td>
                                        <td
                                            className=" h-6 border border-black/25 px-2"
                                            key={uuidv4()}
                                        >
                                            {item.tags}
                                        </td>
                                    </tr>
                                );
                            }
                            {
                                /* make first page visible in previous if statement and then make the rest hidden */
                            }
                            return (
                                <tr
                                    id={index.toString() + "row"}
                                    key={uuidv4()}
                                >
                                    <td
                                        className="hidden h-6 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {uuidv4()}
                                    </td>
                                    <td
                                        className="hidden h-6 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {item.name}
                                    </td>
                                    <td
                                        className="hidden h-6 min-w-48 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {item.content}
                                    </td>
                                    <td
                                        key={uuidv4()}
                                        className="hidden h-6 border border-black/25 px-2 text-center"
                                    >
                                        <time
                                            key={uuidv4()}
                                            dateTime={item.startDate}
                                        />
                                        {item.startDate.toString().slice(0, 10)}
                                    </td>
                                    <td
                                        key={uuidv4()}
                                        className="hidden h-6 border border-black/25 px-2 text-center"
                                    >
                                        <time
                                            key={uuidv4()}
                                            dateTime={item.endDate}
                                        >
                                            {item.endDate
                                                .toString()
                                                .slice(0, 10)}
                                        </time>
                                    </td>
                                    <td
                                        className="hidden h-6 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {item.status}
                                    </td>
                                    <td
                                        className="hidden h-6 border border-black/25 px-2"
                                        key={uuidv4()}
                                    >
                                        {item.tags}
                                    </td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
            <div className=" relative bg-yellow-400 w-3/4 mb-4 mx-auto flex flex-row row-span-6 justify-end">
                <CreateTaskForm getApiData={getApiData} />
                <button
                    value="prev"
                    className=" w-1/12 border border-black/25"
                    onClick={(e) => changePage(e)}
                >
                    Previous
                </button>
                <h1 className=" mx-3 font-bold text-md">
                    Current page: {page + 1}
                </h1>
                <button
                    value="next"
                    className=" w-1/12 border border-black/25"
                    onClick={(e) => changePage(e)}
                >
                    Next
                </button>
            </div>
        </>
    );
}
