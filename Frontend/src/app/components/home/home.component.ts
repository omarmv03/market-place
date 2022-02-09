import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IProducto } from 'src/app/model/producto';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  public productos$: Observable<IProducto[]> = this.productsService.productos$;

  constructor(private productsService: ProductsService) { }

}
