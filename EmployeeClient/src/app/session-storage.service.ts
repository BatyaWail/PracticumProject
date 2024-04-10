// import { Injectable } from '@angular/core';
// import { Subject } from 'rxjs';

// @Injectable({
//   providedIn: 'root'
// })
// export class SessionStorageService {

//   private tokenSubject = new Subject<string | null>();

//   constructor() {
//     // רישום לאירועי שינוי ב־sessionStorage
//     window.addEventListener('storage', (event) => {
//       if (event.key === 'token') {
//         this.tokenSubject.next(event.newValue); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
//       }
//     });
//   }

//   setToken(token: string): void {
//     sessionStorage.setItem('token', token);
//   }

//   getToken(): string | null {

//     // if (typeof sessionStorage !== 'undefined') {
//       return sessionStorage.getItem('token');
//     // }
//     // else{
//     //   console.error('sessionStorage is not available');
//     //   return null
//     // }
//   }

//   clearToken(): void {
//     sessionStorage.removeItem('token');
//   }

//   // פונקציה להרשמה לאירועי שינוי ב־sessionStorage
//   subscribeToTokenChanges(callback: (token: string | null) => void) {
//     this.tokenSubject.subscribe(callback);
//   }
// }
// // // import { Injectable } from '@angular/core';
// // // import { Subject } from 'rxjs';

// // // @Injectable({
// // //   providedIn: 'root'
// // // })
// // // export class SessionStorageService {

// // //   private tokenSubject = new Subject<string | null>();

// // //   constructor() {
// // //     // רישום לאירועי שינוי ב־sessionStorage
// // //     window.addEventListener('storage', (event) => {
// // //       if (event.key === 'token') {
// // //         this.tokenSubject.next(event.newValue); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// // //       }
// // //     });
// // //   }

// // //   setToken(token: string): void {
// // //     sessionStorage.setItem('token', token);
// // //     this.tokenSubject.next(token); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// // //   }

// // //   getToken(): string | null {
// // //     return sessionStorage.getItem('token');
// // //   }

// // //   clearToken(): void {
// // //     sessionStorage.removeItem('token');
// // //     this.tokenSubject.next(null); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// // //   }

// // //   // פונקציה להרשמה לאירועי שינוי ב־sessionStorage
// // //   subscribeToTokenChanges(callback: (token: string | null) => void) {
// // //     this.tokenSubject.subscribe(callback);
// // //   }
// // // }
// // import { Injectable } from '@angular/core';
// // import { Subject } from 'rxjs';

// // @Injectable({
// //   providedIn: 'root'
// // })
// // export class SessionStorageService {

// //   private tokenSubject = new Subject<string | null>();

// //   constructor() {
// //     // רישום לאירועי שינוי ב־sessionStorage
// //     if (typeof window !== 'undefined') {
// //       window.addEventListener('storage', (event) => {
// //         if (event.key === 'token') {
// //           this.tokenSubject.next(event.newValue); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// //         }
// //       });
// //     }
// //   }

// //   setToken(token: string): void {
// //     if (typeof window !== 'undefined') {
// //       sessionStorage.setItem('token', token);
// //       this.tokenSubject.next(token); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// //     }
// //   }

// //   getToken(): string | null {
// //     if (typeof window !== 'undefined') {
// //       return sessionStorage.getItem('token');
// //     }
// //     return null;
// //   }

// //   clearToken(): void {
// //     if (typeof window !== 'undefined') {
// //       sessionStorage.removeItem('token');
// //       this.tokenSubject.next(null); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// //     }
// //   }

// //   // פונקציה להרשמה לאירועי שינוי ב־sessionStorage
// //   subscribeToTokenChanges(callback: (token: string | null) => void) {
// //     this.tokenSubject.subscribe(callback);
// //   }
// // }
// // import { Injectable, Inject } from '@angular/core';
// // import { Subject } from 'rxjs';

// // @Injectable({
// //   providedIn: 'root'
// // })
// // export class SessionStorageService {

// //   private tokenSubject = new Subject<string | null>();

// //   constructor(@Inject('Window') private window: Window) {
// //     // רישום לאירועי שינוי ב־sessionStorage
// //     if (this.window) {
// //       this.window.addEventListener('storage', (event) => {
// //         if (event.key === 'token') {
// //           this.tokenSubject.next(event.newValue); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// //         }
// //       });
// //     }
// //   }

// //   setToken(token: string): void {
// //     if (this.window) {
// //       this.window.sessionStorage.setItem('token', token);
// //       this.tokenSubject.next(token); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// //     }
// //   }

// //   getToken(): string | null {
// //     if (this.window) {
// //       return this.window.sessionStorage.getItem('token');
// //     }
// //     return null;
// //   }

// //   clearToken(): void {
// //     if (this.window) {
// //       this.window.sessionStorage.removeItem('token');
// //       this.tokenSubject.next(null); // שליחת אירוע ל־Subject כאשר משתנה ה־sessionStorage
// //     }
// //   }

// //   // פונקציה להרשמה לאירועי שינוי ב־sessionStorage
// //   subscribeToTokenChanges(callback: (token: string | null) => void) {
// //     this.tokenSubject.subscribe(callback);
// //   }
// // }
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SessionStorageService {
  private tokenSubject = new Subject<string | null>();

  constructor() {
    window.addEventListener('storage', (event) => {
      if (event.key === 'token') {
        this.tokenSubject.next(event.newValue);
      }
    });
  }

  setToken(token: string): void {
    sessionStorage.setItem('token', token);
  }

  getToken(): string | null {
    return sessionStorage.getItem('token');
  }

  clearToken(): void {
    sessionStorage.removeItem('token');
  }

  subscribeToTokenChanges(callback: (token: string | null) => void) {
    this.tokenSubject.subscribe(callback);
  }

  foundCompanyNameFromToken() {
    const token = sessionStorage.getItem('token');
    if (token) {
      try {
        const tokenPayload: any = JSON.parse(atob(token.split('.')[1]));
        if (tokenPayload && typeof tokenPayload === 'object' && 'name' in tokenPayload) {
          return tokenPayload.name;
        }
      } catch (error) {
        console.error("Error decoding token:", error);
      }
    }
    return null;
  }
}
