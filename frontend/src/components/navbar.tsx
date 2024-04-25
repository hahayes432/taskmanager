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
                                        to="/activities"
                                    >
                                        Activities
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
                        <div className="-mr-2 flex md:hidden">
                            <button
                                type="button"
                                className="bg-gray-800 inline-flex items-center justify-center p-2 rounded-md text-gray-400 hover:text-white hover:bg-gray-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-offset-gray-800 focus:ring-white"
                                aria-controls="mobile-menu"
                                aria-expanded="false"
                            >
                                <span className="sr-only">Open main menu</span>
                                <svg
                                    className="block h-6 w-6"
                                    xmlns="http://www.w3.org/2000/svg"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                >
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        strokeWidth={2}
                                        d="M4 6h16M4 12h16M4 18h16"
                                    />
                                </svg>
                                <svg
                                    className="hidden h-6 w-6"
                                    xmlns="http://www.w3.org/2000/svg"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                >
                                    <path
                                        strokeLinecap="round"
                                        strokeLinejoin="round"
                                        strokeWidth={2}
                                        d="M6 18L18 6M6 6l12 12"
                                    />
                                </svg>
                            </button>
                        </div>
                    </div>
                </div>

                <div className="md:hidden" id="mobile-menu">
                    <div className="px-2 pt-2 pb-3 space-y-1 sm:px-3">
                        <Link to="/">Home</Link>
                        <Link to="/task">Tasks</Link>
                        <Link to="/activity">Activities</Link>
                    </div>
                </div>
            </nav>
            <Outlet></Outlet>
        </>
    );
}
