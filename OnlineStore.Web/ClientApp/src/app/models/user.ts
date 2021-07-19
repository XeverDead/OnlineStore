import { Role } from "./enums/role";
import { EmailModel } from "./sub-models/email-model";
import { PhoneNumberModel } from "./sub-models/phone-number-model";

export interface User {
  id: number;

  firstName: string;

  lastName: string;

  username: string;

  role: Role;

  phoneNumbers: PhoneNumberModel[];

  emails: EmailModel[];
}
