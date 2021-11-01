import './App.css';
import AppContainer from "./Components/AppContainer";
import ScreenSection from "./Components/ScreenSection";
import Header from "./Components/Header";
import KeysSection from "./Components/KeysSection";

function App() {
  return (
    <AppContainer>
      <Header />
      <ScreenSection />
      <KeysSection />
    </AppContainer>
  );
}

export default App;