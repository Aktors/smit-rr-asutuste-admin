import {AsutusShortDto, QueryResponse} from '../../shared/model/asutus.model';
import {DataProvider} from '../../shared/table/table.model';
import {AsutusClient} from '../../../services/api/asutus.client';
import {PagedQuery} from '../../shared/model/query.model';
import {Observable} from 'rxjs';
import {SearchCriteria} from './asutuste-search-form/asutuste-search-form.model';

export class AsutusDataProvider extends DataProvider<AsutusShortDto> {
  private searchCriteria: SearchCriteria | null = null;

  constructor(private asutusService: AsutusClient, initialCriteria: SearchCriteria | null) {
    super();
    this.searchCriteria = initialCriteria;
  }

  updateSearchCriteria(criteria: SearchCriteria): void {
    this.searchCriteria = criteria;
    this.paginator?.firstPage();
  }

  getData(pagination: PagedQuery): Observable<QueryResponse<AsutusShortDto>> {
    const query = {
      ...pagination,
      code: this.searchCriteria?.codePart,
      name: this.searchCriteria?.namePart,
    };
    return this.asutusService.search(query);
  }
}

