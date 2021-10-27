const updateStatus = (item, todos, setTodos, newStatus) => {

    console.log(newStatus);
    console.log(todos);
    // state update
    let newTodos = [...todos]
    newTodos = newTodos.filter(t => t.text !== item.text)
    newTodos.push({ text: item.text, status: newStatus, createdAt: item.createdAt, updatedAt: new Date() })
    setTodos(newTodos)
    console.log(newTodos);

    localStorage.setItem("todos", JSON.stringify(newTodos))

}

// Todonun güncellenmesi
const updateText = (item, todos, setTodos) => {
    let newText = prompt("New Todo? ");

    if (newText) {
        if (newText === "" || newText.replace(/^\s+|\s+$/g, "").length === 0) {
            alert("Text cannot be empty");
        }
        // Text'in localstorage'da olup olmadığının kontrolü
        else if (isExist(newText)) {
            alert("Todo already exist");
        }
        else {
            let newTodos = [...todos]
            newTodos = newTodos.filter(t => t.text !== item.text)
            newTodos.push({ text: newText, status: item.status, createdAt: item.createdAt, updatedAt: new Date() })
            setTodos(newTodos)

            
            localStorage.setItem("todos", JSON.stringify(newTodos))

        }
    }


}

// Info butonuna tıklandığında todonun detayının gösterilmesi ve silinmesi
const showInfo = (item, todos, setTodos) => {
    let data = JSON.parse(localStorage.getItem(item.text))
    let deleteTask = window.confirm(
        `
        Text: ${data.text}
        Status: ${data.status}
        Created at: ${data.createdAt}
        Last update: ${data.updatedAt}
        
        Do you want to delete the task?
        `
    )
    if (deleteTask) {
        //Deleting todo from localStorage
        localStorage.removeItem(item.text)
        //Deleting todo from state
        let newTodos = [...todos]
        newTodos = newTodos.filter(t => t.text !== item.text)
        setTodos(newTodos)
    }

}

// Todonun olup olmadığını kontrol eden fonksiyon
const isExist = (textToControl) => {
    const localStorageData = localStorage.getItem("todos");
    const dataArray = JSON.parse(localStorageData)
    const data = dataArray.find(item => item.text === textToControl )
    if(data) return true
    else return false
}

export { updateText, showInfo, updateStatus }