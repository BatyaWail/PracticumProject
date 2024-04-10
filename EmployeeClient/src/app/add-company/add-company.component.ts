import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

import { MatSelectModule } from '@angular/material/select';
import { CommonModule } from '@angular/common';
import { CompanyService } from '../company.service';
import { Company } from '../entities/company.entites';
import { DialogMessegeComponent } from '../errors-dialog/dialog-messege/dialog-messege.component';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-company',
  standalone: true,
  imports: [
    FormsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatCardModule,
    MatIconModule, MatSelectModule, CommonModule, FormsModule, CommonModule,
    ReactiveFormsModule
    ],
  templateUrl: './add-company.component.html',
  styleUrl: './add-company.component.scss'
})
export class AddCompanyComponent implements OnInit {
hide: boolean = true;
  company!: Company;
  addCompanyForm!: FormGroup;
  constructor(private fb: FormBuilder,
    //  private header: HeaderComponent,
    private companyService: CompanyService,private router: Router,
    private dialog: MatDialog
  ) { }
  ngOnInit(): void {
    this.addCompanyForm = this.fb.group({
      name: ['', Validators.required],
      password: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    }, {
      validators: this.passwordMatchValidator
    });
  }
  add() {
    if (this.addCompanyForm.valid) {
      // const company: Company = this.addCompanyForm.value;
      console.log(this.addCompanyForm.value.name);
      // const name=this.addCompanyForm.value.name;
      // console.log(name);
      // this.company.name=name.trim();
      // this.company.password=this.addCompanyForm.value.password;
      const name = this.addCompanyForm.value.name;
    const password = this.addCompanyForm.value.password;

    // Define the company object
    const company: Company = {
      name: name.trim(),
      password: password,
      id: 0
    };
      this.companyService.addCompany(company).subscribe({
        next: () => {
          this.addCompanyForm.reset();
          const dialogRef = this.dialog.open(DialogMessegeComponent, {
            width: '250px',
            // data: "you don't have permission to access!! move to login!"
            data:{title:"success",messege:"the company added successfully! moved to login page to enter!",icon:"send"}
          });
          dialogRef.afterClosed().subscribe((result: any) => {
            console.log('The dialog was closed');
            this.toLoginPage()
          });
        },
        error: (err) => {
          console.error('Error adding Company:', err);
        }
      })
    }
    else{
      const messege="you have error in the form: "+this.addCompanyForm.errors?['passwordMismatch']+" !":"the filedes is required!";
      const dialogRef = this.dialog.open(DialogMessegeComponent, {
        width: '250px',
        // data: "you don't have permission to access!! move to login!"
        data:{title:"error",messege:messege,icon:"error"}
      });
      dialogRef.afterClosed().subscribe((result: any) => {
        console.log('The dialog was closed');
        this.addCompanyForm.reset();
      });
    }
  }
  toLoginPage() {
    this.router.navigate(['/login']);
  }
  // passwordMatchValidator(formGroup: FormGroup) {
  //   const password = formGroup.get('password').value;
  //   const confirmPassword = formGroup.get('confirmPassword').value;

  //   return password === confirmPassword ? null : { passwordMismatch: true };
  // }
  passwordMatchValidator(formGroup: FormGroup) {
    const password = formGroup.get('password')?.value;
    const confirmPassword = formGroup.get('confirmPassword')?.value;

    // Check if password and confirmPassword are not null
    if (password !== null && confirmPassword !== null) {
        return password === confirmPassword ? null : { passwordMismatch: true };
    } else {
        // Handle the case where either password or confirmPassword is null
        return null;
    }
}


}
