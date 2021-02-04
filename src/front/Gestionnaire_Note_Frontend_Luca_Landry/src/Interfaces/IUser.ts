export interface IUser
{
  id: number;
  userName: string;
  userLastName: string;
  userEmail: string;
  userPassword: string;
  avatar: File;
  admin: boolean;
}
