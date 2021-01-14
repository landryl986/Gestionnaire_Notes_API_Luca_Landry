import { Component, NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlueComponent } from './Components/blue/blue.component';
import { PortalComponent } from './Components/portal.component';
import { RedComponent } from './Components/red/red.component';
import { LoggedGuardGuard } from '../guard/logged-guard.guard';
import {CharacterComponent} from './Components/character/character.component';

const routes: Routes = [
  {
    path: 'portal',
    component: PortalComponent,
    canActivate: [LoggedGuardGuard],
    children: [
      {path: 'character', component: CharacterComponent},
      {path: 'red', component: RedComponent},
      {path: 'blue', component: BlueComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class PortalRoutingModule { }
