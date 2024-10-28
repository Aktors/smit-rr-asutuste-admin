import { Component, Input } from '@angular/core';
import { TableColumnComponent } from '../table-column/table-column.component';
import { TABLE_COLUMN_TOKEN } from '../table-column/table-column.token';

@Component({
  selector: 'app-table-button-column',
  templateUrl: './table-button-column.component.html',
  providers: [{ provide: TABLE_COLUMN_TOKEN, useExisting: TableButtonColumnComponent }]
})
export class TableButtonColumnComponent extends TableColumnComponent {
  @Input() linkPrefix!: string;
  @Input() action!: string;
  @Input() label!: string;

  getRouterLink(code: string): any[] {
    return [this.linkPrefix, code, this.action];
  }
}
