# CP4 .NET | Book API & MongoDB

## Integrantes
| Nome                   |   RM   |
| :--------------------- | :----: |
| Otavio Miklos Nogueira | 554513 |
| Luciayla Yumi Kawakami | 557987 |
| Sofia Andrade Petruk   | 556585 |

## Links
- Github: [https://github.com/omininola/cp4_dotnet](https://github.com/omininola/cp4_dotnet)
- Vídeo: [https://youtu.be/Yy0EYkUx4LY](https://youtu.be/Yy0EYkUx4LY)

## Rodando o projeto

### Inicialização
```bash
# Clone o projeto
git clone https://github.com/omininola/cp4_dotnet

# Entre no diretório do projeto
cd cp4_dotnet
```

### Conexão com o Mongo
```json
// appsettings.json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",

  "MongoDB": {
    "ConnectionString": <suaStringDeConexão>,
    "DatabaseName": <nomeDoBanco>,
    "CollectionName": <nomeDaCollection>
  }
}
```

### Rodando & Testes
```bash
# Dentro do diretório rode o projeto com o comando abaixo
dotnet run
```

1. No seu navegador de preferência entre na url:
[http://localhost:8080/swagger](http://localhost:8080/swagger)
2. Rode as requisições HTTP