import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// project import
import { AdminComponent } from './theme/layout/admin/admin.component';

const routes: Routes = [
  {
    path: '',
    component: AdminComponent,
    children: [
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
      },
      {
        path: 'basic',
        loadChildren: () => import('./demo/ui-elements/ui-basic/ui-basic.module').then((m) => m.UiBasicModule)
      },
      {
        path: 'tables/users',
        loadComponent: () => import('./demo/pages/tables/tbl-bootstrap-user/tbl-bootstrap.component').then((c) => c.TblBootstrapComponent)
      },
      {
        path: 'tables/tasks',
        loadComponent: () => import('./demo/pages/tables/tbl-bootstrap-task/tbl-bootstrap.component').then((c) => c.TblBootstrapComponent)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
