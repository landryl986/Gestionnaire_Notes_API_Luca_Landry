import { Injectable } from '@angular/core';
import {IPhilial} from '../Interfaces/IPhilial';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PhilialService {

  philial: IPhilial;
  route = 'https://localhost:5001/philials';

  constructor(private http: HttpClient)
  {
    this.philial = {} as IPhilial;
  }

  Add(newPhilial: IPhilial): Observable<IPhilial>
  {
    return this.http.post<IPhilial>(this.route, newPhilial);
  }

  Delete(id: number): Observable<IPhilial>
  {
    return this.http.delete<IPhilial>(this.route + '/' + id.toString());
  }

  GetSingle(id: number): Observable<IPhilial>
  {
    return this.http.get<IPhilial>(this.route + '/' + id.toString());
  }

  GetAll(): Observable<Array<IPhilial>>
  {
    return this.http.get<Array<IPhilial>>(this.route);
  }

  GetAllByUser(id: number): Observable<Array<IPhilial>>
  {
    return this.http.get<Array<IPhilial>>(this.route + '/' + id + '/user');
  }

  Update(id: number, userUpdated: IPhilial): Observable<IPhilial>
  {
    // @ts-ignore
    return this.http.post<IPhilial>(this.route + '/' + id.toString());
  }
}
