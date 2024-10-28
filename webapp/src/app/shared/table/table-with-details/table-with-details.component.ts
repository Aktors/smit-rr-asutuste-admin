import {
  Component,
  Input,
  TemplateRef,
} from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import {TableComponent} from '../table.component';

@Component({
  selector: 'app-table-with-details',
  templateUrl: './table-with-details.component.html',
  styleUrl: './table-with-details.component.scss',
  animations: [
    trigger('detailExpand', [
      state('collapsed,void', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TableComponentWithDetails<T> extends  TableComponent<T> {
  @Input() expandedTemplate?: TemplateRef<any>;
  displayedHeadersWithDetails: string[] = [];
  expandedElement: T | null = null;


  override ngAfterViewInit(): void {
    super.ngAfterViewInit();

    this.displayedHeadersWithDetails = [...this.displayedHeaders, "expand"];

    this.changeDetectorRef.detectChanges();
  }
}
