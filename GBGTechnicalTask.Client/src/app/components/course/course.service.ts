import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Course } from 'src/app/models/course';
import { ApiResponse } from 'src/app/models/genericResopnse';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private httpClient:HttpClient) {

  }

  getAll():Observable<ApiResponse<Course[]>>{
    return this.httpClient.get<ApiResponse<Course[]>>(`${environment.mainUrl}${environment.course}${environment.coursesList}`)
    .pipe(
      map((response) => {
        return response
    } )
  );
  }

}
