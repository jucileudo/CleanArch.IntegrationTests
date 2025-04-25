# 🧪 CleanArch.IntegrationTests

Repositório de exemplo para **testes de integração com .NET** utilizando uma estrutura baseada em **Clean Architecture**, combinando boas práticas de injeção de dependência, persistência de dados com PostgreSQL e execução automatizada com Testcontainers.

> Este projeto é ideal para quem quer aprender como escrever testes de integração robustos e escaláveis em aplicações .NET modernas.

---

## ✅ Tecnologias Utilizadas

- **.NET 9**
- **xUnit** – Framework de testes
- **FluentAssertions** – Sintaxe fluente para assertions
- **Testcontainers** – Criação de containers Docker para testes
- **PostgreSQL** – Banco de dados relacional
- **EF Core** – ORM utilizado para comunicação com o banco

---

## 🧱 Estrutura do Projeto

```text
CleanArch.IntegrationTests/
├── src/                     # Camadas da aplicação (Domain, Application, Infra, etc.)
├── tests/
│   └── Integration/
│       ├── Fixtures/        # TestDatabaseFixture com Testcontainers
│       ├── Commons/         # Base genérica de testes
│       └── Services/        # Testes por serviço
└── README.md
```

---

## ⚙️ Pré-requisitos

- [.NET SDK 9.0+](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Docker](https://www.docker.com/) instalado e configurado para containers **Linux**

---

## 🧪 Como Executar os Testes

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/CleanArch.IntegrationTests.git
cd CleanArch.IntegrationTests
```

2. Execute os testes:

```bash
dotnet test
```

> Os testes de integração criam dinamicamente um container PostgreSQL durante a execução, não sendo necessário ter um banco configurado localmente.

---

## 💡 O Que Você Vai Aprender

- Como configurar e isolar um banco de dados real para testes
- Como injetar dependências reais e mocks em testes
- Como simular cenários reais e garantir persistência de dados
- Como aplicar tudo isso respeitando a Clean Architecture

---

## 📷 Exemplo Visual

> Exemplo de execução bem-sucedida de teste de cadastro:

![Exemplo de teste](./docs/test-success-example.png)

---

## 👤 Autor

**Jucileudo Lima**  
🔗 [LinkedIn](https://www.linkedin.com/in/seu-perfil)  
🔗 [GitHub](https://github.com/seu-usuario)

---

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
