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
  deleteEmployee(employee:Employee): Observable<Employee> {
    return this.http.delete<Employee>(this.baseUrlEmployee+"/"+employee.identity)
  }
}
