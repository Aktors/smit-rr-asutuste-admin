import {Component} from '@angular/core';
import {TableColumnComponent} from '../table-column/table-column.component';
import {TABLE_COLUMN_TOKEN} from '../table-column/table-column.token';
import {TableTextColumnComponent} from '../table-text-column/table-text-column.component';

@Component({
  selector: 'app-table-template-column',
  templateUrl: 'table-template-column.component.html',
  providers: [{ provide: TABLE_COLUMN_TOKEN, useExisting: TableTextColumnComponent }]
})
export class TableTemplateColumnComponent extends TableColumnComponent {

}
