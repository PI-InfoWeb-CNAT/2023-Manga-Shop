
# Projeto Comercio Eletrônico - MangaShop

## Especificação do caso de uso - Favoritar Produto

### Histórico da Revisão
|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 04/08/2023 | **0.00** | Descrição do caso de uso sobre favoritar um produto | Vinícius Barbosa |
| 11/09/2023 | **1.00** | Merge das versões | João Costa, Minora, Rafael, Vinícius |


### 1. Resumo 
    Detalhamento sobre favoritar ou desfavoritar alguma página de um produto especifico que trouxe interesse ao usuário.
### 2. Atores
- Usuários do Sistema

### 3. Pré-condições
São pré-condições para iniciar este caso de uso:
- 	O usuário deve possuir um registro ativo no sistema.
- 	O usuário deve estar logado no sistema.

### 4.Pós-condições
Após a execução deste casos de uso, espera que o sistema:
-  Sistema registrarar o produto como favoritado ou desfavoritado na conta do usuário

### 5. Fluxos de evento

#### 5.1. Fluxo Principal

|  Ator  | Sistema |
|:-------|:------- |
| 1. Usuário abre página do produto | --- |
| --- | 2.  Sistema redireciona usuário para página do produto |
| 3. Usuário clica no botão para favoritar produto | --- |
| --- | 4.  Sistema registra produto favoritado na lista de favoritos do usuário |
| 5. Usuário Continua navegando | --- |

#### 5.1. Fluxo Alternativo

|  Ator  | Sistema |
|:-------|:------- |
| 1. O usuário clica na página de “Lista de Desejos” | --- |
| --- | 2.  Sistema o redireciona para a página. |
| 3. Usuário clica no botão de desfavoritar produto | --- |
| --- | 4. Sistema desfavoritar o produto |
| 5. usuário continua navegando. | --- |

### 6. Dicionário de dados
- string (caixa de texto para digitação da pesquisa)

### 7. Protótipos de UI
