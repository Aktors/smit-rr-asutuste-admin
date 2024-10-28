import {Component, OnInit} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {ReplicationClient} from '../../../../services/api/replication.client';
import {ReplicationLog} from '../../../shared/model/replication.model';
import {ReplicationLogDataProvider} from './replication-log.model';

@Component({
  selector: 'app-replication-log',
  templateUrl: './replication-log.component.html',
  styleUrls: ['./replication-log.component.scss'],
})
export class ReplicationLogComponent implements OnInit{
  items: ReplicationLog[] = [];
  isDataLoading$ = new BehaviorSubject<boolean>(false);
  logDataProvider!: ReplicationLogDataProvider;

  constructor(private replicationService: ReplicationClient) {  }

  ngOnInit(): void {
    this.logDataProvider = new ReplicationLogDataProvider(this.replicationService);
  }

  refreshTable(): void {
    this.logDataProvider.filter$.next([])
  }
}
