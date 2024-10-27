import {
  AfterViewInit,
  ChangeDetectorRef,
  Component,
  ContentChildren,
  Input,
  QueryList, TemplateRef,
  ViewChild
} from '@angular/core';
import { MatTable } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import {DataProvider} from './table.model';
import {TableColumnComponent} from './table-column/table-column.component';
import {TABLE_COLUMN_TOKEN} from './table-column/table-column.token';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {TableActionsColumnComponent} from './table-action-column/table-actions-column.component';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss',
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableComponent<T> implements  AfterViewInit {
  @Input() dataProvider!: DataProvider<T>;
  @Input() expandedTemplate?: TemplateRef<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<T>;

  @ContentChildren(TABLE_COLUMN_TOKEN) columns!: QueryList<TableColumnComponent>;
  @ContentChildren(TableActionsColumnComponent) actions!: QueryList<TableActionsColumnComponent<T>>;

  displayedHeaders: string[] = [];
  displayedHeadersWithDetails: string[] = [];
  expandedElement: T | null = null;

  constructor(private changeDetectorRef :ChangeDetectorRef) { }

  ngAfterViewInit(): void {
    this.dataProvider.sort = this.sort;
    this.dataProvider.paginator = this.paginator;
    this.table.dataSource = this.dataProvider;

    this.displayedHeaders =[...this.columns.map(col => col.field), ...this.actions.map(col => col.key)];
    this.displayedHeadersWithDetails = [...this.displayedHeaders];
    if(this.expandedTemplate){
      this.displayedHeadersWithDetails.push("expanded");
    }
    this.changeDetectorRef.detectChanges();
  }

  toggleRow(element: T) {
    this.expandedElement = this.expandedElement === element ? null : element;
  }
}
