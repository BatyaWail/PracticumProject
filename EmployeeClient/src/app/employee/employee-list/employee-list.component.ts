// import { Component, OnInit } from '@angular/core';
// import { EmployeeService } from '../employee.service';
// import { CommonModule } from '@angular/common';


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


// import { MatIconModule } from '@angular/material/icon';
// import { MatButtonModule } from '@angular/material/button';
// import { FormsModule } from '@angular/forms';
// import { MatInputModule } from '@angular/material/input';
// import { MatFormFieldModule } from '@angular/material/form-field';
// import { AddEmployeeComponent } from '../add-employee/add-employee.component';
// import {
//   MatDialog,
//   MAT_DIALOG_DATA,
//   MatDialogRef,
//   MatDialogTitle,
//   MatDialogContent,
//   MatDialogActions,
//   MatDialogClose,
// } from '@angular/material/dialog';
// import Swal from 'sweetalert2';

// import { AfterViewInit, ViewChild } from '@angular/core';
// import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
// import { MatSort, MatSortModule } from '@angular/material/sort';
// import { MatTableDataSource, MatTableModule } from '@angular/material/table';
// import { Router } from '@angular/router';
// import { DeleteEmployeeDialogComponent } from '../../errors-dialog/delete-employee-dialog/delete-employee-dialog.component';
// import { DialogMessegeComponent } from '../../errors-dialog/dialog-messege/dialog-messege.component';
// import * as XLSX from 'xlsx';
// import { Employee } from '../../classes/entities/employee.entites';
// import { EditEmployeeDialogComponent } from '../edit-employee-dialog/edit-employee-dialog.component';

// export interface UserData {
//   id: string;
//   name: string;
//   progress: string;
//   fruit: string;
// }


// @Component({
//   selector: 'app-employee-list',
//   standalone: true,
//   imports: [CommonModule,
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

//     MatIconModule, MatButtonModule,
//     MatFormFieldModule, MatInputModule, FormsModule,
//     MatInputModule, MatTableModule, MatSortModule, MatPaginatorModule

//   ],
//   templateUrl: './employee-list.component.html',
//   styleUrl: './employee-list.component.scss'
// })
// export class EmployeeListComponent implements OnInit {
//   displayedColumns: string[] = ['firstName', 'lastName', 'identity', 'startDate', 'actions'];
//   dataSource: MatTableDataSource<Employee>;

//   filteredEmployeeList: Employee[] = [];

//   @ViewChild(MatPaginator) paginator!: MatPaginator;
//   @ViewChild(MatSort) sort!: MatSort;
//   employeeList!: Employee[];
//   employeeFromEdit: any;
//   token: any;
//   companyId: any;
//   filterEmployeeByCompanyId!:Employee[]

//   getFilteredEmployeeList(): void {
//     this._employeeService.getEmployeeList().subscribe({
//       next: (res: Employee[]) => {
//         this.filteredEmployeeList = res.filter(employee => employee.status);
//         this.dataSource.data = this.filteredEmployeeList;
//         this.dataSource.paginator = this.paginator;
//         this.dataSource.sort = this.sort;
//       },
//       error: (err) => {
//         console.log(err);
//       }
//     });
//   }

//   applyFilter(event: Event) {
//     const filterValue = (event.target as HTMLInputElement).value.toLowerCase();
//     this.dataSource.filter = filterValue.trim().toLowerCase();
//     this.dataSource.filterPredicate = (data: Employee, filter: string) => {
//       const startDateString = data.startDate ? data.startDate.toString().toLowerCase() : '';
//       // Check if the filter value is present in any of the fields
//       return data.firstName.toLowerCase().includes(filter) ||
//         data.lastName.toLowerCase().includes(filter) ||
//         data.identity.toLowerCase().includes(filter) ||
//         startDateString.includes(filter);
//     };

//     if (this.dataSource.paginator) {
//       this.dataSource.paginator.firstPage();
//     }
//   }

//   name: any;
//   animal: any;
//   constructor(private _employeeService: EmployeeService, public dialog: MatDialog, private router: Router) {
//     this.dataSource = new MatTableDataSource<Employee>();
//   }
//   ngOnInit(): void {
//     this.foundCompanyIdFromToken()

//     console.log("start")
//     this.getEmployeeList()
//   }
//   ngAfterViewInit() {
//     this.dataSource.paginator = this.paginator;
//     this.dataSource.sort = this.sort;
//   }
//   filterEmployeesByCompanyId() {
//     this.filterEmployeeByCompanyId = this.employeeList.filter(employee => employee.companyId === this.companyId);
//   }
//   getEmployeeList() {
//     this._employeeService.getEmployeeList().subscribe({
//       next: (res) => {
//         console.log("res", res)
//         this.employeeList = res;
//         this.getFilteredEmployeeList()
//         this.filterEmployeeByCompanyId()
//       },
//       error: (err) => {
//         console.log(err)
//       }
//     })
//   }

//   foundCompanyIdFromToken() {
//     this.token = sessionStorage.getItem('token');

//     if (this.token) {
//       // Decode the token
//       try {
//         const tokenPayload: any = JSON.parse(atob(this.token.split('.')[1]));
//         // Access the id property
//         if (tokenPayload && typeof tokenPayload === 'object' && 'id' in tokenPayload) {
//           this.companyId = tokenPayload.id;
//           console.log("Company ID:", this.companyId);
//         } else {
//           console.error("Invalid token format or missing id property");
//         }
//       } catch (error) {
//         console.error("Error decoding token:", error);
//       }
//     } else {
//       console.error("Token not found in sessionStorage");
//     }
//   }

//   // פונקציה זו מקבלת רשימה של עובדים ומפילטרת אותם כך שרק עובדים שה- companyId שלהם שווה ל- companyId הנוכחי יוצגו
//   // filterEmployees(employees: Employee[]): Employee[] {
//   //   return employees.filter(employee => employee.companyId === this.companyId);
//   // }

//   // applyCompanyFilter(event: Event) {
//   //   const filterValue = (event.target as HTMLInputElement).value;
//   //   this.dataSource.filter = filterValue.trim().toLowerCase();
//   //   this.dataSource.data = this.filterEmployees(this.dataSource.filteredData);
//   // }


//   // בפונקציה הזו אנו קוראים לפונקציה הקודמת לפני פילטור הנתונים בטבלה
//   // applyCompanyIdFilter(event: Event) {
//   //   const filterValue = (event.target as HTMLInputElement).value;
//   //   this.dataSource.filter = filterValue.trim().toLowerCase();
//   //   this.dataSource.data = this.filterEmployees(this.dataSource.filteredData);
//   // }
//   exportToExcel(): void {
//     const data: any[] = this.dataSource.filteredData.map((employee: Employee) => {
//       return {
//         'First Name': employee.firstName,
//         'Last Name': employee.lastName,
//         'Identity': employee.identity,
//         'Start Date': employee.startDate || 'N/A', // Provide a default value if startDate is empty
//       };
//     });

//     const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(data);
//     const wb: XLSX.WorkBook = XLSX.utils.book_new();
//     XLSX.utils.book_append_sheet(wb, ws, 'Employees');

//     // Generate a file name
//     const fileName = 'employees.xlsx';

//     // Save the file
//     XLSX.writeFile(wb, fileName);
//   }
//   editEmployee(employee: Employee) {
//     // this.router.navigate(["edit-employee", employee.identity]);
//     const dialogRef = this.dialog.open(EditEmployeeDialogComponent, {
//       // data: { employee:employee },
//       data: employee,
//     });

//     dialogRef.afterClosed().subscribe((result: any) => {
//       console.log('The dialog was closed');
//       this.employeeFromEdit = result;
//       this.getEmployeeList()
//     });


//   }
//   deleteEmployee(employee: Employee) {
//     const dialogRef = this.dialog.open(DeleteEmployeeDialogComponent, {
//       width: '250px',
//       data: employee.identity  // שם הקובץ שתרצה למחוק
//     });

//     dialogRef.afterClosed().subscribe(result => {
//       if (result) {
//         // אם נבחר למחוק
//         console.log('User clicked Ok');
//         this._employeeService.deleteEmployee(employee.identity).subscribe({
//           next: (res) => {
//             console.log("res", res)
//             this.getFilteredEmployeeList()
//             const dialogRef = this.dialog.open(DialogMessegeComponent, {
//               width: '250px',
//               data: "the employee has been deleted!!!"
//             });
//           },
//           error: (err) => {
//             console.log(err)
//           }
//         })
//         // בצע את פעולת המחיקה כאן
//       } else {
//         // אם לא נבחר למחוק
//         console.log('User clicked No');
//         // לא עשה כלום או כל פעולה אחרת שתרצה
//       }
//     });
//   }
//   addEmployee(): void {
//     this.router.navigate(["add-employee"]);
//   }

// }

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

import { DatePipe } from '@angular/common';
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

  filteredStatusEmployeeList: Employee[] = [];
  filteredCompanyIdEmployeeList: Employee[] = [];
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  employeeList!: Employee[];
  employeeFromEdit: any;
  token: any;
  companyId: any;


  // getStatusFilteredEmployeeList(): void {
  //   this._employeeService.getEmployeeList().subscribe({
  //     next: (res: Employee[]) => {
  //       this.filteredStatusEmployeeList = res.filter(employee => employee.status);
  //       this.dataSource.data = this.filteredStatusEmployeeList;
  //       this.dataSource.paginator = this.paginator;
  //       this.dataSource.sort = this.sort;
  //     },
  //     error: (err) => {
  //       console.log(err);
  //     }
  //   });

  //   this.filteredStatusEmployeeList = this.employeeList.filter(employee => employee.status);
  //   this.dataSource.data = this.filteredStatusEmployeeList;
  //   this.dataSource.paginator = this.paginator;
  //   this.dataSource.sort = this.sort;

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
  constructor(private _employeeService: EmployeeService, public dialog: MatDialog, private router: Router) {
    this.dataSource = new MatTableDataSource<Employee>();
  }
  ngOnInit(): void {
    console.log("start")
    setTimeout(() => {
      this.getEmployeeList()
      // כאן תוכל להפעיל פעולה לאחר מספר שניות
    }, 1000); // לדוגמה, מחכה 5 שניות

  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  getEmployeeList() {
    this.foundCompanyIdFromToken()
    this._employeeService.getEmployeeList().subscribe({
      next: (res) => {
        console.log("res", res)
        this.employeeList = res;
        // this.getStatusFilteredEmployeeList()
        this.employeeList = res.filter(employee => employee.status && employee.companyId === Number(this.companyId));
        this.dataSource.data = this.employeeList;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        // this.filterEmployeesByCompanyId()
      },
      error: (err) => {
        console.log(err)
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
            data: "its error on get-employee-list"
          })
          dialogRef.afterClosed().subscribe((result: any) => {
            console.log('The dialog was closed');
          });
        }
      }
    })

  }
  filterEmployeesByCompanyId() {
    console.log("this.companyId", this.companyId)
    this.employeeList = this.employeeList.filter(employee => employee.companyId === Number(this.companyId));
    console.log("this.employeeList", this.employeeList)
  }
  foundCompanyIdFromToken() {
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
  toLoginPage() {
    this.router.navigate(['/login']);
  }
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
  deleteEmployee(employee: Employee) {
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
            // this.getStatusFilteredEmployeeList()
            this.getEmployeeList()
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
  }
  addEmployee(): void {
    this.router.navigate(["add-employee"]);
  }
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

}

