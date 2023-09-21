import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DepartmentModel } from 'src/app/domain/models/employeemanager/department/department-model';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.scss']
})
export class DeleteDialogComponent {
  constructor(
    private dialogReference:MatDialogRef<DeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public departmentData: DepartmentModel
    ) { }

    confirmDelete(){
      if(this.departmentData){
        this.dialogReference.close("eliminar");
      }
    }
}
