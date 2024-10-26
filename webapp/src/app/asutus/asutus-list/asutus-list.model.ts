import {AsutusShortDto, QueryResponse} from '../../shared/model/asutus.model';
import {DataProvider} from '../../shared/table/table.model';
import {AsutusClient} from '../../../services/api/asutus.client';
import {PagedQuery} from '../../shared/model/query.model';
import {Observable} from 'rxjs';

export class AsutusDataProvider extends DataProvider<AsutusShortDto> {
  constructor(private asutusService: AsutusClient) {
    super();
  }

  getData(pagination: PagedQuery): Observable<QueryResponse<AsutusShortDto>> {
    return this.asutusService.search(pagination);
  }
}

