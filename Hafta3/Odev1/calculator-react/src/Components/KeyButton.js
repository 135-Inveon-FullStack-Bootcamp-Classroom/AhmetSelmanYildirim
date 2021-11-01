import { useContext, useState } from "react";
import { CalculationContext } from "../Contexts/CalculationContext";


const getHoveredStyle = (isBlue) => {
    let hoveredStyle = { cursor: "pointer", backgroundColor: "#777" };
    if (isBlue) hoveredStyle = { ...hoveredStyle, backgroundColor: "#24568b" };

    return hoveredStyle;
};

const getHoveredKeyTextStyle = (hovered) => {
    if (hovered) return { color: "black" };
};

const KeyButton = ({ label, isBlue, isDarker, isOperator, isNumber, isDot }) => {

    const { handleKeyClick } = useContext(CalculationContext)

    const [hovered, setHovered] = useState(false)

    const isBlueStyle = isBlue ? { backgroundColor: "#134569" } : {};
    const isDarkerStyle = isDarker ? { backgroundColor: "#070707" } : {};
    const isHoveredStyle = hovered ? getHoveredStyle(isBlue) : {}


    return (
        <div
            className="key-container"
            style={{
                ...isBlueStyle,
                ...isDarkerStyle,
                ...isHoveredStyle,
            }}

            onMouseEnter={() => setHovered(true)}
            onMouseLeave={() => setHovered(false)}
            onClick={()=> handleKeyClick(isNumber, label, isOperator, isDot)}
        >

            <span
                className="key-text"
                style={{
                    ...getHoveredKeyTextStyle(hovered),
                }}
            >
                {label}
            </span>
        </div>
    )
}

export default KeyButton