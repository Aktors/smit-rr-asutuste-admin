import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {AsutusListComponent} from './asutus-list/asutus-list.component';
import {AsutusRoutesModule} from './asutus.routes';

@NgModule({
  declarations: [
    AsutusListComponent
  ],
  imports: [
    CommonModule,AsutusRoutesModule
  ]
})
export class AsutusModule { }
