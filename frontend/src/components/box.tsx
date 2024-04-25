
import'./component.css'

export default function Box({ children }) {
    return (
        <div className="box h-32 w-20 p-4 border-4 border-teal-400 bg-teal-200">
            {children}
        </div>
    );
}