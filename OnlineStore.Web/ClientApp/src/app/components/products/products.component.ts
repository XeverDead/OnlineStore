import { Component, OnInit } from '@angular/core';
import { PriceComparison } from '../../models/enums/priceComparison';
import { SearchType } from '../../models/enums/searchType';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  providers: [ProductService]
})
export class ProductsComponent implements OnInit {

  public searchType = SearchType;
  public priceComparisonType = PriceComparison

  public chosenSearchType: SearchType;

  public products: Product[];

  constructor(
    private readonly productService: ProductService
  ) { }

  ngOnInit(): void {
    this.productService.getAll().subscribe(result => {
      this.products = result;
    });
  }

  public getByName(name: string): void {
    this.productService.getByName(name).subscribe(result => {
      this.products = result;
    });
  }

  public getByCategory(category: string): void {
    this.productService.getByCategory(category).subscribe(result => {
      this.products = result;
    });
  }

  public getByPrice(price: number, priceComparison: PriceComparison): void {
    this.productService.getByPrice(price, priceComparison).subscribe(result => {
      this.products = result;
    });
  }
}
