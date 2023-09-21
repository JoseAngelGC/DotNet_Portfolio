import { Observable } from 'rxjs';
import { EmployeemanagerApisResponse } from '../../responses/employeemanager-apis-response';

export abstract class EmployeemanagerCatalogsBase{
    abstract getAll():Observable<EmployeemanagerApisResponse>;
    abstract addNew<T>(model:T):Observable<EmployeemanagerApisResponse>;
    abstract editRecord<T>(id: number, model:T):Observable<EmployeemanagerApisResponse>;
}