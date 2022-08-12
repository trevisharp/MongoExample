import React, { useEffect } from 'react';
import './Message.css';

function Message(props) {
  useEffect(() =>
  {
    let h3 = document.getElementById(props.messageid);
    h3.innerHTML = props.text;
  });
  return (<div className="Message" data-testid="Message">
    <h3 id={props.messageid}></h3>
    <h6>-{props.author}</h6>
  </div>)
}

export default Message;
