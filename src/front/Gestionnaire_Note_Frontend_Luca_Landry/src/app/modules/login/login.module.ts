import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginPageComponent } from './Components/login-page/login-page.component';
import {LoginRouting} from './login-routing';
import {FormsModule} from '@angular/forms';
import {BrowserModule} from '@angular/platform-browser';
import {RegisterComponent} from './Components/register/register.component';
import { MainLoginComponent } from './Components/main-login/main-login.component';



@NgModule({
  declarations: [
      LoginPageComponent,
      RegisterComponent,
      MainLoginComponent
    ],
  imports: [
    CommonModule,
    LoginRouting,
    FormsModule,
    BrowserModule
  ]
})
export class LoginModule { }
