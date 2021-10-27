import React, { useState } from 'react';
import { updateText, showInfo, updateStatus } from '../CommonFunctions/CommonFunctions';


const Pending = ({ todos, setTodos }) => {

    const [show, setShow] = useState(true)

    const pendingTodos = todos.filter(item => item.status === "pending")

    return (
        <div>
            <h2 className="title-pending" onClick={() => { setShow(!show) }} > Pending  {show ? <span className="hide">hide</span> : <span className="show">show</span>} </h2>
            {show &&
                <ul className="list">

                    {

                        pendingTodos.map((item, index) => (
                            <li key={item + index}><div className="li-text"> {item.text}</div>
                                <div className="li-buttons">
                                    <button className="btn btn-success done-button" onClick={() => { updateStatus(item, todos, setTodos, "done") }}><i className="fas fa-check"></i></button>
                                    <button className="cancel-button btn btn-danger" onClick={() => { updateStatus(item, todos, setTodos, "cancelled") }}><i className="fas fa-times"></i></button>
                                    <button className="cancel-button btn btn-secondary" onClick={() => { updateText(item, todos, setTodos) }}><i className="fas fa-pen"></i></button>
                                    <button className="info-button btn btn-info" onClick={() => { showInfo(item, todos, setTodos) }}><i className="fas fa-info"></i></button>
                                </div>
                            </li>
                        ))
                    }

                </ul>
            }
        </div>
    )
}


export default Pending
