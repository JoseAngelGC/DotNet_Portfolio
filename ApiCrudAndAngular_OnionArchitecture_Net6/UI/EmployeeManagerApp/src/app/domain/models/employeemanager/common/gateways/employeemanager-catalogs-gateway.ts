import { Observable } from 'rxjs';
import { EmployeemanagerApisResponse } from '../responses/employeemanager-apis-response';
import { EmployeemanagerCatalogsBase } from './bases/employeemanager-catalogs-base';

export abstract class EmployeemanagerCatalogsGateway extends EmployeemanagerCatalogsBase{
    abstract getById(id: number):Observable<EmployeemanagerApisResponse>;
    abstract deleteRecord<T>(id: number, model:T):Observable<EmployeemanagerApisResponse>;
}