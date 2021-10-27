const updateStatus = (item, todos, setTodos, newStatus) => {

    // state update
    let newTodos = [...todos]
    newTodos = newTodos.filter(t => t.text !== item.text)
    newTodos.push({ text: item.text, status: newStatus })
    setTodos(newTodos)

    // localStorage update
    let localValue = JSON.parse(localStorage.getItem(item.text))
    let obj = { text: item.text, status: newStatus, createdAt: localValue.createdAt, updatedAt: new Date() }
    localStorage.setItem(item.text, JSON.stringify(obj))

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
            newTodos.push({ text: newText, status: item.status, createdAt: item.createdAt })
            setTodos(newTodos)

            // let oldKeyData = localStorage.getItem(item.text)
            localStorage.setItem(newText, JSON.stringify({ text: newText, status: item.status, createdAt: item.createdAt, updatedAt: new Date() }))

            localStorage.removeItem(item.text)
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



/*
//Todoları localstrogedan dolduran fonksiyon
const getAllTodosFromLocalStorage = () => {

    let keys = Object.keys(localStorage);
    let data = []
    keys.forEach(item => {
        let key = JSON.parse(localStorage.getItem(item))
        let updatedAt = key.updatedAt ? key.updatedAt : "There is no update"
        data.push({ text: key.text, status: key.status, createdAt: key.createdAt, updatedAt: updatedAt })
        // setTodos([...todos, { text: key.text, status: key.status, createdAt: key.createdAt, updatedAt: updatedAt }])
    })

    return data;

}
*/

// Todonun olup olmadığını kontrol eden fonksiyon
const isExist = (textToControl) => localStorage.getItem(textToControl) ? true : false;

export { updateText, showInfo, updateStatus }