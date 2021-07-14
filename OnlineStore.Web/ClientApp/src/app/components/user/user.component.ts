import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Role } from '../../models/enums/role';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
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

    this.userService.getById(id).subscribe(result => {
      this.user = result;
    })
  }

  public create(): void {
    this.userService.create(this.user).subscribe(result => {
      this.user = result;
    })
  }

  public update(): void {
    this.userService.update(this.user).subscribe(result => {
      this.user = result;
    })
  }

  public delete(): void {
    this.userService.delete(this.user.id).subscribe();
  }
}
