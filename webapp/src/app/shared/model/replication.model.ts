import {PagedQuery} from './query.model';

export interface  ReplicationLogQuery extends PagedQuery {

}

export interface ReplicationLog {
  referenceId: string,
  caption: number,
  sentDate?: string,
  content?: string
}

export interface ReplicationSystemDto {
  code: string,
  environments: string[],
}
