import {Component, OnInit} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {AsutusService} from '../../../services/asutus.service';
import {AsutusDataProvider} from './asutus-list.model';

@Component({
  selector: 'asutus-list',
  templateUrl: './asutus-list.component.html',
  styleUrl: './asutus-list.component.scss'
})
export class AsutusListComponent implements OnInit{
  isDataLoading$ = new BehaviorSubject<boolean>(false);
  asutusDataProvider!: AsutusDataProvider;

  constructor(private asutusService: AsutusService) {  }

  ngOnInit(): void {
    this.asutusDataProvider = new AsutusDataProvider(this.asutusService);
  }
}
