import {Component, OnInit} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {ReplicationService} from '../../../../services/replication.service';
import {ReplicationLog} from '../../../shared/model/replication.model';
import {ReplicationLogDataProvider} from './replication-log.model';
import {AsutusDataProvider} from '../../asutus-list/asutus-list.model';

@Component({
  selector: 'app-replication-log',
  templateUrl: './replication-log.component.html',
})
export class ReplicationLogComponent implements OnInit{
  items: ReplicationLog[] = [];
  isDataLoading$ = new BehaviorSubject<boolean>(false);
  logDataProvider!: ReplicationLogDataProvider;

  constructor(private replicationService: ReplicationService) {  }

  ngOnInit(): void {
    this.logDataProvider = new ReplicationLogDataProvider(this.replicationService);
  }
}
