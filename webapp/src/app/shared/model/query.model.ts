export interface PagedQuery {
  page?: number,
  pageSize?: number,
  sortBy?: string,
  sortOrder: "desc" | "asc" | "" | undefined,
}

export interface QueryResultDto {
  result: any[],
  page: number,
  totalPages: number,
  pageSize: number,
  total: number
}
