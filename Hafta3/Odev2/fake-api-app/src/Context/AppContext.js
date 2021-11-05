import React, { useState, createContext, useEffect } from "react";
import axios from "axios";

export const AppContext = createContext();

export const AppProvider = ({ children }) => {
    const [pageNumber, setPageNumber] = useState(0);
    const [blogs, setBlogs] = useState([]);
    const blogCount = 12;

    useEffect(()=>{
        setPage(0)
    },[])

    // Butona tiklaninca sayfa numarası statei degisecek
    const setPage = async (number) => {
        setPageNumber(number);
        // Veriler getirilip blogs stateine verilecek
        const { data } = await axios(`https://jsonplaceholder.typicode.com/photos?_start=${number * blogCount}&_limit=${blogCount}`);
        setBlogs(data);
    };

    // edinilen veriler contexti kullanacak componentlere verilir.
    return (
        <AppContext.Provider
            value={{
                pageNumber,
                setPageNumber,
                setPage,
                blogs
            }}
        >
            {children}
        </AppContext.Provider>
    );
};