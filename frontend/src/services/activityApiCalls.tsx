import axios from "axios";

export default async function getActivities() {
    const response = await axios.get(
        "https://localhost:7296/SqiqqeliQuery/Get activities and free eBooks FREE OF CHARGE!!!"
    );
    if (!response.data.ok) {
        console.error("Vituiks meni", response.statusText);
        return response.data;
    }
    localStorage.setItem("OMGWTF", response.data);
    return response.data;
}
