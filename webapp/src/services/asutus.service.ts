import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AsutusShortDto, QueryResponse} from '../app/shared/model/asutus.model';
import {PagedQuery} from '../app/shared/model/query.model';

@Injectable({
  providedIn: 'root'
})
export class AsutusService {
  //TODO: make it configurable
  private apiUrl = 'http://localhost:8080/asutus/';
  constructor(private http: HttpClient) {}

  search(pagination: PagedQuery): Observable<QueryResponse<AsutusShortDto>> {
    return this.http.get<QueryResponse<AsutusShortDto>>(this.apiUrl+'list');
  }
}
