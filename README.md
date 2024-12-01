# 📚 SoftDesign Library - Projeto de aplicação

## 🔧 Instruções

- *Restauração/Criação do banco de dados**:

  - Abrir o arquivo Web.config no projeto SoftDesign.Library.WebAPI e atualizar a senha (Pwd) da connection string SoftDesignLibrary para a senha do banco de dados MySQL da máquina local
  - Determinar o projeto SoftDesign.Library.WebAPI como Startup Project
  - Abrir o Package Manager Consolde dentro do Visual Studio
  - Determinar o projeto SoftDesign.Library.Infrastructure como Default Project
  - Executar Update-Database para restaurar o banco de dados
  - (O método Seed irá criar alguns registros padrões no banco)

OU

  - Executar script CreateDatabase.sql contido na pasta do projeto

## 💻 Execução do projeto:

  - Determinar ambos projetos SoftDesign.Library.WebAPI e SoftDesign.Library.WebAPP como Startup Project
  - Executar ambos ao mesmo tempo

  - Usuário: systemadmin
  - Senha: gr3at@3wdsG
