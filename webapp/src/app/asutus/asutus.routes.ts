import {AsutusListComponent} from './asutus-list/asutus-list.component';
import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AsutusFormComponent} from './asutus-form/asutus-form.component';

const routes: Routes = [
  {
    path: '',
    component: AsutusListComponent,
    children: [
      {
        path:'new',
        component: AsutusFormComponent
      },
      {
        path:':code',
        component: AsutusFormComponent
      },
      {
        path:':code/edit',
        component: AsutusFormComponent
      }
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AsutusRoutesModule { }
