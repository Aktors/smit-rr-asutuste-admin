import {Component} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {ReplicationService} from '../../../../services/replication.service';
import {ReplicationLog} from '../../../shared/model/replication.model';

@Component({
  selector: 'app-replication-log',
  templateUrl: './replication-log.component.html',
})
export class ReplicationLogComponent {
  items: ReplicationLog[] = [];
  isDataLoading$ = new BehaviorSubject<boolean>(false);

  constructor(private replicationService: ReplicationService) {
  }

  fetchItems(): void {
    this.isDataLoading$.next(true);
    this.replicationService.getLog().subscribe({
      next: (response) => {
        this.items = response.result;
        this.isDataLoading$.next(false);
      },
      error: err => {
        this.isDataLoading$.next(false);
      }
    });
  }
}
