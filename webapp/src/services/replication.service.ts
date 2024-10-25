import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ReplicationLog} from '../app/shared/model/replication.model';
import {PagedQuery} from '../app/shared/model/query.model';
import {QueryResponse} from '../app/shared/model/asutus.model';

@Injectable({
  providedIn: 'root'
})
export class ReplicationService {
  //TODO: make it configurable
  private apiUrl = 'http://localhost:8080/replication/log';
  constructor(private http: HttpClient) {}

  getLog(pagination: PagedQuery): Observable<QueryResponse<ReplicationLog>> {
    return this.http.get<QueryResponse<ReplicationLog>>(this.apiUrl);
  }
}
