import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import {FormsModule, ReactiveFormsModule} from '@angular/forms'
import {HttpClientModule, HttpClient} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClienteComponent } from './cliente/cliente.component';
import {ClienteService} from './cliente.service'
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule   
  ],
  providers: [HttpClientModule, ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
