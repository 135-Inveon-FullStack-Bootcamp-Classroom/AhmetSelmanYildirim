import React, { useContext } from 'react'
import { CalculationContext } from '../Contexts/CalculationContext';

const ScreenSection = () => {
    const { mainText, lastResult, currentOperation } = useContext(CalculationContext);

    // Ustteki kucuk text alanini duzenleyen fonksiyon
    const renderCaption = () => {

        if (lastResult && currentOperation)
            return (
                <span className="top-text">
                    {console.log("curretOperation", currentOperation)}
                    {lastResult} {currentOperation === "1/x" || "CE" || "<-" || "x^2" || "kök(x)"   ? "":  currentOperation }
                </span>
            )
    }

    // Tum sonuclarin gosterilecegi ekran alani
    return (
        <div className="screen-section">
            {renderCaption()}
            <span className="main-text"> {mainText}</span>
        </div>
    )
}

export default ScreenSection
