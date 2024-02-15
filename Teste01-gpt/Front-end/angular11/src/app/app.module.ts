import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CadastroProjetoComponent } from './cadastro-projeto/cadastro-projeto.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProjetoService } from './cadastro-projeto/services/projeto.service';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    CadastroProjetoComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
    
  ],
  providers: [ProjetoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
