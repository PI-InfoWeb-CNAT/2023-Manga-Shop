
﻿
# Projeto Comercio Eletrônico - MangaShop

## Especificação do caso de uso - Criar Produto

### Histórico da Revisão
|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 14/09/2023 | **0.00** | Fazer detalhamento do caso de uso sobre Registrar novo produto | Vinícius Barbosa |


### 1. Resumo 
    Detalha o processo de registrar um novo produto no sistema
### 2. Atores
- Usuários do Sistema(vendedor)

### 3. Pré-condições
São pré-condições para iniciar este caso de uso:
- 	O usuário deve possuir um registro ativo no sistema.
- 	O usuário deve estar logado no sistema.

### 4.Pós-condições
Após a execução deste casos de uso, espera que o sistema:
- O usuário Registra seu produto para venda

### 5. Fluxos de evento

#### 5.1. Fluxo Principal

|  Ator  | Sistema |
|:-------|:------- |
| 1. Usuario clicar no perfil | --- |
| --- | 2. Sistema redireciona para página do perfil do usuario |
| 3.  Usuario Clica em “Registrar Produto” | --- |
| --- | 4.  Sistema mostra Overlay com as caixas de texto para registro de dados do produto |
| 5. Usuário Insere Informações | --- |
| --- | 6. Sistema pede confirmação |
| 7. Usuario confirma | --- |
| --- | 8. Sistema registra o produto no banco de dados |
| --- | 9. Sistema Mostra mensagem de produto registrado com sucesso |
| 10. Usuario continua navegando… | --- |

### 6. Dicionário de dados

### 7. Protótipos de UI
