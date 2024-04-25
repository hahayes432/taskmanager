import Box from "../components/box";
import CreateTaskForm from "../components/taskCreationForm.jsx";
import { taskItem } from "../services/types.js";
import TaskElementConstructor from "../components/taskElement.js";

export default function Home() {
    const task: taskItem = {
        id: 1,
        name: "Buy milk",
        content: "Go to store and buy milk",
        startDate: new Date(),
        endDate: new Date(),
        tags: [2, 3, 4],
        status: 2,
        activityId: 3,
    };

    const aaa: taskItem[] = [...Array(5)].fill(task);

    return (
        <>
            <div className="gigaChad">
                <h1>Home pagings</h1>
                <CreateTaskForm />
            </div>
            <div className="flex">
                {aaa.map((item, index) => {
                    return (
                        <Box>
                            <TaskElementConstructor
                                key={index}
                                data={item}
                            ></TaskElementConstructor>
                        </Box>
                    );
                })}
            </div>
        </>
    );
}
