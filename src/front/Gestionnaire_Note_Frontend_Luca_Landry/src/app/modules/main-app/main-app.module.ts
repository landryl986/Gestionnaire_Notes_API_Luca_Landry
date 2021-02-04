import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {BrowserModule} from '@angular/platform-browser';
import {UsersManagmentComponent} from './Components/users-managment/users-managment.component';
import {MainAppRouting} from './main-app-routing';
import { NavComponent } from './Components/nav/nav.component';
import { MainComponent } from './Components/main/main.component';
import { FilialeComponent } from './Components/filiale/filiale.component';
import {FormsModule} from '@angular/forms';
import { FilialCardsComponent } from './Components/filiale/Component/filial-cards/filial-cards.component';



@NgModule({
  declarations:
    [
      UsersManagmentComponent,
      NavComponent,
      MainComponent,
      FilialeComponent,
      FilialCardsComponent,
    ],
  imports: [
    CommonModule,
    BrowserModule,
    MainAppRouting,
    FormsModule
  ]
})
export class MainAppModule { }
