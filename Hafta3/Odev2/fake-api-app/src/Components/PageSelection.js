import React, { useContext } from 'react'
import { AppContext } from '../Context/AppContext'

// Sayfalama butonlari
const PageSelection = () => {

    const { setPage, pageNumber } = useContext(AppContext)
    // Sayfalar butonlarla degistirilecek
    return (
        <div style={styles.buttonsField}>
            {
                pageNumber > 0 &&
                <button onClick={() => { setPage(pageNumber - 1) }}> Previous </button>
            }

            <span>Page: {pageNumber+1}</span>

            <button onClick={() => { setPage(pageNumber + 1) }}> Next </button>
        </div>
    )
}

const styles = {
    buttonsField: {
        display: "flex",
        width: "20%",
        justifyContent: "space-between",
        alignItems: "center"
    }
}

export default PageSelection

