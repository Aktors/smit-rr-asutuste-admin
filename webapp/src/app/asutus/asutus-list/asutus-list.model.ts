import {AsutusShortDto, QueryResponse} from '../../shared/model/asutus.model';
import {DataProvider} from '../../shared/table/table.model';
import {AsutusClient} from '../../../services/api/asutus.client';
import {PagedQuery, QueryCriterionDto} from '../../shared/model/query.model';
import {Observable} from 'rxjs';

export class AsutusDataProvider extends DataProvider<AsutusShortDto> {
  constructor(private asutusService: AsutusClient) {
    super();
  }

  updateSearchCriteria(criteria: QueryCriterionDto[]): void {
    this.filter$.next(criteria);
  }

  getData(pagination: PagedQuery): Observable<QueryResponse<AsutusShortDto>> {
    return this.asutusService.search(pagination);
  }
}
