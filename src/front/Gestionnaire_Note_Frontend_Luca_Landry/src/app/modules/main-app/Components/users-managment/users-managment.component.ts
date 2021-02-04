import { Component, OnInit } from '@angular/core';
import {IUser} from '../../../../../Interfaces/IUser';
import {UserService} from '../../../../../Services/user.service';
import {Router} from "@angular/router";

@Component({
  selector: 'app-users-managment',
  templateUrl: './users-managment.component.html',
  styleUrls: ['./users-managment.component.scss']
})
export class UsersManagmentComponent implements OnInit {
  user = {} as IUser;
  users: Array<IUser> = new Array<IUser>();

  // tslint:disable-next-line:variable-name
  constructor(private _userService: UserService, private router: Router) {}

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll(): void
  {
    this._userService.GetAll().subscribe
    (
      data =>
      {
        if (data)
        {
          this.users = data['result'];
        }
      },
      error => {}
    );
  }
  SetAvatar(event, id: number): void
  {
    let File: FileList = event.target.files;
    if (File.length > 0){
      this._userService.AddAvatar(id, File[0]).subscribe(
        response =>
        {
            console.log(response);
            window.location.reload();
        },
        error => {}
      );
    }
  }

}
