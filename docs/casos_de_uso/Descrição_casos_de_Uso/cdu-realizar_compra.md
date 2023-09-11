
# Projeto Comercio Eletrônico - MangaShop

## Especificação do caso de uso - Realizar compra

### Histórico da Revisão
|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 04/08/2023 | **0.00** | Descrever exibir um determinado produto | Vinícius Barbosa |
| 04/09/2023 | **1.00** | Versão modelo  | João Costa, Minora, Rafa Duarte, Rafael |
| 11/09/2023 | **2.00** | Merge das versões | João Costa, Minora, Rafael, Vinícius |


### 1. Resumo 
    Detalhamento do método de compra de um produto dentro da plataforma da manga shop
### 2. Atores
- Usuarios do Sistema

### 3. Pré-condições
São pré-condições para iniciar este caso de uso:
- 	O usuário deve possuir um registro ativo no sistema.
- 	O usuário deve estar logado no sistema.
- 	O produto deve possuir registro ativo no sistema.

### 4.Pós-condições
Após a execução deste casos de uso, espera que o sistema:
-  Registre uma compra tanto para o usuario como o vendedor

### 5. Fluxos de evento

#### 5.1. Fluxo Principal
##### Pagamento por pix

|  Ator  | Sistema |
|:-------|:------- |
| 1. Usuário clica no anúncio do produto | --- |
| --- | 2. Sistema redireciona usuário para página do Produto clicado |
| 3.  usuario clica no botão para Comprar Produto | --- |
| --- | 4. Sistema Informa mensagem perguntando método de pagamento |
| 5. Usuário informa método de pagamento | --- |
| --- | 6. Sistema Exibe pedido de pagamento |
| 7. Usuário efetua pagamento | --- |
| --- | 8. Sistema Faz Confirmação do pagamento  |
| --- | 9. Sistema fecha aba de pagamento |
| 10. Usuário Continua Navegando | --- |

#### 5.1. Fluxo alternativo
##### pagamento por boleto

|  Ator  | Sistema |
|:-------|:------- |
| 1. Usuário clica no anúncio do produto | --- |
| --- | 2. Sistema redireciona usuário para página do Produto clicado |
| 3.  usuario clica no botão para Comprar Produto | --- |
| --- | 4. Sistema Informa mensagem perguntando método de pagamento |
| 5. Usuário informa método de pagamento | --- |
| --- | 6. Sistema Exibe pedido de pagamento |
| 7. Usuário efetua pagamento | --- |
| --- | 8. Sistema informa tempo para confirmação do pagamento |
| --- | 9. clica para fechar aba de pagamento |
| --- | 11. Sistema fecha aba de pagamento |
| 12. Usuário Continua Navegando | --- |


### 6. Dicionário de dados

### 7. Protótipos de UI
