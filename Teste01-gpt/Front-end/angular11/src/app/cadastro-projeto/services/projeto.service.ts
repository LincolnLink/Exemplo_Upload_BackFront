import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Projeto } from '../models/projeto.interface';

@Injectable({
  providedIn: 'root'
})
export class ProjetoService {

  protected UrlServiceV1: string = "http://localhost:5062/api/";

  constructor(private http: HttpClient,) { }

  registrarProjeto(projeto: FormData) : Observable<any>{

    return this.http.post(this.UrlServiceV1 + 'projeto/Adicionar', projeto).pipe(
      catchError(this.handleError)
    )        
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // Erro ocorreu no lado do cliente
      console.error('Erro ocorreu:', error.error.message);
    } else {
      console.log("erro: ", error)
      // O backend retornou um código de resposta de erro
      // console.error(
      //   `Código de status: ${error.status}, ` +
      //   `Erro: ${error.error}`);
    }
    // Retorna um observable com uma mensagem de erro amigável
    return throwError('Ocorreu um erro. Por favor, tente novamente mais tarde.');
  }
}
