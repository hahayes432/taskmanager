import { taskItem } from "../services/types";


export default function TaskElementConstructor({ data }: { data: taskItem }) {
    return (
        <div className="task-box w-full bg-gray-100 rounded-lg shadow-md p-4">
            <h1 className="text-xl font-bold mb-2">{data.name}</h1>
            <p className="text-gray-700 mb-2">{data.content}</p>
            <div className="flex flex-wrap mb-2">
                <p className="mr-4">Start Date: {new Date(data.startDate).toLocaleDateString()}</p>
                <p>End Date: {new Date(data.endDate).toLocaleDateString()}</p>
            </div>
            <p className="text-gray-700 mb-2">Tags: {data.tags.join(', ')}</p>
            <p className="text-gray-700 mb-2">Status: {data.status}</p>
            <p className="text-gray-700">Activity: {data.activityId}</p>
        </div>
    );
}
