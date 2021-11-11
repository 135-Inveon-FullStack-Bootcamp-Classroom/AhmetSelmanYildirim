import React from 'react'
import { connect } from 'react-redux'
import { Link } from "react-router-dom";
import { getMemeById } from '../Redux/Actions/memeActions';


const styles = {
    container: {
        display: "flex",
        flexDirection: "row",
        justifyContent: "center",
        alignItems: "center",
        width: "90%",
        marginLeft: "5%",
        flexWrap: "wrap"
    },
    meme: {
        width: "30%",
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
        textAlign: "center",
        padding: "10px",
    },
    memePhoto: {
        width: "100%",
        height: "30vh",
        minHeight: "150px"

    }
}
// Tum memeler burada gosterilir
function AllMemes(props) {

    if (props.memes.length < 10) return "Loading..."

    return (
        <div style={styles.container}>
            {
                props.memes.map(meme => (
                    <div key={meme.id} style={styles.meme}>
                        {/* Tiklanilan meme sayfasi acilir */}
                        <Link
                            onClick={() => { props.dispatch(getMemeById({ id: meme.id, url: meme.url })) }}
                            to={`/single-caps/${meme.id}`} >
                            <img src={meme.url} alt={meme.url} style={styles.memePhoto} />
                            <p>{meme.name}</p>
                        </Link>

                    </div>
                ))
            }
        </div>
    )
}
// Apiden cekilip redux tarafina gonderilen memeler bu dosyada kullanilmak uzere cekilir
function mapStateToProps(state) {
    return { memes: state.memeReducer }
}

export default connect(mapStateToProps)(AllMemes)
