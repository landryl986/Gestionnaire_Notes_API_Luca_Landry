import { Injectable } from '@angular/core';
import {ICreateUserDto} from '../Interfaces/ICreateUserDto';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {IPatchUserModel} from '../Interfaces/IPatchUserModel';
import {IUser} from '../Interfaces/IUser';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  user: IUser;
  route = 'https://localhost:5001/users';

  constructor(private http: HttpClient) {
    this.user = {} as IUser;
  }

  Add(newUser: ICreateUserDto): Observable<ICreateUserDto> {
    newUser.admin = false;
    return this.http.post<ICreateUserDto>(this.route, newUser);
  }

  Delete(id: number): Observable<IUser> {
    return this.http.delete<IUser>(this.route + '/' + id.toString());
  }

  GetSingle(id: number): Observable<IUser> {
    return this.http.get<IUser>(this.route + '/' + id.toString());
  }

  GetAll(): Observable<Array<IUser>> {
    return this.http.get<Array<IUser>>(this.route);
  }

  Login(email: string, pwd: string): Observable<boolean> {
    return this.http.get<boolean>(this.route + '/' + email + '/' + pwd + '/login');
  }

  GetByMail(email: string): Observable<IUser>{
    return this.http.get<IUser>(this.route + '/' + email + '/email');
  }

  Update(id: number, userUpdated: IPatchUserModel): Observable<IPatchUserModel>
  {
    // @ts-ignore
    return this.http.post<IPatchUserModel>(this.route + '/' + id.toString());
  }

  AddAvatar(id: number, image: File): Observable<File>
  {
    let formData = new FormData();
    formData.append('file', image, image.name);
    return this.http.post<File>(this.route + '/' + id.toString() + '/avatar', formData);
  }

  GetAvatar(id: number): Observable<Blob>
  {
    const httpOptions = {
      responseType: 'blob' as 'json'
    };
    return this.http.get<Blob>(this.route + '/' + id.toString() + '/avatar', httpOptions);
  }
}
