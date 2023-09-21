import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DepartmentModel } from 'src/app/domain/models/employeemanager/department/department-model';
import { NewDepartmentUsecase } from 'src/app/domain/usecases/employeemanager/department/new-department-usecase';
import { EditDepartmentUsecase } from 'src/app/domain/usecases/employeemanager/department/edit-department-usecase';

export interface ActiveStates {
  value: boolean;
  viewValue: string;
}

@Component({
  selector: 'app-add-edit-dialog',
  templateUrl: './add-edit-dialog.component.html',
  styleUrls: ['./add-edit-dialog.component.scss']
})
export class AddEditDialogComponent implements OnInit {
  formDepartment: FormGroup;
  titleAction: string='Nuevo';
  buttonAction: string='Guardar';
  
  activeStates: ActiveStates[] = [
    {value: false, viewValue: 'False'},
    {value: true, viewValue: 'True'}
  ];

  constructor(
    private dialogReference:MatDialogRef<AddEditDialogComponent>,
    private formBuilder: FormBuilder,
    private _snackBar:MatSnackBar,
    private _newDepartmentUseCase: NewDepartmentUsecase,
    private _editDepartmentUsecase: EditDepartmentUsecase,
    @Inject(MAT_DIALOG_DATA) public departmentData: DepartmentModel
    ){
      this.formDepartment = this.formBuilder.group({
        id:[0],
        name:['',Validators.required],
        active:[false]
      });
    }

    ngOnInit(): void {
      if(this.departmentData){
        this.formDepartment.patchValue({
          id: this.departmentData.id,
          name: this.departmentData.name,
          active: this.departmentData.active
        })

        this.titleAction="Editar";
        this.buttonAction="Actualizar";
      }
    }

    openAlert(message: string, action: string) {
      this._snackBar.open(message, action,{
        horizontalPosition:"center",
        verticalPosition:"top",
        duration:5000
      });
    }

    addEditDepartment(){
      const modelo: DepartmentModel={
        id: this.formDepartment.value.id,
        name: this.formDepartment.value.name,
        active: this.formDepartment.value.active
      }

      if(this.departmentData == null){
        this._newDepartmentUseCase.newDepartment(modelo).subscribe({
          next:(resp) =>{
            this.openAlert("Departamento creado exitosamente!","Listo");
            this.dialogReference.close("creado");
          },error:(e) =>{
            this.openAlert("No se pudo crear el departamento!","Error");
          }
        })
      }else{
        this._editDepartmentUsecase.editDepartment(modelo).subscribe({
          next:(resp) => {
            this.openAlert("Departamento actualizado exitosamente!","Listo");
            this.dialogReference.close("editado");
          },error:(e) =>{
            this.openAlert("No se pudo actualizar el departmento","Error");
          }
        })
      }

    }

}
