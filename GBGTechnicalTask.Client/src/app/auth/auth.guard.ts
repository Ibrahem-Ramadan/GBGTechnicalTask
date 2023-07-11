
import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot
} from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
      // private authService: AuthService,
      private router: Router) { }
  canActivate(
      route: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): boolean | Promise<boolean> {
      // var isAuthenticated = this.authService.getAuthStatus();
      // if (!isAuthenticated) {
      //     this.router.navigate(['/login']);
      // }
      return true;
  }
}
