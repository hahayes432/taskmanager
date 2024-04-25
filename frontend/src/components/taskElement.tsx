import { taskItem } from "../services/types";

export default function TaskElementConstructor({ data }: { data: taskItem }) {
    return (
        // TODO: style these
        <div className="task-box w-full">
            <h1>{data.name}</h1>
            <p>{data.content}</p>
            <p>{data.startDate.toDateString()}</p>
            <p>{data.endDate.toDateString()}</p>
            <p>Tags: {data.tags}</p>
            <p>Status: {data.status}</p>
            <p>Activity: {data.activityId}</p>
        </div>
    );
}
