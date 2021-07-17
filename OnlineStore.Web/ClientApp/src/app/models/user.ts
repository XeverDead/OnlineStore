import { Role } from "./enums/role";
import { EmailModel } from "./sub-models/email-model";
import { PhoneNumberModel } from "./sub-models/phone-number-model";

export interface User {
  id: number;

  username: string;

  firstName: string;

  lastName: string;

  phoneNumbers: PhoneNumberModel[];

  emails: EmailModel[];

  role: Role;
}
