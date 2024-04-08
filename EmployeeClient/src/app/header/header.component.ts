import { Component, HostListener, Input, OnInit, ViewChild } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenav, MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { Router } from '@angular/router';
import { Company } from '../classes/entities/company.entites';
import { CompanyService } from '../company.service';
import { LoginComponent } from '../loginJwt/login/login.component';
// import { SessionStorageService } from '../session-storage.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatSidenavModule,MatToolbarModule, MatIconModule,
     MatButtonModule, MatTooltipModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {
  
  @ViewChild('sidenav') sidenav!: MatSidenav;
  company!: Company;
  companyId: any;
  companyName: any;

  token: any;
  @Input() receivedToken: string = '';

  constructor(private router: Router,private companyService: CompanyService
    // ,private loginComponent: LoginComponent
    // , private sessionStorageService: SessionStorageService
    ) { }
  // ngOnInit(): void {
  //   this.foundCompanyNameFromToken()
  // }
  
  ngOnInit(): void {
    // הרשמה לאירועי שינוי ב־sessionStorage
    // this.sessionStorageService.subscribeToTokenChanges((token) => {
    //   if (token) {
    //     this.foundCompanyNameFromToken(); // אם יש טוקן, נמצא את השם של החברה מהטוקן
    //   }
    // });
    // this.foundCompanyNameFromToken();
    this.foundCompanyNameFromToken(); // Initial call
    // Subscribe to tokenSaved event
    // this.loginComponent.tokenSaved.subscribe(token => {
    //   this.foundCompanyNameFromToken();
    // });
  }
  scrolled: boolean = false;

  @HostListener('window:scroll', ['$event'])
  foundCompanyNameFromToken(){
    // this.token = this.sessionStorageService.getToken();
    this.token = sessionStorage.getItem('token');
    if (this.token) {
      // Decode the token
      try {
        const tokenPayload: any = JSON.parse(atob(this.token.split('.')[1]));
        // Access the id property
        if (tokenPayload && typeof tokenPayload === 'object' && 'name' in tokenPayload) {
          this.companyName = tokenPayload.name;
          console.log("Company ID:", this.companyName);
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
  yourCompany(){
    this.foundCompanyNameFromToken()
    // this.companyService.getCompanyById(this.companyId).subscribe({
    //   next: (res) => {
    //     console.log("res", res)
    //     this.company = res
    //   },
    //   error: (err) => {
    //     console.log(err)
    //   }
    // })
  }
  onWindowScroll() {
    this.scrolled = window.scrollY > 0;
  }
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
