import React from 'react';
import ReactDOM from 'react-dom/client';
import {
  createBrowserRouter,
   RouterProvider,
  } from 'react-router-dom';
import './index.css';
import Home from './pages/home.tsx';
import Navbar from './components/navbar.tsx';


const router = createBrowserRouter([
  {
    path: "/",
    element: <Navbar/>,
    children: [
      {
        children: [
          {index: true, element: <Home/>},
        ],
      },
    ],
  },
])

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
