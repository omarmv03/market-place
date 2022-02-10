import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private userService: UserService,
                private router: Router) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            
            if (err.status === 401) {
                this.userService.logout();
                this.router.navigate(['/login']);
                alert(err.error && err.error.message ? err.error.message :  'Unauthorized');
            } else  if (err.status === 400) {
                alert(err.error && err.error.message ? err.error.message :  'Unauthorized');
            }

            // const error = err.error.message || err.statusText;
            const error = err;

            return throwError(error);
        }))
    }
}