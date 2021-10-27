import { useState, useEffect } from 'react';
import './App.css';
import Header from "./Components/Header";
import ToDoList from "./Components/ToDoList";

const deleteAll = (setTodos) => {
  let confirm = window.confirm(`Do you want to delete all todos`)
  if (confirm) {
    localStorage.clear();
    setTodos([])
  }
}

function App() {

  const [todoText, setTodoText] = useState("");
  const [todos, setTodos] = useState([]);
  let [title, setTitle] = useState("To Do List");

  useEffect(() => {
    if (localStorage.length > 0) {
      setTodos(JSON.parse(localStorage.getItem("todos")))
    }
  }, []);

  return (
    <div className="container">
      <Header
        title={title}
        setTitle={setTitle}
        todoText={todoText}
        setTodoText={setTodoText}
        todos={todos}
        setTodos={setTodos}
      />
      <hr />
      <ToDoList todos={todos} setTodos={setTodos} />
      <p className="delete-btn" onClick={() => { deleteAll(setTodos) }}> <span ><i className="fas fa-trash-alt"></i></span> <span>Delete All</span></p>
    </div>
  )
}

export default App;
