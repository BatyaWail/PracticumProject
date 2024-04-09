import { Component, Inject } from '@angular/core';
import {
  MatDialog,
  MatDialogRef,
  MatDialogActions,
  MatDialogClose,
  MatDialogTitle,
  MatDialogContent,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-delete-employee-dialog',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent,
    MatIcon],
  templateUrl: './delete-employee-dialog.component.html',
  styleUrl: './delete-employee-dialog.component.scss'
})
export class DeleteEmployeeDialogComponent {
// data: any;
  constructor(public dialogRef: MatDialogRef<DeleteEmployeeDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: string) {
    console.log("data",this.data)
  }
  onNoClick(): void {
    this.dialogRef.close(false); // החזרת ערך false אם לא נבחר למחוק
  }
  
  onYesClick(): void {
    this.dialogRef.close(true); // החזרת ערך true אם נבחר למחוק
  }
}
