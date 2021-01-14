import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './Components/login.component';
import { IsLoggedGuard } from '../guard/is-logged.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
    canActivate: [IsLoggedGuard]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class LoginRoutingModule { }
