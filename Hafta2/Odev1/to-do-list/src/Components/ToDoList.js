import React from 'react'
import Pending from "./Pending";
import Done from "./Done";
import Cancelled from "./Cancelled";

const ToDoList = ({ todos, setTodos }) => {

    return (
        <div className="todo-body">
            <Pending todos={todos} setTodos={setTodos} />
            <hr />
            <Done todos={todos} setTodos={setTodos} />
            <hr />
            <Cancelled todos={todos} setTodos={setTodos} />
        </div>
    )
}

export default ToDoList
