import React, { useState } from 'react';
import { TextField, Checkbox, Button, Grid, Paper } from '@mui/material';
import TodoEntity from '../../models/TodoEntity';

interface TodoFormProps {
    initialValues: TodoEntity;
    onSubmit: (updatedTodo: TodoEntity) => void;
}

const TodoComponent: React.FC<TodoFormProps> = ({ initialValues, onSubmit }) => {
    const [title, setTitle] = useState(initialValues.title || '');
    const [description, setDescription] = useState(initialValues.description || '');
    const [completed, setCompleted] = useState(initialValues.isCompleted || false);

    const handleSave = () => {
        const updatedTodo: TodoEntity = {
            ...initialValues,
            title: title,
            description: description,
            isCompleted: completed,
        };

        onSubmit(updatedTodo);
    };

    return (
        <Paper elevation={3} style={{ padding: 16 }}>
            <Grid container spacing={2}>
                <Grid item xs={12}>
                    <TextField
                        label="Başlık"
                        fullWidth
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                    />
                </Grid>
                <Grid item xs={12}>
                    <TextField
                        label="Açıklama"
                        fullWidth
                        multiline
                        rows={4}
                        value={description}
                        onChange={(e) => setDescription(e.target.value)}
                    />
                </Grid>
                <Grid item xs={12}>
                    <Checkbox
                        checked={completed}
                        onChange={(e) => setCompleted(e.target.checked)}
                    />
                    Tamamlandı
                </Grid>
                <Grid item xs={12}>
                    <Button onClick={handleSave} variant="contained" color="primary">
                        Kaydet
                    </Button>
                </Grid>
            </Grid>
        </Paper>
    );
};

export default TodoComponent;
