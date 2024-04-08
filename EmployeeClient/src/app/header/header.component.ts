import { Component, ViewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenav, MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatSidenavModule,MatToolbarModule, MatIconModule,
     MatButtonModule, MatTooltipModule],
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
  logOut(){
    sessionStorage.removeItem('token');
  }
  home(){
    this.router.navigate(['home']);
  }


}
