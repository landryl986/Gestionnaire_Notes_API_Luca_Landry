import { Component, OnInit } from '@angular/core';
import {UserService} from '../../../../../Services/user.service';
import {IUser} from '../../../../../Interfaces/IUser';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  user: IUser;
  // tslint:disable-next-line:variable-name
  constructor(private _service: UserService)
  {
    this.user = {} as IUser;
  }

  ngOnInit(): void {
  }

  Add(): void
  {
    this._service.Add(this.user).subscribe(
      (res) => console.log(res),
        (err) => console.log(err)
    );
    this.user = {} as IUser;
  }

}
