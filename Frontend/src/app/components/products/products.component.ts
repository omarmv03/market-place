import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IProducto } from 'src/app/model/producto';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit{

  showModal = false;
  selectedProduct!: IProducto;
  constructor(private productsService: ProductsService) { }
  public productos$: IProducto[] = [];
  
  ngOnInit(): void {
    this.productsService.get().subscribe(x => {
      this.productos$ = x;
    });
  }
  
  deleteProduct() {
    this.productsService.delete(this.selectedProduct)
    .subscribe(x => {
      this.showModal = false;
      this.productsService.get().subscribe(x => {
        this.productos$ = x;
      });
      alert(x.message);
    });
  }

  deleteItem(p: IProducto) {
    this.selectedProduct = p;
    this.showModal = true;
  }
}
