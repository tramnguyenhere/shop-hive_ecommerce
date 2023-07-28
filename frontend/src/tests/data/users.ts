import { User, userRoleEnum } from "../../types/User";

const user1: User = {
  id: 1,
  email: "john@mail.com",
  name: "john",
  password: "john",
  avatar: "",
  role: userRoleEnum.Admin,
};

const user2: User = {
  id: 2,
  email: "sabrina@mail.com",
  name: "sabrina",
  password: "sabrina",
  avatar: "",
  role: userRoleEnum.Customer,
};

const user3: User = {
  id: 3,
  email: "cina@mail.com",
  name: "cina",
  password: "cina",
  avatar: "",
  role: userRoleEnum.Admin,
};

const user4: User = {
  id: 4,
  email: "alina@mail.com",
  name: "alina",
  password: "alina",
  avatar: "",
  role: userRoleEnum.Customer,
};

export { user1, user2, user3, user4 };
