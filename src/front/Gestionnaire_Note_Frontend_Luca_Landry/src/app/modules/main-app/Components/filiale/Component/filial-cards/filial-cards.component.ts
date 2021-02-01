import {PhilialService} from '../../../../../../../Services/philial.service';
import {IPhilial} from '../../../../../../../Interfaces/IPhilial';
import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';

@Component({
  selector: 'app-filial-cards',
  templateUrl: './filial-cards.component.html',
  styleUrls: ['./filial-cards.component.scss']
})
export class FilialCardsComponent implements OnInit {

  constructor(private service: PhilialService, ) { }

  @Input() filiale: IPhilial;
  @Output() filialeSelected = new EventEmitter<IPhilial>();
  @Output() filialeSelectedUpdate = new EventEmitter<IPhilial>();


  ngOnInit(): void {
  }

  selectFiliale(): void {
    this.filialeSelected.emit(this.filiale);
  }

  selectFilialeUpdate(): void {
    this.filialeSelectedUpdate.emit(this.filiale);
  }

}
