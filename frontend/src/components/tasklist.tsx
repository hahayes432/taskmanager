export default function TaskList() {
    const now: Date = new Date();
    const end: Date = new Date(now.getDate() + 7);
    const task: any = {
        name: "what",
        content:
            "what the hell what the hell what the hell what the hell what the hell what the hell what the hell what the hell ",
        startDate: now,
        endDate: end,
        tags: [1, 2, 3],
        status: 1,
        activityId: 1,
    };
    const taskArray = [...Array(24)].fill(task);
    return (
        <>
            <div>
                {taskArray.map((item, index) => {
                    return (
                        <div
                            key={index}
                            className="flex flex-row w-11/12 m-auto justify-evenly bg-neutral-400"
                        >
                            <p className="border border-black px-2">
                                {item.name}
                            </p>
                            <p className="border border-black px-2">
                                {item.startDate.toString()}
                            </p>
                            <p className="border border-black px-2">
                                {item.content}
                            </p>
                            <p className="border border-black px-2">
                                {item.endDate.toString()}
                            </p>
                            <p className="border border-black px-2">
                                {item.tags}
                            </p>
                            <p className="border border-black px-2">
                                {item.status}
                            </p>
                            <p className="border border-black px-2">
                                {item.activityId}
                            </p>
                        </div>
                    );
                })}
            </div>
        </>
    );
}
