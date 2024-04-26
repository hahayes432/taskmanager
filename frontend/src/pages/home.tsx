import Box from "../components/box";
import CreateTaskForm from "../components/taskCreationForm.jsx";
import { taskItem } from "../services/types.js";
import TaskElementConstructor from "../components/taskElement.js";

export default function Home() {
    const task: taskItem = {
        id: 1,
        name: "Buy milk",
        content:
            "Go to store and buy milk. jklsdfdhlasd faklfhjklasdj faklösjfklö sdlaskDalsk sLKD LJK HSD FKAJHSFD KLJASFLJ Kkl jsklsöjklsdfjsklöadfj aslkdf jlkjadklöf",
        startDate: new Date(),
        endDate: new Date(),
        tags: [2, 3, 4],
        status: 2,
        activityId: 3,
    };

    const aaa: taskItem[] = [...Array(3)].fill(task);

    return (
        <>
            <div className="gigaChad">
                <h1>Home pagings</h1>
                <CreateTaskForm />
            </div>
            {/* Edit this div to adjust size of task boxes */}
            <div className="flex flex-col w-3/4">
                {aaa.map((item, index) => {
                    return (
                        <div className="min-h-fit max-w-fit" key={index}>
                            <Box>
                                <TaskElementConstructor data={item} />
                            </Box>
                        </div>
                    );
                })}
            </div>
        </>
    );
}
