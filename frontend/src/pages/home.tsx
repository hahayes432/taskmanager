import Box from "../components/box";
import CreateTaskForm from "../components/taskCreationForm.jsx";

export default function Home() {
    return (
        <>
            <div className="flex">
                <Box>
                    <h1>Contents 1</h1>
                    <p>Additional content</p>
                </Box>
                <Box>
                    <h1>Contents 2</h1>
                    <p>More content</p>
                </Box>
                <Box>
                    <h1>Contents 3</h1>
                    <p>Even more content</p>
                </Box>
            </div>
            <div>
                <h1>Home pagings</h1>
            </div>
        </>
    );
}
