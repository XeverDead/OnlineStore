import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Product } from "../models/product";

@Injectable()
export class ProductService {
  private readonly path: string = 'api/products';

  constructor(private readonly http: HttpClient) { }

  public create(product: Product): Product {
    let createdProduct: Product;

    this.http.post(this.path, product).subscribe((data: any) => createdProduct = data);

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

    this.http.get(this.path).subscribe((data: any) => products = data);

    return products;
  }

  public getById(id: number): Product {
    let product: Product;

    let path: string = this.path + "/" + id;

    this.http.get(path).subscribe((data: any) => product = data);

    return product;
  }

  public update(product: Product): Product {
    let updatedProduct: Product;

    this.http.put(this.path, product).subscribe((data: any) => updatedProduct = data);

    return updatedProduct;
  }
}
