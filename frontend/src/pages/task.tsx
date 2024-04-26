import TaskList from "../components/tasklist";

export default function Task() {
    return (
        <>
            <div className="flex flex-col w-full h-full">
                <div className="w-fit mx-auto mt-4">
                    <h2 className="text-2xl font-bold">Tasks Page</h2>
                </div>
                <TaskList />
            </div>
        </>
    );
}
