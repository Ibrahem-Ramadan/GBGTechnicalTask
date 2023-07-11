import { Component, OnInit, OnDestroy } from '@angular/core';
import { Directive, ElementRef, HostListener, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { TranslationService } from './translation.service';

@Component({
  selector: '[translate]',
  template: `{{ this.translatedText }}`,
})
export class Translate implements OnInit , OnDestroy {
  @Input('translate') translateText!: string;
  protected translatedText = '';

  subscription = new Subscription();

  constructor(private ref: ElementRef, private translationService: TranslationService) {}
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }


  ngOnInit(): void {
    this.subscription.add(
      this.translationService.activeLang.subscribe((lang) => {
          this.translatedText = this.translationService.translateText(this.translateText);
      })
    );
  }

}
