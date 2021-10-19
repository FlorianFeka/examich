import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { AuthService } from 'src/api';

import { AuthUtilService } from '../services/auth-util.service';

@Component({
  selector: 'examich-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;

  constructor(
    fb: FormBuilder,
    private auth: AuthService,
    private snackBar: MatSnackBar,
    private router: Router,
    private authUtil: AuthUtilService
  ) {
    this.loginForm = fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  ngOnInit(): void {
    if (this.authUtil.isAuthenticated()) this.router.navigate(['dashboard']);
  }

  onSubmit(): void {
    if (this.loginForm.invalid) {
      return;
    }

    let result = this.auth.apiAuthLoginPost({
      email: this.loginForm.get('email')?.value,
      password: this.loginForm.get('password')?.value,
      rememberLogin: true,
    });
    result.subscribe(
      (a) => {
        localStorage.setItem('token', a.token);
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
}
