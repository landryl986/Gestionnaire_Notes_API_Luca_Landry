import { Injectable } from '@angular/core';
import {IUser} from '../Interfaces/IUser';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthentificationService {

  public isLogged: boolean;
  user: IUser;
  users: Array<IUser>;
  pwd: string;

  // tslint:disable-next-line:variable-name
  constructor(private route: Router) {}

  public disconect(): void{
    this.isLogged = false;
    localStorage.clear();
    localStorage.setItem('isLogged', String(this.isLogged));
    this.route.navigate(['login']);
  }
}
