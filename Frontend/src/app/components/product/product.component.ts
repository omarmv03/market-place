import { Component, Input, OnInit } from '@angular/core';
import { MarketService } from 'src/app/services/market.service';
import { IProducto } from '../../model/producto';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  @Input() producto!: IProducto;
  constructor(private marketService: MarketService) { }

  ngOnInit(): void {
  }

  add(producto: IProducto) {
    this.marketService.addItem(producto);
  }

}
