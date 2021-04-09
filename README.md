# Conta Virtual
## Server

Dependências:

 - [Net Core SDK 3.1](https://dotnet.microsoft.com/download) 
 
Para rodar a API da Conta Virtual é necessário abrir um terminal de comando apontando para pasta onde está o projeto **ContaVirtual_AM**

Exemplo do caminho: `~\ContaVirtual\server\ContaVirtual_AM`

Feita essa etapa, é necessário rodar o seguinte comando: `dotnet run`. Após isso a documentação da API estará disponível no seguinte endereço: https://localhost:5001/swagger.

OBS: Caso a solução seja aberta no Visual Studio, não rodar a aplicação com **IIS Express** selecionado. 

## Client

Para rodar o front-end da aplicação basta abrir o arquivo `index.html` no caminho `~\ContaVirtual\client\ContaVirtual`.

Mas caso possua o [NodeJS](https://nodejs.org/en/) instalado, é possível rodar o comando `npx http-server -o` com diretório apontado para mesma pasta com arquivo `index.html`.