import React from "react";
import { useState } from "react";
import Popup from "reactjs-popup";
import "reactjs-popup/dist/index.css";
import {CreateTaskApiCall} from "../services/taskApiCalls";
import "./component.css";

export default function CreateTaskForm() {
    const [taskInfo, setTaskInfo] = useState({
        name: "",
        content: "",
        startDate: new Date(),
        endDate: new Date(),
        tags: "",
        status: Number,
        activityId: Number,
    });

    const statusOptions = [
        { id: 1, text: "New" },
        { id: 2, text: "Ongoing" },
        { id: 3, text: "Done" },
    ];

    const activityOptions = [
        { id: 1, text: "School" },
        { id: 2, text: "Work" },
        { id: 3, text: "Hobby" },
        { id: 4, text: "Chore" },
    ];

    const handleChange = (e) => {
        const { name, value } = e.target;
        setTaskInfo({
            ...taskInfo,
            [name]: value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // console.log(taskInfo);
        CreateTaskApiCall(taskInfo);

    };

    return (
        <div className="mr-auto">
            <Popup
                trigger={
                    <button className="border border-black/25 px-1 bg-gradient-to-tr w-fit h-fit ml-auto">
                        Create task
                    </button>
                }
                modal
                nested
            >
                {(close) => (
                    <div className="flex flex-row">
                        <div className="creationForm min-w-max">
                            <div className="Modal-header">Weclom E jeps</div>

                            <div className="Modal-body">
                                <form onSubmit={handleSubmit}>
                                    <div className="form-group">
                                        <label htmlFor="name"></label>
                                        <input
                                            type="text"
                                            name="name"
                                            placeholder="Buy bread"
                                            value={taskInfo.name}
                                            onChange={handleChange}
                                            required
                                        />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="content"></label>
                                        <input
                                            type="text"
                                            name="content"
                                            placeholder="Description"
                                            value={taskInfo.content}
                                            onChange={handleChange}
                                            required
                                        />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="startDate"></label>
                                        <input
                                            type="date"
                                            name="startDate"
                                            placeholder=""
                                            value={taskInfo.startDate}
                                            onChange={handleChange}
                                            required
                                        />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="endDate"></label>
                                        <input
                                            type="date"
                                            name="endDate"
                                            placeholder=""
                                            value={taskInfo.endDate}
                                            onChange={handleChange}
                                            required
                                        />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="tags"></label>
                                        <input
                                            type="text"
                                            name="tags"
                                            placeholder="Enter tags"
                                            value={taskInfo.tags}
                                            onChange={handleChange}
                                            required
                                        />
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="status"></label>
                                        <select
                                            onChange={handleChange}
                                            required
                                            name="status"
                                        >
                                            <option>Status</option>
                                            {statusOptions.map((option) => {
                                                return (
                                                    <option
                                                        key={option.id}
                                                        value={option.id}
                                                    >
                                                        {option.text}
                                                    </option>
                                                );
                                            })}
                                        </select>
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="activityId"></label>
                                        <input
                                            type="text"
                                            name="activityId"
                                            placeholder="activityId"
                                            value={taskInfo.activityId}
                                            onChange={handleChange}
                                            required
                                        />
                                    </div>
                                    <button type="submit">Save</button>
                                </form>
                            </div>

                            <div className="Modal-footer">
                                <div>
                                    <button onClick={() => close()}>
                                        Cancel
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                )}
            </Popup>
        </div>
    );
}
