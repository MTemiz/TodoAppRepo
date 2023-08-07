import React, { useEffect, useState } from 'react';
import todoService from '../services/TodoService';
import TodoEntity from '../models/TodoEntity';
import { useParams, useNavigate } from 'react-router-dom';
import { TextField, Checkbox, Button, Grid, Paper } from '@mui/material';
import TodoComponent from '../components/ui/TodoComponent';

const TodoEdit = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [todo, setTodo] = useState(null);

    useEffect(() => {
        const fetchTodo = async () => {
            try {

                const fetchedTodo = await todoService.getTodoById(id);

                setTodo(fetchedTodo);
            } catch (error) {
                console.error('Todo verisi çekilirken hata oluştu:', error);
            }
        };
        fetchTodo();
    }, [id]);

    const handleSave = async (updatedTodo: TodoEntity) => {
        await todoService.updateTodo(id, updatedTodo);
        navigate('/list');
      };

    if (!todo) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <h2>Todo Düzenle: {todo.title}</h2>
            <TodoComponent initialValues={todo} onSubmit={handleSave} />
        </div>
    );
};

export default TodoEdit;