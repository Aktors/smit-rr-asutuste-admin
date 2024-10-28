import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import {ClassifierDto} from '../app/shared/model/common.model';
import {SystemClient} from './api/system.client';

@Injectable({
  providedIn: 'root',
})
export class ClassifierStore {
  // Holds the cached values for languages
  private langSubject = new BehaviorSubject<ClassifierDto[]>([]);
  lang$: Observable<ClassifierDto[]> = this.langSubject.asObservable();

  private instanceSubject = new BehaviorSubject<ClassifierDto[]>([]);
  instance$: Observable<ClassifierDto[]> = this.instanceSubject.asObservable();

  constructor(private systemClient: SystemClient) {
    this.loadLanguages();
    this.loadInstances();
  }

  private loadLanguages(): void {
    this.systemClient.getClassifier('Language')
      .pipe(
        tap((data) => this.langSubject.next(data))
      )
      .subscribe();
  }

  private loadInstances(): void {
    this.systemClient.getClassifier('Instance')
      .pipe(
        tap((data) => this.instanceSubject.next(data))
      )
      .subscribe();
  }

  getLang(): ClassifierDto[] {
    return this.langSubject.getValue();
  }

  getInstance(): ClassifierDto[] {
    return this.instanceSubject.getValue();
  }
}
