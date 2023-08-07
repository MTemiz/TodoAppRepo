import React, { useEffect, useState } from 'react';
import todoService from '../services/TodoService';
import TodoEntity from '../models/TodoEntity';
import { Checkbox, Dialog, DialogActions, DialogContent, Button } from '@mui/material';
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
import Box from '@mui/material/Box';
import IconButton from '@mui/material/IconButton';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import DeleteConfirmationDialog from '../components/DeleteConfirmationDialog';
import { useNavigate } from 'react-router-dom';

const TodoList = () => {
  const navigate = useNavigate();

  const [todos, setTodos] = useState([]);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [selectedTodoId, setSelectedTodoId] = useState(null);

  const fetchTodos = async () => {
    try {
      const fetchedTodos = await todoService.getTodos();
      setTodos(fetchedTodos);
    } catch (error) {
      console.error('Todo verileri çekilirken hata oluştu:', error);
    }
  };

  useEffect(() => {
    fetchTodos();
  }, []);

  const handleConfirmDelete = async () => {
    if (selectedTodoId) {
      await todoService.deleteTodo(selectedTodoId);
      await fetchTodos();
    }
    setSelectedTodoId(null);
    setDialogOpen(false);
  };

  const handleEdit = (id) => {
    navigate(`/edit/${id}`);
  };

  const handleCreateTodo = () => {
    navigate('/create');
  };

  const columns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'title', headerName: 'Başlık', width: 250 },
    { field: 'description', headerName: 'Açıklama', width: 250 },
    {
      field: 'isCompleted',
      headerName: 'Tamamlandı',
      width: 120,
      renderCell: (params) => (
        <Checkbox disabled checked={params.value} />
      ),
    },
    {
      field: 'actions',
      headerName: 'İşlemler',
      width: 250,
      renderCell: (params) => (
        <Box>
          <IconButton color="primary">
            <EditIcon onClick={() => {
              handleEdit(params.row.id);
            }} />
          </IconButton>
          <IconButton
            color="secondary"
            onClick={() => {
              setSelectedTodoId(params.row.id);
              setDialogOpen(true);
            }}
          >
            <DeleteIcon />
          </IconButton>
        </Box>
      ),
    },
  ];

  return (
    <Box sx={{ height: 500, width: '100%' }}>
      <Box display="flex" justifyContent="flex-end" mb={2}>
        <Button variant="contained" color="primary" onClick={handleCreateTodo}>Ekle</Button>
      </Box>
      <DataGrid rows={todos} columns={columns} initialState={{
        pagination: {
          paginationModel: {
            pageSize: 5,
          },
        },
      }}
        pageSizeOptions={[5]} disableSelectionOnClick />
      <DeleteConfirmationDialog
        open={dialogOpen}
        onClose={() => setDialogOpen(false)}
        onConfirm={handleConfirmDelete} />
    </Box>
  );
};

// const columns: GridColDef[] = [
//   { field: 'id', headerName: 'ID', width: 90 },
//   {
//     field: 'firstName',
//     headerName: 'First name',
//     width: 150,
//     editable: true,
//   },
//   {
//     field: 'lastName',
//     headerName: 'Last name',
//     width: 150,
//     editable: true,
//   },
//   {
//     field: 'age',
//     headerName: 'Age',
//     type: 'number',
//     width: 110,
//     editable: true,
//   },
//   {
//     field: 'fullName',
//     headerName: 'Full name',
//     description: 'This column has a value getter and is not sortable.',
//     sortable: false,
//     width: 160,
//     valueGetter: (params: GridValueGetterParams) =>
//       `${params.row.firstName || ''} ${params.row.lastName || ''}`,
//   },
// ];

// const rows = [
//   { id: 1, lastName: 'Snow', firstName: 'Jon', age: 35 },
//   { id: 2, lastName: 'Lannister', firstName: 'Cersei', age: 42 },
//   { id: 3, lastName: 'Lannister', firstName: 'Jaime', age: 45 },
//   { id: 4, lastName: 'Stark', firstName: 'Arya', age: 16 },
//   { id: 5, lastName: 'Targaryen', firstName: 'Daenerys', age: null },
//   { id: 6, lastName: 'Melisandre', firstName: null, age: 150 },
//   { id: 7, lastName: 'Clifford', firstName: 'Ferrara', age: 44 },
//   { id: 8, lastName: 'Frances', firstName: 'Rossini', age: 36 },
//   { id: 9, lastName: 'Roxie', firstName: 'Harvey', age: 65 },
// ];

// return (
//   <Box sx={{ height: 400, width: '100%' }}>
//     <DataGrid
//       rows={rows}
//       columns={columns}
//       initialState={{
//         pagination: {
//           paginationModel: {
//             pageSize: 5,
//           },
//         },
//       }}
//       pageSizeOptions={[5]}
//       checkboxSelection
//       disableRowSelectionOnClick
//     />
//   </Box>
// );
// };
export default TodoList;