import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './components/product/product.component';
import { HomeComponent } from './components/home/home.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MarketDetailComponent } from './components/market-detail/market-detail.component';
import { LoginComponent } from './components/login/login.component';
import { ProductsComponent } from './components/products/products.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BasicLayoutComponent } from './layouts/basic-layout/basic-layout.component';
import { AuthGuard } from './guard/auth.guard';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { RegisterComponent } from './components/register/register.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    HomeComponent,
    MarketDetailComponent,
    LoginComponent,
    ProductsComponent,
    EditProductComponent,
    BasicLayoutComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    ToastrModule.forRoot(), // ToastrModule added
  ],
  providers: [AuthGuard,
              { 
                provide: HTTP_INTERCEPTORS, 
                useClass: ErrorInterceptor,
                multi: true },
              {
                provide: HTTP_INTERCEPTORS,
                useClass: TokenInterceptor,
                multi: true
              },],
  bootstrap: [AppComponent]
})
export class AppModule { }
