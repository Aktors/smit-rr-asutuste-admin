import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AsutusDto, AsutusShortDto, AsutusteQuery, QueryResponse} from '../../app/shared/model/asutus.model';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AsutusClient {
  private baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.asutusApiUrl;
  }

  search(query: AsutusteQuery): Observable<QueryResponse<AsutusShortDto>> {
    let url_ = this.baseUrl + "/api/v1/asutus/list?";

    if (query.code)
      url_ += "code=" + encodeURIComponent("" + query.code) + "&";
    if (query.name)
      url_ += "name=" + encodeURIComponent("" + query.code) + "&";
    if (query.startDate)
      url_ += "startDate=" + encodeURIComponent(query.startDate ? "" + query.startDate.toISOString() : "") + "&";
    if (query.endDate !== undefined)
      url_ += "endDate=" + encodeURIComponent(query.endDate ? "" + query.endDate.toISOString() : "") + "&";
    if (query.page)
      url_ += "page=" + encodeURIComponent("" + query.page) + "&";
    if (query.pageSize)
      url_ += "pageSize=" + encodeURIComponent("" + query.pageSize) + "&";
    if (query.sortBy)
      url_ += "sortBy=" + encodeURIComponent("" + query.sortBy) + "&";
    if (query.sortOrder)
      url_ += "sortOrder=" + encodeURIComponent("" + query.sortOrder) + "&";
    url_ = url_.replace(/[?&]$/, "");

    return this.http.get<QueryResponse<AsutusShortDto>>(url_);
  }

  getByCode(code: string): Observable<AsutusDto> {
    let url_ = this.baseUrl + "/api/v1/asutus/{code}";
    url_ = url_.replace("{code}", encodeURIComponent("" + code));
    url_ = url_.replace(/[?&]$/, "");

    return this.http.get<AsutusDto>(url_);
  }

  update(code: string, body: AsutusDto): Observable<void> {
    let url_ = this.baseUrl + "/api/v1/asutus/{code}";
    url_ = url_.replace("{code}", encodeURIComponent("" + code));
    url_ = url_.replace(/[?&]$/, "");
    return this.http.put<void>(url_,body);
  }
}
