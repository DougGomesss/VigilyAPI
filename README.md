# Vigily API

O Vigily é uma plataforma de conexão entre empresas e vigilantes.

Uma empresa entra na plataforma, encontra vigilantes disponíveis e solicita contato com um deles. O vigilante recebe a solicitação, analisa as informações da empresa e decide se aceita ou não. Quando aceita, os dois lados passam a ter acesso aos dados de contato um do outro e a comunicação acontece fora da plataforma.

O produto foi pensado para ser simples e direto: empresa encontra vigilante, solicita, vigilante aceita, os dois se conectam.

---

## O que o projeto utiliza

- **Scalar** — visualização e teste dos endpoints da API (disponível em `/scalar/v1` ao rodar em modo desenvolvimento)
- **MySQL** — banco de dados relacional
- **Entity Framework Core** — ORM para comunicação com o banco
- **Pomelo** — provider do EF Core para MySQL
- **.NET 9** — framework da aplicação

---

## Como rodar

**Pré-requisitos:**

- .NET 9 SDK instalado
- MySQL rodando localmente

**1.Crie o `appsettings.json` e Configure a connection string :**

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seuip;Database=seudatabase;Uid=root;Pwd=senha"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**2. Configure o banco de dados:**

Se for a primeira vez ou quiser recriar o banco do zero:

- Certifique-se de que os Models estão corretos em `Models/`
- Registre qualquer nova entidade no `Context/VigilyAPICon.cs` com um `DbSet`
- Crie a migration:

```
dotnet ef migrations add NomeDaMigration
```

- Aplique no banco:

```
dotnet ef database update
```

**3. Rode o projeto:**

```
dotnet run
```

**4. Acesse o Scalar para visualizar os endpoints:**

```
https://localhost:{porta}/scalar/v1
```

---

## Tecnologias usadas

- Data Annotations
- Migrations
- SOLID
