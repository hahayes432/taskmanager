import React from "react";
import { useState } from "react";
import Popup from "reactjs-popup";
import 'reactjs-popup/dist/index.css';
import './task.css'
import essentialAsset from '../assets/essentialAsset.png'
// import taskItem from "../services/types.tsx";
// import DatePicker from "react-date-picker";

export default function CreateTaskForm() {
    const [taskInfo, setTaskInfo] = useState({
        name: '',
        description: '',
        startDate: new Date(),
        endDate: new Date(),
        tags: '',
        status: Number,
        relatedActivity: Number
    })

    const statusOptions = [
        {id: 1, text: "Done"},
        {id: 2, text: "In progress"},
        {id: 3, text: "New"},
        {id: 4, text: "Cancelled"},
    ]

    const activityOptions = [
        {id: 1, text: "School"},
        {id: 2, text: "Job"},
        {id: 3, text: "Hobby"},
        {id: 4, text: "Chore"},
    ]

    const handleChange = (e) => {
        const { name, value } = e.target;
        setTaskInfo({
          ...taskInfo,
          [name]: value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(taskInfo)
    }

    return (
        <div className="mr-auto">
            <Popup trigger={<button className="border border-black/25 px-1 bg-gradient-to-tr w-fit h-fit ml-auto" >Create task</button>} modal nested>
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
                                        <label htmlFor="description"></label>
                                        <input 
                                            type="text"
                                            name="description"
                                            placeholder="Description"
                                            value={taskInfo.description}
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
                                                    <option key={option.id} value={option.id}>
                                                        {option.text}
                                                    </option>
                                                );
                                            })}

                                        </select>
                                    </div> 
                                    <div className="form-group">
                                        <label htmlFor="relatedActivity"></label>
                                        <select
                                            onChange={handleChange}
                                            required 
                                            name="relatedActivity"
                                        >
                                            <option>Activity</option>
                                            {activityOptions.map((option) => {
                                                return (
                                                    <option key={option.id} value={option.id}>
                                                        {option.text}
                                                    </option>
                                                );
                                            })}

                                        </select>
                                    </div> 
                                    <button type="submit">Save</button>
                                </form>
                            </div>
                            
                            <div className="Modal-footer">
                                <div>
                                    <button onClick={() => close()}>Cancel</button>
                                </div>
                            </div>     
                        </div>
                        
                        <div className="w-2/4 min-h-full my-auto">
                            <img src={essentialAsset} className="h-2/4 w-full"></img>
                        </div>
                    </div>
                )}
            </Popup>
        </div>
    );
}