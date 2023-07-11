import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnrollStudentToCourseComponent } from './enroll-student-to-course.component';

describe('EnrollStudentToCourseComponent', () => {
  let component: EnrollStudentToCourseComponent;
  let fixture: ComponentFixture<EnrollStudentToCourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnrollStudentToCourseComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnrollStudentToCourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
