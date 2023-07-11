import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { CourseService } from '../components/course/course.service';
import { Course } from '../models/course';
import { StudentService } from '../components/student/student.service';
import { Student } from '../models/student';

@Injectable({
  providedIn: 'root'
})
export class DDLService {

  private coursesListSource = new BehaviorSubject<Course[]>([]);
  public coursesList = this.coursesListSource.asObservable() ;

  private studentListSource = new BehaviorSubject<Student[]>([]);
  public studentsList = this.studentListSource.asObservable() ;

  constructor(
    private courseService:CourseService,
    private studentService:StudentService
  ) {
    this.ddlCoursesList();
    this.ddlStudentsList();
  }

  ddlCoursesList(){
    this.courseService.getAll()
    .pipe(
      map((rsponse)=>{
      return rsponse.data
    }
    )).subscribe((response)=>{
      this.coursesListSource.next(response!)
    })
  }

  ddlStudentsList(){
    this.studentService.getAll()
    .pipe(
      map((rsponse)=>{
      return rsponse.data
    }
    )).subscribe((response)=>{
      this.studentListSource.next(response!)
    })
  }
}
