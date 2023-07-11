import { Course } from "./course";

export interface Student{
  id?:number,
  name:string,
  courses?:Course[]
}

export interface AddStudentCommand{
  studentName:string,
}
