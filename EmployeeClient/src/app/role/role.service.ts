import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Role } from '../entities/role.entites';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  public baseUrlRole = 'https://localhost:7031/api/Role'

  constructor(private http: HttpClient) { }



  getAllRoles(): Observable<Role[]> {
    return this.http.get<Role[]>(this.baseUrlRole)
  }
}
