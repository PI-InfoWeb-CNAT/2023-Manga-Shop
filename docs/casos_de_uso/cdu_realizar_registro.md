
# Projeto Comercio Eletrônico

## Especificação do caso de uso - Realizar registro

### Histórico da Revisão
|  Data  | Versão | Descrição | Autor |
|:-------|:-------|:----------|:------|
| 26/06/2023 | **1.00** | Versão modelo  | João Costa |


### 1. Resumo 
Este caso de uso permite o registro do usuário a plataforma.


### 2. Atores 
- Usuário

### 3. Pré-condições
São pré-condições para iniciar este caso de uso:
- _Possuir e-mail institucional._

### 4.Pós-condições
Após a execução deste casos de uso, espera que o sistema:
- salve o usuário cadastrado no sistema.

### 5. Fluxos de evento

#### 5.1. Fluxo Principal 

|  Ator  | Sistema |
|:-------|:------- |
|1. O _usuário_ _clica_ na função Registrar-se na página inicial. | --- |
| --- |2. O sistema _redireciona o usuário para a página de registro e exibe o formulário de registro_.| --- |
|3. O _usuário_ _insere_ os dados solicitados no formulário. | --- |
|4. O _usuário_ _clica_ em "Registrar-se" |--- |
|---| 5. O sistema _valida_ o e-mail e o cpf do usuário |
|--- | 6. O sistema _redireciona_ o usuário para a página inicial com sua conta ativada. |
|7. O _usuário_ _visualiza_ a página inicial com sua conta ativa. | --- |

### 6. Fluxo de exceção
- a) Erro nos dados: Sistema emite mensagem de erro informando que e-mail e/ou cpf são inválidos;

### 7. Dicionário de dados
- E-mail - dados alfanuméricos com 20 caracteres ou mais;
- Senha - dados alfanuméricos com 8 caracteres ou mais;
- CPF - dados numéricos com 11 caracteres;
### 8. Regras de negócio
- E-mail- String com final em @escolar.ifrn.edu.br;
- Senha - mínimo de 8 caracteres; pelo menos uma letra maiúscula e minúscula; um caractere especial.
- CPF - soma dos dígitos tem que ser igual a 33, 44, 55 ou 66;
