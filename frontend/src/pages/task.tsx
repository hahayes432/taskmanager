import TaskList from "../components/tasklist";
import CreateTaskForm from "../components/taskCreationForm.jsx";

export default function Task() {
    return (
        <>
            <div className="flex flex-col w-full h-screen overflow-hidden">
                <div className="w-fit mx-auto mt-4">
                    <h2 className="text-2xl font-bold">Tasks peigi</h2>
                </div>
                <TaskList />
                {/* tähä tulee lista sit tosia  :DDDD */}
                <CreateTaskForm />
            </div>
        </>
    );
}
