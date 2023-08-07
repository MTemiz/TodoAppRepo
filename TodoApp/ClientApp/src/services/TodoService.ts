import axios from 'axios';
import TodoEntity from '../models/TodoEntity';

const API_URL = 'http://localhost:5081/todo';

const getTodos = async (): Promise<TodoEntity[]> => {
  const response = await axios.get<TodoEntity[]>(API_URL);
  return response.data;
};

const deleteTodo = async (id: number) => {
  try {
    debugger;
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error('Todo silinirken hata oluştu:', error);
    throw error;
  }
};

const getTodoById = async (id: number): Promise<TodoEntity> => {
  try {
    const response = await axios.get<TodoEntity>(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    console.error(`ID ${id} ile todo verisi çekilirken hata oluştu:`, error);
    throw error;
  }
};

const updateTodo = async (id: number, updatedTodo: TodoEntity) => {
  try {
    const response = await axios.put(`${API_URL}/${id}`, updatedTodo);
    return response.data;
  } catch (error) {
    console.error(`ID ${id} ile todo güncellenirken hata oluştu:`, error);
    throw error;
  }
};

const createTodo = async (todo: TodoEntity) => {
  try {
    const response = await axios.post(`${API_URL}`, todo);
    return response.data;
  } catch (error) {
    throw error;
  }
};

const todoService = {
  getTodos,
  deleteTodo,
  getTodoById,
  updateTodo,
  createTodo
};

export default todoService;