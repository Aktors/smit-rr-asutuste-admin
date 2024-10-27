import {Component, OnInit} from '@angular/core';
import {BehaviorSubject} from 'rxjs';
import {AsutusClient} from '../../../services/api/asutus.client';
import {AsutusDataProvider} from './asutus-list.model';
import {Router} from '@angular/router';
import {AsutusShortDto} from '../../shared/model/asutus.model';
import {SearchCriteria} from './asutuste-search-form/asutuste-search-form.model';

@Component({
  selector: 'asutus-list',
  templateUrl: './asutus-list.component.html',
  styleUrl: './asutus-list.component.scss'
})
export class AsutusListComponent implements OnInit{
  isDataLoading$ = new BehaviorSubject<boolean>(false);
  asutusDataProvider!: AsutusDataProvider;

  currentSearchCriteria: SearchCriteria | null = null;

  constructor(private asutusService: AsutusClient, private router: Router) {}

  ngOnInit(): void {
    this.asutusDataProvider = new AsutusDataProvider(this.asutusService, this.currentSearchCriteria);
  }

  onSearch(criteria: SearchCriteria): void {
    this.currentSearchCriteria = criteria;
    this.asutusDataProvider.updateSearchCriteria(criteria);
  }

  editItem(element: AsutusShortDto): void {
    if (element?.code) {
      this.router.navigate(['/asutused/manage', element.code, 'edit']);
    }
  }
}
