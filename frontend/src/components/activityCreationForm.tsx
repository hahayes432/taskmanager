import { useRef } from "react";
import Popup from "reactjs-popup";

export default function ActivityCreationForm({
    handleSubmit,
    activityInfo,
    setActivityInfo,
}) {
    const ref = useRef();

    const statusOptions = [
        { id: 1, text: "New" },
        { id: 2, text: "Ongoing" },
        { id: 3, text: "Done" },
    ];

    const handleChange = (e) => {
        const { name, value } = e.target;
        setActivityInfo({
            ...activityInfo,
            [name]: value,
        });
    };

    return (
        <div className="w-3/4 mx-auto">
            <Popup
                trigger={
                    <button className="border border-black/25 px-1 w-fit h-fit ml-auto rounded-md bg-blue-300">
                        Create task
                    </button>
                }
                modal
                nested
                ref={ref}
            >
                <div className="flex flex-row">
                    <div className="creationForm min-w-max">
                        <div className="Modal-header">Weclom E jeps</div>

                        <div className="Modal-body">
                            <form
                                onSubmit={(e) => {
                                    e.preventDefault();
                                    handleSubmit();
                                    ref.current.close();
                                }}
                            >
                                <div className="form-group">
                                    <label htmlFor="name"></label>
                                    <input
                                        type="text"
                                        name="name"
                                        placeholder="Buy bread"
                                        value={activityInfo.name}
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
                                        value={activityInfo.content}
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
                                        value={activityInfo.startDate}
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
                                        value={activityInfo.endDate}
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
                                        value={activityInfo.tags}
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
                                <button type="submit">Save</button>
                            </form>
                        </div>

                        <div className="Modal-footer">
                            <div>
                                <button onClick={() => ref.current.close()}>
                                    Cancel
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </Popup>
        </div>
    );
}
