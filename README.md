# Exemplo_Upload_BackFront
Exemplo usando DotNet, Angular,OracleSql

# Instalando versão antiga do Node, para usar Angular versao antiga.

 - Precisa instalar o nvm, baixa o nvm-setup.exe

   https://github.com/coreybutler/nvm-windows/releases

 - Comandos:

  - nvm ls : lista as minhas versoes do Node.
  - nvm use ....: escolha a versao do node para usar.
  - node -v: versão do node que está sendo usada.
  - nvm list available: lista todas as versões do node disponivel.
  - nvm install 'numero da versao do node': instala o node.

# Angular CLI

 - Com o node antigo instalado, deve ser instalar o Angular CLI da versão antiga que você deseja, por exemplo, angular 11, usa o CLI 11, angular10 o CLI 10.

 - npm install @angular/cli@10 --save-dev

 - sempreque rodar o projeto deve intalar da versão desejada.

 ### instalar apenas no projeto

 - npm install @angular/cli@11 --save-dev

# Criando projetos antigos do Angular

 - ng new nome-do-projeto --version=11.0.0
  
# Variavelde ambiente do ng

 - C:\Users\Lincoln\AppData\Roaming\npm\node_modules\@angular\cli\bin

# Para executar o npm i em projetos antigos

 - npm install --legacy-peer-deps

 - Forçar a instalação: Você pode tentar forçar a instalação das dependências usando o parâmetro --legacy-peer-deps ao executar o comando npm install. Isso pode ajudar a aceitar uma resolução de dependências mais antiga que pode ser compatível com as versões específicas dos pacotes que você está usando.