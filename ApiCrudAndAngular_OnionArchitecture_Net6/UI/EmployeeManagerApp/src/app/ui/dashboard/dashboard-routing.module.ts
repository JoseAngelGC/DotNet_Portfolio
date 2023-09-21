import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component';

const routes: Routes = [
  {
    path:'',
    component:AdminDashboardComponent,
    loadChildren: () => import('../employeemanager/home/home.module').then(m => m.HomeModule)
  },
  {
    path:'department',
    component:AdminDashboardComponent,
    loadChildren: () => import('../employeemanager/department/department.module').then(m => m.DepartmentModule)
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
