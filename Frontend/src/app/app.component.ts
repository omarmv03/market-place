import { Component } from '@angular/core';
import { MarketService } from './services/market.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
  title = 'creek-market-place';

  /**
   *
   */
  constructor(private marketService: MarketService) {
  }

  
  public get cantMarket() : number {
    return this.marketService.cant;
  }
  
}
