import {Component, Input, TemplateRef, ViewChild} from '@angular/core';
import {TABLE_COLUMN_TOKEN} from './table-column.token';

@Component({
  selector: 'app-table-column',
  template: '<ng-template><ng-content></ng-content></ng-template>',
  providers: [{ provide: TABLE_COLUMN_TOKEN, useExisting: TableColumnComponent }]
})
export class TableColumnComponent {
  @Input() field!: string;
  @Input() header?: string;
  @ViewChild(TemplateRef) template!: TemplateRef<any>;
}
