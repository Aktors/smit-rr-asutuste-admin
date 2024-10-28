import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AsutusFormComponent} from './asutus-form/asutus-form.component';
import {AsutusComponent} from './asutus.component';
import {AsutusListComponent} from './asutus-list/asutus-list.component';
import {AsutusDetailsShowComponent} from './asutus-details-show/asutus-details-show.component';
import {AsutusDetailsEditComponent} from './asutus-details-edit/asutus-details-edit.component';

const routes: Routes = [
  {
    path: '',
    component: AsutusComponent,
    children: [
      {
        path: '',
        component: AsutusListComponent,
      },
      {
        path: 'manage',
        component: AsutusFormComponent,
        children: [
          {
            path:'new',
            component: AsutusDetailsEditComponent,
          },
          {
            path: ':code',
            component: AsutusDetailsShowComponent
          },
          {
            path:':code/edit',
            component: AsutusDetailsEditComponent
          }
        ]
      },
    ]
  }
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AsutusRoutesModule { }
