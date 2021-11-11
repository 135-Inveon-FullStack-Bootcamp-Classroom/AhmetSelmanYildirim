import { combineReducers } from "redux";
import memeReducer from "./memeReducer";
// Tum reducerlar burada birlestirilir
const reducers = combineReducers({
    memeReducer
});

export default reducers;