// // import { Injectable } from '@angular/core';

import { Injectable } from "@angular/core";

// // @Injectable({
// //   providedIn: 'root'
// // })
// // export class AuthService {

// //   constructor() { }
// // }
// import { Injectable } from '@angular/core';

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthService {
//   private token: string | null = null;
//   getToken(): string | null {
//     return this.token;
//   }
//   setToken(token: string) {
//     // Implement secure storage mechanism (e.g., encrypted Local Storage)
//     const encryptedToken = this.encryptToken(token); // Implement encryption logic
//     localStorage.setItem('auth_token', encryptedToken);
//   }
  
//   private encryptToken(token: string): string {
//     // Implement your encryption logic here
//     // This example is a placeholder, replace with your chosen encryption method
//     return btoa(token); // Basic token encoding (not secure, replace with proper encryption)
//   }
  
// }

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private token: string | null = null;

  getToken(): string | null {
    // Retrieve the token from storage and decrypt if needed
    const encryptedToken = localStorage.getItem('auth_token');
    this.token = this.decryptToken(encryptedToken);
    return this.token;
  }

  setToken(token: string) {
    // Implement secure storage mechanism (e.g., encrypted Local Storage)
    const encryptedToken = this.encryptToken(token);
    localStorage.setItem('auth_token', encryptedToken);
    this.token = token;
  }

  private encryptToken(token: string): string {
    // Implement encryption logic
    return token; // Placeholder for encryption logic
  }

  private decryptToken(encryptedToken: string | null): string | null {
    // Implement decryption logic
    return encryptedToken; // Placeholder for decryption logic
  }
}
