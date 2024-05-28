export default function Notifications({ children, handleClick, show }) {
    const count = Array.from(children).length;
    return (
        <>
            <div className="relative">
                <button
                    className="text-white bg-gray-800 px-4 py-2 rounded-lg hover:bg-gray-700"
                    onClick={handleClick}
                >
                    Notifications
                </button>
                {show ? (
                    <dialog className="rounded-lg flex flex-col w-96 h-72 pb-3 bg-white border border-slate-600 z-50">
                        <div className="flex w-11/12 justify-between mx-auto mt-2">
                            {count > 0 ? (
                                <h1>You have {count} notifications</h1>
                            ) : (
                                <h1>You dont have any notifications</h1>
                            )}
                            <button
                                onClick={handleClick}
                                className="w-fit h-fit px-1 rounded-md border border-transparent hover:shadow-lg shadow-black"
                            >
                                X
                            </button>
                        </div>
                        <div className="spinnu bg-neutral-200 flex flex-col w-5/6 h-5/6 m-auto border-2 border-black border-solid border-opacity-20 rounded-lg px-1 overflow-y-auto overflow-x-hidden ">
                            {children}
                        </div>
                    </dialog>
                ) : undefined}
            </div>
        </>
    );
}
