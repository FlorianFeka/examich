import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthUtilService } from 'src/app/services/auth-util.service';

@Component({
  selector: 'examich-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  authenticated$: Observable<boolean>;
  username$: Observable<string>;

  username: string = '';

  constructor(private authUtil: AuthUtilService) {
    this.authenticated$ = authUtil.getAuthenticatedObs();
    this.username$ = authUtil.getUsername();
  }

  ngOnInit(): void {
    this.username$.subscribe((a) => {
      this.username = a;
      console.log(a);
    });
  }

  onLogout(): void {
    this.authUtil.logout();
  }
}
