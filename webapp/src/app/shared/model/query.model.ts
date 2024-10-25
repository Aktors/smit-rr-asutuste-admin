import {ReplicationLog} from './replication.model';

export interface PagedQuery {
  page?: number,
  pageSize?: number,
  sortBy?: string,
  srtOrder: "desc" | "asc" | "" | undefined,
}

export interface QueryResultDto {
  result: any[],
  page: number,
  totalPages: number,
  pageSize: number,
  total: number
}
