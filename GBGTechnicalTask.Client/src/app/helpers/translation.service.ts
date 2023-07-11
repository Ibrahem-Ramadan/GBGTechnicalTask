import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class TranslationService {
  private activeLangSource = new BehaviorSubject<string>('EN');
  public activeLang = this.activeLangSource.asObservable() ;
  constructor() {
    if(localStorage.getItem('LANG') == null ){
      localStorage.setItem('LANG', 'EN');
    }
    this.activeLangSource.next(localStorage.getItem('LANG') as string);

  }

  updateLang(lang: string){
    localStorage.setItem('LANG', lang);
    this.activeLangSource.next(lang);
  }

  public translateText(text: string){
    text = text.replace(/-/ig,'_').replace(/ /ig, '_').toUpperCase();
    if (this.TRANSLATION[text] == undefined) {
      console.warn('Missing Translation for word ', text);
      return text;
    } else if (this.TRANSLATION[text][this.activeLangSource.getValue()] == undefined) {
      console.warn(
        `Missing Translation for word ${text} LANG ${this.activeLangSource.getValue()} `
      );
      return text;
    } else {
      return this.TRANSLATION[text][this.activeLangSource.getValue()];
    }
  }

  public getSelectdLang(){
    return this.activeLangSource.getValue();
  }

  public getDirection(){
    return this.getSelectdLang() === 'AR' ? 'rtl' : 'ltr';

  }

  public TRANSLATION: any = {
    STUDENTS:{
      EN:"Students",
      Ar:"الطلاب"
    },
    COURSES:{
      EN:"Courses",
      Ar:"المسارات التعليمية"
    },
    STUDENT:{
      EN:"Student",
      Ar:"الطالب"
    },
    COURSE:{
      EN:"Course",
      Ar:"المسار التعليمي"
    },
    ID:{
      EN:"ID",
      Ar:"الرقم التسلسلي"
    },
    NAME:{
      EN:"Name",
      Ar:"الاسم"
    },
  };
}
