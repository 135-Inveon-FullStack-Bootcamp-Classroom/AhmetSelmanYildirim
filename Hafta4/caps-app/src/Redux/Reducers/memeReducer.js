import * as actionTypes from "../Actions/actionTypes";

// Reducer icinde yalnızca basit state yonetimi islemleri yapilir
const memeReducer = (state = "0", action) => {
    let newState;
    switch (action.type) {
        case actionTypes.SET_MEMES:
            return (newState = action.payload)
        case actionTypes.GET_MEME_BY_ID:
            return (newState = action.payload)    
        default:
            return state;
    }
}

export default memeReducer;