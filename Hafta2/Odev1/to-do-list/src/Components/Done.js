import React, { useState } from 'react'
import { updateText, showInfo, updateStatus } from '../CommonFunctions/CommonFunctions';


const Done = ({ todos, setTodos }) => {

    const [show, setShow] = useState(true)

    const doneTodos = todos.filter(item => item.status === "done")

    return (
        <div>
            <h2 className="title-done" onClick={() => { setShow(!show) }} > Done {show ? <span className="hide">hide</span> : <span className="show">show</span>} </h2>

            {show &&
                <ul className="list">

                    {
                        doneTodos.map((item, index) => (
                            <li key={item + index}><div className="li-text">{item.text}</div>
                                <div className="li-buttons">
                                    <button className="btn btn-warning text-white" onClick={() => { updateStatus(item, todos, setTodos, "pending") }}><i className="fas fa-hourglass-half"></i></button>
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


export default Done
