import {AsutusListComponent} from './asutus-list/asutus-list.component';
import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';

const routes = [
  {
    path: '',
    component: AsutusListComponent,
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AsutusRoutesModule { }
