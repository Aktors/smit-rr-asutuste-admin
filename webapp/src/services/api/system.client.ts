import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {ClassifierDto, InformationSystemDto} from '../../app/shared/model/common.model';
import {environment} from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SystemClient {
  private baseUrl: string;
  constructor(private http: HttpClient) {
    this.baseUrl = environment.asutusApiUrl;
  }

  getClassifier(group: string): Observable<ClassifierDto[]> {
    let url_ = this.baseUrl + "/api/v1/system/classifier/{group}/list";
    url_ = url_.replace("{group}", encodeURIComponent("" + group));
    url_ = url_.replace(/[?&]$/, "");

    return this.http.get<ClassifierDto[]>(url_);
  }

  getInformationSystems(): Observable<InformationSystemDto[]> {
    let url_ = this.baseUrl + "/api/v1/system/information-systems/list";
    url_ = url_.replace(/[?&]$/, "");

    return this.http.get<InformationSystemDto[]>(url_);
  }
}
