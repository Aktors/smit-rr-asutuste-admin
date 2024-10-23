import { Component } from '@angular/core';
import {TableColumnComponent} from '../table-column/table-column.component';
import {TABLE_COLUMN_TOKEN} from '../table-column/table-column.token';

@Component({
  selector: 'app-table-text-column',
  templateUrl: './table-text-column.component.html',
  providers: [{ provide: TABLE_COLUMN_TOKEN, useExisting: TableTextColumnComponent }]
})
export class TableTextColumnComponent extends TableColumnComponent { }
