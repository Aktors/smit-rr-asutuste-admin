import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LoaderComponent} from './loader/loader.component';
import {FormComponent} from './form/form.component';
import {FormTextInputComponent} from './form/form-text-input/form-text-input.component';
import {CardComponent} from './card/card.component';
import {MatIconModule} from '@angular/material/icon';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {TableComponent} from './table/table.component';
import {TableColumnComponent} from './table/table-column/table-column.component';
import {TableTextColumnComponent} from './table/table-text-column/table-text-column.component';
import {TableDateColumnComponent} from './table/table-date-column/table-date-column.component';
import {TableTemplateColumnComponent} from './table/table-template-column/table-template-column.component';
import {TableLinkColumnComponent} from './table/table-link-column/table-link-column.component';
import {FormDateInputComponent} from './form/form-date-input/form-date-input.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatOption, provideNativeDateAdapter} from '@angular/material/core';
import {MatButton, MatIconButton} from '@angular/material/button';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatSelect} from '@angular/material/select';
import {RouterLink} from "@angular/router";
import {TableButtonColumnComponent} from './table/table-button-column/table-button-column.component';
import {TableActionsColumnComponent} from './table/table-action-column/table-actions-column.component';
import {TableComponentWithDetails} from './table/table-with-details/table-with-details.component';

@NgModule({
  declarations: [
    FormComponent,
    FormTextInputComponent,
    FormDateInputComponent,
    LoaderComponent,
    CardComponent,
    TableComponent,
    TableComponentWithDetails,
    TableColumnComponent,
    TableTextColumnComponent,
    TableDateColumnComponent,
    TableTemplateColumnComponent,
    TableLinkColumnComponent,
    TableButtonColumnComponent,
    TableActionsColumnComponent,
  ],
  providers:[
    provideNativeDateAdapter()
  ],
    imports: [
        CommonModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatIconModule,
        MatFormFieldModule,
        MatInputModule,
        MatDatepickerModule,
        MatIconButton,
        FormsModule,
        ReactiveFormsModule,
        MatSelect,
        MatOption,
        MatButton,
        RouterLink
    ],
  exports: [
    FormComponent,
    FormTextInputComponent,
    FormDateInputComponent,
    LoaderComponent,
    CardComponent,
    TableComponent,
    TableComponentWithDetails,
    TableTextColumnComponent,
    TableDateColumnComponent,
    TableTemplateColumnComponent,
    TableLinkColumnComponent,
    TableButtonColumnComponent,
    TableActionsColumnComponent
  ]
})
export class SharedModule {}
