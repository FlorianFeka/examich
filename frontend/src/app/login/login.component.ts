import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

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

    this.authUtil.authenticate({
      email: this.loginForm.get('email')?.value,
      password: this.loginForm.get('password')?.value,
      rememberLogin: true,
    });
  }
}
