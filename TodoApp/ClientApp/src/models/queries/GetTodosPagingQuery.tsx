import PagingQuery from './PagingQuery';

export default interface GetTodosPagingQuery extends PagingQuery {
    title: string;
    description: string;
    isCompleted?: boolean;
  }