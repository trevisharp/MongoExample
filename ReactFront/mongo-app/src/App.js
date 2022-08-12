import logo from './logo.svg';
import './App.css';
import React, { useEffect, useState } from 'react';

import Message from './components/Message/Message';

function App() {
  const [messages, setMessages] = useState([])
  const [page, setPage] = useState(0)

  useEffect(() =>
  {
    setMessages([])
    let url = "https://localhost:7041/receive?page=" + page
    fetch(url, {
      method: "GET"
    })
    .then(response => response.json())
    .then(json => 
    {
      setMessages(json.messages)
    })
    .catch(error => console.log(error))

  }, [page])

  if (messages.length == 0)
  {
    return (<div className="App">
      <h1>Carregando...</h1>
    </div>)
  }
  return (
    <div className="App">
      <h1>{
        messages.map(x => (<Message 
          text={x.text} 
          messageid={x.id}
          author={x.name}></Message>))
        }</h1>
      <br/>
      <button onClick={() => setPage(page - 1)}>Previous</button>
      {page}
      <button onClick={() => setPage(page + 1)}>Next</button>
    </div>
  );
}

export default App;
