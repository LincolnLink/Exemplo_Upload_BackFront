import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { Projeto } from './models/projeto.interface';
import { ProjetoService } from './services/projeto.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-cadastro-projeto',
  templateUrl: './cadastro-projeto.component.html',
  styleUrls: ['./cadastro-projeto.component.css']
})
export class CadastroProjetoComponent implements OnInit {

  meuFormGroup!: FormGroup;
  arquivoInvalido: boolean = false;
  imagemForm: any;
  imagemNome: string = '';

  projeto: Projeto = {
    nomeProjeto: '',
    dataValidade: null,
    arquivoExcel: null,
    nomeExcel: ''
  };

  @ViewChild('meuFormulario') meuFormulario!: NgForm;

  constructor(    
    private formBuilder: FormBuilder,
    private projetoService: ProjetoService
    ) {
      this.imagemForm = new FormData();
    }

  ngOnInit(): void {

    this.meuFormGroup = this.formBuilder.group({
      nomeProjeto: ['', Validators.required],
      dataValidade: ['', Validators.required],
      arquivoExcel: [null, Validators.required]
    });
  }

  submitForm() {
    if (this.meuFormGroup && this.meuFormGroup.valid) { // Verifica se meuFormGroup não é nulo
      const nomeProjeto = this.meuFormGroup.get('nomeProjeto')?.value; // Verifica se nomeProjeto não é nulo
      const dataValidade = this.meuFormGroup.get('dataValidade')?.value; // Verifica se dataValidade não é nulo
      const arquivoExcel = this.meuFormGroup.get('arquivoExcel')?.value; // Verifica se arquivoExcel não é nulo
  
      if (nomeProjeto && dataValidade && arquivoExcel) 
      {
         // Verifica se os valores não são nulos
        //const formData = new FormData();

        let projetoFormObj = Object.assign({}, this.projeto, this.meuFormGroup.value)

        projetoFormObj.dataValidade = dataValidade;

        //formData.append('nomeProjeto', nomeProjeto);
        //formData.append('dataValidade', dataValidade.toISOString());
        //formData.append('arquivoExcel', arquivoExcel);
  
        this.projetoHandle(projetoFormObj)
          .subscribe(
          response => {
            console.log('Dados enviados com sucesso!', response);
            this.meuFormGroup.reset();
          },
          error => {
            console.error('Erro ao enviar dados:', error);
          }
        );
      }
    }
  }

  handleFileInput(event: any) {
    const file = event.target.files[0];
    // Verifica se é um arquivo Excel
    if (file.type !== 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet') {
      this.arquivoInvalido = true;
      this.meuFormGroup.get('arquivoExcel')?.setErrors({ 'invalidFileType': true });
    } else {
      this.arquivoInvalido = false;
      this.meuFormGroup.get('arquivoExcel')?.setValue(file);
      this.imagemForm = file;
      this.imagemNome = file.name;
    }
  }

  projetoHandle(projeto: Projeto): Observable<Projeto>{

    let formData = new FormData();
    projeto.nomeExcel = this.imagemNome;

    formData.append('projeto', JSON.stringify(projeto));
    formData.append('ImagemUpload', this.imagemForm, this.imagemNome);

    return this.projetoService.registrarProjeto(formData);
  }

}
