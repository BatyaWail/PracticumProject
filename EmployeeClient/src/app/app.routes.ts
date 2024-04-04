import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', redirectTo: 'employee-list', pathMatch: 'full' },
    { path: 'employee-list', loadComponent: () => import('./employee/employee-list/employee-list.component').then(c => c.EmployeeListComponent) },
    { path: 'add-employee', loadComponent: () => import('./employee/add-employee/add-employee.component').then(c => c.AddEmployeeComponent) },
    { path: 'edit-employee/:identity', loadComponent: () => import('./employee/edit-employee/edit-employee.component').then(c => c.EditEmployeeComponent) },
    {path:'about-us',loadComponent:()=>import('./about-us/about-us.component').then(c=>c.AboutUsComponent)},
    {path:'login',loadComponent:()=>import('./loginJwt/login/login.component').then(c=>c.LoginComponent)},
    {path:'**',loadComponent:()=>import('./not-found/not-found.component').then(c=>c.NotFoundComponent)}

];
