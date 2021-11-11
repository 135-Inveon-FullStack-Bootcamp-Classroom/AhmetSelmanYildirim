import './App.css';
import AppContainer from './Components/AppContainer';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import SingleMeme from './Components/SingleMeme';


function App() {
  return (
    <div>
      <Router>
        <Routes>
          <Route path="/" element={<AppContainer />} />
          <Route path="/single-caps/:id" element={<SingleMeme />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
