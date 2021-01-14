import { Component, OnInit } from '@angular/core';
import {UsersServiceService} from '../../Services/users-service.service';
import {IUser} from '../../Interfaces/IUser';

@Component({
  selector: 'app-admin-component',
  templateUrl: './admin-component.component.html',
  styleUrls: ['./admin-component.component.scss']
})
export class AdminComponentComponent implements OnInit {
  users: Array<IUser>;
  user = {} as IUser;

  // tslint:disable-next-line:variable-name
  constructor(private _userService: UsersServiceService) { }

  ngOnInit(): void {
    this.OnGetUsers();
  }

  OnGetUsers(): void{
    this._userService.GetAll().subscribe(
      data =>
      {
        if (data){
          debugger;
          this.users = data;
        }
      },
      error =>
      { }
    );
  }

}
