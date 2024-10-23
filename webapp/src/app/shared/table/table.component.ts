import { Component, ContentChildren, Input, QueryList} from '@angular/core';
import {TableColumnComponent} from './table-column/table-column.component';
import {TABLE_COLUMN_TOKEN} from './table-column/table-column.token';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
})
export class TableComponent {
  @Input() dataSource!: any[];
  @ContentChildren(TABLE_COLUMN_TOKEN) columns!: QueryList<TableColumnComponent>;
}
