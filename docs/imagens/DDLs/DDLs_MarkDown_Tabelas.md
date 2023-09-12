#DDL DAS TABELAS DO DBEAVER
-

##**Tabela Usuário**

CREATE TABLE public.usuario (
	email varchar(50) NOT NULL,
	nome varchar(150) NOT NULL,
	senha varchar(50) NOT NULL,
	curso varchar(20) NULL,
	cpf bpchar(11) NOT NULL,
	data_nescimento date NULL,
	telefone varchar(15) NULL,
	campus varchar(30) NOT NULL,
	id_administrador int4 NULL,
	foto varchar(10) NULL,
	CONSTRAINT usuario_pk PRIMARY KEY (email),
	CONSTRAINT usuario_un UNIQUE (senha, nome, cpf),
	CONSTRAINT usuario_fk FOREIGN KEY (id_administrador) REFERENCES public.administrador(id)
);

---

##**Tabela Administrador**

CREATE TABLE public.administrador (
	id serial4 NOT NULL,
	nome varchar(150) NOT NULL,
	senha varchar(50) NOT NULL,
	CONSTRAINT administrador_pk PRIMARY KEY (id)
);

----

##**Tabela Produto**

CREATE TABLE public.produto (
	id serial4 NOT NULL,
	descrição varchar(300) NOT NULL,
	preco float4 NOT NULL,
	nome varchar(150) NOT NULL,
	compra_email_usuario varchar(50) NULL,
	registrar_email_usuario varchar(50) NOT NULL,
	id_administrador int4 NULL,
	CONSTRAINT produto_pk PRIMARY KEY (id),
	CONSTRAINT produto_fk FOREIGN KEY (compra_email_usuario) REFERENCES public.usuario(email) ON UPDATE CASCADE,
	CONSTRAINT produto_fk_1 FOREIGN KEY (registrar_email_usuario) REFERENCES public.usuario(email) ON UPDATE CASCADE,
	CONSTRAINT produto_fk_2 FOREIGN KEY (id_administrador) REFERENCES public.administrador(id)
);

----

##**Tabela Suporte**

CREATE TABLE public.suporte (
	"token" serial4 NOT NULL,
	"data-hora" timestamp NOT NULL,
	email_usuario varchar(50) NOT NULL,
	id_admnistrador int4 NOT NULL,
	CONSTRAINT suporte_pk PRIMARY KEY (token),
	CONSTRAINT suporte_fk FOREIGN KEY (email_usuario) REFERENCES public.usuario(email),
	CONSTRAINT suporte_fk_1 FOREIGN KEY (id_admnistrador) REFERENCES public.administrador(id)
);

----

##**Tabela Gerenciada**

CREATE TABLE public.gerenciada (
	id serial4 NOT NULL,
	id_administrador int4 NOT NULL,
	nome_categoria varchar(150) NOT NULL,
	CONSTRAINT gerenciada_pk PRIMARY KEY (id),
	CONSTRAINT gerenciada_un UNIQUE (id_administrador, nome_categoria),
	CONSTRAINT gerenciada_fk FOREIGN KEY (id_administrador) REFERENCES public.administrador(id),
	CONSTRAINT gerenciada_fk_1 FOREIGN KEY (nome_categoria) REFERENCES public.categoria(nome)
);

----

##**Tabela Categoria**

CREATE TABLE public.categoria (
	nome varchar(150) NOT NULL,
	CONSTRAINT categoria_pk PRIMARY KEY (nome)
);

-----

##**Tabela Produto Imagem**

CREATE TABLE public.produto_imagem (
	id serial4 NOT NULL,
	imagem varchar(10) NOT NULL,
	id_produto int4 NOT NULL,
	CONSTRAINT produto_imagem_pk PRIMARY KEY (id),
	CONSTRAINT produto_imagem_un UNIQUE (imagem, id_produto),
	CONSTRAINT produto_imagem_fk FOREIGN KEY (id_produto) REFERENCES public.produto(id) ON UPDATE CASCADE
);

----

##**Tabelas Pertence**

CREATE TABLE public.pertence (
	id serial4 NOT NULL,
	id_produto int4 NOT NULL,
	nome_categoria varchar(150) NOT NULL,
	CONSTRAINT pertence_pk PRIMARY KEY (id),
	CONSTRAINT pertence_un UNIQUE (id_produto, nome_categoria),
	CONSTRAINT pertence_fk FOREIGN KEY (id_produto) REFERENCES public.produto(id) ON UPDATE CASCADE,
	CONSTRAINT pertence_fk_1 FOREIGN KEY (nome_categoria) REFERENCES public.categoria(nome) ON UPDATE CASCADE
);

----

##**Tabela Favorita**

CREATE TABLE public.favorita (
	id serial4 NOT NULL,
	email_usuario varchar(50) NOT NULL,
	id_produto int4 NOT NULL,
	CONSTRAINT favorita_pk PRIMARY KEY (id),
	CONSTRAINT favorita_un UNIQUE (email_usuario, id_produto),
	CONSTRAINT favorita_fk FOREIGN KEY (email_usuario) REFERENCES public.usuario(email),
	CONSTRAINT favorita_fk_1 FOREIGN KEY (id_produto) REFERENCES public.produto(id)
);
