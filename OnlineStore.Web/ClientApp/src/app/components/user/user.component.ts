import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Role } from '../../models/enums/role';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  providers: [UserService]
})
export class UserComponent implements OnInit {

  public user: User;

  public roleType = Role;

  constructor(
    private readonly userService: UserService,
    private readonly url: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let id: number = this.url.snapshot.params.id;

    this.user = this.userService.getById(id);
  }

  public create(): void {
    this.user = this.userService.create(this.user);
  }

  public update(): void {
    this.user = this.userService.update(this.user);
  }

  public delete(): void {
    this.userService.delete(this.user.id);
  }
}
