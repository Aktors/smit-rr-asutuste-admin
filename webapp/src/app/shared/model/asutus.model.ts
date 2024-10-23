import {PagedQuery} from './query.model';
import {ReplicationLog} from './replication.model';

export interface AsutusteQuery extends PagedQuery {
  code?: string,
  name?: string,
  startDate?: Date,
  endDate?: Date,
}

export interface AsutusteQueryResponse {
  result: AsutusShortDto[],
  page: number,
  totalPages: number,
  pageSize: number,
  total: number,
}

export interface AsutusShortDto {
  code: string,
  name: string,
  startDate: Date,
  endDate?: Date,
}

export interface Translation {
  code: string,
  text: string,
}

export interface AsutusDto extends AsutusShortDto{
  translations: Translation[];
}
