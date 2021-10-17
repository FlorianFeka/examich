import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ApiModule } from 'src/api';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './core/header/header.component';
import { MaterialModule } from './material.module';

@NgModule({
  declarations: [AppComponent, HeaderComponent],
  imports: [
    MaterialModule,
    BrowserModule,
    NoopAnimationsModule,
    HttpClientModule,
    ApiModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
