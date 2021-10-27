import React, { useState } from 'react'
import { updateText, showInfo, updateStatus } from '../CommonFunctions/CommonFunctions';

const Cancelled = ({ todos, setTodos }) => {

    const [show, setShow] = useState(true)
    const cancelledTodos = todos.filter(item => item.status === "cancelled")

    return (
        <div>
            <h2 className="title-cancelled" onClick={() => { setShow(!show) }} > Cancelled {show ? <span className="hide">hide</span> : <span className="show">show</span>} </h2>

            {show &&
                <ul className="list">
                    {
                        cancelledTodos.map((item, index) => (
                            <li key={item + index}><div className="li-text">{item.text}</div>
                                <div className="li-buttons">
                                    <button className="cancel-button btn btn-success" onClick={() => { updateStatus(item, todos, setTodos, "done") }}><i className="fas fa-check"></i></button>
                                    <button className="btn btn-warning pending-button text-white" onClick={() => { updateStatus(item, todos, setTodos, "pending") }}><i className="fas fa-hourglass-half"></i></button>
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

export default Cancelled
