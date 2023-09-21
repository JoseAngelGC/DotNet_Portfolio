import { Component, OnInit, ViewChild } from '@angular/core';
import { delay } from 'rxjs/operators';
/*Angular material components*/
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
/*Models and use cases from department module*/
import { DepartmentModel } from 'src/app/domain/models/employeemanager/department/department-model';
import { GetDepartmentUsecase } from 'src/app/domain/usecases/employeemanager/department/get-department-usecase';
import { DeleteDepartmentUsecase } from 'src/app/domain/usecases/employeemanager/department/delete-department-usecase';
/*Shared internal components from department module*/
import { AddEditDialogComponent } from '../shared/add-edit-dialog/add-edit-dialog.component';
import { DeleteDialogComponent } from '../../components/delete-dialog/delete-dialog.component';
import { TableColumnsModel } from 'src/app/domain/models/shared/table/table-columns-model';


@Component({
  selector: 'app-departments-list',
  templateUrl: './departments-list.component.html',
  styleUrls: ['./departments-list.component.scss']
})
export class DepartmentsListComponent implements OnInit {
  /*Variables definitions*/
  dataSource = new MatTableDataSource<DepartmentModel>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  departmentsTableColumns:TableColumnsModel[]=[
    {label:"No.", def:"id", datakey:"id"},
    {label:"Nombre", def:"name", datakey:"name"},
    {label:"Activo", def:"active", datakey:"active"},
    {label:"Acciones", def:"actions", datakey:"actions"}
  ];
  
  /*constructor method*/
  constructor(
    private _getDepartmentUsecase: GetDepartmentUsecase,
    private _deleteDepartmentUseCase: DeleteDepartmentUsecase,
    private _snackBar:MatSnackBar,
    public dialog: MatDialog){/*constructor content*/}

  /*Lifecycle methods*/
  ngOnInit() {
    this.getDepartments();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  /*Auxs methods*/
  rowClick(e:any){
    let action = e.action;
    let dataRow = e.row;

    switch(action){
      case "edit":
        this.editDepartmentDialog(dataRow);
        break;
      case "delete":
        this.deleteDepartmentDialog(dataRow);
    }
  }


  openAlert(message: string, action: string) {
    this._snackBar.open(message, action,{
      horizontalPosition:"center",
      verticalPosition:"bottom",
      duration:3000
    });
  }

  /*View-Model interaction methods*/
  getDepartments(){
    this._getDepartmentUsecase.getAllDepartments().subscribe({
      next:(dataResp) =>{
        console.log(dataResp);
        this.dataSource.data = dataResp.data;
      },error:(e) =>{
        console.log(e);
      }
    })

  }

  newDepartmentDialog(){
    this.dialog.open(AddEditDialogComponent,{
      disableClose: true,
      width: '350px'
    }).afterClosed().subscribe(resultado =>{
      if(resultado === "creado"){
        delay(3000);
        this.getDepartments();
      }
    })
  }

  editDepartmentDialog(departmentData:DepartmentModel){
    this.dialog.open(AddEditDialogComponent,{
      disableClose: true,
      width: '350px',
      data:departmentData
    }).afterClosed().subscribe(resultado =>{
      if(resultado === "editado"){
        delay(3000);
        this.getDepartments();
      }
    })
  }

  deleteDepartmentDialog(departmentData:DepartmentModel){
    this.dialog.open(DeleteDialogComponent,{
      disableClose: true,
      data:departmentData
    }).afterClosed().subscribe(resultado =>{
      if(resultado === "eliminar"){
        this._deleteDepartmentUseCase.deleteDepartment(departmentData).subscribe({
          next:(resp) =>{
            this.openAlert("El departamento fue eliminado!","Listo");
            delay(3000);
            this.getDepartments();
          },error:(e) =>{
            this.openAlert("No se pudo eliminar el departamento","Error");
            delay(3000);
            this.getDepartments();
          }

        }) //End deleteDepartment subscribe block

      } //End IF block

    })//End afterClosed subscribe block
  }

}