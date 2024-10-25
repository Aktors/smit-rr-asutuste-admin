import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LoaderComponent} from './loader/loader.component';
import {VerticalFormComponent} from './form/vertical-form.component';
import {FormTextInputComponent} from './form/form-text-input/form-text-input.component';
import {CardComponent} from './card/card.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule, MatIconButton} from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {TableComponent} from './table/table.component';
import {TableColumnComponent} from './table/table-column/table-column.component';
import {TableTextColumnComponent} from './table/table-text-column/table-text-column.component';
import {TableDateColumnComponent} from './table/table-date-column/table-date-column.component';
import {TableTemplateColumnComponent} from './table/table-template-column/table-template-column.component';

@NgModule({
  declarations: [
    VerticalFormComponent,
    FormTextInputComponent,
    LoaderComponent,
    CardComponent,
    TableComponent,
    TableColumnComponent,
    TableTextColumnComponent,
    TableDateColumnComponent,
    TableTemplateColumnComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatIconButton
  ],
  exports: [
    VerticalFormComponent,
    FormTextInputComponent,
    LoaderComponent,
    CardComponent,
    TableComponent,
    TableTextColumnComponent,
    TableDateColumnComponent,
    TableTemplateColumnComponent
  ]
})
export class SharedModule {}
