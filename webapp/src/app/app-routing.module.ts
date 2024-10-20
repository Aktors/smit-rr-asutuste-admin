import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';

export const AppPaths = {
  asutus: {
    root: 'asutused',
  }
};
export const routes: Routes = [
  { path: '', redirectTo: AppPaths.asutus.root, pathMatch: 'full' },
  {
    path: AppPaths.asutus.root,
    loadChildren: () =>
      import('./asutus/asutus.module').then((m) => m.AsutusModule)
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export default class AppRoutingModule {

}
