import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../models/user";

@Injectable()
export class UserService {
  private readonly path: string = 'api/users';

  constructor(private readonly http: HttpClient) { }

  public create(user: User): User {
    let createdUser: User;

    this.http.post<User>(this.path, user).subscribe((data) => createdUser = data);

    return createdUser;
  }

  public delete(id: number): void {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id
      },
    };

    this.http.delete<User>(this.path, options);
  }

  public getAll(): User[] {
    let users: User[];

    this.http.get<User[]>(this.path).subscribe((data: any) => users = data);

    return users;
  }

  public getById(id: number): User {
    let user: User;

    let path: string = this.path + "/" + id;

    this.http.get<User>(path).subscribe((data) => user = data);

    return user;
  }

  public update(user: User): User {
    let updatedUser: User;

    this.http.put<User>(this.path, user).subscribe((data) => updatedUser = data);

    return updatedUser;
  }

  public getByUsername(username: string): User[] {
    let users: User[];

    let path: string = this.path + '/byUsername/' + username;

    this.http.get<User[]>(path).subscribe((data) => users = data);

    return users;
  }
}
