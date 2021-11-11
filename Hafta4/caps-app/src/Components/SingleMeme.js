import React from 'react'
import { connect } from 'react-redux'
import Header from './Header'
import SetText from './SetText'

const styles = {
    container: {
        marginLeft: "10vw",
        width: "80vw",
        display: "flex",
        justifyContent: "space around",
        alignItems: "flex-start",

    },
    left: {
        width: "60%",
        height: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        flexDirection: "column",
    },
    right: {
        height:"50vh",
        width: "40%",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        flexDirection: "column",

    },
    image: {
        width: "100%",
        height: "100%"
    }
}

function SingleMeme(props) {
    let meme = props.meme
    return (
        <div>
            <div style={styles.container}>
            
            <div style={styles.left} >
                <img style={styles.image} alt={meme.id} src={meme.url}  ></img>

            </div>
            {/* Textleri almak icin farkli bir component kullanilir */}
            <div style={styles.right} >
                <SetText meme={meme} />
            </div>
        </div>
        </div>
        
    )
}

function mapStateToProps(state) {
    return { meme: state.memeReducer }
}

export default connect(mapStateToProps)(SingleMeme)