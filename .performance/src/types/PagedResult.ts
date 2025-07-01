export interface PagedResult<T> {
    items: T[];
    totalCount: number;
    pageSize: number;
    page: number;
    totalPages: number;
}
