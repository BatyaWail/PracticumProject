// import { Component, OnInit } from '@angular/core';
// import { CommonModule } from '@angular/common';
// import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
// import { MatInputModule } from '@angular/material/input';
// import { MatFormFieldModule } from '@angular/material/form-field';
// import { MatIconModule } from '@angular/material/icon';
// import { MatDatepickerModule } from '@angular/material/datepicker';
// import { MatNativeDateModule, MatOptionModule } from '@angular/material/core';
// import { ActivatedRoute, Router } from '@angular/router';
// import Swal from 'sweetalert2';
// import { Employee } from '../../entities/employee.entites';
// import { Role } from '../../entities/role.entites';
// import { RoleService } from '../../role/role.service';
// import { EmployeeService } from '../employee.service';

// import { MdbAccordionModule } from 'mdb-angular-ui-kit/accordion';
// import { MdbCarouselModule } from 'mdb-angular-ui-kit/carousel';
// import { MdbCheckboxModule } from 'mdb-angular-ui-kit/checkbox';
// import { MdbCollapseModule } from 'mdb-angular-ui-kit/collapse';
// import { MdbDropdownModule } from 'mdb-angular-ui-kit/dropdown';
// import { MdbFormsModule } from 'mdb-angular-ui-kit/forms';
// import { MdbModalModule } from 'mdb-angular-ui-kit/modal';
// import { MdbPopoverModule } from 'mdb-angular-ui-kit/popover';
// import { MdbRadioModule } from 'mdb-angular-ui-kit/radio';
// import { MdbRangeModule } from 'mdb-angular-ui-kit/range';
// import { MdbRippleModule } from 'mdb-angular-ui-kit/ripple';
// import { MdbScrollspyModule } from 'mdb-angular-ui-kit/scrollspy';
// import { MdbTabsModule } from 'mdb-angular-ui-kit/tabs';
// import { MdbTooltipModule } from 'mdb-angular-ui-kit/tooltip';
// import { MdbValidationModule } from 'mdb-angular-ui-kit/validation';
// import { MatDialog, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogTitle } from '@angular/material/dialog';

// import { MatExpansionModule } from '@angular/material/expansion';

// import { FormControlName, FormControl } from '@angular/forms';
// import { NgModule } from '@angular/core';
// import { MatButtonModule } from '@angular/material/button';
// import { MatRadioModule } from '@angular/material/radio';
// import { MatSelectModule } from '@angular/material/select';



// @Component({
//   selector: 'app-edit-employee',
//   standalone: true,
//   imports: [
//     FormsModule,
//     ReactiveFormsModule,
//     MdbAccordionModule,
//     MdbCarouselModule,
//     MdbCheckboxModule,
//     MdbCollapseModule,
//     MdbDropdownModule,
//     MdbFormsModule,
//     MdbModalModule,
//     MdbPopoverModule,
//     MdbRadioModule,
//     MdbRangeModule,
//     MdbRippleModule,
//     MdbScrollspyModule,
//     MdbTabsModule,
//     MdbTooltipModule,
//     MdbValidationModule,
//     CommonModule,
//     FormsModule,
//     ReactiveFormsModule,
//     MatInputModule,
//     MatFormFieldModule,
//     MatIconModule,
//     MatDatepickerModule,
//     MatNativeDateModule,
//     MatExpansionModule,


//     MatButtonModule,
//     MatDialogTitle,
//     MatDialogContent,
//     MatDialogActions,
//     MatDialogClose,

//     MatButtonModule,

//     MatSelectModule,
//     MatOptionModule,
//     MatRadioModule,
//   ],
//   templateUrl: './edit-employee.component.html',
//   styleUrl: './edit-employee.component.scss'
// })
// export class EditEmployeeComponent implements OnInit{
//   public employeeForm!: FormGroup
//   public employee: Employee = new Employee();
//   public employeResult!: Employee;
//   public rolesList!: Role[];
//   employeeId: any;
// employeeRoles: any;
//   constructor(
//     // public dialogRef: MatDialogRef<AddEmployeeComponent>,
//     // @Inject(MAT_DIALOG_DATA) public data: DialogData,
//     private _employeeService: EmployeeService,
//     private _roleServices: RoleService,
//     private fb: FormBuilder // Inject FormBuilder
//     ,public dialog: MatDialog,
//     private route: ActivatedRoute,
//     private router: Router
//   ) { }


//   ngOnInit(): void {

//     // this.employeeId = this.route.snapshot.paramMap.get('id');
//     this.route.params.subscribe((param) => {
//       this.employeeId = param['identity'];

//      // Assuming you're passing employee ID via route
//      console.log("employeeId", this.employeeId)
//     this._employeeService.getEmployeeById(this.employeeId).subscribe({
//       next: (res) => {
//         console.log("res", res) 
//         this.employeResult = res;
//         console.log("employee1111111", this.employeResult)
//         // this.initializeForm();
//         this.employeeForm = this.fb.group({
//           firstName: [this.employeResult.firstName, Validators.required],
//           lastName: [this.employeResult.lastName, Validators.required],
//           identity: [this.employeResult.identity, Validators.required],
//           startDate: [this.employeResult.startDate, Validators.required],
//           dateOfBirth: [this.employeResult.dateOfBirth, Validators.required],
//           maleOrFmale: [this.employeResult.maleOrFmale ? "0" : "1", Validators.required], // Assuming maleOrFmale is a boolean
//           employeeRoles: this.fb.array(this.initializeRoles())
//         });
//       },
//       error: (error) => {
//         console.error(error);
//         // Handle error appropriately
//       }
//     });
//   });

//     this._roleServices.getAllRoles().subscribe({
//       next: (roles) => {
//         this.rolesList = roles;
//       },
//       error: (error) => {
//         console.error(error);
//         // Handle error appropriately
//       }
//     });
//   }
//   step = 0;

//   setStep(index: number) {
//     this.step = index;
//   }
//   initializeForm(): void {
//     this.employeeForm = this.fb.group({
//       firstName: [this.employee.firstName, Validators.required],
//       lastName: [this.employee.lastName, Validators.required],
//       identity: [this.employee.identity, Validators.required],
//       startDate: [this.employee.startDate, Validators.required],
//       dateOfBirth: [this.employee.dateOfBirth, Validators.required],
//       maleOrFmale: [this.employee.maleOrFmale ? "0" : "1", Validators.required], // Assuming maleOrFmale is a boolean
//       employeeRoles: this.fb.array(this.initializeRoles())
//     });
//   }

//   initializeRoles(): FormGroup[] {
//     return this.employeResult.employeeRoles.map(role => {
//       return this.fb.group({
//         roleName: [role.roleName, Validators.required],
//         isManagementRole: [role.isManagementRole ? "0" : "1", Validators.required], // Assuming isManagementRole is a boolean
//         entryDate: [role.entryDate, Validators.required]
//       });
//     });
//   }

//   updateEmployee(): void {
//     if (this.employeeForm.valid) {
//       const updatedEmployee: Employee = this.employeeForm.value;
//       // Perform any necessary formatting or adjustments to the data before sending it to the service
//       this._employeeService.updateEmployee(updatedEmployee).subscribe({
//         next: (res) => {
//           // Handle success response
//           Swal.fire('Success', 'Employee updated successfully', 'success');
//         },
//         error: (error) => {
//           console.error(error);
//           // Handle error appropriately
//           Swal.fire('Error', 'Failed to update employee', 'error');
//         }
//       });
//     } else {
//       // Form is invalid, display error message or take appropriate action
//       Swal.fire('Error', 'Please fill out all required fields', 'error');
//     }
//   }

// }
import { Component, Inject, OnInit, QueryList, ViewChildren } from '@angular/core';
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
import { AbstractControl, FormArray, FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { ActivatedRoute } from '@angular/router';
import { DialogMessegeComponent } from '../../errors-dialog/dialog-messege/dialog-messege.component';
import { Employee } from '../../classes/entities/employee.entites';
import { Role } from '../../classes/entities/role.entites';
import { EmployeeRolePostModel } from '../../classes/postModel/employeeRole.postModel';


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
    MatRadioModule, ReactiveFormsModule
  ],
  providers: [provideNativeDateAdapter()],

  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.scss'
})
export class EditEmployeeComponent implements OnInit {

  public employeeForm!: FormGroup; // Define FormGroup
  public employee: Employee = new Employee()
  public rolesList!: Role[]
  public newRoleList!: Role[]
  employeeRoles: { roleName: string, isManagementRole: string, entryDate: Date | null }[] = [{ roleName: '', isManagementRole: '', entryDate: null }];
  employeeRoleResult: EmployeeRolePostModel[] = []
  employeeToUpdate:Employee=new Employee()

  @ViewChildren(MatDatepicker)
  entryDatePickers!: QueryList<MatDatepicker<any>>;
  employeeRolePostModel: EmployeeRolePostModel = new EmployeeRolePostModel()
  validationErrors: string[] = []; // Array to store validation errors
  employeeId: any;
  // public employeResult!: Employee;


  constructor(
    // public dialogRef: MatDialogRef<AddEmployeeComponent>,
    // @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private _employeeService: EmployeeService,
    private _roleServices: RoleService,
    private fb: FormBuilder // Inject FormBuilder
    , public dialog: MatDialog,
    private route: ActivatedRoute,

  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((param) => {
      this.employeeId = param['identity'];
      // Assuming you're passing employee ID via route
      console.log("employeeId", this.employeeId)
      this._employeeService.getEmployeeById(this.employeeId).subscribe({
        next: (res) => {
          console.log("res", res)
          this.employee = res;
          console.log("employee1111111", this.employee)
          console.log("employee.firstName", this.employee.firstName)
          let firstName=this.employee.firstName
          let lastName=this.employee.lastName
          console.log("firstName", firstName, "lastName", lastName)
          console.log("employee.lastName", this.employee.lastName)
          this.initializeForm();
          // this.employeeForm.get('data').setValue(dataFormControlArray);
          this.employeeForm.get('firstName')?.setValue(firstName);
          this.employeeForm.get('lastName')?.setValue(lastName);

        },
        error: (error) => {
          console.error(error);
          // Handle error appropriately
        }
      });
    });

    this._roleServices.getAllRoles().subscribe({
      next: (roles) => {
        this.rolesList = roles;
      },
      error: (error) => {
        console.error(error);
        // Handle error appropriately
      }
    });
  }
  initializeForm(){
    this.employeeForm = this.fb.group({
      identity: [this.employee.identity, Validators.required],
      firstName: [this.employee.firstName, Validators.required],
      lastName: [this.employee.lastName, Validators.required],
      startDate: [this.employee.startDate, Validators.required],
      dateOfBirth: [this.employee.dateOfBirth, Validators.required],
      maleOrFmale: [this.employee.maleOrFmale ? "0" : "1", Validators.required], // Assuming maleOrFmale is a boolean
      employeeRoles: this.fb.array(this.initializeRoles())
    });
  }
  initializeRoles(): FormGroup[] {
    return this.employee.employeeRoles.map(role => {
      return this.fb.group({
        roleName: [role.roleId, Validators.required],
        isManagementRole: [role.isManagementRole ? "0" : "1", Validators.required], // Assuming isManagementRole is a boolean
        entryDate: [role.entryDate, Validators.required]
      });
    });
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

  addRole() {
    const roleFormGroup = this.fb.group({
      roleName: ['', [Validators.required, this.roleNameValidator(this.employeeRolesFormArray.length)]], // Apply custom validator
      isManagementRole: ['', Validators.required],
      entryDate: [null, [Validators.required, this.startDateBeforeEntryDateValidator.bind(this)]]
    });
    this.employeeRolesFormArray.push(roleFormGroup);
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

    // this.onNoClick();

  }
  updateEmployee(): void {
    if (this.employeeForm.valid) {
      const updatedEmployee: Employee = this.employeeForm.value;
      // Perform any necessary formatting or adjustments to the data before sending it to the service
      this._employeeService.updateEmployee(updatedEmployee).subscribe({
        next: (res) => {
          // Handle success response
          Swal.fire('Success', 'Employee updated successfully', 'success');
        },
        error: (error) => {
          console.error(error);
          // Handle error appropriately
          Swal.fire('Error', 'Failed to update employee', 'error');
        }
      });
    } else {
      // Form is invalid, display error message or take appropriate action
      Swal.fire('Error', 'Please fill out all required fields', 'error');
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
    this.employeeToUpdate = this.employeeForm.value
    this.employeeRoles = this.employeeForm.get('employeeRoles')?.value;

    console.log("employee----- ", this.employeeToUpdate, "role-----", this.employeeRoles)
    for (let i = 0; i < this.employeeRoles.length; i++) {
      this.employeeRolePostModel.roleId=Number(this.employeeRoles[i].roleName)
      console.log("employPostModel.roleId----", this.employeeRolePostModel.roleId)

        // if (this.employeeRoles[i].roleName == this.rolesList[j].roleName) {
        //   this.employeeRolePostModel.roleId = this.rolesList[j].id
          this.employeeRolePostModel.entryDate = this.employeeRoles[i].entryDate
          this.employeeRolePostModel.isManagementRole = false;
          if (this.employeeRoles[i].isManagementRole == "1") {
            this.employeeRolePostModel.isManagementRole = true;
          }
          this.employeeRoleResult.push(this.employeeRolePostModel)

      
        
      }
    console.log("this.employeeRoleResult----", this.employeeRoleResult)
    this.employeeToUpdate.employeeRoles = this.employeeRoleResult
    this.employeeToUpdate.maleOrFmale=this.employee.maleOrFmale
    if (this.employeeForm.get('maleOrFmale')?.value == "0") {
      this.employeeToUpdate.maleOrFmale = true;
    }
    console.log("employee before send-----", this.employeeToUpdate)
    this._employeeService.updateEmployee(this.employeeToUpdate).subscribe({
      next: (res) => {
        console.log("res----update employee", res)
        // Swal.fire('Success', 'Employee updated successfully', 'success');},
        const dialogRef = this.dialog.open(DialogMessegeComponent, {
          width: '250px',
          data: "Employee updated successfully!!"
        });
        
      },
      error: (err) => {
        console.error(err)
        const dialogRef = this.dialog.open(DialogMessegeComponent, {
          width: '250px',
          data: "its was error on update employee!!"
        });
      }
    })
    console.log("employee after send-----", this.employee)
  }
}

