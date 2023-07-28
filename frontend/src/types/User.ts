export enum userRoleEnum {
  Customer = "customer",
  Admin = "admin",
}

export interface User {
  id: number | string;
  email: string;
  password: string;
  role: userRoleEnum;
  name: string;
  avatar: string;
}
