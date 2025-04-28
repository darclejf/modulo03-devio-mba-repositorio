# **Plataforma Educação Online**

## **1. Apresentação**

Bem-vindo ao repositório do projeto **Plataforma Educação Online**. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo **MÓDULO 3 - Arquitetura, Modelagem e Qualidade de Software**.
Desenvolver uma API que permita aos usuários gerenciar seus cursos e aulas na plataforma EAD.

### **Autor**
- **Darclê José Fredrez**

## **2. Proposta do Projeto**

O projeto consiste em:

- **API RESTful:** Exposição dos recursos da gestão de conta para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
- **Autenticação e Autorização:** Implementação de controle de acesso, com a utlilização de claims para autorização.
- **Acesso a Dados:** Implementação de acesso ao banco de dados através de ORM.

## **3. Tecnologias Utilizadas**

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQLite
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token) para autenticação na API
- **Documentação da API:** Swagger

## **4. Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:

- src/  
  - 01.API/PlataformaEducacaoOnline.API/ - API RESTful
  - 02.Alunos/PlataformaEducacaoOnline.Alunos.Application/ - Definição de serviços de aplicação para fornecer dados para API e outros contextos
  - 02.Alunos/PlataformaEducacaoOnline.Alunos.Data/ - Modelos de Dados e Configuração do EF Core do contexto de gerenciamento de Alunos
  - 02.Alunos/PlataformaEducacaoOnline.Alunos.Domain/ - Definição de entidades e regras de Domínio da contexto de gerenciamento de Alunos
  - 03.Conteudos/PlataformaEducacaoOnline.Conteudos.Application/ - Definição de serviços de aplicação para fornecer dados para API e outros contextos
  - 03.Conteudos/PlataformaEducacaoOnline.Alunos.Data/ - Modelos de Dados e Configuração do EF Core do contexto de gerenciamento de Conteudos
  - 03.Conteudos/PlataformaEducacaoOnline.Alunos.Domain/ - Definição de entidades e regras de Domínio da contexto de gerenciamento de Conteudos
  - 04.Financeiro
  - 05.Core/PlataformaEducacaoOnline.Core
  - 06.Autenticacao
- tests/
  - Alunos/PlataformaEducacaoOnline.Alunos.Domain.Tests
  - Conteudos/PlataformaEducacaoOnline.Conteudos.Application.Tests
  - Conteudos/PlataformaEducacaoOnline.Conteudos.Domain.Tests
- README.md - Arquivo de Documentação do Projeto
- FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
- .gitignore - Arquivo de Ignoração do Git

## **5. Funcionalidades Implementadas**

- **CRUD para Cursos, Aulas, Conteúdos e Alunos:** Permite criar, editar, visualizar e excluir.
- **Autenticação e Autorização:** Controle de acesso e autorização baseada em claims.
- **API RESTful:** Exposição de endpoints para operações via API.
- **Documentação da API:** Documentação automática dos endpoints da API utilizando Swagger.

## **6. Como Executar o Projeto**

### **Pré-requisitos**
- .NET SDK 8.0 ou superior
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

### **Passos para Execução**

1. **Clone o Repositório:**
   - `git clone https://github.com/darclejf/modulo03-devio-mba-repositorio.git`
   - `cd modulo03-devio-mba-repositorio`

2. **Configuração do Banco de Dados:**
   - No arquivo `appsettings.json`, localizado no projeto **PlataformaEducacaoOnline.API**, configure a string de conexão do SQLite. Esta configuração é compartilhada por todos os projetos incluídos nesta solução.
   - Utilizando prompt de comando, acesse a pasta raiz **src/PlataformaEducacaoOnline.API** e execute o comando **dotnet ef database update -c AutenticacaoDbContext**
   - Utilizando prompt de comando, acesse a pasta raiz **src/PlataformaEducacaoOnline.API** e execute o comando **dotnet ef database update -c ConteudoDbContext**
   - O seed configurará um usuário com perfil Admin. 
     - login: admin@admin.com
     - senha: Admin@123

3. **Executar a API:**
   - `cd src/PlataformaEducacaoOnline.API/`
   - `dotnet run urls=https://localhost:5000`
   - Acesse a documentação da API em: https://localhost:5000/swagger

## **7. Instruções de Configuração**

- **JWT para API:** As chaves de configuração do JWT estão no `appsettings.json`.
- **Migrações do Banco de Dados:** As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

## **8. Documentação da API**

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

https://localhost:5000/swagger

## **9. Avaliação**

- Este projeto é parte de um curso acadêmico e não aceita contribuições externas. 
- Para feedbacks ou dúvidas utilize o recurso de Issues
- O arquivo `FEEDBACK.md` é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
