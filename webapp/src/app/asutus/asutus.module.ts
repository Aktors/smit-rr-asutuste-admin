import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AsutusListComponent} from './asutus-list/asutus-list.component';
import {AsutusRoutesModule} from './asutus.routes';
import {SharedModule} from '../shared/shared.module';
import {AustusDetailsComponent} from './asutus-details/austus-details.component';
import {ReplicationDetails} from './replication/replication-details/replication-details.component';
import {AsutusFormComponent} from './asutus-form/asutus-form.component';
import { AsutusComponent } from './asutus.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {AppModule} from "../app.module";
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
import {TableExpandableRowsExample} from "../shared/table/test-table/table-expandable-rows-example.component";

@NgModule({
  declarations: [
    AsutusFormComponent,
    AustusDetailsComponent,
    AsutusListComponent,
    ReplicationDetails,
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
        TableExpandableRowsExample
    ]
})
export class AsutusModule { }
