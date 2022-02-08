import { Injectable } from '@angular/core';
import { Producto } from '../model/producto';

@Injectable({
  providedIn: 'root'
})
export class MarketService {

  _cant = 0;
  _productCart: Producto[] = [];
  constructor() { }
  
  public get cant() : number {
    return this._cant;
  }
  private set cant(v : number) {
    this._cant = v;
  }

  private set productCart(v : Producto) {
    this._productCart.push(v);
  }
  
  addItem(pr: Producto) {
    this.productCart = pr;
    this.cant++;
  }
  
}
