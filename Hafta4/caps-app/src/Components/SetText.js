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
    const [text2,setText2] = useState()
    const [text3,setText3] = useState()

    const generateUrl = async (text0,text1,text2,text3) => {

        const url = `https://api.imgflip.com/caption_image?template_id=${props.meme.id}&username=nodedenemenodedeneme&password=EPs2H4r3!!bq9S4&boxes[0][text]=${text0}&boxes[1][text]=${text1}&boxes[2][text]=${text2}&boxes[3][text]=${text3}`
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
            <input type="text" value={text2} placeholder="Text 3" onChange={(e)=>{setText2(e.target.value)}} />
            <br/>
            <input type="text" value={text3} placeholder="Text 4" onChange={(e)=>{setText3(e.target.value)}} />
            <br/>
            <button onClick={() => { generateUrl(text0,text1,text2,text3) }}> Generate Caps </button>
            <br/>
            <a href="/" > Go back to home </a>
        </div>
    )
}


function mapDispatchToProps(dispatch) {
    return { actions: bindActionCreators(getMemeById, dispatch) }
}

export default connect(mapDispatchToProps)(SetText);
