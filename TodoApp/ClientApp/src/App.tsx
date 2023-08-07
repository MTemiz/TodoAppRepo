import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import logo from './logo.svg';
import './App.css';
import TodoList from './pages/TodoList';
import TodoEdit from './pages/TodoEdit';
import TodoCreate from './pages/TodoCreate';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/list" element={<TodoList />} />
        <Route path="/edit/:id" element={<TodoEdit/>} />
        <Route path="/create" element={<TodoCreate/>} />
      </Routes>
    </BrowserRouter>

  );
}

export default App;
