import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../entities/employee.entites';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


  public baseUrlEmployee = 'https://localhost:7031/api/Employee'

  constructor(private http: HttpClient) { }

  addEmployee(employee :Employee): Observable<Employee> {
    return this.http.post<Employee>(this.baseUrlEmployee, employee)
  }

  getEmployeeList(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrlEmployee)
  }
  deleteEmployee(identity:string): Observable<Employee> {
    return this.http.delete<Employee>(this.baseUrlEmployee+"/"+identity)
  }
  updateEmployee(employee:Employee): Observable<Employee> {
    return this.http.put<Employee>(this.baseUrlEmployee+"/"+employee.identity,employee)
  }
  getEmployeeById(identity:string): Observable<Employee> {
    return this.http.get<Employee>(this.baseUrlEmployee+"/"+identity)
  }
}
