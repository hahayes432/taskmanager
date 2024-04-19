import React from "react";
import { useState } from "react";
import Popup from "reactjs-popup";
import DatePicker from "react-date-picker";
import 'reactjs-popup/dist/index.css';

export default function CreateTaskForm() {
    const [taskInfo, setTaskInfo] = useState({
        name: '',
        description: '',
        startDate: new Date(),
        endDate: new Date(),
        tags: '',
        status: '',
        relatedActivity: ''
    })

    const options = [
        "Done",
        "In progress",
        "New",
        "Cancelled",
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
        <div>
            <Popup trigger={<button>Create task</button>} modal nested>
                {(close) => (
                    <div className="creationForm">
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
                                    {/* <DatePicker 
                                        onChange={handleChange}>
                                        value={taskInfo.endDate}
                                    </DatePicker> */}
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
                                    >
                                        <option>Please choose one option</option>
                                            {options.map((option, index) => {
                                                return (
                                                    <option key={index}>
                                                        {option}
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
                )}
            </Popup>
        </div>
    );
}