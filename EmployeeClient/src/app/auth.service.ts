import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Company } from './entities/company.entites';
import { Observable } from 'rxjs';
import { LoginModel } from './entities/login.model';
// import { LoginModel } from './entities/login.model';
interface LoginResponse {
  token: string;
  
}
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public baseUrlAuth = 'https://localhost:7031/api/Auth'

  constructor(private http: HttpClient) { }
  // getToken(company :Company) {
  //   return this.http.post<Company>(this.baseUrlAuth, company)
  // }
  login(loginModel:LoginModel):Observable<LoginResponse>{
    return this.http.post<LoginResponse>(this.baseUrlAuth,loginModel)
  }
  getIsValidToken():Observable<boolean>{
    const headers=new HttpHeaders({
      'Authorization':`Bearer ${localStorage.getItem('token')}`
    });
    return this.http.get<boolean>('https://localhost:7215/api/Auth/verifyToken',{headers});
  }

}

/*import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../classes/entities/employee.entites';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {  
  returnTokenFromSesionStorage(){
    // if (typeof sessionStorage !== 'undefined') {
      return sessionStorage.getItem('token');
    // }
    // else{
    //   console.error('sessionStorage is not available');
    //   return null
    // }
  }
  public baseUrlEmployee = 'https://localhost:7031/api/Employee'

  constructor(private http: HttpClient) { }

  // const headers = new HttpHeaders({
  //   'Authorization': `Bearer ${sessionStorage.getItem('token')}`
  // });
  addEmployee(employee :Employee): Observable<Employee> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${sessionStorage.getItem('token')}`
    });
    return this.http.post<Employee>(this.baseUrlEmployee, employee, { headers })
  }

  getEmployeeList(): Observable<Employee[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${sessionStorage.getItem('token')}`
    });
    return this.http.get<Employee[]>(this.baseUrlEmployee, { headers })
  }
  deleteEmployee(identity:string): Observable<Employee> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${sessionStorage.getItem('token')}`
    });
    return this.http.delete<Employee>(this.baseUrlEmployee+"/"+identity, { headers })
  }
  updateEmployee(employee:Employee): Observable<Employee> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${sessionStorage.getItem('token')}`
    });
    return this.http.put<Employee>(this.baseUrlEmployee+"/"+employee.identity,employee, { headers })
  }
  getEmployeeById(identity:string): Observable<Employee> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${sessionStorage.getItem('token')}`
    });
    return this.http.get<Employee>(this.baseUrlEmployee+"/"+identity, { headers })
  }
}*/
