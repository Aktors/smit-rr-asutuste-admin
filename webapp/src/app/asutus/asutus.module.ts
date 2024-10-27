import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AsutusListComponent} from './asutus-list/asutus-list.component';
import {AsutusRoutesModule} from './asutus.routes';
import {SharedModule} from '../shared/shared.module';
import {AsutusDetailsShowComponent} from './asutus-details-show/asutus-details-show.component';
import {ReplicationDetailsComponent} from './replication/replication-details/replication-details.component';
import {AsutusFormComponent} from './asutus-form/asutus-form.component';
import { AsutusComponent } from './asutus.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {ReplicationLogComponent} from './replication/replication-log/replication-log.component';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderRow,
  MatHeaderRowDef,
  MatRow, MatRowDef, MatTable
} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort, MatSortHeader} from '@angular/material/sort';
import {AsutusDetailsEditComponent} from './asutus-details-edit/asutus-details-edit.component';
import {MatFormField, MatLabel, MatSuffix} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {MatOption} from '@angular/material/core';
import {MatSelect} from '@angular/material/select';
import {ReactiveFormsModule} from '@angular/forms';
import {TranslationItemComponent} from './asutus-details-edit/translation-item/translation-item.component';
import {MatDatepicker, MatDatepickerInput, MatDatepickerToggle} from '@angular/material/datepicker';
import {
  ReplicationSystemItemComponent
} from './replication/replication-details/replication-system-item/replication-system-item.component';
import {MatCheckbox} from '@angular/material/checkbox';
import {MatTooltip} from '@angular/material/tooltip';

@NgModule({
  declarations: [
    AsutusFormComponent,
    AsutusDetailsShowComponent,
    AsutusDetailsEditComponent,
    TranslationItemComponent,
    AsutusListComponent,
    ReplicationDetailsComponent,
    ReplicationSystemItemComponent,
    AsutusComponent,
    ReplicationLogComponent,
  ],
  exports: [
  ],
  imports: [
    CommonModule,
    SharedModule,
    AsutusRoutesModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatCell,
    MatCellDef,
    MatColumnDef,
    MatHeaderCell,
    MatHeaderRow,
    MatHeaderRowDef,
    MatPaginator,
    MatRow,
    MatRowDef,
    MatSort,
    MatSortHeader,
    MatTable,
    MatFormField,
    MatInput,
    MatLabel,
    MatOption,
    MatSelect,
    ReactiveFormsModule,
    MatDatepicker,
    MatDatepickerToggle,
    MatDatepickerInput,
    MatSuffix,
    MatCheckbox,
    MatTooltip,
  ]
})
export class AsutusModule { }
