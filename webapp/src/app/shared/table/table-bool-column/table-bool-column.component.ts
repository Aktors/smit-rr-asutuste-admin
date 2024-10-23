import {Component} from '@angular/core';
import {TableColumnComponent} from '../table-column/table-column.component';
import {TABLE_COLUMN_TOKEN} from '../table-column/table-column.token';

@Component({
  selector: 'app-table-bool-column',
  templateUrl: './table-bool-column.component.html',
  providers: [{ provide: TABLE_COLUMN_TOKEN, useExisting: TableBooleanColumnComponent }]
})
export class TableBooleanColumnComponent extends TableColumnComponent { }
