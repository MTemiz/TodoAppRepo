export default interface TodoEntity {
  id: number | null;
  title: string;
  description: string;
  isCompleted?: boolean;
}

export default interface GetTodosQuery {
  title: string;
  description: string;
  isCompleted?: boolean;
}