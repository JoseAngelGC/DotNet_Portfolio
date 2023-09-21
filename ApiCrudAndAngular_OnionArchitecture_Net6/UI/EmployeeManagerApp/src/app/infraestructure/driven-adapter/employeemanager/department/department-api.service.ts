import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { DepartmentApiEndpointsV1 } from 'src/app/domain/models/employeemanager/department/consts/department-api-endpoints-v1';
import { EmployeemanagerApisResponse } from 'src/app/domain/models/employeemanager/common/responses/employeemanager-apis-response';
import { EmployeemanagerCatalogsGateway } from 'src/app/domain/models/employeemanager/common/gateways/employeemanager-catalogs-gateway';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DepartmentApiService extends EmployeemanagerCatalogsGateway {
  private baseApi= environment.api;

  constructor(private _http: HttpClient) { super();}

  getAll():Observable<EmployeemanagerApisResponse>{
    const apiUrlRequest=this.baseApi + DepartmentApiEndpointsV1.GETALL_DEPARTMENTS;
    return this._http.get<EmployeemanagerApisResponse>(apiUrlRequest).pipe(
      map((resp:EmployeemanagerApisResponse) =>{
        return resp;
      })
    )
  }

  getById(id: number):Observable<EmployeemanagerApisResponse>{
    throw new Error('Method not implemented');
  }

  addNew<T>(model:T):Observable<EmployeemanagerApisResponse>{
    const apiUrlRequest=this.baseApi + DepartmentApiEndpointsV1.ADD_DEPARTMENT;
    return this._http.post<EmployeemanagerApisResponse>(apiUrlRequest,model).pipe(
      map((resp:EmployeemanagerApisResponse) =>{
        return resp;
      })
    )
  }

  editRecord<T>(id: number, model: T): Observable<EmployeemanagerApisResponse> {
    const apiUrlRequest=this.baseApi + DepartmentApiEndpointsV1.EDIT_DEPARTMENT;
    return this._http.put<EmployeemanagerApisResponse>(apiUrlRequest+id,model).pipe(
      map((resp:EmployeemanagerApisResponse) =>{
        return resp;
      })
    )
  }

  deleteRecord<T>(id: number, model:T):Observable<EmployeemanagerApisResponse>{
    const apiUrlRequest=this.baseApi + DepartmentApiEndpointsV1.DELETE_DEPARTMENT;
    return this._http.delete<EmployeemanagerApisResponse>(apiUrlRequest+id,{body:model}).pipe(
      map((resp:EmployeemanagerApisResponse) =>{
        return resp;
      })
    )
  }
  
}
