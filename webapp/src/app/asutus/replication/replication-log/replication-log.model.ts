import {DataProvider} from '../../../shared/table/table.model';
import {ReplicationLog} from '../../../shared/model/replication.model';
import {ReplicationClient} from '../../../../services/api/replication.client';
import {PagedQuery} from '../../../shared/model/query.model';
import {Observable} from 'rxjs';
import {QueryResponse} from '../../../shared/model/asutus.model';

export class ReplicationLogDataProvider extends DataProvider<ReplicationLog> {
  constructor(private replicationService: ReplicationClient) {
    super();
  }

  getData(pagination: PagedQuery): Observable<QueryResponse<ReplicationLog>> {
    return this.replicationService.getLog(pagination);
  }
}
