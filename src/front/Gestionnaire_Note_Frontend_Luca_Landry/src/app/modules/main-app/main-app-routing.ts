import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginPageComponent} from './Components/login-page/login-page.component';
import {UsersManagmentComponent} from '../main-app/Components/users-managment/users-managment.component';

const routes: Routes = [
  {
    path: 'login',
    component: LoginPageComponent
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class LoginRouting { }
