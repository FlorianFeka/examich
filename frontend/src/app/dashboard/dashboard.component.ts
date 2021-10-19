import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/api';

@Component({
  selector: 'examich-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  constructor(private userService: UsersService) {}

  ngOnInit(): void {
    this.userService.apiUsersOptions().subscribe((a) => console.log(a));
  }
}
