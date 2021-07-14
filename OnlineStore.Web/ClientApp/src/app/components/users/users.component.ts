import { Component, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
  providers: [UserService]
})
export class UsersComponent implements OnInit {

  public users: User[];

  constructor(
    private readonly userService: UserService
  ) { }

  ngOnInit(): void {
    this.userService.getAll().subscribe(result => {
      this.users = result;
    });
  }

  public getByUsername(username: string): void {
    this.userService.getByUsername(username).subscribe(result => {
      this.users = result;
    });
  }
}
