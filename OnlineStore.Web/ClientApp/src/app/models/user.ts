import { Role } from "./enums/role";

export interface User {
  id: number;

  username: string;

  firstName: string;

  lastName: string;

  phoneNumbers: string[];

  emails: string[];

  role: Role;
}
