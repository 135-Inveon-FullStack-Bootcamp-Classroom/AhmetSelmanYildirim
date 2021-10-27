import React from 'react'

const styles = { color: "#fa560f" }

const saveTodo = (todoText, todos, setTodos, setTitle) => {
    if (todos) {
        const localStorageTodos = [...todos]
        const newTodo = { text: todoText, status: "pending", createdAt: new Date(), updatedAt: "There is no update" }
        const checkExist = todos.filter(item => item.text === todoText)
        if (todoText === "" || todoText.replace(/^\s+|\s+$/g, "").length === 0) { setTitle("Text Cannot be Empty"); setTimeout(() => { setTitle("To Do List"); }, 1500) }
        else if (checkExist.length >= 1) { alert("Todo already exist"); }
        else {
            setTodos([...todos, newTodo]);
            localStorageTodos.push(newTodo)
            localStorage.setItem("todos", JSON.stringify(localStorageTodos))
        }
    }
}

const Header = ({ todoText, setTodoText, title, todos, setTodos, setTitle }) => {

    return (
        <div className="header">
            {
                title.length < 15
                    ? <h1 className="title"  >{title}</h1>
                    : <h1 className="title" style={styles}  >{title}</h1>
            }
            <div className="todo-container input-group mb-3">
                <input className="input" id="todo-text" placeholder="What are you going to do?" value={todoText} onChange={(e) => setTodoText(e.target.value)} />

                <button id="todo-button" className="btn btn-primary" onClick={() => { saveTodo(todoText, todos, setTodos, setTitle); setTodoText(""); }}> Save</button>

            </div>
        </div>
    )
}

export default Header
