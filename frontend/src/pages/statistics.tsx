import {
    Chart as ChartJS,
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend,
} from "chart.js";
import { Line } from "react-chartjs-2";

ChartJS.register(
    CategoryScale,
    LinearScale,
    PointElement,
    LineElement,
    Title,
    Tooltip,
    Legend
);

export const options = {
    maintainAspectRatio: false,
    responsive: true,
    plugins: {
        legend: {
            position: "top" as const,
        },
        title: {
            display: true,
            text: "Completed tasks in the last 30 days",
        },
    },
};

// const array = [...Array(24).fill(1)];

let array: number[] = [];
const labels = [...Array(30)].map((item, index) => index);
for (let i = 0; i < labels.length; i++) {
    array.push(Math.floor(Math.random() * 312));
}
export const data = {
    labels,
    datasets: [
        {
            label: "Dataset 1",
            data: array,
            borderColor: "rgb(0, 99, 132)",
            backgroundColor: "rgba(0, 99, 132, 0.5)",
        },
    ],
};

export default function Statistics() {
    return (
        <>
            <div className="w-full h-screen">
                <div className="m-auto w-3/5 h-2/5">
                    <Line
                        className="w-full h-full"
                        data={data}
                        options={options}
                    />
                </div>
            </div>
        </>
    );
}
