import { Injectable } from '@angular/core';

import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = localStorage.getItem('access_token');
    const newReq = req.clone({
      setHeaders: {
        'token': `${token}`,
        'Content-type': 'application/json',
        'Access-Control-Allow-Origin': '*' 
      }
    });
    return next.handle(newReq);
  }
}