import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {UsersManagmentComponent} from '../main-app/Components/users-managment/users-managment.component';
import {MainComponent} from './Components/main/main.component';
import {IsloggedGuard} from '../../../Guards/islogged.guard';
import {AdminGuard} from '../../../Guards/admin.guard';
import {FilialeComponent} from './Components/filiale/filiale.component';

const routes: Routes = [
  {
    path: 'app',
    component: MainComponent,
    canActivate: [IsloggedGuard],
    children:
    [
      {
        path: 'admin',
        canActivate: [AdminGuard],
        component: UsersManagmentComponent
      },
      {
        path: 'filiale',
        component: FilialeComponent
      }
    ]
  }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class MainAppRouting { }
