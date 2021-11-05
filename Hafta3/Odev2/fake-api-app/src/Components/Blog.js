import React, { useContext } from 'react'
import { AppContext } from '../Context/AppContext'

const Blog = () => {
    // Contextten gelen veriler duzenlenip sayfaya bastirilir
    const { blogs } = useContext(AppContext)
    return (
        <div style={styles.blogContainer}>
            {blogs &&
                blogs.map((item, index) => (
                    <div key={item + index} style={styles.blogSingle}>
                        <img style={styles.blogImage} src={item.thumbnailUrl} alt="imagea" />
                        <p>{item.title}</p>
                    </div>
                ))
            }

        </div>
    )
}

const styles = {
    blogContainer: {
        width: "90%",
        display: "flex",
        flexDirection: "row",
        justifyContent: "space-around",
        alignItems: "center",
        flexWrap: "wrap",
        marginTop: "2%"
    },
    blogSingle: {
        width: "30%",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        flexDirection: "column"

    },
    blogImage: {

    }
}

export default Blog
