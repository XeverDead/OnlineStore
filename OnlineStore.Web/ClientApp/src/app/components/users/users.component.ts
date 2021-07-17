import { Component, OnInit } from '@angular/core';
import { UserData } from '../../models/user-data';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService]
})
export class UsersComponent implements OnInit {

  public usersData: UserData[];

  constructor(
    private readonly userService: UserService
  ) { }

  ngOnInit(): void {
    this.userService.getAll().subscribe(result => {
      this.usersData = result;
    });
  }

  public getByUsername(username: string): void {
    this.userService.getByUsername(username).subscribe(result => {
      this.usersData = result;
    });
  }
}
