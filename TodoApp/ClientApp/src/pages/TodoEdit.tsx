import { useEffect, useState } from 'react';
import todoService from '../services/TodoService';
import TodoEntity from '../models/entities/TodoEntity';
import { useParams, useNavigate } from 'react-router-dom';
import TodoComponent from '../components/ui/TodoComponent';

const TodoEdit = () => {
    debugger;
    const { id } = useParams();
    const numericId = Number(id);
    const navigate = useNavigate();

    const [todo, setTodo] = useState<TodoEntity | null>(null);

    useEffect(() => {
        const fetchTodo = async () => {
            try {
                const fetchedTodo = await todoService.getTodoById(numericId);
                setTodo(fetchedTodo);
            } catch (error) {
                console.error('Todo verisi çekilirken hata oluştu:', error);
            }
        };
        fetchTodo();
    }, [id]);

    const handleSave = async (updatedTodo: TodoEntity) => {
        await todoService.updateTodo(numericId, updatedTodo);
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