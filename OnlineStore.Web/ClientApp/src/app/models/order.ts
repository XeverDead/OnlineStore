import { OrderState } from "./enums/order-state";
import { Product } from "./product";

export interface Order {
  id: number;

  date: string;

  products: Product[];

  address: string;

  userId: number;

  state: OrderState;
}
