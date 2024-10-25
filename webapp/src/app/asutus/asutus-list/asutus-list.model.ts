import {AsutusShortDto, QueryResponse} from '../../shared/model/asutus.model';
import {DataProvider} from '../../shared/table/table.model';
import {AsutusService} from '../../../services/asutus.service';
import {PagedQuery} from '../../shared/model/query.model';
import {Observable} from 'rxjs';

export class AsutusDataProvider extends DataProvider<AsutusShortDto> {
  constructor(private asutusService: AsutusService) {
    super();
  }

  getData(pagination: PagedQuery): Observable<QueryResponse<AsutusShortDto>> {
    return this.asutusService.search(pagination);
  }
}

