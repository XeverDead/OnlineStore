import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { PriceComparison } from "../models/enums/priceComparison";
import { Product } from "../models/product";

@Injectable()
export class ProductService {
  private readonly path: string = 'api/products';

  constructor(private readonly http: HttpClient) { }

  public create(product: Product): Product {
    let createdProduct: Product;

    this.http.post<Product>(this.path, product).subscribe((data) => createdProduct = data);

    return createdProduct;
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

  public getAll(): Product[] {
    let products: Product[];

    this.http.get<Product[]>(this.path).subscribe((data) => products = data);

    return products;
  }

  public getById(id: number): Product {
    let product: Product;

    let path: string = this.path + "/" + id;

    this.http.get<Product>(path).subscribe((data) => product = data);

    return product;
  }

  public update(product: Product): Product {
    let updatedProduct: Product;

    this.http.put<Product>(this.path, product).subscribe((data) => updatedProduct = data);

    return updatedProduct;
  }

  public getByCategory(category: string): Product[] {
    let productsOfCategory: Product[];

    let path = this.path + "/byCategory/" + category;

    this.http.get<Product[]>(path).subscribe((data) => productsOfCategory = data);

    return productsOfCategory;
  }

  public getByName(name: string): Product[] {
    let productsOfName: Product[];

    let path = this.path + "/byName/" + name;

    this.http.get<Product[]>(path).subscribe((data) => productsOfName = data);

    return productsOfName;
  }

  public getByPrice(price: number, comparisonType: PriceComparison): Product[] {
    let productsOfPrice: Product[];

    let params = new HttpParams()
      .set("price", price.toString())
      .set("comparisonType", comparisonType.toString());

    let path = this.path + "/byPrice?" + params.toString();

    this.http.get<Product[]>(path).subscribe((data) => productsOfPrice = data);

    return productsOfPrice;
  }

  public addToCurrentUserOrder(product: Product): void {
    let path = this.path + '/addToOrder';

    this.http.post<Product>(path, product);
  }
}
