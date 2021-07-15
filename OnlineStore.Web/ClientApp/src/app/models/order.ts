import { OrderState } from "./enums/orderState";
import { Product } from "./product";

export interface Order {
  id: number;

  date: Date;

  products: Product[];

  address: string;

  userId: number;

  state: OrderState;
}
