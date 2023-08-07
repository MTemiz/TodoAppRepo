export default interface TodoEntity  {
  id: number;
  title: string;
  description: string;
  isCompleted?: boolean;
}