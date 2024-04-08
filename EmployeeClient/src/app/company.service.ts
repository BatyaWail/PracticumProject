import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from './classes/entities/company.entites';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  public baseUrlCompany = 'https://localhost:7031/api/Company'

  constructor(private http: HttpClient) { }
  getAllCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrlCompany)
  }
}
