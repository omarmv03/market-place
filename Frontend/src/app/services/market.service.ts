import { Injectable } from '@angular/core';
import { IProducto } from '../model/producto';

@Injectable({
  providedIn: 'root'
})
export class MarketService {

  _cant = 0;
  _productCart: IProducto[] = [];
  constructor() { }
  
  public get cant() : number {
    return this._cant;
  }
  private set cant(v : number) {
    this._cant = v;
  }

  private set productCart(v : IProducto) {
    v.cantidadPedida = v.cantidadPedida ? v.cantidadPedida + 1 : 1;
    this._productCart.push(v);
  }
  
  addItem(pr: IProducto) {
    var exist = this._productCart.find(f => f.id === pr.id);

    if (exist) {
      exist.cantidadPedida = exist.cantidadPedida + 1;
      this.cant++;
      return;
    }

    this.productCart = pr;
    this.cant++;
  }

  removeItem(pr: IProducto) {
    var idx = this._productCart.findIndex(x => x == pr);
    this._productCart[idx].cantidadPedida = this._productCart[idx].cantidadPedida - 1;
    this.cant--;

    if (this._productCart[idx].cantidadPedida == 0) {
      this._productCart.splice(idx,1);
    }
  }
  
}
