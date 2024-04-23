import {
    Chart as ChartJS,
    ArcElement,
    Tooltip,
    Legend,
    LineController,
    LineElement,
    PointElement,
} from "chart.js";
import { Line } from "react-chartjs-2";

ChartJS.register(
    ArcElement,
    Tooltip,
    Legend,
    LineController,
    LineElement,
    PointElement
);

export default function Chart(data, options) {
    return (
        <div>
            <Line className="w-full h-full" data={data} options={options} />;
        </div>
    );
}
