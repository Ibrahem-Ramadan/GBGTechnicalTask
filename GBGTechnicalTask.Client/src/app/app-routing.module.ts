import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { StudentTableComponent } from './components/student/student-table/student-table.component';
import { CourseTableComponent } from './components/course/course-table/course-table.component';
const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    data: { title: 'DASHBOARD' },
    children: [
      {
        path: 'main',
        component: StudentTableComponent,
        canActivate: [AuthGuard],
        data: { title: 'STUDENTS', icon: 'school' }
      },
      {
        path: 'courses',
        component: CourseTableComponent,
        canActivate: [AuthGuard],
        data: { title: 'COURSES', icon: 'library_books' }
      },
      {
        path: '**',
        redirectTo: '/main',
        pathMatch: 'full',
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
