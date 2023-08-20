export default interface TodoEntity {
  id: number;
  title: string;
  description: string;
  isCompleted?: boolean;
}

export default interface GetTodosQuery {
  title: string;
  description: string;
  isCompleted?: boolean;
}