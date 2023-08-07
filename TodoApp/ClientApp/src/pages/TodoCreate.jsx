import React, { useState } from 'react';
import { TextField, Checkbox, Button, Grid, Paper } from '@mui/material';
import TodoEntity from '../models/TodoEntity';
import { useNavigate } from 'react-router-dom';
import todoService from '../services/TodoService';
import TodoComponent from '../components/ui/TodoComponent';

const TodoCreate = () => {
    const navigate = useNavigate();

    const handleSave = async (newTodo: TodoEntity) => {
        await todoService.createTodo(newTodo);
        navigate('/list');
    };

    return (
        <div>
            <h2>
                Yeni Todo Oluştur
            </h2>
            <TodoComponent initialValues={{}} onSubmit={handleSave} />
        </div>

    );
};

export default TodoCreate;






