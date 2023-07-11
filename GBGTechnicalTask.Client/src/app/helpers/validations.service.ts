import { Injectable } from '@angular/core';
import {
  AbstractControl, FormArray, FormControl, FormGroup
} from '@angular/forms';

@Injectable()
export class ValidationService {
  constructor() {}

  public validationPatterns = {
    alphabet: '[a-zA-Z ]+',
    numbers: '[0-9]+',
    positiveNumbers: '[0-9]+',
    email: '[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}',
    username: '[a-z0-9._-]+'
  };


  passwordConfirming(c: AbstractControl): { invalidPassword: boolean } {
    if (c.get('newPassword')?.value != c.get('confirmation')?.value) {
      return { invalidPassword: true };
    }
    return  { invalidPassword: false }
  }

  routingRange(c: AbstractControl): { invalidRange: boolean } {
    if (Number(c.get('numberFrom')?.value) && Number(c.get('numberTo')?.value)) {
      if (
        Number(c.get('numberFrom')?.value) > Number(c.get('numberTo')?.value) ||
        c.get('numberFrom')?.value.length != c.get('numberTo')?.value.length
      ) {
        return { invalidRange: true };
      }
    }
    return  { invalidRange: false }
  }

  validateAllFormFields(formGroup: FormGroup) {
    Object.keys(formGroup.controls).forEach(field => {
      const control = formGroup.get(field);
      if (control instanceof FormControl) {
        control.markAsTouched({ onlySelf: true });
      } else if (control instanceof FormGroup) {
        this.validateAllFormFields(control);
      } else if (control instanceof FormArray) {
        Object.keys(control.controls).forEach(field => {
          const con = control.get(field);
          if (con instanceof FormControl) {
            con.markAsTouched({ onlySelf: true });
          } else if (con instanceof FormGroup) {
            this.validateAllFormFields(con);
          }
        });
      }
    });
  }

}
