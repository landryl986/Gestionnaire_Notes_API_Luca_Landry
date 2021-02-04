import { Component, OnInit } from '@angular/core';
import {IUser} from '../../../../../Interfaces/IUser';
import {Router} from '@angular/router';
import {UserService} from '../../../../../Services/user.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  user: IUser;
  public isLogged: boolean;
  errormessage: string;

  constructor(private router: Router, private userService: UserService)
  {
    this.user = {} as IUser;
  }

  ngOnInit(): void {
  }

  login(): void {
    this.isLogged = false;
    this.userService.Login(this.user.userEmail, this.user.userPassword).subscribe(
      response => {
        this.isLogged = response;
        if (this.isLogged){
          this.userService.GetByMail(this.user.userEmail).subscribe(
            data => {
              this.user = data;
              localStorage.setItem('admin', String(this.user.admin));
              localStorage.setItem('Id', String(this.user.id));
              this.user = {} as IUser;
            }
          );
        }
        localStorage.setItem('isLogged', String(this.isLogged));
        if (!this.isLogged){
          this.errormessage = 'error login';
        }
        this.router.navigate(['app']);
      },
      error => {console.log(error); }
    );
  }
}
