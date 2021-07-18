import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { PriceComparison } from '../../models/enums/price-comparison';
import { SearchType } from '../../models/enums/search-type';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
  providers: [ProductService]
})
export class ProductsComponent implements OnInit {

  public searchType = SearchType;
  public priceComparisonType = PriceComparison

  public query: number | string;
  public chosenPriceComparison: PriceComparison;

  public chosenSearchType: SearchType;

  public products: Product[];

  constructor(
    private readonly productService: ProductService
  ) { }

  ngOnInit(): void {
    this.productService.getAll().subscribe(result => {
      this.products = result;

      this.chosenPriceComparison = PriceComparison.lessOrEqual;
    });
  }

  public getByName(): void {
    this.productService.getByName(this.query.toString()).subscribe(result => {
      this.products = result;
    });
  }

  public getByCategory(): void {
    this.productService.getByCategory(this.query.toString()).subscribe(result => {
      this.products = result;
    });
  }

  public getByPrice(): void {
    this.productService.getByPrice(<number>this.query, this.chosenPriceComparison).subscribe(result => {
      this.products = result;
    });
  }

  public clearQueryValue(): void {
    this.query = null;
  }
}
