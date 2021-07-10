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
    this.orders = this.orderService.getAll();
  }

  public getByUserId(): void {
    this.orders = this.orderService.getByUserId(this.userId);
  }
}
