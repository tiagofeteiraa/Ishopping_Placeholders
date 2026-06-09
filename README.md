# iShopping — Aplicação de Gestão de Compras Domésticas

Projeto Final da Unidade Curricular de **Desenvolvimento de Aplicações**  
Curso Técnico Superior Profissional de Programação de Sistemas de Informação  
Instituto Politécnico de Leiria — Escola Superior de Tecnologia e Gestão

---

## Elementos do Grupo

| Nome | Número de Estudante |
|------|---------------------|
| Henrique Manuel Salgueiro de Freitas | 2024113651 |
| Vasco Miguel Silva Carvalho | 2023124727 |
| Tiago Ferreira Santos Féteira | 2025190507 |

---

## Descrição

O **iShopping** é um protótipo desenvolvido em C# com Windows Forms para gestão de compras domésticas. Permite gerir orçamentos mensais, planear listas de compras, registar artigos adquiridos (previstos e não previstos) e consultar estatísticas de consumo. A aplicação utiliza o padrão de arquitetura MVC e persiste todos os dados numa base de dados SQL Server através do Entity Framework 6.

---

## Pré-requisitos

- **Sistema Operativo:** Windows 10 ou superior
- **Visual Studio:** 2022 (Community ou superior) com a carga de trabalho **.NET desktop development** instalada
- **.NET Framework:** 4.8
- **SQL Server LocalDB** (incluído na instalação do Visual Studio)
- **Entity Framework:** 6.5.2 (restaurado automaticamente via NuGet)

---

## Instalação e Configuração

### 1. Extrair o Projeto

Descompactar o ficheiro `.zip` para uma pasta local à escolha.

### 2. Abrir o Projeto

Abrir a pasta extraída e fazer duplo clique no ficheiro `Ishopping_Placeholders.slnx` para abrir a solução no Visual Studio 2022.

### 3. Criação Automática da Base de Dados

A base de dados é criada automaticamente na primeira execução da aplicação através do Entity Framework. Não é necessário executar scripts SQL manualmente.

### 4. Compilar e Executar

1. No Visual Studio, restaurar os pacotes NuGet se necessário (**Tools → NuGet Package Manager → Restore**).
2. Compilar a solução (**Build → Build Solution** ou `Ctrl+Shift+B`).
3. Executar a aplicação (**F5** ou **Ctrl+F5**).

---

## Dados de Acesso Iniciais (Seed)

Na primeira execução, a base de dados é populada automaticamente com os seguintes utilizadores de teste:

| Username | Password |
|----------|----------|
| henrique | 12345 |
| vasco    | 12345 |
| tiago    | 12345 |

---

## Funcionalidades Principais

- Autenticação de utilizadores com username e password
- Gestão de Tipos de Artigo e Artigos (CRUD)
- Gestão de Utilizadores (CRUD)
- Gestão de Orçamentos mensais
- Planeamento de listas de Compras com itens previstos
- Modo Compra: registo de artigos adquiridos (previstos e não previstos), com controlo de orçamento em tempo real
- Fecho de compras com registo de data/hora e utilizador
- Exportação de compras fechadas para ficheiro CSV (separado por ponto e vírgula)
- Estatísticas: comparação orçamento vs. total gasto por mês, percentagem de artigos previstos/não previstos
- Apoio à decisão: sugestão de orçamento para o próximo mês

---

## Estrutura do Projeto

```
Ishopping/
├── Controller/      # Lógica de negócio (padrão MVC)
├── Model/           # Entidades e contexto Entity Framework
├── View/            # Formulários Windows Forms
├── App.config       # Configuração da aplicação e ligação à BD
└── Program.cs       # Ponto de entrada da aplicação
```

---

## Tecnologias Utilizadas

- **Linguagem:** C# (.NET Framework 4.8)
- **Interface:** Windows Forms (WinForms)
- **ORM:** Entity Framework 6.5.2
- **Base de Dados:** SQL Server
- **Arquitetura:** MVC (Model-View-Controller)

---

## Notas Adicionais

- Cada registo criado ou alterado fica associado ao utilizador com sessão iniciada.
- O campo `Username` é único — não é possível registar dois utilizadores com o mesmo nome de utilizador.
- Uma compra fechada não pode ser editada; apenas pode ser consultada em modo de leitura.
- O ficheiro CSV exportado inclui o cabeçalho na primeira linha com os campos: `NomeCompra`, `DataCriacao`, `DataFechada`, `NomeArtigo`, `ArtigoPrevisto`, `ArtigoNaoPrevisto`, `QuantidadePrevista`, `QuantidadeAdquirida`, `PrecoUnitario`.
