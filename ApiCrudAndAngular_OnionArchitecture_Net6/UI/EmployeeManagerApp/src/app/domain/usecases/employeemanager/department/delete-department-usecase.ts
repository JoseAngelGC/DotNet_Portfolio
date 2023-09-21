import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { EmployeemanagerCatalogsGateway } from "src/app/domain/models/employeemanager/common/gateways/employeemanager-catalogs-gateway";
import { EmployeemanagerApisResponse } from "src/app/domain/models/employeemanager/common/responses/employeemanager-apis-response";
import { DepartmentModel } from "src/app/domain/models/employeemanager/department/department-model";

@Injectable({
    providedIn: 'root'
})

export class DeleteDepartmentUsecase{
    constructor(private _employeemanageCatalogsGateway: EmployeemanagerCatalogsGateway){}
    
    deleteDepartment(departmentModel:DepartmentModel):Observable<EmployeemanagerApisResponse>{
        return this._employeemanageCatalogsGateway.deleteRecord(departmentModel.id, departmentModel);
    }
}