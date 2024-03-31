import { Component, Inject } from '@angular/core';
// import { MAT_DIALOG_DATA } from '@angular/material/dialog';

import {
  MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogTitle,
} from '@angular/material/dialog';
@Component({
  selector: 'app-dialog-messege',
  standalone: true,
  imports: [MatDialogTitle, MatDialogContent,MatDialogActions,],
  templateUrl: './dialog-messege.component.html',
  styleUrl: './dialog-messege.component.scss'
})
export class DialogMessegeComponent {
  dialogRef: any;
  constructor(@Inject(MAT_DIALOG_DATA) public data: string) {
    console.log(this.data);
  }
  onClick(): void {
    this.dialogRef.close(false); // החזרת ערך false אם לא נבחר למחוק
  }

}
