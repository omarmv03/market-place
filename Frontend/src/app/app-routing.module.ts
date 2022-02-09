import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { MarketDetailComponent } from './components/market-detail/market-detail.component';
import { ProductsComponent } from './components/products/products.component';
import { AuthGuard } from './guard/auth.guard';
import { BasicLayoutComponent } from './layouts/basic-layout/basic-layout.component';

const routes: Routes = [
  {
    path: '', component: BasicLayoutComponent,
    children: [
      { path: '', component: HomeComponent, canActivate: [AuthGuard] },
      {
        path: 'edit-product',
        component: EditProductComponent, canActivate: [AuthGuard]
      },
      {
        path: 'edit-product/:id',
        component: EditProductComponent, canActivate: [AuthGuard]
      },
      {
        path: 'market-detail',
        component: MarketDetailComponent, canActivate: [AuthGuard]
      },
      {
        path: 'products',
        component: ProductsComponent, canActivate: [AuthGuard]
      },
    ]
  },

  {
    path: 'login',
    component: LoginComponent
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
