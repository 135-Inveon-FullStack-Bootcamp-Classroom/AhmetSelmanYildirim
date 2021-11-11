import { createStore } from "redux";
import reducers from "./index";
// Birlestirilen reducerlar burada store a verilir
export default function configureStore(){
    return createStore(reducers);
}
