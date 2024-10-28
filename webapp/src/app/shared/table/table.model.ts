import { DataSource } from '@angular/cdk/collections';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import {BehaviorSubject, merge, Observable, of, switchMap, tap} from 'rxjs';
import {PagedQuery, QueryCriterionDto} from '../model/query.model';
import {map} from 'rxjs/operators';
import {QueryResponse} from '../model/asutus.model';

export abstract class DataProvider<T> extends DataSource<T> {
  filter$ = new BehaviorSubject<QueryCriterionDto[]>([]);

  paginator: MatPaginator | undefined;
  sort: MatSort | undefined;
  totalRecords: number = 0;

  connect(): Observable<T[]> {
    if(this.paginator && this.sort){
      var query$ = merge(
        this.filter$.asObservable(),
        this.paginator.page,
        this.sort.sortChange
      ).pipe(
        map(():PagedQuery  => {
          return {
            criteria: this.filter$.value,
            page: this.paginator?.pageIndex,
            pageSize: this.paginator?.pageSize,
            sortBy: this.sort?.active,
            sortOrder: this.sort?.direction
        }})
      );

      return query$.pipe(
        switchMap((query: PagedQuery) => {
          return this.getData(query).pipe(
            tap((res) => {
              this.totalRecords = res.total;
            }),
            map((res) => res.result)
          );
        })
      );
    } else {
      throw Error('Please set the paginator and sort on the data source before connecting.');
    }
  }
  disconnect(): void {}

  abstract getData(pagination: PagedQuery): Observable<QueryResponse<T>>;
}


