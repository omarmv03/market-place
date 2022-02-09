import { Component, OnInit } from '@angular/core';
import { MarketService } from 'src/app/services/market.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-basic-layout',
  templateUrl: './basic-layout.component.html',
  styleUrls: ['./basic-layout.component.scss']
})
export class BasicLayoutComponent {
  constructor(private marketService: MarketService,
              private userService: UserService) {
  }
  public get cantMarket() : number {
    return this.marketService.cant;
  }

  
  public get isAdmin() : boolean {
    return this.userService.isAdmin;
  }
  

}
