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
import { AbstractControl, FormArray, FormsModule, ReactiveFormsModule, ValidatorFn } from '@angular/forms';
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
    MatCardModule
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
  employeeRoles: { roleName: string, isManagementRole: string, entryDate: Date | null }[] = [{ roleName: '', isManagementRole: '', entryDate: null }];
  employeeRoleResult: EmployeeRolePostModel[] = []

  @ViewChildren(MatDatepicker)
  entryDatePickers!: QueryList<MatDatepicker<any>>;
  employeeRolePostModel: EmployeeRolePostModel = new EmployeeRolePostModel()
  validationErrors: string[] = []; // Array to store validation errors
  @ViewChild(MatAccordion) accordion!: MatAccordion;


  constructor(
    // public dialogRef: MatDialogRef<AddEmployeeComponent>,
    // @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private _employeeService: EmployeeService,
    private _roleServices: RoleService,
    private fb: FormBuilder // Inject FormBuilder
    , public dialog: MatDialog,
    private router: Router
  ) { }
  ngOnInit(): void {
    this._roleServices.getAllRoles().subscribe({
      next: (res) => {
        console.log("res", res)
        this.rolesList = res;
      },
      error: (err) => {
        console.log(err)
      }
    })
    this.employeeForm = this.fb.group({ // Initialize FormGroup
      identity: ['', [Validators.required, Validators.minLength(9), Validators.maxLength(9), this.identityFormatValidator]],
      firstName: ['', Validators.required], // Define FormControls with initial values and validators
      lastName: ['', Validators.required],
      maleOrFmale: ['', Validators.required],
      dateOfBirth: [null, [Validators.required, this.dateOfBirthValidator.bind(this)]],
      startDate: [null, [Validators.required, this.startDateValidator]],
      employeeRoles: this.fb.array([], this.roleNameNotDuplicateValidator) // Initialize FormArray for employee roles

    });
    this.addRole()
    this.employee.employeeRoles = [];

  }
  addRole() {
    const roleFormGroup = this.fb.group({
      roleName: ['', [Validators.required, this.roleNameValidator(this.employeeRolesFormArray.length)]], // Apply custom validator
      isManagementRole: ['', Validators.required],
      entryDate: [null, [Validators.required, this.startDateBeforeEntryDateValidator.bind(this)]]
      // entryDate: [null, [Validators.required, this.entryDateValidator]]

    });
    this.employeeRolesFormArray.push(roleFormGroup);
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
    // this.employee.employeeRoles=new EmployeeRole()
    // let count = 0;
    for (let i = 0; i < this.employeeRoles.length; i++) {

      this.employeeRolePostModel.roleId = Number(this.employeeRoles[i].roleName)

      this.employeeRolePostModel.entryDate = this.employeeRoles[i].entryDate
      this.employeeRolePostModel.isManagementRole = false;
      if (this.employeeRoles[i].isManagementRole == "1") {
        this.employeeRolePostModel.isManagementRole = true;
      }
      this.employeeRoleResult.push(this.employeeRolePostModel)


    }


    this.employee.employeeRoles = this.employeeRoleResult
    // this.employee.dateOfBirth = this.employee.dateOfBirth.toISOString()
    // this.employee.startDate=this.
    this.employee.maleOrFmale = false;
    if (this.employeeForm.get('maleOrFmale')?.value == "0") {
      this.employee.maleOrFmale = true;
    }
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
        const dialogRef = this.dialog.open(DialogMessegeComponent, {
          width: '250px',
          data: "its was error on add employee!!"
        })
      }
    })
    // Call API or perform further actions
    console.log("employee after send-----", this.employee)

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
  // dateOfBirthValidator(control: AbstractControl): { [key: string]: boolean } | null {
  //   const selectedDate = new Date(control.value);
  //   const currentDate = new Date();
  //   return selectedDate <= currentDate ? null : { 'futureDateOfBirth': true };
  // }
  dateOfBirthValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const selectedDate = new Date(control.value);
    const currentDate = new Date();
    const minDateOfBirth = new Date();
    minDateOfBirth.setFullYear(currentDate.getFullYear() - 18);

    if (selectedDate > currentDate || selectedDate > minDateOfBirth) {
      return { 'invalidDateOfBirth': true };
    }
    return null;
  }
  startDateValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const selectedDate = new Date(control.value);
    const currentDate = new Date();
    return selectedDate >= currentDate ? null : { 'pastStartDate': true };
  }
  entryDateValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const startDate = control.parent?.get('startDate')?.value;
    const entryDate = control.value;
    return startDate && entryDate && entryDate >= startDate ? null : { 'entryDateBeforeStartDate': true };
  }
  // startDateValidator(control: AbstractControl): { [key: string]: boolean } | null {
  //   const selectedDate = new Date(control.value);
  //   const currentDate = new Date();
  //   const dateOfBirth = new Date(this.employeeForm.get('dateOfBirth')?.value);
  //   if (selectedDate < dateOfBirth || selectedDate < currentDate) {
  //     return { 'invalidStartDate': true };
  //   }
  //   return null;
  // }
  // startDateValidator(dateOfBirth: Date): ValidatorFn {
  //   return (control: AbstractControl): { [key: string]: boolean } | null => {
  //     const selectedDate = new Date(control.value);
  //     const currentDate = new Date();
  //     if (selectedDate < dateOfBirth || selectedDate < currentDate) {
  //       return { 'invalidStartDate': true };
  //     }
  //     return null;
  //   };
  // }
}
