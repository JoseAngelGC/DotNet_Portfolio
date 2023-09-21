import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';

//Trabajar con formularios reactivos
import { ReactiveFormsModule} from '@angular/forms';
//Trabajar para peticiones http
import { HttpClientModule } from '@angular/common/http';
//Módulos de angular material
import { SharedMaterialModule } from '../../shared/shared-material.module';
//Módulos de ruteo
import { DepartmentRoutingModule } from './department-routing.module';
//Componentes del módulo departament
import { DepartmentsListComponent } from './views-models/departments-list/departments-list.component';
import { EmployeemanagerCatalogsGateway } from 'src/app/domain/models/employeemanager/common/gateways/employeemanager-catalogs-gateway';
import { DepartmentApiService } from 'src/app/infraestructure/driven-adapter/employeemanager/department/department-api.service';
import { AddEditDialogComponent } from './views-models/shared/add-edit-dialog/add-edit-dialog.component';
import { DeleteDialogComponent } from './components/delete-dialog/delete-dialog.component';
import { CommonsTablesModule } from '../../shared/commons-tables/commons-tables.module';


@NgModule({
  declarations: [
    DepartmentsListComponent,
    AddEditDialogComponent,
    DeleteDialogComponent
  ],
  imports: [
    CommonModule,
    DepartmentRoutingModule,
    SharedMaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    CommonsTablesModule
  ],
  providers:[
    { provide: EmployeemanagerCatalogsGateway, useClass: DepartmentApiService }
  ]
})
export class DepartmentModule { }
