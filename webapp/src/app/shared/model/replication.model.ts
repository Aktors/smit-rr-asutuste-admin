﻿import {PagedQuery} from './query.model';

export interface  ReplicationLogQuery extends PagedQuery {

}

export interface ReplicationLogResponse {
  result: ReplicationLog[],
  page: number,
  totalPages: number,
  pageSize: number,
  total: number,
}

export interface ReplicationLog {
  referenceId: string,
  caption: number,
  sentDate: string,
  content: string
}

export interface ReplicationDto {
  code: string,
  environments: string[],
}