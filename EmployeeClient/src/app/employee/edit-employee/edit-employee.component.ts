import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Employee } from '../../entities/employee.entites';
import { Role } from '../../entities/role.entites';
import { RoleService } from '../../role/role.service';
import { EmployeeService } from '../employee.service';

import { MdbAccordionModule } from 'mdb-angular-ui-kit/accordion';
import { MdbCarouselModule } from 'mdb-angular-ui-kit/carousel';
import { MdbCheckboxModule } from 'mdb-angular-ui-kit/checkbox';
import { MdbCollapseModule } from 'mdb-angular-ui-kit/collapse';
import { MdbDropdownModule } from 'mdb-angular-ui-kit/dropdown';
import { MdbFormsModule } from 'mdb-angular-ui-kit/forms';
import { MdbModalModule } from 'mdb-angular-ui-kit/modal';
import { MdbPopoverModule } from 'mdb-angular-ui-kit/popover';
import { MdbRadioModule } from 'mdb-angular-ui-kit/radio';
import { MdbRangeModule } from 'mdb-angular-ui-kit/range';
import { MdbRippleModule } from 'mdb-angular-ui-kit/ripple';
import { MdbScrollspyModule } from 'mdb-angular-ui-kit/scrollspy';
import { MdbTabsModule } from 'mdb-angular-ui-kit/tabs';
import { MdbTooltipModule } from 'mdb-angular-ui-kit/tooltip';
import { MdbValidationModule } from 'mdb-angular-ui-kit/validation';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-edit-employee',
  standalone: true,
  imports: [
    MdbAccordionModule,
    MdbCarouselModule,
    MdbCheckboxModule,
    MdbCollapseModule,
    MdbDropdownModule,
    MdbFormsModule,
    MdbModalModule,
    MdbPopoverModule,
    MdbRadioModule,
    MdbRangeModule,
    MdbRippleModule,
    MdbScrollspyModule,
    MdbTabsModule,
    MdbTooltipModule,
    MdbValidationModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatDatepickerModule,
    MatNativeDateModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.scss'
})
export class EditEmployeeComponent implements OnInit{
  public employeeForm!: FormGroup;
  public employee: Employee = new Employee();
  public rolesList!: Role[];
  employeeId: any;
  constructor(
    // public dialogRef: MatDialogRef<AddEmployeeComponent>,
    // @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private _employeeService: EmployeeService,
    private _roleServices: RoleService,
    private fb: FormBuilder // Inject FormBuilder
    ,public dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router
  ) { }


  ngOnInit(): void {
    // this.employeeId = this.route.snapshot.paramMap.get('id');
    this.route.params.subscribe((param) => {
      this.employeeId = param['identity'];
      
     // Assuming you're passing employee ID via route
     console.log("employeeId", this.employeeId)
    this._employeeService.getEmployeeById(this.employeeId).subscribe({
      next: (res) => {
        this.employee = res;
        console.log("employee", this.employee)
        this.initializeForm();
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

  initializeForm(): void {
    this.employeeForm = this.fb.group({
      firstName: [this.employee.firstName, Validators.required],
      lastName: [this.employee.lastName, Validators.required],
      identity: [this.employee.identity, Validators.required],
      startDate: [this.employee.startDate, Validators.required],
      dateOfBirth: [this.employee.dateOfBirth, Validators.required],
      maleOrFmale: [this.employee.maleOrFmale ? "0" : "1", Validators.required], // Assuming maleOrFmale is a boolean
      employeeRoles: this.fb.array(this.initializeRoles())
    });
  }

  initializeRoles(): FormGroup[] {
    return this.employee.employeeRoles.map(role => {
      return this.fb.group({
        roleName: [role.roleName, Validators.required],
        isManagementRole: [role.isManagementRole ? "0" : "1", Validators.required], // Assuming isManagementRole is a boolean
        entryDate: [role.entryDate, Validators.required]
      });
    });
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

}
