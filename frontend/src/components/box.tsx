import "./component.css";

export default function Box({ children }) {
    return (
        <div className="box h-3/4 w-3/4 p-4 border-4 border-teal-400 bg-teal-200">
            {children}
        </div>
    );
}
