import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrderState } from '../../models/enums/order-state';
import { Order } from '../../models/order';
import { Product } from '../../models/product';
import { OrderService } from '../../services/order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [OrderService]
})
export class OrderComponent implements OnInit {

  public order: Order;

  public stateType = OrderState;

  constructor(
    private readonly orderService: OrderService,
    private readonly url: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let id: number = this.url.snapshot.params.id;

    this.orderService.getById(id).subscribe(result => {
      this.order = result;
    });
  }

  public create(): void {
    this.orderService.create(this.order).subscribe(result => {
      this.order = result;
    });
  }

  public update(): void {
    this.orderService.update(this.order).subscribe(result => {
      this.order = result;
    });
  }

  public delete(): void {
    this.orderService.delete(this.order.id).subscribe();
  }

  public removeProduct(product: Product): void {
    let index: number = this.order.products.indexOf(product);

    if (index != -1) {
      this.order.products.splice(index, 1);
    }
  }
}
