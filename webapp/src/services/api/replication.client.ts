import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ReplicationLog, ReplicationLogQuery} from '../../app/shared/model/replication.model';
import {QueryResponse} from '../../app/shared/model/asutus.model';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ReplicationClient {
  private baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = environment.asutusApiUrl;
  }
  getLog(query: ReplicationLogQuery): Observable<QueryResponse<ReplicationLog>> {
    let url_ = this.baseUrl + "/api/v1/replication/log?";

    if (query.page)
      url_ += "page=" + encodeURIComponent("" + query.page) + "&";
    if (query.pageSize)
      url_ += "pageSize=" + encodeURIComponent("" + query.pageSize) + "&";
    if (query.sortBy)
      url_ += "sortBy=" + encodeURIComponent("" + query.sortBy) + "&";
    if (query.sortOrder)
      url_ += "sortOrder=" + encodeURIComponent("" + query.sortOrder) + "&";
    url_ = url_.replace(/[?&]$/, "");

    return this.http.get<QueryResponse<ReplicationLog>>(url_);
  }

  publish(code: string, body: ReplicationLog[]): Observable<void> {
    let url_ = this.baseUrl + "/api/v1/replication/publish/{code}";
    url_ = url_.replace("{code}", encodeURIComponent("" + code));
    url_ = url_.replace(/[?&]$/, "");

    return this.http.post<void>(url_,body);
  }
}
