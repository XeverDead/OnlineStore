import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { PriceComparison } from "../models/enums/price-comparison";
import { Product } from "../models/product";

@Injectable()
export class ProductService {
  private readonly path: string = 'api/product';

  constructor(private readonly http: HttpClient) { }

  public create(product: Product): Observable<Product> {
    return this.http.post<Product>(this.path, product);
  }

  public delete(id: number): Observable<void> {
    const options = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
      body: {
        id: id
      },
    };

    return this.http.delete<void>(this.path, options);
  }

  public getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.path);
  }

  public getById(id: number): Observable<Product> {
    let path: string = this.path + "/" + id;

    return this.http.get<Product>(path);
  }

  public update(product: Product): Observable<Product> {
    return this.http.put<Product>(this.path, product);
  }

  public getByCategory(category: string): Observable<Product[]> {
    let path = this.path + "/byCategory/" + category;

    return this.http.get<Product[]>(path);
  }

  public getByName(name: string): Observable<Product[]> {
    let path = this.path + "/byName/" + name;

    return this.http.get<Product[]>(path);
  }

  public getByPrice(price: number, comparisonType: PriceComparison): Observable<Product[]> {
    let params = new HttpParams()
      .set("price", price.toString())
      .set("comparisonType", comparisonType.toString());

    let path = this.path + "/byPrice?" + params.toString();

    return this.http.get<Product[]>(path);
  }

  public addToCurrentUserOrder(product: Product): Observable<void> {
    let path = this.path + '/addToOrder';

    return this.http.post<void>(path, product);
  }
}
