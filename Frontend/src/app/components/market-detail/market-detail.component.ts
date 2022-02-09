import { Component, OnInit } from '@angular/core';
import { IProducto } from 'src/app/model/producto';
import { MarketService } from 'src/app/services/market.service';

@Component({
  selector: 'app-market-detail',
  templateUrl: './market-detail.component.html',
  styleUrls: ['./market-detail.component.scss']
})
export class MarketDetailComponent implements OnInit {

  list: IProducto[] = [];
  constructor(private marketService: MarketService) { }

  ngOnInit(): void {
    this.list = this.marketService._productCart;
  }

  
  public get total() : number {
    var total = 0;
    this.list.forEach(i => {
      total = total + (i.precio * i.cantidadPedida);
    });

    return total;
  }
  

  public get cantMarket() : number {
    return this.marketService.cant;
  }

  remove(pr: IProducto) {
    this.marketService.removeItem(pr)
  }

}
