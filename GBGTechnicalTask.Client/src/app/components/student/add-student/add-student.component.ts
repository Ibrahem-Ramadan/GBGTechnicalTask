import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormArray, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription, catchError } from 'rxjs';
import { NotificationBuilderService } from 'src/app/helpers/notificationBuilder.service';
import { ModalResponseType } from 'src/app/models/modalResponse';
import { AddStudentCommand, Student } from 'src/app/models/student';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-add-student',
  templateUrl: './add-student.component.html',
  styleUrls: ['./add-student.component.scss']
})
export class AddStudentComponent implements OnInit, OnDestroy {
  submitting: boolean = false;

  private subscription = new Subscription();
  private student!: AddStudentCommand;
  addStudentForm: FormGroup = new FormGroup({
    studentName: new FormControl(null, [Validators.required,Validators.minLength(4),Validators.maxLength(50)]),
  });


  constructor(
    private snackBar: MatSnackBar,
    private notify: NotificationBuilderService,
    public dialogRef: MatDialogRef<AddStudentComponent>,
    @Inject(MAT_DIALOG_DATA) private studentData: Student,
    private studentService: StudentService
  ) {
    console.log(studentData);
    if(studentData !== null){
      this.addStudentForm.patchValue(studentData);
    }
  }

	get getStudentNameFormControl() { return this.addStudentForm.get('studentName') as FormControl }


  ngOnInit(): void {
  }

  submit() {
    if (this.submitting === true) return;

    if (this.addStudentForm.invalid) {
      this.notify.showError('Invalid data');
      return;
    }
    let snackBarRef = this.snackBar.open('Submitting ... ');
    this.submitting = true;
    this.student = this.addStudentForm.value;
    console.log(this.student);
    this.subscription.add(
      this.studentService
        .add(this.student)
        .subscribe({
          next:(response)=>{
            this.submitting = false;
            snackBarRef.dismiss();
            this.notify.showSuccess('Student Added Successfully .');
            this.dialogRef.close({status: ModalResponseType.SUCCESS, data: response});
          },
          error:(err)=>{
            this.submitting = false;
            snackBarRef.dismiss();
            if(err.error.StatusCode == 422){
              this.notify.showError('Student already exist');
            }
            else{
              this.notify.showError('Unexpected Error');
            }
          }
        })
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
