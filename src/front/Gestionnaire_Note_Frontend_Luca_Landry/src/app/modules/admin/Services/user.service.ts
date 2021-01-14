import { Injectable } from '@angular/core';
import {IUser} from '../Interfaces/IUser';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  user: IUser;
  route = 'https://localhost:5001/users';

  constructor(private http: HttpClient)
  {
    this.user = {} as IUser;
  }

  Add(newUser: IUser): Observable<[IUser]>
  {
    return this.http.post<[IUser]>(this.route, newUser);
  }

  Delete(id: number): Observable<[IUser]>
  {
    return this.http.delete<[IUser]>(this.route + '/' + id.toString());
  }

  GetSingle(id: number): Observable<[IUser]>
  {
    return this.http.get<[IUser]>(this.route + '/' + id.toString());
  }

  GetAll(): Observable<Array<IUser>>
  {
    return this.http.get<[IUser]>(this.route);
  }

  Update(id: number, userUpdated: IUser): Observable<[IUser]>
  {
    // @ts-ignore
    return this.http.post<[IUser]>(this.route + '/' + id.toString());
  }

  AddAvatar(id: number, image: File): Observable<[File]>
  {
    return this.http.post<[File]>(this.route + '/' + id.toString() + '/avatar', image);
  }

  GetAvatar(id: number): Observable<[File]>
  {
    return this.http.get<[File]>(this.route + '/' + id.toString() + '/avatar');
  }
}
