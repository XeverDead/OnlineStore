import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  providers: [ProductService]
})
export class ProductComponent implements OnInit {

  public product: Product;

  constructor(
    private readonly productService: ProductService,
    private readonly url: ActivatedRoute
  ) { }

  ngOnInit(): void {
    let id: number = this.url.snapshot.params.id;

    this.product = this.productService.getById(id);
  }

  public create(): void {
    this.product = this.productService.create(this.product);
  }

  public update(): void {
    this.product = this.productService.update(this.product);
  }

  public delete(): void {
    this.productService.delete(this.product.id);
  }

  public addToCurrentUserOrder(): void {
    this.productService.addToCurrentUserOrder(this.product);
  }
}
