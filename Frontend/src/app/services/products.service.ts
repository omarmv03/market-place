import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IProducto } from '../model/producto';
import { environment } from 'src/environments/environment';
import { GenericResponse } from '../model/genericResponse';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  readonly controller = 'product';

  constructor(private httpClient: HttpClient) { }

  get(): Observable<IProducto[]> {
    return this.httpClient.get<IProducto[]>(`${environment.serverApi}/${this.controller}`);
  } 

  delete(p: IProducto): Observable<GenericResponse> {
    return this.httpClient.delete<GenericResponse>(`${environment.serverApi}/${this.controller}/${p.id.toString()}`)
  }

  update(p: IProducto): Observable<GenericResponse> {
    return this.httpClient.put<GenericResponse>(`${environment.serverApi}/${this.controller}`, p);
  }

  new(p: IProducto, file: File): Observable<GenericResponse> {
    const formData$ = new FormData();
    formData$.append('file', file); 
    formData$.append('jsonObject', JSON.stringify(p));

    return this.httpClient.post<GenericResponse>(`${environment.serverApi}/${this.controller}`, formData$);
  }
}
