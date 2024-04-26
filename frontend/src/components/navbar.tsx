import { Link, Outlet } from "react-router-dom";
import { useState } from "react";
import Notifications from "./notifications";

export default function Navbar() {
    const [show, setShow] = useState<boolean>(false);
    function showNotifications() {
        if (show === true) {
            setShow((old) => false);
        } else {
            setShow((old) => true);
        }
    }
    return (
        <>
            <nav className="bg-gray-800">
                <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
                    <div className="flex items-center justify-between h-16">
                        <div className="flex items-center">
                            <div className="flex-shrink-0"></div>
                            <div className="hidden md:block">
                                <div className="ml-10 flex items-baseline space-x-4">
                                    <Link
                                        className="text-white bg-gray-800 px-4 py-2 rounded-lg hover:bg-gray-700"
                                        to="/"
                                    >
                                        Home
                                    </Link>
                                    <Link
                                        className="text-white bg-gray-800 px-4 py-2 rounded-lg hover:bg-gray-700"
                                        to="/task"
                                    >
                                        Tasks
                                    </Link>
                                    <Link
                                        className="text-white bg-gray-800 px-4 py-2 rounded-lg hover:bg-gray-700"
                                        to="/activity"
                                    >
                                        Activities
                                    </Link>
                                    <Link
                                        className="text-white bg-gray-800 px-4 py-2 rounded-lg hover:bg-gray-700"
                                        to="/statistics"
                                    >
                                        Statictics
                                    </Link>
                                </div>
                            </div>
                        </div>
                        <div>
                            <Notifications
                                show={show}
                                handleClick={showNotifications}
                            >
                                {[...Array(30)].map((item, index) => {
                                    return <p key={index}>what {index + 1}</p>;
                                })}
                            </Notifications>
                        </div>
                    </div>
                </div>
            </nav>
            <Outlet></Outlet>
        </>
    );
}
