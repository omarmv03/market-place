import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private httpClient: HttpClient) { }

  //public productos$ = this.httpClient.get('Productos');

  productos$: Observable<any[]> = of([
    { id: "1", descripcion: "Teclado Gammer con 6 meses garantia", precio: 5000, imagen: "https://http2.mlstatic.com/D_NQ_NP_929016-MLA45169314172_032021-O.webp", titulo: "Teclado" },
    { id: "2", descripcion: "Mouse inalambrico", precio: 500, imagen: "https://247tecno.com/wp-content/uploads/2018/05/Rat%C3%B3n-o-mouse.jpg", titulo: "Mouse" },
    { id: "3", descripcion: "Parlante estereo USB", precio: 100, imagen: "https://247tecno.com/wp-content/uploads/2018/05/Rat%C3%B3n-o-mouse.jpg", titulo: "Parlante" }
  ]);
}
