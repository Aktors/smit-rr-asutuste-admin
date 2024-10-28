import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import {InformationSystemDto} from '../app/shared/model/common.model';
import {SystemClient} from './api/system.client';

@Injectable({
  providedIn: 'root'
})
export class InformationSystemsStore {
  private informationSystemsSubject = new BehaviorSubject<InformationSystemDto[]>([]);
  informationSystems$: Observable<InformationSystemDto[]> = this.informationSystemsSubject.asObservable();

  constructor(private systemClient: SystemClient) {
    this.loadInformationSystems();
  }

  private loadInformationSystems(): void {
    this.systemClient.getInformationSystems()
      .pipe(
        tap((data) => this.informationSystemsSubject.next(data))
      )
      .subscribe();
  }

  getInformationSystems(): InformationSystemDto[] {
    return this.informationSystemsSubject.getValue();
  }
}
