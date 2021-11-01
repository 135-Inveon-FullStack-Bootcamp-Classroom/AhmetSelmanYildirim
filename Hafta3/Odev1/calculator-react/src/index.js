import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { CalculationProvider } from "./Contexts/CalculationContext"

ReactDOM.render(
  <React.StrictMode>
    <CalculationProvider>
      <App />
    </CalculationProvider>
  </React.StrictMode>,
  document.getElementById('root')
);
