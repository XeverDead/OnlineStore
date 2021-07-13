import { Component, OnInit } from '@angular/core';
import { Order } from '../../models/order';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  providers: [OrderService]
})
export class OrdersComponent implements OnInit {

  public userId: number;

  public orders: Order[];

  constructor(
    private readonly orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.orderService.getAll().subscribe(result => {
      this.orders = result;
    });
  }

  public getByUserId(): void {
    this.orderService.getByUserId(this.userId).subscribe(result => {
      this.orders = result;
    });
  }
}
