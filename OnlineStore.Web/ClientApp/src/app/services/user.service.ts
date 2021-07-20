import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User } from "../models/user";
import { UserData } from "../models/user-data";

@Injectable()
export class UserService {
  private readonly path: string = 'api/user';

  constructor(private readonly http: HttpClient) { }

  public create(user: User): Observable<User> {

    return this.http.post<User>(this.path, user)
  }

  public delete(id: number): Observable<void> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id
      },
    };

    return this.http.delete<void>(this.path, options);
  }

  public getAll(): Observable<UserData[]> {
    return this.http.get<UserData[]>(this.path);
  }

  public getById(id: number): Observable<User> {
    let path: string = this.path + "/" + id;

    return this.http.get<User>(path);
  }

  public update(user: User): Observable<User> {
    return this.http.put<User>(this.path, user);
  }

  public getByUsername(username: string): Observable<UserData[]> {
    let path: string = this.path + '/byUsername/' + username;

    return this.http.get<UserData[]>(path);
  }
}
