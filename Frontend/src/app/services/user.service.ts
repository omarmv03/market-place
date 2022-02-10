import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { GenericResponse } from '../model/genericResponse';
import { ILogin } from '../model/login';
import { IRegister } from '../model/register';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly controller = 'user';
  constructor(private httpClient: HttpClient) { }

  private _isAdmin: boolean = false;

  public get isAdmin(): boolean {
    return this._isAdmin;
  }

  private set isAdmin(v: boolean) {
    this._isAdmin = v;
  }

  logout() {
    this.httpClient.post<GenericResponse>(`${environment.serverApi}/${this.controller}/logout`,null)
    .pipe(map((u:any) => {
      localStorage.removeItem('access_token');
      this.isAdmin = false;
    }));
  }

  login(login: ILogin): Observable<GenericResponse> {
    return this.httpClient.post<GenericResponse>(`${environment.serverApi}/${this.controller}`, login)
      .pipe(map((u: any) => {
        localStorage.setItem('access_token', u.token);
        this.isAdmin = u.isAdmin;

        return u;
      }));
  }

  register(reg: IRegister): Observable<GenericResponse> {
    return this.httpClient.post<GenericResponse>(`${environment.serverApi}/${this.controller}/register`, reg);
  }


}
