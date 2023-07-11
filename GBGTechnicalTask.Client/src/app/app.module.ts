import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NotificationBuilderService } from './helpers/notificationBuilder.service';
import { MaterialModule } from './helpers/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ValidationService } from './helpers/validations.service';
import { AuthService } from './auth/auth.service';
import { HttpClientModule } from '@angular/common/http';
import { NgApexchartsModule } from 'ng-apexcharts';
import { InputError } from './helpers/inputError.component';
import { DDLService } from './commons/ddl.service';
import { UtilsService } from './helpers/utils';
import { Translate } from './helpers/translations';
import { TranslationService } from './helpers/translation.service';
import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule  } from '@angular-material-components/datetime-picker';
import { GoogleMapsModule } from '@angular/google-maps';
import { MatDialogConfig, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { AddStudentComponent } from './components/student/add-student/add-student.component';
import { StudentTableComponent } from './components/student/student-table/student-table.component';
import { EnrollStudentToCourseComponent } from './components/student/enroll-student-to-course/enroll-student-to-course.component';
import { CourseTableComponent } from './components/course/course-table/course-table.component';


@NgModule({
  declarations: [
    AppComponent,
    MainLayoutComponent,
    InputError,
    Translate,
    AddStudentComponent,
    StudentTableComponent,
    EnrollStudentToCourseComponent,
    CourseTableComponent,
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgApexchartsModule,
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    NgxMatTimepickerModule,
    MaterialModule,
    FlexLayoutModule,
    GoogleMapsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      maxOpened: 5,
      timeOut: 16000,
      closeButton: true,
      positionClass: 'toast-bottom-right',
    }),
  ],
  providers: [
    NotificationBuilderService,
    ValidationService,
    AuthService,
    TranslationService,
    DDLService,
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { direction: localStorage.getItem("LANG")  === 'AR' ? 'rtl' : 'ltr'
  } as MatDialogConfig} ,
    UtilsService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
