import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../models/user";

@Injectable()
export class UserService {
  private readonly path: string = 'api/users';

  constructor(private readonly http: HttpClient) { }

  public create(user: User): User {
    let createdUser: User;

    this.http.post(this.path, user).subscribe((data: any) => createdUser = data);

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

    this.http.delete(this.path, options);
  }

  public getAll(): User[] {
    let users: User[];

    this.http.get(this.path).subscribe((data: any) => users = data);

    return users;
  }

  public getById(id: number): User {
    let user: User;

    let path: string = this.path + "/" + id;

    this.http.get(path).subscribe((data: any) => user = data);

    return user;
  }

  public update(user: User): User {
    let updatedUser: User;

    this.http.put(this.path, user).subscribe((data: any) => updatedUser = data);

    return updatedUser;
  }
}
