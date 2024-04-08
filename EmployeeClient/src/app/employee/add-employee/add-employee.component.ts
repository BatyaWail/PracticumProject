import { Component, Inject, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import {
  // MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
  MatDialog,
} from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { AbstractControl, FormArray, FormControl, FormsModule, ReactiveFormsModule, ValidatorFn } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { provideNativeDateAdapter } from '@angular/material/core';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';


import { EmployeeService } from '../employee.service';
import { RoleService } from '../../role/role.service';

import { MatRadioModule } from '@angular/material/radio';

import { MatDatepicker } from '@angular/material/datepicker';

import { FormBuilder, FormGroup, Validators } from '@angular/forms'; // Import form-related modules
import Swal from 'sweetalert2';
import { ErrorDialogAddEmployeeComponent } from '../../errors-dialog/error-dialog-add-employee/error-dialog-add-employee.component';

import { NgModule } from '@angular/core';

import { MatAccordion } from '@angular/material/expansion';
import { DialogMessegeComponent } from '../../errors-dialog/dialog-messege/dialog-messege.component';
import { Router } from '@angular/router';
import { Employee } from '../../classes/entities/employee.entites';
import { Role } from '../../classes/entities/role.entites';
import { EmployeeRolePostModel } from '../../classes/postModel/employeeRole.postModel';

import { MatCardModule } from '@angular/material/card';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
// import * as jwt_decode from 'jwt-decode';
// import jwt_decode from 'jwt-decode';
import * as jwt from 'jsonwebtoken';


export interface DialogData2 {
  errors: string[]
}
@Component({
  selector: 'app-add-employee',
  standalone: true,
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatExpansionModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatSelectModule,
    MatOptionModule,
    MatRadioModule, ReactiveFormsModule,
    CommonModule,
    MatCardModule,
    MatSlideToggleModule
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.scss'
})
export class AddEmployeeComponent implements OnInit {

  public employeeForm!: FormGroup; // Define FormGroup
  public employee: Employee = new Employee()
  public rolesList!: Role[]
  public newRoleList!: Role[]
  employeeRoles: { roleName: string, isManagementRole: boolean, entryDate: Date | null }[] = [{ roleName: '', isManagementRole: false, entryDate: null }];
  employeeRoleResult: EmployeeRolePostModel[] = []

  @ViewChildren(MatDatepicker)
  entryDatePickers!: QueryList<MatDatepicker<any>>;
  employeeRolePostModel: EmployeeRolePostModel = new EmployeeRolePostModel()
  validationErrors: string[] = []; // Array to store validation errors
  @ViewChild(MatAccordion) accordion!: MatAccordion;

  dateOfBirth: Date = new Date()
  token: any; 
  companyId: any;

  constructor(
    private _employeeService: EmployeeService,
    private _roleServices: RoleService,
    private fb: FormBuilder // Inject FormBuilder
    , public dialog: MatDialog,
    private router: Router
  ) { }
  // foundCompanyIdFromToken(){
  //   // this.token = sessionStorage.getItem('token');

  //   // if (this.token) {
  //   //   // Decode the token
  //   //   const decodedToken: any = jwt_decode(this.token);
  //   //   // Access the id property
  //   //   this.companyId = Number(decodedToken.id);
  //   //   console.log("Company ID:", this.companyId);
  //   // } else {
  //   //   console.error("Token not found in sessionStorage");
  //   // }
    
  //   // Assuming the token is stored in sessionStorage under the name "token"
  //   this.token = sessionStorage.getItem('token');

  //   if (this.token) {
  //     // Decode the token
  //     try {
  //       const decodedToken: any = jwt.decode(this.token);
  //       // Access the id property
  //       if (decodedToken && typeof decodedToken === 'object' && 'id' in decodedToken) {
  //         this.companyId = decodedToken.id;
  //         console.log("Company ID:", this.companyId);
  //       } else {
  //         console.error("Invalid token format or missing id property");
  //       }
  //     } catch (error) {
  //       console.error("Error decoding token:", error);
  //     }
  //   } else {
  //     console.error("Token not found in sessionStorage");
  //   }
  // }
  foundCompanyIdFromToken(){
    this.token = sessionStorage.getItem('token');
  
    if (this.token) {
      // Decode the token
      try {
        const tokenPayload: any = JSON.parse(atob(this.token.split('.')[1]));
        // Access the id property
        if (tokenPayload && typeof tokenPayload === 'object' && 'id' in tokenPayload) {
          this.companyId = tokenPayload.id;
          console.log("Company ID:", this.companyId);
        } else {
          console.error("Invalid token format or missing id property");
        }
      } catch (error) {
        console.error("Error decoding token:", error);
      }
    } else {
      console.error("Token not found in sessionStorage");
    }
  }
  
  ngOnInit(): void {
    this._roleServices.getAllRoles().subscribe({
      next: (res) => {
        console.log("res", res)
        this.rolesList = res;
        this.filterRoles()
      },
      error: (err) => {
        console.log(err)
      }
    })
    this.employeeForm = this.fb.group({ // Initialize FormGroup
      identity: ['', [Validators.required, Validators.minLength(9), Validators.maxLength(9), this.identityFormatValidator]],
      firstName: ['', Validators.required], // Define FormControls with initial values and validators
      lastName: ['', Validators.required],
      maleOrFmale: [false, Validators.required],
      dateOfBirth: [null, [Validators.required, this.dateOfBirthValidator.bind(this)]],
      startDate: [null, [Validators.required, this.startDateValidator.bind(this)]],
      employeeRoles: this.fb.array([], this.roleNameNotDuplicateValidator) // Initialize FormArray for employee roles
    });
    this.addRole()
    this.employee.employeeRoles = [];
    // this.filterRoles()
  }
  addRole() {
    // this.filterRoles()

    // if (this.newRoleList.length === 0) {
    //   console.log("Cannot add more roles. No roles available.");
    //   return;
    // }
    const roleFormGroup = this.fb.group({
      roleName: ['', [Validators.required, this.roleNameValidator(this.employeeRolesFormArray.length)]], // Apply custom validator
      isManagementRole: [false, Validators.required],
      entryDate: [null, [Validators.required, this.startDateBeforeEntryDateValidator.bind(this)]]
    });
    this.employeeRolesFormArray.push(roleFormGroup);    
    this.filterRoles()

  }
  step = 0;
  setStep(index: number) {
    this.step = index;
  }
  nextStep() {
    this.step++;
  }
  prevStep() {
    this.step--;
  }
  get employeeRolesFormArray() {
    return this.employeeForm.get('employeeRoles') as FormArray;
  }

  removeRole(index: number) {
    this.employeeRolesFormArray.removeAt(index);
    this.filterRoles()
  }
  submit() {
    if (!this.submitForm()) {
      this.dialog.open(ErrorDialogAddEmployeeComponent, {
        data: {
          errors: this.validationErrors,
        },
      });
      console.log("Validation errors:", this.validationErrors);
    }
  }
  submitForm(): boolean {
    this.validationErrors = []; // Reset validation errors array before checking
    this.checkAndLogControlErrors(this.employeeForm); // Check and log control errors

    if (this.validationErrors.length === 0) {
      this.sendData();
      return true;
    } else {
      console.log("Validation errors:", this.validationErrors);
      console.log("Error!! Form is invalid.");
      return false;
    }
  }

  checkAndLogControlErrors(control: AbstractControl, controlName: string = '') {
    if (control instanceof FormGroup) {
      Object.keys(control.controls).forEach(key => {
        this.checkAndLogControlErrors(control.get(key) as AbstractControl, `${controlName}.${key}`);
      });
    } else if (control instanceof FormArray) {
      (control as FormArray).controls.forEach((arrayControl, index) => {
        this.checkAndLogControlErrors(arrayControl, `${controlName}[${index}]`);
      });
    } else {
      const controlErrors = control.errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach(keyError => {
          const errorMessage = `Control: ${controlName}, Error: ${keyError}, Value: ${controlErrors[keyError]}`;
          this.validationErrors.push(errorMessage); // Store validation error in the component's array
        });
      } else {
        // If there are no errors, remove the error message from the validationErrors array
        const errorMessageIndex = this.validationErrors.findIndex(msg => msg.startsWith(`Control: ${controlName}`));
        if (errorMessageIndex !== -1) {
          this.validationErrors.splice(errorMessageIndex, 1);
        }
      }
    }
  }
  logControlErrors(control: AbstractControl, controlName: string = '') {
    if (control instanceof FormGroup) {
      Object.keys(control.controls).forEach(key => {
        this.logControlErrors(control.get(key) as AbstractControl, `${controlName}.${key}`);
      });
    } else if (control instanceof FormArray) {
      (control as FormArray).controls.forEach((arrayControl, index) => {
        this.logControlErrors(arrayControl, `${controlName}[${index}]`);
      });
    } else {
      const controlErrors = control.errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach(keyError => {
          console.log(`Control: ${controlName}, Error: ${keyError}, Value: ${controlErrors[keyError]}`);
        });
      }
    }
  }
  sendData() {
    console.log("Form data:", this.employeeForm.value);
    this.employee = this.employeeForm.value
    this.employeeRoles = this.employeeForm.get('employeeRoles')?.value;

    console.log("employee----- ", this.employee, "role-----", this.employeeRoles)

    for (let i = 0; i < this.employeeRoles.length; i++) {

      this.employeeRolePostModel.roleId = Number(this.employeeRoles[i].roleName)

      this.employeeRolePostModel.entryDate = this.employeeRoles[i].entryDate

      this.employeeRolePostModel.isManagementRole = this.employeeRoles[i].isManagementRole
      this.employeeRoleResult.push(this.employeeRolePostModel)
    }
    this.employee.employeeRoles = this.employeeRoleResult

    this.employee.maleOrFmale = false;
    if (this.employeeForm.get('maleOrFmale')?.value == "male") {
      this.employee.maleOrFmale = true;
    }
    this.foundCompanyIdFromToken()
    this.employee.companyId=Number(this.companyId)
    console.log("employee before send-----", this.employee)
    this._employeeService.addEmployee(this.employee).subscribe({
      next: (res) => {
        console.log("res----add employee", res)
        // this.employee=res;
        const dialogRef = this.dialog.open(DialogMessegeComponent, {
          width: '250px',
          data: "Employee added successfully!!"
        });
        this.router.navigate(["employee-list"]);

      },
      error: (err) => {
        console.error(err)
        // const dialogRef = this.dialog.open(DialogMessegeComponent, {
        //   width: '250px',
        //   data: "its was error on add employee!!"
        // })
        
      //   const dialogRef = this.dialog.open(DialogMessegeComponent, {
      //     width: '250px',
      //     data: "you don't have permission to access!! move to login!"
      //   })
      // dialogRef.afterClosed().subscribe((result: any) => {
      //   console.log('The dialog was closed');
      //   this.toLoginPage()
      // });
      if (err.status === 403) {
        const dialogRef = this.dialog.open(DialogMessegeComponent, {
          width: '250px',
          data: "you don't have permission to access!! move to login!"
        })
        dialogRef.afterClosed().subscribe((result: any) => {
          console.log('The dialog was closed');
          this.toLoginPage()
        });
      }
      else{
        const dialogRef = this.dialog.open(DialogMessegeComponent, {
          width: '250px',
          data: "you don't have error on add employee"
        })
        dialogRef.afterClosed().subscribe((result: any) => {
          console.log('The dialog was closed');
        });
      }
       }
    })
    // Call API or perform further actions
    console.log("employee after send-----", this.employee)
  }
  toLoginPage() {
    this.router.navigate(["login"]);
  }
  startDateBeforeEntryDateValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const startDate = this.employeeForm.get('startDate');
    const entryDate = control.value;

    // Check if both startDate and entryDate are valid and entryDate is after startDate
    if (startDate && startDate.value && entryDate && entryDate > startDate.value) {
      return null; // Valid
    } else {
      return { 'startDateBeforeEntryDate': true }; // Invalid
    }
  }
  roleNameNotDuplicateValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const employeeRoles = control.value as { roleName: string }[];
    const roleNameSet = new Set();
    for (const role of employeeRoles) {
      if (roleNameSet.has(role.roleName)) {
        return { 'roleNameDuplicate': true };
      }
      roleNameSet.add(role.roleName);
    }
    return null;
  }
  roleNameValidator(index: number) {
    return (control: AbstractControl): { [key: string]: any } | null => {
      const selectedRoleNames = this.employeeRolesFormArray.value.map((role: { roleName: string }) => role.roleName);
      const roleName = control.value;
      if (selectedRoleNames.slice(0, index).includes(roleName) || selectedRoleNames.slice(index + 1).includes(roleName)) {
        return { 'roleNameDuplicate': true };
      }
      return null;
    };
  }
  identityFormatValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const identityRegex = /^\d{9}$/; // Adjust this regex according to your identity format
    return identityRegex.test(control.value) ? null : { 'invalidIdentityFormat': true };
  }
  dateOfBirthValidator(control: AbstractControl): { [key: string]: boolean } | null {
    this.dateOfBirth = new Date(control.value);
    const currentDate = new Date();
    const minDateOfBirth = new Date();
    minDateOfBirth.setFullYear(currentDate.getFullYear() - 18);

    if (this.dateOfBirth > currentDate || this.dateOfBirth > minDateOfBirth) {
      return { 'invalidDateOfBirth': true };
    }
    return null;
  }

  entryDateValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const startDate = control.parent?.get('startDate')?.value;
    const entryDate = control.value;
    return startDate && entryDate && entryDate >= startDate ? null : { 'entryDateBeforeStartDate': true };
  }
  startDateValidator(control: AbstractControl): { [key: string]: any } | null {
    const selectedDate = control.value;

    if (selectedDate && this.employeeForm && this.employeeForm.get('dateOfBirth')) {
      const currentDate = new Date();
      const selectedDateObj = new Date(selectedDate);

      const dobControl = this.employeeForm.get('dateOfBirth');

      // Check if dobControl is defined and has a value
      if (dobControl && dobControl.value) {
        const birthDate = new Date(dobControl.value);
        const minAgeDate: Date = new Date(birthDate.getFullYear() + 18, birthDate.getMonth(), birthDate.getDate());

        // Check if the selected date is greater than the current date
        if (selectedDateObj > currentDate) {
          return { futureDate: true }; // Return error if the selected date is in the future
        }

        // Check that the age is greater than 18
        // const ageDiff = currentDate.getFullYear() - dob.getFullYear();
        if (selectedDateObj < minAgeDate) {
          return { underAge: true }; // Return error if age is less than 18
        }
      }
    }
    return null; // If the date passes all checks, return null (valid)
  }


  filterRoles() {
    // Get selected role IDs
    const selectedRoleIds = this.employeeRolesFormArray.controls.map(control => control.get('roleName')?.value);
    // Filter the roles list to exclude already selected roles
    this.newRoleList = this.rolesList.filter(role => !selectedRoleIds.includes(role.id));
  }
  filteredRoles(index: number): Role[] {
    if (!this.employeeRolesFormArray||!this.rolesList) {
      return [];
    }
    const selectedRoles = this.employeeRolesFormArray.controls
      .filter((control, i) => i !== index) // סנן את התפקידים שאינם שווים לאינדקס שנמצא בפרמטר
      .map(roleGroup => roleGroup.get('roleName')?.value);
    return this.rolesList.filter(role => !selectedRoles.includes(role.id));
  }
}
