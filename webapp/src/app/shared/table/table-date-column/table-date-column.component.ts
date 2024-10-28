import {Component} from '@angular/core';
import {TableColumnComponent} from '../table-column/table-column.component';
import {TABLE_COLUMN_TOKEN} from '../table-column/table-column.token';

@Component({
  selector: 'app-table-date-column',
  templateUrl: './table-date-column.component.html',
  providers: [{ provide: TABLE_COLUMN_TOKEN, useExisting: TableDateColumnComponent }]
})
export class TableDateColumnComponent extends TableColumnComponent { }
