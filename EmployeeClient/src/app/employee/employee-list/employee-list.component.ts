import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
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
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
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

import { AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import { DeleteEmployeeDialogComponent } from '../../errors-dialog/delete-employee-dialog/delete-employee-dialog.component';
import { DialogMessegeComponent } from '../../errors-dialog/dialog-messege/dialog-messege.component';
import * as XLSX from 'xlsx';
import { Employee } from '../../classes/entities/employee.entites';
import { EditEmployeeDialogComponent } from '../edit-employee-dialog/edit-employee-dialog.component';

export interface UserData {
  id: string;
  name: string;
  progress: string;
  fruit: string;
}

/** Constants used to fill up our data base. */
const FRUITS: string[] = [
  'blueberry',
  'lychee',
  'kiwi',
  'mango',
  'peach',
  'lime',
  'pomegranate',
  'pineapple',
];
const NAMES: string[] = [
  'Maia',
  'Asher',
  'Olivia',
  'Atticus',
  'Amelia',
  'Jack',
  'Charlotte',
  'Theodore',
  'Isla',
  'Oliver',
  'Isabella',
  'Jasper',
  'Cora',
  'Levi',
  'Violet',
  'Arthur',
  'Mia',
  'Thomas',
  'Elizabeth',
];

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
    MatFormFieldModule, MatInputModule, FormsModule,
    MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule

  ],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent implements OnInit {
  displayedColumns: string[] = ['firstName', 'lastName', 'identity', 'startDate', 'actions'];
  dataSource: MatTableDataSource<Employee>;

  filteredEmployeeList: Employee[] = [];

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  employeeList!: Employee[];
  employeeFromEdit: any;

  // constructor(private _employeeService: EmployeeService, public dialog: MatDialog) {
  //   this.dataSource = new MatTableDataSource<Employee>();
  // }

  // ngOnInit(): void {
  //   this.getFilteredEmployeeList(); // Initial call to fetch data
  // }
  exportToExcel(): void {
    const data: any[] = this.dataSource.filteredData.map((employee: Employee) => {
      return {
        'First Name': employee.firstName,
        'Last Name': employee.lastName,
        'Identity': employee.identity,
        'Start Date': employee.startDate || 'N/A', // Provide a default value if startDate is empty
      };
    });

    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Employees');

    // Generate a file name
    const fileName = 'employees.xlsx';

    // Save the file
    XLSX.writeFile(wb, fileName);
  }

  getFilteredEmployeeList(): void {
    this._employeeService.getEmployeeList().subscribe({
      next: (res: Employee[]) => {
        this.filteredEmployeeList = res.filter(employee => employee.status);
        this.dataSource.data = this.filteredEmployeeList;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  // applyFilter(event: Event) {
  //   const filterValue = (event.target as HTMLInputElement).value;
  //   this.dataSource.filter = filterValue.trim().toLowerCase();

  //   if (this.dataSource.paginator) {
  //     this.dataSource.paginator.firstPage();
  //   }
  // }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value.toLowerCase();

    this.dataSource.filter = filterValue.trim().toLowerCase();

    this.dataSource.filterPredicate = (data: Employee, filter: string) => {
      // Convert startDate to string before applying toLowerCase()
      const startDateString = data.startDate ? data.startDate.toString().toLowerCase() : '';

      // Check if the filter value is present in any of the fields
      return data.firstName.toLowerCase().includes(filter) ||
        data.lastName.toLowerCase().includes(filter) ||
        data.identity.toLowerCase().includes(filter) ||
        startDateString.includes(filter);
    };

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  // displayedColumns: string[] = ['id', 'name', 'progress', 'fruit'];
  // dataSource!: MatTableDataSource<UserData>;

  // @ViewChild(MatPaginator) paginator!: MatPaginator ;
  // @ViewChild(MatSort) sort!: MatSort ;


  // public employeeList!:Employee[]
  // public filteredEmployeeList: Employee[] = [];

  name: any;
  animal: any;
  constructor(private _employeeService: EmployeeService, public dialog: MatDialog, private router: Router) {
    this.dataSource = new MatTableDataSource<Employee>();
  }
  ngOnInit(): void {
    // Create 100 users
    const users = Array.from({ length: 100 }, (_, k) => createNewUser(k + 1));

    // Assign the data to the data source for the table to render
    //  this.dataSource = new MatTableDataSource(users);
    console.log("start")
    this.getEmployeeList()
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  // applyFilter(event: Event) {
  //   const filterValue = (event.target as HTMLInputElement).value;
  //   this.dataSource.filter = filterValue.trim().toLowerCase();

  //   if (this.dataSource.paginator) {
  //     this.dataSource.paginator.firstPage();
  //   }
  // }
  getEmployeeList() {
    this._employeeService.getEmployeeList().subscribe({
      next: (res) => {
        console.log("res", res)
        this.employeeList = res;
        this.getFilteredEmployeeList()
      },
      error: (err) => {
        console.log(err)
      }
    })
  }
  // getFilteredEmployeeList(): void {
  //   this._employeeService.getEmployeeList().subscribe({
  //     next: (res: Employee[]) => {
  //       this.filteredEmployeeList = [];
  //       res.forEach(employee => {
  //         if (employee.status) {
  //           this.filteredEmployeeList.push(employee); // Add employee to the filtered list if status is true
  //         }
  //       });
  //     },
  //     error: (err) => {
  //       console.log(err);
  //     }
  //   });
  // }
  editEmployee(employee: Employee) {
    // this.router.navigate(["edit-employee", employee.identity]);
    const dialogRef = this.dialog.open(EditEmployeeDialogComponent, {
      // data: { employee:employee },
      data: employee,
    });

    dialogRef.afterClosed().subscribe((result: any) => {
      console.log('The dialog was closed');
      this.employeeFromEdit = result;
      this.getEmployeeList()
    });
  

}
deleteEmployee(employee: Employee){
  const dialogRef = this.dialog.open(DeleteEmployeeDialogComponent, {
    width: '250px',
    data: employee.identity  // שם הקובץ שתרצה למחוק
  });

  dialogRef.afterClosed().subscribe(result => {
    if (result) {
      // אם נבחר למחוק
      console.log('User clicked Ok');
      this._employeeService.deleteEmployee(employee.identity).subscribe({
        next: (res) => {
          console.log("res", res)
          this.getFilteredEmployeeList()
          const dialogRef = this.dialog.open(DialogMessegeComponent, {
            width: '250px',
            data: "the employee has been deleted!!!"
          });
        },
        error: (err) => {
          console.log(err)
        }
      })
      // בצע את פעולת המחיקה כאן
    } else {
      // אם לא נבחר למחוק
      console.log('User clicked No');
      // לא עשה כלום או כל פעולה אחרת שתרצה
    }
  });
  // Swal.fire({
  //   title: "Are you sure?",
  //   text: "You won't be able to revert this!",
  //   icon: "warning",
  //   showCancelButton: true,
  //   confirmButtonColor: "#3085d6",
  //   cancelButtonColor: "#d33",
  //   confirmButtonText: "Yes, delete it!"
  // }).then((result) => {
  //   if (result.isConfirmed) {
  //     this._employeeService.deleteEmployee(employee.identity).subscribe({
  //       next:(res)=>{
  //         console.log("res",res)
  //         this.getFilteredEmployeeList()
  //         Swal.fire({
  //           title: "Deleted!",
  //           text: "Your file has been deleted.",
  //           icon: "success"
  //         });
  //       },
  //       error:(err)=>{
  //         console.log(err)
  //       }
  //     })
  //   }
  // });

}


addEmployee(): void {
  //   const dialogRef = this.dialog.open(AddEmployeeComponent, {
  //     data: {name: this.name, animal: this.animal},
  //   });

  //   dialogRef.afterClosed().subscribe((result: any) => {
  //     console.log('The dialog was closed');
  //     this.animal = result;
  //     this.getEmployeeList()
  //   });
  // }
  this.router.navigate(["add-employee"]);
}
  
}
/** Builds and returns a new User. */
function createNewUser(id: number): UserData {
  const name =
    NAMES[Math.round(Math.random() * (NAMES.length - 1))] +
    ' ' +
    NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) +
    '.';

  return {
    id: id.toString(),
    name: name,
    progress: Math.round(Math.random() * 100).toString(),
    fruit: FRUITS[Math.round(Math.random() * (FRUITS.length - 1))],
  };
}
