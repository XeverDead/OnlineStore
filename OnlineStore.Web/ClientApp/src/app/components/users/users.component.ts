import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  providers: [UserService]
})
export class UsersComponent implements OnInit {

  public users: User[];

  constructor(
    private readonly userService: UserService
  ) { }

  ngOnInit(): void {
    this.users = this.userService.getAll();
  }

  public getByUsername(username: string): void {
    this.users = this.userService.getByUsername(username);
  }
}
