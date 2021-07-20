import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
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
    let id = this.url.snapshot.params.id;

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

  public getEmailControl(email: string): FormControl {
    return new FormControl(email, [
      Validators.required,
      Validators.email
    ]);
  }

  public addEmail(): void {
    this.user.emails.push({
      id: 0,
      email: null,
      userId: this.user.id
    });
  }

  public addPhoneNumber(): void {
    this.user.phoneNumbers.push({
      id: 0,
      phoneNumber: null,
      userId: this.user.id
    });
  }

  public removeEmail(): void {

  }

  public removePhoneNumber(): void {

  }
}
