import { Component , OnInit , ViewContainerRef} from '@angular/core';
import { Directive, ElementRef, HostListener, Input } from '@angular/core';


@Component({
  selector: 'input-error',
  template: `
                <span *ngIf="input.errors.required">
                  This field is <strong>Required</strong> !
                </span>
                <span *ngIf="(( input.errors.minlength  ) && (!input.errors.pattern))">
                    Minimum Length <strong>{{input.errors.minlength.requiredLength}}</strong> characters
                </span>
                <span *ngIf="((input.errors.maxlength ) && (!input.errors.pattern))">
                    Maximum Length <strong>{{input.errors.maxlength.requiredLength}}</strong> characters
                </span>
                <span *ngIf="( input.errors.pattern )">
                    Invalid <strong>{{patternErrorMap[pattern]}}</strong> !
                </span>
                <span *ngIf="( input.errors.matDatepickerMax )">
                    Invalid <strong>Max Date is [ {{ input.errors.matDatepickerMax.max | date : "dd-MM-yyyy" }} ]</strong> !
                </span>
                <span *ngIf="( input.errors.matDatepickerMin )">
                    Invalid <strong>Min Date is [ {{input.errors.matDatepickerMin.min | date : "dd-MM-yyyy"}} ]</strong> !
                </span>
                <span *ngIf="( input.errors.invalidRange )">
                    Invalid <strong>Number Range</strong> !
                </span>
            `
})

export class InputError {
  @Input() input : any;
  @Input() pattern : any;

  patternErrorMap: any = {
  	"alphabet":"Only Alphabet ",
    "numbers":"Only Numbers ",
    "positiveNumbers":"Only positive numbers are allowed",
  	"phoneNumber":"Phone Number ",
  	"email":"Email Format ",
  	"username":"Only Alphabet and (. - _) ",
  }

	constructor(vcr: ViewContainerRef){

	}
}

