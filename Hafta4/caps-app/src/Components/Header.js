import React, { useEffect } from 'react'
import { connect } from 'react-redux'
import { bindActionCreators } from 'redux'
import { setMemes } from '../Redux/Actions/memeActions'

const styles = {
    container: { textAlign: "center" }
}
// Sayfa acilisindaki header yuklenirken capslerin apiden cekilmesini saglar
function Header(props) {

    useEffect(() => {
        fetch("https://api.imgflip.com/get_memes")
            .then((response) => response.json())
            // memeAction.js de belirtilen aksiyon burada dispatch yardimiyla kullanilir
            .then((result) => props.dispatch(setMemes(result.data.memes)));
    }, []);

    return (
        <div style={styles.container}>
            CAPS APPLICATION
        </div>
    )
}
// reduxta tanimlanan kullanilacak aksiyon belirtilir
function mapDispatchToProps(dispatch) {
    return { actions: bindActionCreators(setMemes, dispatch) }
}
// connect ile redux ile baglanti saglanir
export default connect(mapDispatchToProps)(Header);
