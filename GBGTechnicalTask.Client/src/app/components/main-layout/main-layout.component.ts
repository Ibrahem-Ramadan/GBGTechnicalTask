import {
  ChangeDetectorRef,
  Component,
  OnDestroy,
  OnInit,
  ViewEncapsulation,
} from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { MatDialog } from '@angular/material/dialog';
import {
  ActivatedRoute,
  ActivationEnd,
  Data,
  NavigationEnd,
  Router,
  RoutesRecognized,
} from '@angular/router';
import { MediaMatcher } from '@angular/cdk/layout';
import { Subscription, filter, map, buffer, debounceTime } from 'rxjs';
import { UtilsService } from 'src/app/helpers/utils';
import { TranslationService } from 'src/app/helpers/translation.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class MainLayoutComponent implements OnInit, OnDestroy {
  panelOpenState: boolean = false;
  isLoaded = this.authService.isLoadedSource.getValue();
  currentApp = this.authService.currentAppSource.getValue();
  subscription = new Subscription();
  userSessionData: any = this.authService.userSessionSource.getValue();
  activeUrl = '';
  selectedLang: string = 'EN';
  mobileQuery: MediaQueryList;
  private _mobileQueryListener: () => void;
  routeData?:Data = {title: '', icon:''};
  notifications : any[] = [];

  constructor(
    private authService: AuthService,
    private changeDetectorRef: ChangeDetectorRef,
    public dialog: MatDialog,
    public utilsService: UtilsService,
    protected translationService : TranslationService,
    private router: Router,
    private media: MediaMatcher
  ) {
    this.subscription.add(this.router.events
      .pipe(
        map((val) => {
          if (val instanceof NavigationEnd) {
            this.activeUrl = val.urlAfterRedirects;
          }
          return val;
        }),
        filter((event) => event instanceof NavigationEnd),
        map(() => {
          return this.utilsService.getRouteData();
        })
      )
      .subscribe((headerClasses: Data | undefined) => {
        this.routeData = headerClasses;
      }));

    this.subscription.add(
      this.authService.userSession.subscribe((response) => {
        this.userSessionData = response;
      })
    );

    this.mobileQuery = media.matchMedia('(max-width: 600px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
    this.authService.getCurrentSessionData();

  }


  getNewNotifications(){

  }

  ngOnInit() {
    this.subscription.add(
       this.translationService.activeLang.subscribe(lang => this.selectedLang = lang )
    );
    this.getNewNotifications()
  }

  getDir(){
    return this.selectedLang === 'AR' ? 'rtl' : 'ltr';
  }
  changeLang( lan : string ){
    this.translationService.updateLang(lan);
  }

  isActiveUrl(urls: string[]){
    return urls.includes(this.activeUrl);
  }
  getActiveLink(url: any) {
    if (url && url.isActive) {
      return true;
    }

    return false;
  }

  openDialog(target: string, data: any): void {
    let comp: any;
    let width: string = '500px';
    let disableClose: boolean = true;
    switch (target) {
      case 'loginAs':
        // comp = LoginAsComponent;
        break;
    }

    let dialogRef = this.dialog.open(comp, {
      width,
      disableClose,
      data,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
      }
    });
  }
  changePassword() {}

  logout() {
    this.authService.logOut();
  }

  hasPermission(permission: string) {
    return this.authService.hasPermission(permission);
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
}
