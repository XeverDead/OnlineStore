import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Order } from '../../models/order';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  providers: [OrderService]
})
export class OrderComponent implements OnInit {

  public order: Order;

  constructor(
    private readonly orderService: OrderService,
    private readonly url: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let id: number = this.url.snapshot.params.id;

    this.order = this.orderService.getById(id);
  }

  public create(): void {
    this.order = this.orderService.create(this.order);
  }

  public update(): void {
    this.order = this.orderService.update(this.order);
  }

  public delete(): void {
    this.orderService.delete(this.order.id);
  }
}
