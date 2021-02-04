import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginPageComponent} from './Components/login-page/login-page.component';
import {RegisterComponent} from './Components/register/register.component';
import {LoginGuard} from '../../../Guards/login.guard';
import {MainLoginComponent} from './Components/main-login/main-login.component';

const routes: Routes = [
  {
    path: 'main',
    component: MainLoginComponent,
    canActivate: [LoginGuard],
    children:
    [
      {
        path: 'login',
        component: LoginPageComponent
      },
      {
        path: 'register',
        component: RegisterComponent
      }
    ]
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class LoginRouting { }
