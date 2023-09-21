import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { EmployeemanagerCatalogsGateway } from "src/app/domain/models/employeemanager/common/gateways/employeemanager-catalogs-gateway";
import { EmployeemanagerApisResponse } from "src/app/domain/models/employeemanager/common/responses/employeemanager-apis-response";
import { DepartmentModel } from "src/app/domain/models/employeemanager/department/department-model";

@Injectable({
    providedIn: 'root'
})

export class EditDepartmentUsecase{
    constructor(private _employeemanageCatalogsGateway: EmployeemanagerCatalogsGateway){}

    editDepartment(departmentModel:DepartmentModel):Observable<EmployeemanagerApisResponse>{
        return this._employeemanageCatalogsGateway.editRecord(departmentModel.id,departmentModel);
    }
}