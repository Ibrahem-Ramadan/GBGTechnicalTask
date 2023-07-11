import { Course } from "./course";
import { Student } from "./student";

export interface Enrollment {
  studentId:number,
  courseId:number,
  course?:Course,
  student?:Student,
}
