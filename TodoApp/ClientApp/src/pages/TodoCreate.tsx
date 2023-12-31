import React, { useState } from 'react';
import { TextField, Checkbox, Button, Grid, Paper } from '@mui/material';
import TodoEntity from '../models/entities/TodoEntity';
import { useNavigate } from 'react-router-dom';
import todoService from '../services/TodoService';
import TodoComponent from '../components/ui/TodoComponent';

const TodoCreate = () => {
    const navigate = useNavigate();

    const emptyTodo: TodoEntity = {
        id: null,
        title: '',
        description: '',
        isCompleted: false,
      };

    const handleSave = async (newTodo: TodoEntity) => {
        await todoService.createTodo(newTodo);
        navigate('/list');
    };

    return (
        <div>
            <h2>
                Yeni Todo Oluştur
            </h2>
            <TodoComponent initialValues={emptyTodo} onSubmit={handleSave} />
        </div>

    );
};

export default TodoCreate;






