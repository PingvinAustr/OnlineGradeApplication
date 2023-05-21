import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './Components/App/App';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Login from './Components/Login/Login';
import MainMenu from './Components/MainMenu/MainMenu';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';
import {AuthProvider} from "./Auth/AuthContext";


const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
    <AuthProvider>
      <Router>
          <Routes>
              <Route path="/" element={<Login />} />
              <Route path="/main-menu" element={<MainMenu />} />
          </Routes>
      </Router>
      <ToastContainer />
    </AuthProvider>
);
