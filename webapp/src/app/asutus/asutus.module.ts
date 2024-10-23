import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {AsutusListComponent} from './asutus-list/asutus-list.component';
import {AsutusRoutesModule} from './asutus.routes';
import {SharedModule} from '../shared/shared.module';
import {AustusDetailsComponent} from './asutus-details/austus-details.component';
import {ReplicationDetails} from './replication/replication-details/replication-details.component';
import {AsutusFormComponent} from './asutus-form/asutus-form.component';

@NgModule({
  declarations: [
    AsutusFormComponent,
    AustusDetailsComponent,
    AsutusListComponent,
    ReplicationDetails
  ],
  exports: [
  ],
  imports: [
    CommonModule,
    SharedModule,
    AsutusRoutesModule
  ]
})
export class AsutusModule { }
