import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { EmployeemanagerCatalogsGateway } from "src/app/domain/models/employeemanager/common/gateways/employeemanager-catalogs-gateway";
import { EmployeemanagerApisResponse } from "src/app/domain/models/employeemanager/common/responses/employeemanager-apis-response";

@Injectable({
    providedIn: 'root'
})

export class GetDepartmentUsecase{
    constructor(private _employeemanageCatalogsGateway: EmployeemanagerCatalogsGateway){}

    getAllDepartments():Observable<EmployeemanagerApisResponse>{
        return this._employeemanageCatalogsGateway.getAll();
    }

}