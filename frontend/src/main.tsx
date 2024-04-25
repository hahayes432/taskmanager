import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./index.css";
import Home from "./pages/home.tsx";
import Navbar from "./components/navbar.tsx";
import Task from "./pages/task.tsx";
import ActivityPage from "./pages/activity.tsx";
import Statistics from "./pages/statistics.tsx";

const router = createBrowserRouter([
    {
        path: "/",
        element: <Navbar />,
        children: [
            {
                children: [
                    { index: true, element: <Home /> },
                    { path: "/task", element: <Task /> },
                    { path: "/activity", element: <ActivityPage /> },
                    { path: "/statistics", element: <Statistics /> },
                ],
            },
        ],
    },
]);

ReactDOM.createRoot(document.getElementById("root")!).render(
    <React.StrictMode>
        <RouterProvider router={router} />
    </React.StrictMode>
);
