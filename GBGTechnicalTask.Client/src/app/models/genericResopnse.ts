export interface ApiResponse <T> {
  statusCode:number,
  meta?:Object,
  succeeded:boolean,
  message?:string
  errors?:Array<string>,
  data?:T
}
