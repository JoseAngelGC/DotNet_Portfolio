import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DepartmentsListComponent } from './views-models/departments-list/departments-list.component';

const routes: Routes = [
  {
    path:'',
    component:DepartmentsListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DepartmentRoutingModule { }
