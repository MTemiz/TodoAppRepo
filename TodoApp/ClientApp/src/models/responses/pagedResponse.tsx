export default interface PagedResponse<T> {
    collections: T[];
    pageNumber: number;
    pageSize: number;
    totalCount: number;
}