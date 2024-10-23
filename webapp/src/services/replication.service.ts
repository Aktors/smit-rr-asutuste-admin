import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {ReplicationLogResponse} from '../app/shared/model/replication.model';



@Injectable({
  providedIn: 'root'
})
export class ReplicationService {
  //TODO: make it configurable
  private apiUrl = 'http://localhost:8080/replication/log';
  constructor(private http: HttpClient) {}

  getLog(): Observable<ReplicationLogResponse> {
    return this.http.get<ReplicationLogResponse>(this.apiUrl);
  }
}
