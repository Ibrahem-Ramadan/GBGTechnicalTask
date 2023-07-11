import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import {
  Router
} from '@angular/router';
import { BehaviorSubject, delay, Observable, of, share, take } from 'rxjs';
import { NotificationBuilderService } from '../helpers/notificationBuilder.service';


@Injectable()
export class AuthService {
  userSessionSource = new BehaviorSubject<any>({});
  currentAppSource = new BehaviorSubject<any>({});

  currentApp: any = this.currentAppSource.asObservable();
  userSession = this.userSessionSource.asObservable();
  isLoadedSource = new BehaviorSubject<any>(true);
  isLoaded = this.isLoadedSource.asObservable();
  currentUser: any = {};
  userPermissions = {};


  constructor(
    private router: Router,
    private http: HttpClient,
    private titleService: Title,
    private notify: NotificationBuilderService
  ) {

  }

  public getToken(): string | null {
    return localStorage.getItem('__T');
  }

  public getRefreshToken(): string | null {
    return localStorage.getItem('_R_T');
  }

  public getUserInfo(): string | null {
    return localStorage.getItem('__U');
  }

  public isAuthenticated(): boolean {
    let token = this.getToken();
    return token ? true : false;
  }

  public logOut() {
    // return this.http.get<any>( "test" );
    of(undefined).pipe(
      delay(500)).subscribe(response => {
        this.clearSession();
        this.router.navigate(["/login"]);
      })
  }
  public clearSession() {
    this.clearApp();
    localStorage.removeItem('__T');
    // localStorage.removeItem('__EX');
    // localStorage.removeItem('_R_T');
    // localStorage.removeItem('_R_EX');
    // localStorage.removeItem('__U');
    this.userSessionSource.next({});
  }


  public clearApp() {
    this.currentAppSource.next({});
  }

  public unauthorized() {
  }

  public unauthenticated() {
  }

  public checkSession() {
    if (!localStorage.getItem('__T')) {
      this.clearSession();
    }
  }
  public getCurrentSessionData() {


  }

  public addSession(tokenResponse: any) {
    localStorage.setItem('__T', tokenResponse.token);
    // localStorage.setItem('__EX', session.expires_in);
    // localStorage.setItem('_R_T', session.refresh_token);
    // localStorage.setItem('_R_EX', session.refresh_expires_in);
    this.router.navigate(['/main']);
  }

  // public editOwnInfo(user) {
  //   return this.http.post<any>(this.constants.urls.editOwnInfo, user);
  // }


  // public updateOwnPassword(password) {
  //   return this.http.post<any>(this.constants.urls.updateOwnPassword, password);
  // }

  // public loginAs(user) {
  //   return this.http.post<any>(this.constants.urls.loginAs, user);
  // }

  // public isSuperUser() {
  //   return this.hasRole("super_user");
  // }

  // public hasRole(role): boolean {
  //   if (this.currentUser && this.currentUser.realm_access) {
  //     return this.currentUser.realm_access.roles.find(r => r == role || r == "super_user" ) ;
  //   }
  // }


  public hasPermission(permission: string): boolean {
    // if (this.currentUser && this.currentUser.resource_access) {
    //   return this.currentUser.resource_access["realm-management"].roles.find(p => p == permission ) ;
    // }
    return true;
  }

  // updatePassword(user): Observable<any> {
  //   return this.http.post(this.constants.urls.changePassword, user);
  // }

  // getUserAccount(): Observable<any> {
  //   return this.http.get<any>( this.constants.urls.getUserAccount );
  // }

  login(user: any ) : Observable<any>{
    // return this.http.get<any>( "test" );
    return of({token: "testToken"}).pipe(
      delay(1000));
  }
}
