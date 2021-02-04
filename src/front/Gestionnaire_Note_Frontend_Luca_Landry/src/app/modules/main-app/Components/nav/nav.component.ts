import { Component, OnInit } from '@angular/core';
import {AuthentificationService} from '../../../../../Services/authentification.service';
import {IUser} from "../../../../../Interfaces/IUser";
import {UserService} from "../../../../../Services/user.service";

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  user: IUser;

  constructor(private service: AuthentificationService, private  userService: UserService) {
    this.user = {} as IUser;
  }

  ngOnInit(): void {}
  deco(): void
  {
    this.service.disconect();
  }
  isAdmin(): boolean {
    if (localStorage.getItem('admin') === 'true')
    {
      return true;
    } else {
      return false;
    }
  }

}
