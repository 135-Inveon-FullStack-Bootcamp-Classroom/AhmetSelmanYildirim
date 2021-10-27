import { useState, useEffect } from 'react';
import './App.css';
import Header from "./Components/Header";
import ToDoList from "./Components/ToDoList";

// const getData = (todos, setTodos) => {
//   let keys = Object.keys(localStorage);
//   keys.forEach(item => {

//     let key = JSON.parse(localStorage.getItem(item))
//     let updatedAt = key.updatedAt ? key.updatedAt : "There is no update"

//     let getTodo = { text: key.text, status: key.status, createdAt: key.createdAt, updatedAt: updatedAt }

//     setTodos([...todos, getTodo])
//   })
// }

const deleteAll = (setTodos) => { localStorage.clear(); setTodos([]) }

function App() {

  const [todoText, setTodoText] = useState("");
  const [todos, setTodos] = useState([]);
  let [title, setTitle] = useState("To Do List");


  useEffect(() => {

    

    // getData(todos, setTodos)

    // let keys = Object.keys(localStorage);
    // keys.forEach(item => {

    //   let key = JSON.parse(localStorage.getItem(item))
    //   let updatedAt = key.updatedAt ? key.updatedAt : "There is no update"

    //   let receivedTodo = { text: key.text, status: key.status, createdAt: key.createdAt, updatedAt: updatedAt }

    //   setTodos([...todos, receivedTodo])
    // })

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
