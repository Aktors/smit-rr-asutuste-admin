import {Component, OnInit} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {AsutusClient} from '../../../services/api/asutus.client';
import {AsutusDataProvider} from './asutus-list.model';
import {Router} from '@angular/router';
import {AsutusShortDto} from '../../shared/model/asutus.model';
import {AsutusSearchCriteria} from './asutuste-search-form/asutuste-search-form.model';

@Component({
  selector: 'asutus-list',
  templateUrl: './asutus-list.component.html',
  styleUrl: './asutus-list.component.scss'
})
export class AsutusListComponent implements OnInit{
  isDataLoading$ = new BehaviorSubject<boolean>(false);
  asutusDataProvider!: AsutusDataProvider;

  constructor(private asutusService: AsutusClient, private router: Router) {}

  ngOnInit(): void {
    this.asutusDataProvider = new AsutusDataProvider(this.asutusService);
  }

  onSearch(filter: AsutusSearchCriteria): void {
    var criteria = [];
    if(filter.codePart)
      criteria.push({ field: "code", value: filter.codePart });
    if(filter.namePart)
      criteria.push({ field: "name", value: filter.namePart });

    this.asutusDataProvider.updateSearchCriteria(criteria);
  }

  editItem(element: AsutusShortDto): void {
    if (element?.code) {
      this.router.navigate(['/asutused/manage', element.code, 'edit']);
    }
  }
}
