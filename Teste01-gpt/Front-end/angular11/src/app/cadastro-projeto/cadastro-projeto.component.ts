import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


interface Projeto {
  nome: string;
  dataValidade: Date | null;
  arquivoExcel: File | null;
}

@Component({
  selector: 'app-cadastro-projeto',
  templateUrl: './cadastro-projeto.component.html',
  styleUrls: ['./cadastro-projeto.component.css']
})
export class CadastroProjetoComponent implements OnInit {

  projeto: Projeto = {
    nome: '',
    dataValidade: null,
    arquivoExcel: null
  };

  arquivoInvalido: boolean = false;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
  }

  submitForm() {
    const formData = new FormData();
    formData.append('nome', this.projeto.nome);
    if (this.projeto.dataValidade !== null) {
      formData.append('dataValidade', this.projeto.dataValidade.toISOString());
    }
    if (this.projeto.arquivoExcel !== null) { // Verifique se o arquivo é nulo
      formData.append('arquivoExcel', this.projeto.arquivoExcel);
    }

    this.http.post<any>('URL_DA_SUA_API', formData).subscribe(
      response => {
        console.log('Dados enviados com sucesso!', response);
        // Resetar o formulário ou fazer outras operações após o envio bem-sucedido
      },
      error => {
        console.error('Erro ao enviar dados:', error);
      }
    );    
  }

  handleFileInput(event: any) {
    const file = event.target.files[0];
    if (file && file.type === 'application/vnd.ms-excel') {
      this.projeto.arquivoExcel = file;
      this.arquivoInvalido = false;
    } else {
      this.arquivoInvalido = true;
    }
  }



}
