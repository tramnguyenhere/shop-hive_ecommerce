import { Product } from "./Product";

export interface ProductUpdate {
  id: string;
  update: Omit<Product, "id">;
}
