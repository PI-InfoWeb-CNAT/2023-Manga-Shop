
# Projeto Comercio Eletrônico

## Especificação do caso de uso - Realizar login

### Histórico da Revisão
|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 26/06/2023 | **1.00** | Versão modelo  | João Costa, Gabriel Franco |


### 1. Resumo 
Este caso de uso permite a entrada no site com sua credenciais.


### 2. Atores 
- Alunos
- Administradores

### 3. Pré-condições
São pré-condições para iniciar este caso de uso:
- _Possuir registro ativo no sistema._

### 4.Pós-condições
Após a execução deste casos de uso, espera que o sistema:
- dar ao usuário acesso às funcionalidades do sistema

### 5. Fluxos de evento

#### 5.1. Fluxo Principal 

|  Ator  | Sistema |
|:-------|:------- |
|1. O _usuário_ _clica_ na função Entrar na tela inicial. | --- |
| --- |2. O sistema _redireciona o usuário para a página de login e exibe o formulário_.| --- |
|3. O _usuário_ _insere_ suas credenciais (email/cpf e senha). | --- |
|--- |4. O sistema _valida_ os dados. |
|--- | 5. O sistema _redireciona_ o usuário para a página inicial. |
|6. O _usuário_ _visualiza_ a página inicial logado em sua conta. | --- |


#### 5.2. Fluxo de excessão 

a.  Erro nas credenciais: Sistema emite mensagem de erro informando que matrícula e/ou senha são inválidos.

### 6. Dicionário de dados

- Senha - dados alfanuméricos de 8 caracteres ou mais;
- CPF - dados numéricos com 11 caracteres;

### 7. Regras de negócio
- Senha- mínimo de 8 caracteres; pelo menos uma letra maiúscula e minúscula; um caractere especial.
- E-mail- string com final em @escolar.ifrn.edu.br;
- CPF- soma dos dígitos igual a 33, 44, 55 ou 66;
