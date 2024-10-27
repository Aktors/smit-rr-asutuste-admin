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

  constructor(private systemClient: SystemClient) {
    // Initialize the store by fetching and caching language values
    this.loadLanguages();
  }

  // Method to load language values from the API only once
  private loadLanguages(): void {
    this.systemClient.getClassifier('Language')
      .pipe(
        tap((data) => this.langSubject.next(data)) // Populate lang with API data
      )
      .subscribe();
  }

  // Method to get the cached language values directly
  getLang(): ClassifierDto[] {
    return this.langSubject.getValue();
  }
}
