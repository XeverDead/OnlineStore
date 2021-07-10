import { OrderState } from "./enums/orderState";
import { Product } from "./product";
import { User } from "./user";

export interface Order {
  id: number;

  date: Date;

  products: Product[];

  address: string;

  user: User;

  state: OrderState;
}
