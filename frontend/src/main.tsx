import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./index.css";
import Home from "./pages/home.tsx";
import Navbar from "./components/navbar.tsx";
import Task from "./pages/task.tsx";
import ActivityPage from "./pages/activity.tsx";
import Statistics from "./pages/statistics.tsx";
import ErrorPage from "./pages/errorpage.tsx";

const router = createBrowserRouter([
    {
        path: "/",
        element: <Navbar />,
        errorElement: <ErrorPage />,
        children: [
            {
                children: [
                    {
                        index: true,
                        element: <Home />,
                        errorElement: <ErrorPage />,
                    },
                    {
                        path: "/task",
                        element: <Task />,
                        errorElement: <ErrorPage />,
                    },
                    {
                        path: "/activity",
                        element: <ActivityPage />,
                        errorElement: <ErrorPage />,
                    },
                    {
                        path: "/statistics",
                        element: <Statistics />,
                        errorElement: <ErrorPage />,
                    },
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
