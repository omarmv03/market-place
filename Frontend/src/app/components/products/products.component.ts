import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IProducto } from 'src/app/model/producto';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent {

  showModal = false;
  selectedProduct!: IProducto;
  constructor(private productsService: ProductsService) { }
  public productos$: Observable<any[]> = this.productsService.productos$;

  deleteProduct() {
    this.productsService.delete(this.selectedProduct)
    .subscribe(x => {
      //
    });
  }

  deleteItem(p: IProducto) {
    this.selectedProduct = p;
    this.showModal = true;
  }
}
