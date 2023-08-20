import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import logo from './logo.svg';
import './App.css';
import TodoList from './pages/TodoList';
import TodoEdit from './pages/TodoEdit';
import TodoCreate from './pages/TodoCreate';
import { LoadingProvider } from './components/loadingPanel/LoadingContext';
import LoadingPanel from './components/loadingPanel/LoadingPanel';
import AxiosInterceptor from './components/loadingPanel/AxiosInterceptor';

function App() {
  return (
    <LoadingProvider>
      <AxiosInterceptor />
      <LoadingPanel />
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<TodoList />} />
          <Route path="/list" element={<TodoList />} />
          <Route path="/edit/:id" element={<TodoEdit />} />
          <Route path="/create" element={<TodoCreate />} />
        </Routes>
      </BrowserRouter>
    </LoadingProvider>

  );
}

export default App;
