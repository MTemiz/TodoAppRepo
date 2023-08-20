import React, { useEffect, useState } from 'react';
import todoService from '../services/TodoService';
import TodoEntity from '../models/entities/TodoEntity';
import { Checkbox, Button, Grid, Paper, TextField, Box, FormControl } from '@mui/material';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import IconButton from '@mui/material/IconButton';
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import DeleteConfirmationDialog from '../components/confirmation/DeleteConfirmationDialog';
import { useNavigate } from 'react-router-dom';
import GetTodosPagingQuery from '../models/queries/GetTodosPagingQuery';
import CustomSelect from '../components/controls/CustomSelect';
import CstEvetHayir from "../models/enums/CstEvetHayir";
import { GridPaginationModel } from '@mui/x-data-grid';

const TodoList = () => {
  const navigate = useNavigate();
  const [todos, setTodos] = useState<TodoEntity[]>([]);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [selectedTodoId, setSelectedTodoId] = useState(null);

  const [totalCount, setTotalCount] = useState(0);

  const [paginationModel, setPaginationModel] = useState({
    pageSize: 5,
    page: 0
  });

  const [searchCriteria, setSearchCriteria] = useState<GetTodosPagingQuery>({
    title: '',
    description: '',
    isCompleted: false,
    pageNumber: 0,
    pageSize: 5
  });

  useEffect(() => {
    setSearchCriteria((prevSearchCriteria) => ({
      ...prevSearchCriteria,
      pageNumber: paginationModel.page,
      pageSize: paginationModel.pageSize
    }));
  }, [paginationModel.page, paginationModel.pageSize]);

  useEffect(() => {
    search();
  }, [searchCriteria.pageNumber, searchCriteria.pageSize]);

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = event.target;
    setSearchCriteria((prevCriteria) => ({
      ...prevCriteria,
      [name]: value,
    }));
  };

  const handleConfirmDelete = async () => {
    if (selectedTodoId) {
      await todoService.deleteTodo(selectedTodoId);
      search();
    }
    setSelectedTodoId(null);
    setDialogOpen(false);
  };

  const handleEdit = (id: number) => {
    navigate(`/edit/${id}`);
  };

  const handleCreateTodo = () => {
    navigate('/create');
  };

  const handleSearch = async () => {
    setPaginationModel((prevModel) => ({
      ...prevModel,
      page: 0
    }));

    search();
  }

  const search = async () => {
    const response = await todoService.gedPagedTodos(searchCriteria);
    setTodos(response.result.collections);
    setTotalCount(response.result.totalCount);
  }

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
          <IconButton color="primary" onClick={() => {
            handleEdit(params.row.id);
          }}>
            <EditIcon />
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
    <Box sx={{ height: 450, width: 'auto', mt: 1, ml: 1, mr: 2 }}>
      <Paper style={{ padding: 5, height: 120 }}>
        <h2>Todo İşlemleri</h2>
        <Grid container spacing={2}>
          <Grid item xs={4}>
            <TextField
              label="Title"
              size="small"
              fullWidth
              name='title'
              value={searchCriteria.title}
              onChange={handleInputChange}>
            </TextField>
          </Grid>

          <Grid item xs={4}>
            <Box>
              <TextField
                label="Description"
                size="small"
                fullWidth
                margin="none"
                name='description'
                value={searchCriteria.description}
                onChange={handleInputChange}>
              </TextField>
            </Box>
          </Grid>

          <Grid item xs={2}>
            <FormControl variant="outlined" fullWidth>
              <CustomSelect options={[
                { id: CstEvetHayir.Evet, value: 'Evet' },
                { id: CstEvetHayir.Hayir, value: 'Hayır' },
              ]}
                onSelect={(selectedValue: number) =>
                  setSearchCriteria((prevCriteria) => ({
                    ...prevCriteria,
                    isCompleted: selectedValue === CstEvetHayir.Evet,
                  }))
                }
                labelName="Is Completed"
              />
            </FormControl>
          </Grid>
          <Grid item xs={2}>
            <Box display="flex" justifyContent="flex-end">
              <Button variant="contained" size='small' sx={{ mb: 1, mt: 1 }} color="primary" onClick={handleSearch}>Ara</Button>
            </Box >
          </Grid>
        </Grid>
      </Paper>

      <Box display="flex" justifyContent="flex-end">
        <Button variant="contained" size='small' sx={{ mb: 1, mt: 1 }} color="primary" onClick={handleCreateTodo}>Ekle</Button>
      </Box>
      <DataGrid
        rowHeight={25}
        columnHeaderHeight={25}
        rows={todos}
        columns={columns}
        rowCount={totalCount}
        pageSizeOptions={[5, 10, 20]}
        paginationModel={paginationModel}
        paginationMode="server"
        onPaginationModelChange={(model: GridPaginationModel) => setPaginationModel((prevModel) => ({
          ...prevModel,
          page: model.page,
          pageSize: model.pageSize
        }))}
      />

      <DeleteConfirmationDialog
        open={dialogOpen}
        onClose={() => setDialogOpen(false)}
        onConfirm={handleConfirmDelete} />
    </Box>
  );
};

export default TodoList;