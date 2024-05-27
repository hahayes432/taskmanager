import { useState } from "react";
import { v4 as uuidv4 } from "uuid"; // fix warnings by generating unique keys in table mapping
import { activityItem } from "../services/types";

export default function ActivityList({
    activityArray,
}: {
    activityArray: activityItem[];
}) {
    const [activityPage, setActivityPage] = useState<number>(0);
    const [pageStartIndex, setPageStartIndex] = useState<number>(0);
    const [pageEndIndex, setPageEndIndex] = useState<number>(8);

    const itemsPerPage = 8;
    const buttonLabels: number[] = [];
    for (let i = 0; i < activityArray.length / itemsPerPage; i++) {
        buttonLabels.push(i + 1);
    }
    function changePage(e) {
        const buttonPressed = e.currentTarget.value;
        let newPage = activityPage; //Couldnt get it to work with just the useState but this sort of works
        // console.log(newPage);
        if (buttonPressed === "prev" && newPage > 0) {
            // previous page unless we are already at the first one
            newPage = activityPage - 1;
            setActivityPage((old) => old - 1); // update states for next time
            setPageStartIndex((old) => activityPage * itemsPerPage);
            setPageEndIndex(
                (old) => activityPage * itemsPerPage + itemsPerPage
            );
        } else if (
            buttonPressed === "next" &&
            newPage < activityArray.length / itemsPerPage - 1
        ) {
            //next page if there still is one
            newPage = activityPage + 1;
            setActivityPage((old) => old + 1); // update states for next time
            setPageStartIndex((old) => newPage * itemsPerPage);
            setPageEndIndex((old) => newPage * itemsPerPage + itemsPerPage);
        } else {
            return;
        }
        console.log(activityPage);
        for (let i = 0; i < activityArray.length; i++) {
            let row = document.getElementById(`${i}`); //a row of the table
            row?.classList.toggle(
                "hidden",
                i < pageStartIndex || i >= pageEndIndex
            ); //set class to hidden if row is out of range
            // console.log(row?.classList);
            // console.log(startIndex, endIndex);
        }
    }

    return (
        <>
            <div className="mt-10 w-3/4 h-3/4 m-auto what2">
                <table className="mx-auto w-full h-full bg-neutral-400/50">
                    <thead>
                        <tr>
                            <th className="w-1/12 border border-black/25">
                                ID
                            </th>
                            <th className="w-1/12 border border-black/25">
                                Title
                            </th>
                            <th className="w-1/12 border border-black/25">
                                Description
                            </th>
                            <th className="w-1/12 border border-black/25">
                                Url
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
                            <th className="w-1/12 border border-black/25">
                                ActivityType
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {activityArray.map((item, index) => {
                            if (index < itemsPerPage) {
                                return (
                                    <tr id={index.toString()} key={uuidv4()}>
                                        {/* 
                                        toString because id cant be type number 
                                        possibly used to make pages
                                        */}
                                        <td
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.id}
                                        </td>
                                        <td
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.title}
                                        </td>
                                        <td
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                            title={item.description}
                                        >
                                            {item.description.length >= 37
                                                ? item.description.slice(
                                                      0,
                                                      37
                                                  ) + "..."
                                                : item.description}
                                        </td>
                                        <td
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.url}
                                        </td>
                                        <td
                                            key={uuidv4()}
                                            className=" max-h-6 border border-black/25 px-2 text-center"
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
                                            className=" max-h-6 border border-black/25 px-2 text-center"
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
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.status}
                                        </td>
                                        <td
                                            className=" max-h-6 border border-black/25 px-2"
                                            key={uuidv4()}
                                        >
                                            {item.tags}
                                        </td>
                                        <td
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.activityType}
                                        </td>
                                    </tr>
                                );
                            }
                            {
                                /* make first page visible in previous if statement and then make the rest hidden */
                            }
                            return (
                                <tr id={index.toString()} key={uuidv4()}>
                                    <td
                                        className="hidden max-h-6 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {uuidv4()}
                                    </td>
                                    <td
                                        className="hidden max-h-6 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {item.name}
                                    </td>
                                    <td
                                        className="hidden max-h-6 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {item.content}
                                    </td>
                                    <td
                                        key={uuidv4()}
                                        className="hidden max-h-6 border border-black/25 px-2 text-center"
                                    >
                                        <time
                                            key={uuidv4()}
                                            dateTime={item.startDate}
                                        />
                                        {item.startDate.toString().slice(0, 10)}
                                    </td>
                                    <td
                                        key={uuidv4()}
                                        className="hidden max-h-6 border border-black/25 px-2 text-center"
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
                                        className="hidden max-h-6 border border-black/25 px-2 text-center"
                                        key={uuidv4()}
                                    >
                                        {item.status}
                                    </td>
                                    <td
                                        className="hidden max-h-6 border border-black/25 px-2"
                                        key={uuidv4()}
                                    >
                                        {item.tags.map(
                                            (i) => i.toString() + "  "
                                        )}
                                    </td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
                <div className="bg-yellow-400 w-full flex flex-row row-span-6 justify-end">
                    <button
                        value="prev"
                        className=" w-1/12 border border-black/25"
                        onClick={(e) => changePage(e)}
                    >
                        Previous
                    </button>
                    <h1 className=" mx-3 font-bold text-md">
                        Current page: {activityPage + 1}
                    </h1>
                    <button
                        value="next"
                        className=" w-1/12 border border-black/25"
                        onClick={(e) => changePage(e)}
                    >
                        Next
                    </button>
                </div>
            </div>
        </>
    );
}
