import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { IProducto } from '../model/producto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient: HttpClient) { }

  public getData(): Observable<IProducto[]> {
    const data = [
      { id: 1, descripcion: "Teclado Gammer con 6 meses garantia", precio: 5000, imagen: "https://http2.mlstatic.com/D_NQ_NP_929016-MLA45169314172_032021-O.webp", titulo: "Teclado" },
      { id: 2, descripcion: "Mouse inalambrico", precio: 500, imagen: "https://247tecno.com/wp-content/uploads/2018/05/Rat%C3%B3n-o-mouse.jpg", titulo: "Mouse" },
      { id: 3, descripcion: "Parlante estereo USB", precio: 100, imagen: "https://247tecno.com/wp-content/uploads/2018/05/Rat%C3%B3n-o-mouse.jpg", titulo: "Parlante" }
    ];
    
    return of(data as IProducto[]);
  }

  productos$: Observable<IProducto[]> = of([
    { id: 1, descripcion: "Teclado Gammer con 6 meses garantia", precio: 5000, imagen: "https://http2.mlstatic.com/D_NQ_NP_929016-MLA45169314172_032021-O.webp", titulo: "Teclado" },
    { id: 2, descripcion: "Mouse inalambrico", precio: 500, imagen: "https://247tecno.com/wp-content/uploads/2018/05/Rat%C3%B3n-o-mouse.jpg", titulo: "Mouse" },
    { id: 3, descripcion: "Parlante estereo USB", precio: 100, imagen: "https://247tecno.com/wp-content/uploads/2018/05/Rat%C3%B3n-o-mouse.jpg", titulo: "Parlante" }
  ] as IProducto[]);

  delete(p: IProducto) {
    return this.httpClient.delete(`${environment.serverApi}/${p.id.toString()}`)
  }

  update(p: IProducto) {
    return this.httpClient.put(environment.serverApi, p);
  }

  new(p: IProducto) {
    return this.httpClient.post(environment.serverApi, p);
  }
}
