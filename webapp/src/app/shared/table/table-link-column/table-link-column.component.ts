import {Component, Input} from '@angular/core';
import {TableColumnComponent} from '../table-column/table-column.component';
import {TABLE_COLUMN_TOKEN} from '../table-column/table-column.token';

@Component({
  selector: 'app-table-link-column',
  templateUrl: './table-link-column.component.html',
  providers: [{ provide: TABLE_COLUMN_TOKEN, useExisting: TableColumnComponent }]
})
export class TableLinkColumnComponent extends TableColumnComponent {

}
