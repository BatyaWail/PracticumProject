import { Component, ViewChild } from '@angular/core';
import { MatSidenav, MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatSidenavModule,MatToolbarModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  @ViewChild('sidenav') sidenav!: MatSidenav;
  constructor(private router: Router) { }
  aboutUs(){
      this.router.navigate(['about-us']);
  }
  login(){
    this.router.navigate(['login']);
  }
  employeeList(){
    this.router.navigate(['employee-list']);
  }
  addEmployee(){
    this.router.navigate(['add-employee']);
  }


}
