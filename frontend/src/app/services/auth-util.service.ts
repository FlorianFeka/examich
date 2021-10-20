import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthService, GetUserDto, LoginDto, UsersService } from 'src/api';

@Injectable({
  providedIn: 'root',
})
export class AuthUtilService {
  private _username: BehaviorSubject<string>;
  private username$: Observable<string>;

  private _authenticated: BehaviorSubject<boolean>;
  private authenticated$: Observable<boolean>;

  private userData: GetUserDto | undefined;

  constructor(
    private jwtHelper: JwtHelperService,
    private auth: AuthService,
    private snackBar: MatSnackBar,
    private router: Router,
    private userService: UsersService
  ) {
    this._username = new BehaviorSubject<string>('');
    this.username$ = this._username.asObservable();

    this._authenticated = new BehaviorSubject<boolean>(false);
    this.authenticated$ = this._authenticated.asObservable();
  }

  public authenticate(login: LoginDto): void {
    this.auth.apiAuthLoginPost(login).subscribe(
      (a) => {
        localStorage.setItem('token', a.token);
        this.setAuthenticated();
        this.fetchUserdata();
        this.router.navigate(['dashboard']);
      },
      (err) => {
        if (err.status === 401)
          this.snackBar.open('Wrong email or password.', 'Dismiss', {
            duration: 5000,
          });
      }
    );
  }

  public logout(): void {
    localStorage.removeItem('token');
    this.setUnauthenticated();
    this.setUsername('');
    this.userData = undefined;
    this.router.navigate(['login']);
  }

  public isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      this.setAuthenticated();
      return true;
    }
    this.setUnauthenticated();
    return false;
  }

  public fetchUserdata(): void {
    this.userService.infoGet().subscribe((user) => {
      this.userData = user;
      this.setUsername(`${this.userData.userName}`);
    });
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
