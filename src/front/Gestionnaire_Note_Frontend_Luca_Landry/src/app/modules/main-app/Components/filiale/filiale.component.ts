import { Component, OnInit } from '@angular/core';
import {PhilialService} from '../../../../../Services/philial.service';
import {IPhilial} from "../../../../../Interfaces/IPhilial";
import {ICreateUserDto} from "../../../../../Interfaces/ICreateUserDto";

@Component({
  selector: 'app-filiale',
  templateUrl: './filiale.component.html',
  styleUrls: ['./filiale.component.scss']
})
export class FilialeComponent implements OnInit {
  filiale: IPhilial;
  filiales: Array<IPhilial>;
  id: number;

  constructor(private service: PhilialService) {
    this.filiale = {} as IPhilial;
  }

  ngOnInit(): void {
    this.GetAll();
  }

  addFilial(): void {
    this.filiale.userId = Number(localStorage.getItem('Id'));

    this.service.Add(this.filiale).subscribe(
      (res) => window.location.reload(),
      (err) => console.log(err)
    );
  }

  GetAll(): void
  {
    this.id = Number(localStorage.getItem('Id'));
    this.service.GetAllByUser(this.id).subscribe
    (
      data =>
      {
        if (data)
        {
          this.filiales = data;
        }
      },
      error => {debugger;}
    );
  }
  UpdateFiliale(filiale: IPhilial): void{
    this.service.Update(filiale.id, filiale).subscribe(() => this.GetAll());
  }
  delFiliale(filiale: IPhilial): void{
    this.service.Delete(filiale.id).subscribe(() => this.GetAll());
  }

}
