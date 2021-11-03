// Uygulamanin temiz gorunmesi icin diger componentleri iceren ana component
const AppContainer = ({children}) => {
    return (
        <div className="app-container">
            <div className="calculator-container">
                {children}
            </div>
        </div>
    )
}

export default AppContainer
