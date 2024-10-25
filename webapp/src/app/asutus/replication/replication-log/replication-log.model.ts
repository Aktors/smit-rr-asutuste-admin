import {DataProvider} from '../../../shared/table/table.model';
import {ReplicationLog} from '../../../shared/model/replication.model';
import {ReplicationService} from '../../../../services/replication.service';
import {PagedQuery} from '../../../shared/model/query.model';
import {Observable} from 'rxjs';
import {QueryResponse} from '../../../shared/model/asutus.model';

export class ReplicationLogDataProvider extends DataProvider<ReplicationLog> {
  constructor(private replicationService: ReplicationService) {
    super();
  }

  getData(pagination: PagedQuery): Observable<QueryResponse<ReplicationLog>> {
    return this.replicationService.getLog(pagination);
  }
}
