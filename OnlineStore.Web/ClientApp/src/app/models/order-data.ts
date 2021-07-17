import { OrderState } from "./enums/order-state";

export interface OrderData {
  id: number;

  userId: number;

  state: OrderState;
}
