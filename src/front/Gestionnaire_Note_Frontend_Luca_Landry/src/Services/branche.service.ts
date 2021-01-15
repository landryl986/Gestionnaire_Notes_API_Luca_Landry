import { Injectable } from '@angular/core';
import {IPhilial} from "../Interfaces/IPhilial";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {IBranche} from "../Interfaces/IBranche";

@Injectable({
  providedIn: 'root'
})
export class BrancheService {

  branche: IBranche;
  route = 'https://localhost:5001/philials';

  constructor(private http: HttpClient)
  {
    this.branche = {} as IBranche;
  }

  Add(newBranche: IBranche): Observable<[IBranche]>
  {
    return this.http.post<[IBranche]>(this.route, newBranche);
  }

  Delete(id: number): Observable<[IBranche]>
  {
    return this.http.delete<[IBranche]>(this.route + '/' + id.toString());
  }

  GetSingle(id: number): Observable<[IBranche]>
  {
    return this.http.get<[IBranche]>(this.route + '/' + id.toString());
  }

  GetAll(): Observable<Array<IBranche>>
  {
    return this.http.get<[IBranche]>(this.route);
  }

  Update(id: number, userUpdated: IBranche): Observable<[IBranche]>
  {
    // @ts-ignore
    return this.http.post<[IBranche]>(this.route + '/' + id.toString());
  }
}
