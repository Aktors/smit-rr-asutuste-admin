import {Injectable} from '@angular/core';
import {BehaviorSubject, Observable} from 'rxjs';

@Injectable()
export class AsutusFormStore {
  activeAsutusCode = new BehaviorSubject<string | null>(null);
  asutusCode$: Observable<string | null> = this.activeAsutusCode.asObservable();

  setData(data: string): void {
    this.activeAsutusCode.next(data);
  }

  getData(): string | null {
    return this.activeAsutusCode.value;
  }
}
