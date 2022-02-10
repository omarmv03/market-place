import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IProducto } from 'src/app/model/producto';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public productos$: IProducto[] = [];

  constructor(private productsService: ProductsService) { }
  ngOnInit(): void {
    this.productsService.get().subscribe(x => {
      this.productos$ = x;
    });
  }

}
