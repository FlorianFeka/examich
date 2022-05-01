import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from 'src/api';

import { AuthUtilService } from '../services/auth-util.service';

@Component({
  selector: 'examich-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
    fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar,
    private authUtil: AuthUtilService
  ) {
    this.registerForm = fb.group({
      username: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  ngOnInit(): void {
    if (this.authUtil.isAuthenticated()) this.router.navigate(['dashboard']);
  }

  onSubmit(): void {
    if (this.registerForm.invalid) {
      return;
    }

    var result: Observable<HttpResponse<any>> =
      this.authService.apiAuthRegisterPost({
        username: this.registerForm.get('username')?.value,
        email: this.registerForm.get('email')?.value,
        password: this.registerForm.get('password')?.value,
      });

    result.subscribe(
      (result) => {
        console.log(result);
        this.router.navigate(['login']);
      },
      (err: HttpErrorResponse) => {
        let errMessage = 'There seems to be a problem, please try again later';
        if (typeof err.error === 'string') {
          errMessage = err.error + '';
        }
        this.snackBar.open(errMessage, 'Dismiss', { duration: 5000 });
      }
    );
  }
}
