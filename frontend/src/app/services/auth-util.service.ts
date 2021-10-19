import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthUtilService {
  private _username: Subject<string>;
  private username$: Observable<string>;

  private _authenticated: Subject<boolean>;
  private authenticated$: Observable<boolean>;

  constructor(private jwtHelper: JwtHelperService) {
    this._username = new Subject<string>();
    this.username$ = this._username.asObservable();

    this._authenticated = new Subject<boolean>();
    this.authenticated$ = this._authenticated.asObservable();
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    return false;
  }

  public setAuthenticated(): void {
    this._authenticated.next(true);
  }

  public setUnauthenticated(): void {
    this._authenticated.next(false);
  }

  public getAuthenticatedObs(): Observable<boolean> {
    return this.authenticated$;
  }

  public setUsername(name: string): void {
    this._username.next(name);
  }

  public getUsername(): Observable<string> {
    return this.username$;
  }
}
