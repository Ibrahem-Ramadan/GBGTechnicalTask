export enum ModalResponseType{
  FAILED,SUCCESS,
}

export interface ModalResponse{
  status: ModalResponseType,
  data: any
}
