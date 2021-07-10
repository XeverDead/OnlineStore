import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Order } from "../models/order";

@Injectable()
export class OrderService {
  private readonly path: string = 'api/orders';

  constructor(private readonly http: HttpClient) { }

  public create(order: Order): Order {
    let createdOrder: Order;

    this.http.post<Order>(this.path, order).subscribe((data) => createdOrder = data);

    return createdOrder;
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

    this.http.delete<Order>(this.path, options);
  }

  public getAll(): Order[] {
    let ordres: Order[];

    this.http.get<Order[]>(this.path).subscribe((data) => ordres = data);

    return ordres;
  }

  public getById(id: number): Order {
    let order: Order;

    let path: string = this.path + "/" + id;

    this.http.get<Order>(path).subscribe((data) => order = data);

    return order;
  }

  public update(order: Order): Order {
    let updatedOrder: Order;

    this.http.put<Order>(this.path, order).subscribe((data) => updatedOrder = data);

    return updatedOrder;
  }

  public getByUserId(userId: number): Order[] {
    let userOrders: Order[];

    let path = this.path + "/byUser/" + userId;

    this.http.get<Order[]>(path).subscribe((data) => userOrders = data);

    return userOrders;
  }

  public getNotOrdered(): Order {
    let notOrderedOrder: Order;

    let path = this.path + 'notOrdered';

    this.http.get<Order>(path).subscribe((date) => notOrderedOrder = data);

    return notOrderedOrder;
  }
}
