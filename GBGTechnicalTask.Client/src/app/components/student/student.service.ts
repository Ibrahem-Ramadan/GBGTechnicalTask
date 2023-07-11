import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Enrollment } from 'src/app/models/enrollment';
import { ApiResponse } from 'src/app/models/genericResopnse';
import { AddStudentCommand, Student } from 'src/app/models/student';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<ApiResponse<Student[]>> {
    return this.httpClient.get<ApiResponse<Student[]>>(`${environment.mainUrl}${environment.student}${environment.studentsList}`)
      .pipe(
        map((data) => {
          console.log(data);
          return data;
      } )
    );
  }

  add(student:AddStudentCommand): Observable<Student> {
    const path = `${environment.mainUrl}${environment.student}${environment.createStudent}`
    return this.httpClient.post<Student|any>(path,
    student,{}
    )
      .pipe(
        map((response) => {
          return response;
      } )
    );
  }

  enroll(enrollment:Enrollment): Observable<Enrollment> {
    const path = `${environment.mainUrl}${environment.enrollment}${environment.createEnrollment}`
    return this.httpClient.post<Enrollment|any>(path,
      enrollment,{}
    )
      .pipe(
        map((response) => {
          return response;
      } )
    );
  }
}
