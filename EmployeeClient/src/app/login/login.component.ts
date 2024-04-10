import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { CompanyService } from '../company.service';
import { Company } from '../entities/company.entites';
import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { MatOptionModule } from '@angular/material/core';
import { SessionStorageService } from '../session-storage.service';
import { LoginModel } from '../entities/login.model';
import { AuthService } from '../auth.service';
import { DialogMessegeComponent } from '../errors-dialog/dialog-messege/dialog-messege.component';
import { MatDialog } from '@angular/material/dialog';

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
    private companyService: CompanyService,private authService: AuthService,public dialog: MatDialog,
    private sessionStorageService: SessionStorageService
  ) { }
  hide = true;
  companies: Company[] = [];
  @Output() tokenSaved = new EventEmitter<string>();
  isNameAndPasswordValid: boolean=false;

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
  AddCompany() {
    this.router.navigate(['/add-company']);
  }
  login(): void {
    if (this.loginForm.valid) {
      const loginModel: LoginModel = this.loginForm.value;
      this.authService.login(loginModel).subscribe(
        (response) => {
          const token = response.token;
          console.log("token", token);
          sessionStorage.setItem('token', token);

          // this.checkNameAndPassword();
          this.router.navigate(['/employee-list']);
        },
        (error) => {
          const dialogRef = this.dialog.open(DialogMessegeComponent, {
            width: '250px',
            // data: "the employee has been deleted!!!"
            data:{title:"error",messege:"the password is not correct!!",icon:"error"}
          });
          dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed');
          });
        }
      );
    }
  }
  // checkNameAndPassword() {
  //   this.authService.getIsValidToken().subscribe(
  //     (response) => {
  //       console.log(response);
  //       this.isNameAndPasswordValid = response;
  //       // this.sendTokenToServer(token);
  //     },
  //     (error) => {
  //       console.error('Login failed:', error);

  //     }
  //   );
  //   if(!this.isNameAndPasswordValid){
  //     const dialogRef = this.dialog.open(DialogMessegeComponent, {
  //       width: '250px',
  //       // data: "the employee has been deleted!!!"
  //       data:{title:"error",messege:"the password or name is not correct!!",icon:"error"}
  //     });
  //     dialogRef.afterClosed().subscribe(result => {
  //       console.log('The dialog was closed');
  //     });
  //   }
  //   else{
  //     this.router.navigate(['/employee-list']);
  //   }
  // }
  

  private sendTokenToServer(token: string): void {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  }
  toEmployeeList() {
    this.router.navigate(['employee-list']);
  }
}

