import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/api';

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
    private snackBar: MatSnackBar
  ) {
    this.loginForm = fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
  }

  ngOnInit(): void {}

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
      (a) => console.log(a),
      (err) => {
        if (err.status === 401)
          this.snackBar.open('Wrong email or password.', 'Dismiss', {
            duration: 5000,
          });
      }
    );
  }
}
