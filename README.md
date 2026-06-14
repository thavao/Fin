
# Fin (Em Desenvolvimento)

Fin é um organizador de finanças básico

  

## Objetivo

Ser um organizador de finanças simples e prático.

  

## Desenvolvimento

Para utilizar comandos relacionados ao Entity Framework, como por exemplo `dotnet  ef  database  update`, deve se especificar o projeto onde está a configuração do banco e o de inicialização da aplicação com:  `--project .\src\Fin.Data\ --startup-project .\src\Fin.Api\`

```bash
dotnet ef migrations add <nome-da-migration> --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

Exemplo:

```bash
dotnet ef migrations add InitialCreate --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Remover a última migration

```bash
dotnet ef migrations remove --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Aplicar migrations no banco de dados

```bash
dotnet ef database update --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Aplicar o banco até uma migration específica

```bash
dotnet ef database update <nome-da-migration> --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

Exemplo:

```bash
dotnet ef database update InitialCreate --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Listar migrations existentes

```bash
dotnet ef migrations list --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Gerar script SQL das migrations

```bash
dotnet ef migrations script --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Gerar script SQL de uma migration específica até outra

```bash
dotnet ef migrations script <migration-inicial> <migration-final> --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

Exemplo:

```bash
dotnet ef migrations script InitialCreate AddTransactionsTable --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Reverter o banco para uma migration anterior

```bash
dotnet ef database update <nome-da-migration-anterior> --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```

### Remover todas as migrations aplicadas no banco

```bash
dotnet ef database update 0 --project .\src\Fin.Data\ --startup-project .\src\Fin.Api\
```