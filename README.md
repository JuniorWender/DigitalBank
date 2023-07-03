# DigitalBank

Esta é uma API de Conta Bancária simples para realizar operações como saque, depósito, verificação de saldo e transferência entre contas.
# Como Subir o Docker

1. Abra o terminal
2. Navegue até a pasta onde se encontra o arquivo `docker-compose.yml`
3. Utilize o comando `docker-compose up`

### Abaixo as informações de conexão do banco:

* Host: localhost
* Porta: 3306
* Usuário: root
* Senha: admin

## Rodar Seed Do Banco

1. Abra o Visual Studio
2. Abra o Terminal
3. 

# Como Testar

Para testar as funcionalidades da API, você pode utilizar ferramentas como *Postman*, *Insomnia*, *cURL* ou qualquer outra ferramenta de testes de API.

Certifique-se de que o serviço da API esteja em execução e acesse as rotas descritas abaixo com as respectivas requisições e parâmetros conforme especificado.

Lembre-se de ajustar o número da conta, os valores e os dados conforme necessário para o seu contexto.
# Rotas
## Saque

Realiza um saque em uma conta bancária.

**URL:** `https://localhost:44376/api/sacar`

**Método:** `POST`

**Corpo da Requisição:**

```json
{
  "NumeroDaConta": 12345,
  "Valor": 100.0
}
```
### Resposta de Sucesso:

* Código: 200 OK
* Corpo da resposta: Transação bem sucedida, o seu saldo atual é R$[saldo]

### Resposta de Erro:

* Código: 400 Bad Request
* Corpo da resposta: Mensagem de erro


## Depósito

Realiza um depósito em uma conta bancária.

**URL:** `https://localhost:44376/api/depositar`

**Método:** `POST`

**Corpo da Requisição:**

```json
{
  "NumeroDaConta": 12345,
  "Valor": 100.0
}
```

### Resposta de Sucesso:

* Código: `200 OK`
* Corpo da resposta: `Depósito bem sucedido, o seu saldo atual é R$[saldo]`
### Resposta de Erro:

* Código: `400 Bad Request`
* Corpo da resposta: Mensagem de erro


## Saldo
Verifica o saldo de uma conta bancária.

**URL:** `https://localhost:44376/api/saldo`

**Método:** `GET`

**Cabeçalho da Requisição:**
* numeroDaConta: Número da conta bancária

### Resposta de Sucesso:

* Código: `200 OK`
* Corpo da resposta: `Esta Conta Está Em Nome De [nome] e o seu saldo atual é: R$[saldo]`

### Resposta de Erro:

* Código: `400 Bad Request`
* Corpo da resposta: Mensagem de erro


## Transferência
Realiza uma transferência entre contas bancárias.

**URL:** `https://localhost:44376/api/transferir`

**Método:** `POST`

**Corpo da Requisição:**

```json
{
  "NumeroDaContaOrigem": 12345,
  "NumeroDaContaDestino": 54321,
  "Valor": 100.0
}
```

### Resposta de Sucesso:

* Código: `200 OK`
* Corpo da resposta: `Transação bem sucedida, o seu saldo atual é R$[saldo]`

### Resposta de Erro:

* Código: `400 Bad Request`
* Corpo da resposta: Mensagem de erro

# 

## Feito por: Jorge W. Junior