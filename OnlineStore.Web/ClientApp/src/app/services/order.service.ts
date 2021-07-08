import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Order } from "../models/order";

@Injectable()
export class OrderService {
  private readonly path: string = 'api/orders';

  constructor(private readonly http: HttpClient) { }

  public create(order: Order): Order {
    let createdOrder: Order;

    this.http.post(this.path, order).subscribe((data: any) => createdOrder = data);

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

    this.http.delete(this.path, options);
  }

  public getAll(): Order[] {
    let ordres: Order[];

    this.http.get(this.path).subscribe((data: any) => ordres = data);

    return ordres;
  }

  public getById(id: number): Order {
    let order: Order;

    let path: string = this.path + "/" + id;

    this.http.get(path).subscribe((data: any) => order = data);

    return order;
  }

  public update(order: Order): Order {
    let updatedOrder: Order;

    this.http.put(this.path, order).subscribe((data: any) => updatedOrder = data);

    return updatedOrder;
  }
}
