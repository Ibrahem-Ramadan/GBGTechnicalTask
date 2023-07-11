import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationBuilderService } from 'src/app/helpers/notificationBuilder.service';
import { ModalResponse, ModalResponseType } from 'src/app/models/modalResponse';
import { Student } from 'src/app/models/student';
import { AddStudentComponent } from '../../student/add-student/add-student.component';
import { EnrollStudentToCourseComponent } from '../../student/enroll-student-to-course/enroll-student-to-course.component';
import { StudentService } from '../../student/student.service';
import { Course } from 'src/app/models/course';
import { CourseService } from '../course.service';

@Component({
  selector: 'app-course-table',
  templateUrl: './course-table.component.html',
  styleUrls: ['./course-table.component.scss']
})
export class CourseTableComponent implements OnInit , AfterViewInit  {
  isLoadingResults = true;
  resultsLength = 0;
  data: Course[] = [];
  dataSource:MatTableDataSource<Course>;
  displayedColumns: string[] = [
    'id',
    'name',
  ];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private courseService:CourseService,
    private notification:NotificationBuilderService,
    private dialog: MatDialog
  ) {
    this.dataSource = new MatTableDataSource(this.data);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.getCoursessList();
  }

  getCoursessList(){
    this.isLoadingResults=true;
    this.courseService.getAll().subscribe({
      next:(response:any)=>{
        this.dataSource.data=response.data
        this.resultsLength= this.data.length
        this.dataSource.paginator= this.paginator;
        this.isLoadingResults=false;
        console.log(response)
      },
      error:(err)=>{
        console.error(err)
        this.isLoadingResults=false;
        this.notification.showError("ERROR")
      }
    })
  }


}
