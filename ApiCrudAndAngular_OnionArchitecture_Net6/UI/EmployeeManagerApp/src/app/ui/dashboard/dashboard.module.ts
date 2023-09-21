import { NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';

//Módulos de angular material
import { SharedMaterialModule } from '../shared/shared-material.module';
//Módulos de ruteo
import { DashboardRoutingModule } from './dashboard-routing.module';
import { RouterModule } from '@angular/router';
//Componentes del dashboard
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AdminDashboardComponent } from './pages/admin-dashboard/admin-dashboard.component'; 
//Módulos de páginas independientes del dashboard
import { HomeModule } from '../employeemanager/home/home.module';
import { DepartmentModule } from '../employeemanager/department/department.module';


@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    NavigationComponent,
    AdminDashboardComponent
  ],
  imports: [
    CommonModule,
    SharedMaterialModule,
    DashboardRoutingModule,
    RouterModule,
    HomeModule,
    DepartmentModule
  ]
})
export class DashboardModule {}
