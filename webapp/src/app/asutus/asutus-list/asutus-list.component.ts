import {Component} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {AsutusService} from '../../../services/asutus.service';
import {AsutusShortDto} from '../../shared/model/asutus.model';

@Component({
  selector: 'asutus-list',
  templateUrl: './asutus-list.component.html',
  styleUrl: './asutus-list.component.scss'
})
export class AsutusListComponent {
  items: AsutusShortDto[] = [];
  isDataLoading$ = new BehaviorSubject<boolean>(false);

  constructor(private asutusService: AsutusService) {
  }

  fetchItems(): void {
    this.isDataLoading$.next(true);
    this.asutusService.search().subscribe({
      next: (response) => {
        this.items = response.result;
        console.log(this.items);
        this.isDataLoading$.next(false);
      },
      error: err => {
        this.isDataLoading$.next(false);
      }
    });
  }
}
