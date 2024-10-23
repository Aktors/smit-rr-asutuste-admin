import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {TableComponent} from './table/table.component';
import {TableColumnComponent} from './table/table-column/table-column.component';
import {TableTextColumnComponent} from './table/table-text-column/table-text-column.component';
import {TableDateColumnComponent} from './table/table-date-column/table-date-column.component';
import {TableBooleanColumnComponent} from './table/table-bool-column/table-bool-column.component';
import {LoaderComponent} from './loader/loader.component';
import {VerticalFormComponent} from './form/vertical-form.component';
import {FormTextInputComponent} from './form/form-text-input/form-text-input.component';
import {CardComponent} from './card/card.component';

@NgModule({
  declarations: [
    TableComponent,
    TableColumnComponent,
    TableTextColumnComponent,
    TableDateColumnComponent,
    TableBooleanColumnComponent,
    VerticalFormComponent,
    FormTextInputComponent,
    LoaderComponent,
    CardComponent
  ],
  imports: [CommonModule],
  exports: [
    TableComponent,
    TableTextColumnComponent,
    TableDateColumnComponent,
    TableBooleanColumnComponent,
    VerticalFormComponent,
    FormTextInputComponent,
    LoaderComponent,
    CardComponent
  ]
})
export class SharedModule {}
