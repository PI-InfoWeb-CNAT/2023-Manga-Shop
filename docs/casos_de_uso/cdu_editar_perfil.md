
# Projeto Comercio Eletrônico

## Especificação do caso de uso - Editar perfil

### Histórico da Revisão
|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 26/06/2023 | **1.00** | Versão modelo  | João Costa, Rafa Duarte |


### 1. Resumo 
Este caso de uso permite a atualização dos dados pessoais.


### 2. Atores 
- Alunos
- Administradores

### 3. Pré-condições
São pré-condições para iniciar este caso de uso:
- _Possuir registro ativo no sistema._

### 4.Pós-condições
Após a execução deste casos de uso, espera que o sistema:
- atualize os dados pessoais do usuário.

### 5. Fluxos de evento

#### 5.1. Fluxo Principal 

|  Ator  | Sistema |
|:-------|:------- |
|1. O _usuário_ _clica_ na função Editar Perfil na tela do perfil. | --- |
| --- |2. O sistema _redireciona o usuário para a página de edição do perfil e exibe o formulário de registro_.| --- |
|3. O _usuário_ _insere_ os dados que deseja editar no formulário. | --- |
|4. O _usuário_ _clica_ em "Salvar Alterações" |--- |
|--- | 5. O sistema _redireciona_ o usuário para a página do perfil com os dados atualizados. |
|6. O _usuário_ _visualiza_ a tela do perfil com seus dados atualizados. | --- |

### 6. Dicionário de dados
- Telefone - dados númericos com 8 caracteres;
- Campus - dados alfabéticos com 5 ou mais caracteres;
- Curso - dados alfanuméricos com 5 ou mais caracteres;
