import { Injectable } from '@angular/core';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  private _isAdmin: boolean = false;

  public get isAdmin() : boolean {
    return this._isAdmin;
  }
  
  private set isAdmin(v : boolean) {
    this._isAdmin = v;
  }

  logout() {
    localStorage.removeItem('access_token');
    localStorage.removeItem('currentUser');
  }

  login() {
    localStorage.setItem('access_token', 'asdsadasdas');
    localStorage.setItem('currentUser', 'pepe');
    this.isAdmin = true;
    return of({
      token: 'asdsadasdas',
      current_user: 'pepe'
    })
  }
  
  
}
