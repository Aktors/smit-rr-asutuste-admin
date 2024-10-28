import {Component, ContentChild, Input, TemplateRef} from '@angular/core';

@Component({
  selector: 'app-table-actions-column',
  templateUrl: './table-actions-column.component.html'
})
export class TableActionsColumnComponent<T> {
  @Input() key!: string;
  @Input() header?: string;
  @Input() element!: T;
  @ContentChild(TemplateRef) actionTemplate!: TemplateRef<any>;
}
