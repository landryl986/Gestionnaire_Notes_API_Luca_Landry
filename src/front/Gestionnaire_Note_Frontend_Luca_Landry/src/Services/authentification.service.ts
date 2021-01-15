import { Injectable } from '@angular/core';
import {UserService} from './user.service';
import {IUser} from '../Interfaces/IUser';

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {

  public isLogged = false;
  user: IUser;
  users: Array<IUser>;

  // tslint:disable-next-line:variable-name
  constructor(private _userService: UserService) {}

  public login(userName: string, userPassword: string): boolean
  {
    localStorage.setItem('isLogged', String(this.isLogged));
    this._userService.GetAll().subscribe
    (
      data =>
      {
        if (data){
          this.users = data;
        }
      },
      error =>
      { }
    );

    if (this.users.filter(n => n.userName === userName))
    {
      // @ts-ignore
      this.user = this.users.filter(n => n.userName === userName);

      if (this.user.userPassword === userPassword)
      {
        this.isLogged = true;
      } else
      {
        this.isLogged = false;
      }
    } else
    {
      this.isLogged = false;
    }

    return this.isLogged;
    localStorage.setItem('isLogged', String(this.isLogged));

  }

  public disconect(): void{
    this.isLogged = false;
    localStorage.setItem('isLogged', String(this.isLogged));

  }
}
