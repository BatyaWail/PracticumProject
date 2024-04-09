

import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { CompanyService } from '../../company.service';
import { Company } from '../../classes/entities/company.entites';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { MatOptionModule } from '@angular/material/core';
import { HeaderComponent } from '../../header/header.component';
import { SessionStorageService } from '../../session-storage.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule,
    FormsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatCardModule,
    MatIconModule, MatSelectModule, CommonModule, FormsModule, CommonModule,
    MatOptionModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  // loginForm!: FormGroup;
  // errorMessage: string | null = null;

  // constructor(private fb: FormBuilder, private http: HttpClient) { }

  // ngOnInit(): void {
  //   this.loginForm = this.fb.group({
  //     username: ['', Validators.required],
  //     password: ['', Validators.required]
  //   });
  // }

  // login(): void {
  //   if (this.loginForm.valid) {
  //     const loginModel = this.loginForm.value;

  //     this.http.post<any>('https://localhost:7031/api/Auth', loginModel)
  //       .pipe(
  //         tap(response => {
  //           const token = response.token;
  //           console.log("token", token);
  //           // Securely store the token (e.g., encrypted Local Storage)
  //         }),
  //         map(() => {
  //           // Handle successful login (e.g., navigate to protected area)
  //           this.errorMessage = null;
  //           return null;
  //         }),
  //         catchError(error => {
  //           this.errorMessage = error.error?.message || 'Login failed'; // Handle specific errors or a generic message
  //           return throwError(error);
  //         })
  //       )
  //       .subscribe();
  //   }
  // }
  loginForm!: FormGroup;
  errorMessage: string | null = null;

  constructor(private fb: FormBuilder,
    private http: HttpClient,
    //  private header: HeaderComponent,
    private router: Router,
    private companyService: CompanyService,
    // private sessionStorageService: SessionStorageService
  ) { }
  hide = true;
  companies: Company[] = [];
  @Output() tokenSaved = new EventEmitter<string>();

  ngOnInit(): void {
    // this._employeeService.getEmployeeList().subscribe({
    //   next: (res) => {
    this.companyService.getAllCompanies().subscribe({
      next: (res) => {
        console.log(res);
        this.companies = res;
      },
      error: (err) => {
        console.log(err);
      }
    })
    this.loginForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  // login(): void {
  //   if (this.loginForm.valid) {
  //     const loginModel = this.loginForm.value;

  //     this.http.post<any>('https://localhost:7031/api/Auth', loginModel)
  //       .pipe(
  //         tap(response => {
  //           const token = response.token;
  //           console.log("token", token);
  //           this.sendTokenToServer(token);
  //           sessionStorage.setItem('token', token);
  //           // this.sessionStorageService.setToken(token);
  //           // this.header.foundCompanyNameFromToken();
  //         }),
  //         catchError(error => {
  //           // Handle login error
  //           return throwError(error);
  //         })
  //       ).subscribe();
  //   }
  //   this.toEmployeeList()
  // }
  login(): void {
    if (this.loginForm.valid) {
      const loginModel = this.loginForm.value;
      this.http.post<any>('https://localhost:7031/api/Auth', loginModel)
        .pipe(
          tap(response => {
            const token = response.token;
            console.log("token", token);
            this.sendTokenToServer(token);
            sessionStorage.setItem('token', token);
            // this.tokenSaved.emit(token); // Emit the token after storing it
          }),
          catchError(error => {
            // Handle login error
            return throwError(error);
          })
        ).subscribe();
    }
    this.toEmployeeList();
  }

  private sendTokenToServer(token: string): void {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });


    //   this.http.get('https://localhost:7031/api', { headers })
    //     .subscribe(data => {
    //       // Handle successful token verification on the server
    //       console.log('Token sent and verified successfully:', data);
    //     }, error => {
    //       // Handle server-side token verification error
    //       console.error('Error verifying token on the server:', error);
    //     });
  }
  toEmployeeList() {
    this.router.navigate(['employee-list']);
  }
}

