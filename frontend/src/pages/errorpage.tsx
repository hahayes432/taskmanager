import { useRouteError } from "react-router-dom";

export default function ErrorPage() {
    const error = useRouteError();
    console.error(error);

    return (
        <>
            <div className="flex flex-col justify-center items-center w-full h-5/6 md:mt-72 lg:mt-96">
                <h1>An unexpected error has occurred</h1>
                <p>
                    <i>{error.statusText || error.message}</i>
                </p>
            </div>
        </>
    );
}
