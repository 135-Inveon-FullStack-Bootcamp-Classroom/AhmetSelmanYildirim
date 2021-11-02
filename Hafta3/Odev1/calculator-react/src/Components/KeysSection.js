import React from 'react'
import KeyButton from './KeyButton'

const KeysSection = () => {
    return (
        <div className="keys-section">

            <KeyButton label="%" isOperator />
            <KeyButton label="CE" isOperator />
            <KeyButton label="C" isOperator />
            <KeyButton label="<-" isOperator />

            <KeyButton label="1/x" isOperator />
            <KeyButton label="x^2" isOperator />
            <KeyButton label="kök(x)" isOperator />
            <KeyButton label="/" isOperator />

            <KeyButton label="7" isDarker isNumber />
            <KeyButton label="8" isDarker isNumber />
            <KeyButton label="9" isDarker isNumber />
            <KeyButton label="x" isOperator />

            <KeyButton label="4" isDarker isNumber />
            <KeyButton label="5" isDarker isNumber />
            <KeyButton label="6" isDarker isNumber />
            <KeyButton label="-" isOperator />

            <KeyButton label="1" isDarker isNumber />
            <KeyButton label="2" isDarker isNumber />
            <KeyButton label="3" isDarker isNumber />
            <KeyButton label="+" isOperator />

            <KeyButton label="+/-" isDarker isOperator />
            <KeyButton label="0" isDarker isNumber />
            <KeyButton label="." isDarker isDot/>
            <KeyButton label="=" isBlue isOperator />

        </div>
    )
}

export default KeysSection
