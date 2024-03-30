import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { Employee } from '../../entities/employee.entites';
import { CommonModule } from '@angular/common';


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


import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
import {
  MatDialog,
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule,
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
  
    MatIconModule, MatButtonModule,
    MatFormFieldModule, MatInputModule, FormsModule
  
  ],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent implements OnInit{
  public employeeList!:Employee[]
  public filteredEmployeeList: Employee[] = [];

  name: any;
  animal: any;
  constructor(private _employeeService:EmployeeService,public dialog: MatDialog){}
  ngOnInit(): void {
    console.log("start")
    this.getEmployeeList()
  }
  getEmployeeList(){
    this._employeeService.getEmployeeList().subscribe({
      next:(res)=>{
        console.log("res",res)
        this.employeeList=res;
        this.getFilteredEmployeeList()
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }
  getFilteredEmployeeList(): void {
    this._employeeService.getEmployeeList().subscribe({
      next: (res: Employee[]) => {
        this.filteredEmployeeList = [];
        res.forEach(employee => {
          if (employee.status) {
            this.filteredEmployeeList.push(employee); // Add employee to the filtered list if status is true
          }
        });
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
  editEmployee(employee:Employee){

  }
  deleteEmployee(employee:Employee){
    Swal.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#3085d6",
      cancelButtonColor: "#d33",
      confirmButtonText: "Yes, delete it!"
    }).then((result) => {
      if (result.isConfirmed) {
        this._employeeService.deleteEmployee(employee).subscribe({
          next:(res)=>{
            console.log("res",res)
            this.getFilteredEmployeeList()
            Swal.fire({
              title: "Deleted!",
              text: "Your file has been deleted.",
              icon: "success"
            });
          },
          error:(err)=>{
            console.log(err)
          }
        })
      }
    });
    
  }


  addEmployee(): void {
    const dialogRef = this.dialog.open(AddEmployeeComponent, {
      data: {name: this.name, animal: this.animal},
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      console.log('The dialog was closed');
      this.animal = result;
      this.getEmployeeList()
    });
  }
}
