import * as actionTypes from "./actionTypes";

// Aksiyon fonksiyonlarinin ne yapacagi burada belirlenir.

export const setMemes=(data)=>({
    type:actionTypes.SET_MEMES,
    payload:data
})

export const getMemeById=(id)=>({
    type:actionTypes.GET_MEME_BY_ID,
    payload:id
})