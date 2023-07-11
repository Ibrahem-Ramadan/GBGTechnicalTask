import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { StudentService } from '../student.service';
import { AddStudentComponent } from '../add-student/add-student.component';
import { ModalResponse, ModalResponseType } from 'src/app/models/modalResponse';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { Student } from 'src/app/models/student';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationBuilderService } from 'src/app/helpers/notificationBuilder.service';
import { EnrollStudentToCourseComponent } from '../enroll-student-to-course/enroll-student-to-course.component';

@Component({
  selector: 'app-student-table',
  templateUrl: './student-table.component.html',
  styleUrls: ['./student-table.component.scss']
})
export class StudentTableComponent implements OnInit , AfterViewInit  {
  isLoadingResults = true;
  resultsLength = 0;
  data: Student[] = [];
  dataSource:MatTableDataSource<Student>;
  displayedColumns: string[] = [
    'id',
    'name',
    'action'
  ];
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private studentService:StudentService,
    private notification:NotificationBuilderService,
    private dialog: MatDialog
  ) {
    this.dataSource = new MatTableDataSource(this.data);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
    this.getStudentsList();
  }

  getStudentsList(){
    this.isLoadingResults=true;
    this.studentService.getAll().subscribe({
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

  openDialog(target: string, data: any): void {
    let comp: any;
    let width: string = '800px';
    let disableClose: boolean = true;
    let autoFocus: boolean = true;
    switch (target) {
      case 'addStudent':
        comp = AddStudentComponent;
      break;
      case 'enrollStudent':
        comp = EnrollStudentToCourseComponent;
      break;
    }

    let dialogRef = this.dialog.open(comp, {
      width,
      disableClose,
      autoFocus,
      data,
    });

    dialogRef.afterClosed().subscribe((result?: ModalResponse) => {
      console.log(result);
      if (result?.status === ModalResponseType.SUCCESS) {
        this.getStudentsList();
      }
    });
  }

}
