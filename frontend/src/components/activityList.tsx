import { useState } from "react";
import { v4 as uuidv4 } from "uuid"; // fix warnings by generating unique keys in table mapping

export default function ActivityList() {
    const [activityPage, setActivityPage] = useState<number>(0);
    const [pageStartIndex, setPageStartIndex] = useState<number>(0);
    const [pageEndIndex, setPageEndIndex] = useState<number>(8);
    const now: Date = new Date();
    const end: Date = new Date();
    end.setDate(now.getDate() + 7);
    const activity: any = {
        id: 1,
        title: "lobster",
        description:
            "the lobster are coming. start running the lobster are coming. start running the lobster are coming. start running the lobster are coming. start running the lobster are coming. start running the lobster are coming. start running the lobster are coming. start running the lobster are coming. start running ",
        url: "bennys.pizza.keb.abb",
        startDate: now,
        endDate: end,
        status: 1,
        tags: [1, 2, 3],
        activityType: 1,
    };
    const taskArray: any[] = [...Array(24)].fill(activity);
    const itemsPerPage = 8;
    const buttonLabels: number[] = [];
    for (let i = 0; i < taskArray.length / itemsPerPage; i++) {
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
            newPage < taskArray.length / itemsPerPage - 1
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
        for (let i = 0; i < taskArray.length; i++) {
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
                        {taskArray.map((item, index) => {
                            if (index < 8) {
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
                                            {uuidv4()}
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
                                        >
                                            {item.description.slice(0, 37) +
                                                "..."}
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
                                                    .toISOString()
                                                    .slice(0, 10)}
                                            </time>
                                        </td>
                                        <td
                                            key={uuidv4()}
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                        >
                                            <time
                                                key={uuidv4()}
                                                dateTime={item.endDate.setDate(
                                                    index
                                                )}
                                            >
                                                {item.endDate
                                                    .toISOString()
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
                                            {item.tags.map(
                                                (i) => i.toString() + "  "
                                            )}
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
                                /* make first 8 visible in previous if statement and then make the rest hidden */
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
                                                .toISOString()
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