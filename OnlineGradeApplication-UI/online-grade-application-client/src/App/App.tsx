import React from 'react';
import logo from '../logo.svg';
import './App.css';
import { Button } from 'antd';
import Login from '../Components/Login/Login';
import 'antd/dist/reset.css';

function App() {
  return (
    <div className="App">
      <Login/>
    </div>
  );
}

export default App;
