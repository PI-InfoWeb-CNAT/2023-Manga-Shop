
# Projeto Comercio Eletrônico - MangaShop

## Especificação do caso de uso - Pesquisar Produto

### Histórico da Revisão
|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 08/01/2024 | **1.00** | Criação da descrição do caso de uso | Rafael Gomes |

### 1. Resumo 
    Detalhamento a respeito do caso de uso "pesquisar produto" relacionado a pesquisar produtos. 
    
### 2. Atores
- Usuário do sistema

### 3.Pós-condições
Após a execução deste casos de uso, espera que o sistema:
-  Mostre a View responsável por exibir os produtos solicitados

### 4. Fluxos de evento

#### 4.1 Fluxo Principal

|  Ator  | Sistema |
|:-------|:------- |
| 1. O _usuário_ _clica_ na barra de pesquisa. | --- |
| 2. O _usuário_ _digita_ o termo desejado. | --- |
| 3. O _usuário_ _confirma_ a pesquisa. | --- |
| --- | 5. O sistema _procura_ o termo no DB. |
| --- | 6. O sistema _exibe_ a View com os produtos associados ao termo solicitado pelo usuário. |
| 7. O _usuário_ _contempla_ a View com os produtos solicitados. | --- |

### 5 Fluxo de exceção

|  Ator  | Sistema |
|:-------|:------- |
| --- | 6. O sistema _não_ _encontra_ produtos relacionados ao termo correspondente. |
| --- | 7. O sistema _exibe_ a View com uma mensagem de que não foi possível encontrar produtos relacionados. |
| 8. O _usuário_ _contempla_ a View sem os produtos solicitados. | --- |


### 6. Dicionário de dados
- Termo - String enviada pelo usuário através do formulário de pesquisa. 
- DB - Database/banco de dados. 
- View - Página front-end relacionada ao Controlador

### 7. Protótipos de UI

- [Imagem protótipo de tela](https://www.figma.com/file/BXLoINNyrhLsv0nU7yeTiz/PrototipoPesquisaMangaShop?type=design&node-id=0%3A1&mode=design&t=tRwpkm3KDPPy3lCG-1)
