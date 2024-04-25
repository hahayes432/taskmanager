import { useState } from "react";
import { v4 as uuidv4 } from "uuid"; // fix warnings by generating unique keys in table mapping

export default function TaskList() {
    const [page, setPage] = useState<number>(0);
    const [startIndex, setStartIndex] = useState<number>(0);
    const [endIndex, setEndIndex] = useState<number>(8);
    const now: Date = new Date();
    const end: Date = new Date();
    end.setDate(now.getDate() + 7);
    const task: any = {
        id: 1,
        name: "what",
        content:
            "what the hell what the hell what the hell what the hell what the hell what the hell what the hell what the hell ",
        startDate: now,
        endDate: end,
        tags: [1, 2, 3],
        status: 1,
        activityId: 1,
    };
    const taskArray: any[] = [...Array(24)].fill(task);
    const itemsPerPage = 8;
    const buttonLabels: number[] = [];
    for (let i = 0; i < taskArray.length / itemsPerPage; i++) {
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
            setStartIndex((old) => page * itemsPerPage);
            setEndIndex((old) => page * itemsPerPage + itemsPerPage);
        } else if (
            buttonPressed === "next" &&
            newPage < taskArray.length / itemsPerPage - 1
        ) {
            //next page if there still is one
            newPage = page + 1;
            setPage((old) => old + 1); // update states for next time
            setStartIndex((old) => newPage * itemsPerPage);
            setEndIndex((old) => newPage * itemsPerPage + itemsPerPage);
        } else {
            return;
        }
        console.log(page);
        for (let i = 0; i < taskArray.length; i++) {
            let row = document.getElementById(`${i}`); //a row of the table
            row?.classList.toggle("hidden", i < startIndex || i >= endIndex); //set class to hidden if row is out of range
            // console.log(row?.classList);
            // console.log(startIndex, endIndex);
        }
    }

    return (
        <>
            <div className="w-3/4 h-3/4 m-auto what">
                <table className="mx-auto w-full h-full bg-neutral-400/50">
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
                                            {item.name}
                                        </td>
                                        <td
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                            key={uuidv4()}
                                        >
                                            {item.content}
                                        </td>
                                        <td
                                            key={uuidv4()}
                                            className=" max-h-6 border border-black/25 px-2 text-center"
                                        >
                                            <time
                                                key={uuidv4()}
                                                dateTime={item.startDate}
                                            />
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
            </div>
        </>
    );
}
