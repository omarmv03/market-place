import { Component, Input, OnInit } from '@angular/core';
import { MarketService } from 'src/app/services/market.service';
import { Producto } from '../../model/producto';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  @Input() producto!: Producto;
  constructor(private marketService: MarketService) { }

  ngOnInit(): void {
  }

  add(producto: Producto) {
    this.marketService.addItem(producto);
  }

}
