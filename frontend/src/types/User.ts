export enum userRoleEnum {
  Customer = "Customer",
  Admin = "Admin",
}

export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  role: userRoleEnum;
  avatar: string;
  address: string;
  password?: string;
}
