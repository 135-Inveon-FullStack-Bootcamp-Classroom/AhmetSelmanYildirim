import React, { useState } from 'react'
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { bindActionCreators } from 'redux';
import { getMemeById } from '../Redux/Actions/memeActions';


const styles={
    container:{
        display:"flex",
        flexDirection:"column",
        justifyContent:"center",
        alignItems:"center",
    }
}

// Burada link uretilecek ve state meme degistirilecek


function SetText(props) {

    const [text0,setText0] = useState()
    const [text1,setText1] = useState()

    const generateUrl = async (text0,text1) => {

        const url = `https://api.imgflip.com/caption_image?template_id=${props.meme.id}&username=nodedenemenodedeneme&password=EPs2H4r3!!bq9S4&text0=${text0}&text1=${text1}`
        fetch(url)
            .then((response) => response.json())
            .then((result) => props.dispatch(getMemeById({ id: props.meme.id, url: result.data.url })));
    }

    // Textler belirlenerek capsin olusturulmasi saglanir 
    return (
        <div style={styles.container}>
            
            <input type="text"  value={text0} placeholder="Text 1" onChange={(e)=>{setText0(e.target.value)}} />
            <br/>
            <input type="text" value={text1} placeholder="Text 2" onChange={(e)=>{setText1(e.target.value)}} />
            <br/>
            <button onClick={() => { generateUrl(text0,text1) }}> Generate Caps </button>
            <br/>
            <a href="/" > Go back to home </a>
        </div>
    )
}


function mapDispatchToProps(dispatch) {
    return { actions: bindActionCreators(getMemeById, dispatch) }
}

export default connect(mapDispatchToProps)(SetText);
