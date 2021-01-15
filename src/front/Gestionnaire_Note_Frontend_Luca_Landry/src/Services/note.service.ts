import { Injectable } from '@angular/core';
import {IPhilial} from "../Interfaces/IPhilial";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {INote} from "../Interfaces/INote";

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  note: INote;
  route = 'https://localhost:5001/philials';

  constructor(private http: HttpClient)
  {
    this.note = {} as INote;
  }

  Add(newNote: INote): Observable<[INote]>
  {
    return this.http.post<[INote]>(this.route, newNote);
  }

  Delete(id: number): Observable<[INote]>
  {
    return this.http.delete<[INote]>(this.route + '/' + id.toString());
  }

  GetSingle(id: number): Observable<[INote]>
  {
    return this.http.get<[INote]>(this.route + '/' + id.toString());
  }

  GetAll(): Observable<Array<INote>>
  {
    return this.http.get<[INote]>(this.route);
  }

  Update(id: number, userUpdated: INote): Observable<[INote]>
  {
    // @ts-ignore
    return this.http.post<[INote]>(this.route + '/' + id.toString());
  }
}
