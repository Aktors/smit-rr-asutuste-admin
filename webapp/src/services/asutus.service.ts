import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AsutusteQueryResponse} from '../app/shared/model/asutus.model';

@Injectable({
  providedIn: 'root'
})
export class AsutusService {
  //TODO: make it configurable
  private apiUrl = 'http://localhost:8080/asutus/';
  constructor(private http: HttpClient) {}

  search(): Observable<AsutusteQueryResponse> {
    return this.http.get<AsutusteQueryResponse>(this.apiUrl+'list');
  }
}
