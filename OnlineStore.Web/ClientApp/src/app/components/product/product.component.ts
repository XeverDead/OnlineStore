import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers: [ProductService]
})
export class ProductComponent implements OnInit {

  private id: number;
  public product: Product;

  constructor(
    private readonly productService: ProductService,
    private readonly url: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.id = this.url.snapshot.params.id;

    if (this.id) {
      this.productService.getById(this.id).subscribe(result => {
        this.product = result;
      });
    }
    else {
      this.product = {
        id: 0,
        name: null,
        price: 0,
        category: null,
        description: null,
        imagePath: null
      };
    }
  }

  public createOrUpdate() {
    if (this.id) {
      this.update();
    }
    else {
      this.create();
    }
  }

  public create(): void {
    this.productService.create(this.product).subscribe(result => {
      this.product = result;
    });
  }

  public update(): void {
    this.productService.update(this.product).subscribe(result => {
      this.product = result;
    })
  }

  public delete(): void {
    this.productService.delete(this.product.id).subscribe();
  }

  public addToCurrentUserOrder(): void {
    this.productService.addToCurrentUserOrder(this.product).subscribe();
  }
}
