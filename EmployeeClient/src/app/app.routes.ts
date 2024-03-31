import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'employee-list', pathMatch: 'full' },
    { path: 'employee-list', loadComponent: () => import('./employee/employee-list/employee-list.component').then(c => c.EmployeeListComponent) },
    { path: 'add-employee', loadComponent: () => import('./employee/add-employee/add-employee.component').then(c => c.AddEmployeeComponent) },
    { path: 'edit-employee/:identity', loadComponent: () => import('./employee/edit-employee/edit-employee.component').then(c => c.EditEmployeeComponent) },

];
