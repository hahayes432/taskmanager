import'./component.css'

export default function Box() {
    return(
        <main className="flex flex-wrap">
        <div className="box-1 w-1/2 md:w-2/5 p-4 border-4 border-teal-400 bg-teal-200">
            <h1>render task content into box</h1>
        </div>
        <div className="box-2 w-1/2 md:w-1/5 p-4 border-4 border-teal-400 bg-teal-200">
            <h1>render taks content into box</h1>
        </div>
  
    </main>

  
    

        
);
}