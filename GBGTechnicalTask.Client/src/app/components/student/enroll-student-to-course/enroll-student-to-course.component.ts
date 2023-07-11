import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subscription } from 'rxjs/internal/Subscription';
import { NotificationBuilderService } from 'src/app/helpers/notificationBuilder.service';
import { UtilsService } from 'src/app/helpers/utils';
import { Lookup } from 'src/app/models/lookup';
import { ModalResponseType } from 'src/app/models/modalResponse';
import { AddStudentCommand, Student } from 'src/app/models/student';
import { StudentService } from '../student.service';
import { Enrollment } from 'src/app/models/enrollment';
import { DDLService } from 'src/app/commons/ddl.service';
import { Course } from 'src/app/models/course';

@Component({
  selector: 'app-enroll-student-to-course',
  templateUrl: './enroll-student-to-course.component.html',
  styleUrls: ['./enroll-student-to-course.component.scss']
})
export class EnrollStudentToCourseComponent implements OnInit, OnDestroy {
  submitting: boolean = false;
  private subscription = new Subscription();
  private enrollment!: Enrollment;
  coursesList:Course[] =[]
  studentsList:Student[]=[]
  enrollStudentForm: FormGroup = new FormGroup({
    studentId: new FormControl(null, [Validators.required]),
    courseId: new FormControl(null, [Validators.required])
  });

  constructor(
    private snackBar: MatSnackBar,
    private notify: NotificationBuilderService,
    public dialogRef: MatDialogRef<EnrollStudentToCourseComponent>,
    @Inject(MAT_DIALOG_DATA) private studentData: Student,
    private studentService: StudentService,
    private ddlService:DDLService
  ) {
    if(studentData){
      this.getStudentIdFormControl.patchValue(this.studentData.id)
    }
  }

	get getStudentIdFormControl() { return this.enrollStudentForm.get('studentId') as FormControl }


  ngOnInit(): void {
    this.subscription.add(
      this.ddlService.coursesList.subscribe((courses)=>
      {this.coursesList=courses})
    )
    this.subscription.add(
      this.ddlService.studentsList.subscribe((students)=>
      {this.studentsList=students})
    )
  }

  enroll() {
    if (this.submitting === true) return;

    if (this.enrollStudentForm.invalid) {
      this.notify.showError('Invalid data');
      return;
    }
    let snackBarRef = this.snackBar.open('Submitting ... ');
    this.submitting = true;
    this.enrollment = this.enrollStudentForm.value;
    console.log(this.enrollment);
    this.subscription.add(
      this.studentService
        .enroll(this.enrollment)
        .subscribe({
          next:(response)=>{
            this.submitting = false;
            snackBarRef.dismiss();
            this.notify.showSuccess('Student Enrolled to Course Successfully .');
            this.dialogRef.close({status: ModalResponseType.SUCCESS, data: response});
          },
          error:(err)=>{
            this.submitting = false;
            snackBarRef.dismiss();
            if(err.error.StatusCode == 422){
              this.notify.showError('Student Already Enrolled to This Course');
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
