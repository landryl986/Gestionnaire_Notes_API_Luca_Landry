import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersManagmentComponent } from './Components/users-managment/users-managment.component';

const routes: Routes = [
  {
    path: 'admin',
    component: UsersManagmentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AdminRouting { }
