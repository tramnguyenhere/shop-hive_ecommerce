export interface Review {
  id: string;
  name: string;
  email: string;
  feedback: string;
  productId: string | undefined;
}
