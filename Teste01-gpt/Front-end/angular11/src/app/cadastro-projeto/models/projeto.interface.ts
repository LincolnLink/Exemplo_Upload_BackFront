export interface Projeto {
  nomeProjeto: string;
  dataValidade: Date | null;
  arquivoExcel: File | null;
  nomeExcel: string;
}