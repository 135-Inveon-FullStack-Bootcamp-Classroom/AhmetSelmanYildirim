import React, { useState, createContext } from "react";

export const CalculationContext = createContext();

export const CalculationProvider = ({ children }) => {
  const [mainText, setMainText] = useState("0");
  const [resetMainTextNextTime, setResetMainTextNextTime] = useState(true);

  const [lastResult, setLastResult] = useState("");
  const [currentOperation, setCurrentOperation] = useState("");

  const handleKeyClick = (isNumber, label, isOperator, isDot) => {
    console.log(isNumber, label, isOperator);
    if (isNumber) {
      if (resetMainTextNextTime) {
        setMainText(label);
        setResetMainTextNextTime(false);
      }
      else {
        setMainText((mainText) => {
          return mainText + label;
        });
      }
    }

    if (isOperator) {
      setCurrentOperation(label);
      setResetMainTextNextTime(true);

      switch (label) {

        case "+":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(Number(mainText) + lastResult);
            setMainText(Number(mainText) + lastResult);
          }

          break;

        case "-":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult - Number(mainText));
            setMainText(lastResult - Number(mainText));
          }
          break;

        case "x":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult * Number(mainText));
            setMainText(Number(mainText) * lastResult);
          }
          break;

        case "/":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult / Number(mainText));
            setMainText(lastResult / Number(mainText));
          }
          break;

        case "%":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult((lastResult * Number(mainText)) / 100);
            setMainText((lastResult * Number(mainText)) / 100);
          }
          break;

        case "CE":
          setMainText(0)
          break;

        case "C":
          setLastResult("")
          setMainText(0)
          break;

        case "<-":
          if (lastResult !== "") {
            setLastResult("")
          }
          else if (mainText !== "0" || mainText !== 0) {
            setMainText(mainText.toString().substring(0, mainText.length - 1))
            if (mainText.length === 1) setMainText("0")
          }
          break;

        case "1/x":
          setLastResult(`1/(${mainText})`)
          setMainText((1 / mainText).toFixed(3))
          break;

        case "x^2":
          setLastResult(`sqr(${mainText})`)
          setMainText(mainText * mainText)
          break;

        case "kök(x)":
          setLastResult(`kök(${mainText})`)
          setMainText(Math.sqrt(Number(mainText)))
          break;

        case "+/-":
          let sign = mainText.toString().substring(0, 1)
          if (sign !== "-") {
            setMainText("-"+mainText)
          }
          else{
            setMainText(mainText.toString().substring(1, mainText.length))
          }
          break;

        case "=":
          if (currentOperation === "+") {
            setMainText(Number(mainText) + lastResult);
            setLastResult("");
          }
          else if (currentOperation === "-") {
            setMainText(lastResult - Number(mainText));
            setLastResult("");
          }
          else if (currentOperation === "x") {
            setMainText(lastResult * Number(mainText));
            setLastResult("");
          }
          else if (currentOperation === "/") {
            setMainText(lastResult / Number(mainText));
            setLastResult("");
          }
          else if (currentOperation === "%") {
            setMainText((lastResult * Number(mainText)) / 100);
            setLastResult("");
          }
          break;

        default:
          break;
      }
    }

    if (isDot) {
      if (resetMainTextNextTime) {
        setMainText(label);
        setResetMainTextNextTime(false);
      }
      else {
        setMainText((mainText) => {
          return mainText + label;
        });
      }
    }
  };

  return (
    <CalculationContext.Provider
      value={{
        mainText,
        setMainText,
        handleKeyClick,
        resetMainTextNextTime,
        setResetMainTextNextTime,
        lastResult,
        currentOperation,
      }}
    >
      {children}
    </CalculationContext.Provider>
  );
};