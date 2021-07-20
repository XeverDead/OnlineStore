import { Component, OnInit } from '@angular/core';
import { OrderData } from '../../models/order-data';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css'],
  providers: [OrderService]
})
export class OrdersComponent implements OnInit {

  public userId: number;

  public ordersData: OrderData[];

  constructor(
    private readonly orderService: OrderService
  ) { }

  ngOnInit(): void {
    this.orderService.getAll().subscribe(result => {
      this.ordersData = result;
    });
  }

  public getByUserId(): void {
    this.orderService.getByUserId(this.userId).subscribe(result => {
      this.ordersData = result;
    });
  }
}
