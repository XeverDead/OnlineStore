import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Order } from "../models/order";
import { OrderData } from "../models/order-data";

@Injectable()
export class OrderService {
  private readonly path: string = 'api/order';

  constructor(private readonly http: HttpClient) { }

  public create(order: Order): Observable<Order> {
    return this.http.post<Order>(this.path, order);
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

  public getAll(): Observable<OrderData[]> {
    return this.http.get<OrderData[]>(this.path);
  }

  public getById(id: number): Observable<Order> {
    let path: string = this.path + "/" + id;

    return this.http.get<Order>(path);
  }

  public update(order: Order): Observable<Order> {
    return this.http.put<Order>(this.path, order);
  }

  public getByUserId(userId: number): Observable<OrderData[]> {
    let path = this.path + "/byUser/" + userId;

    return this.http.get<OrderData[]>(path);
  }

  public getNotOrdered(): Observable<Order> {
    let path = this.path + 'notOrdered';

    return this.http.get<Order>(path);
  }
}
