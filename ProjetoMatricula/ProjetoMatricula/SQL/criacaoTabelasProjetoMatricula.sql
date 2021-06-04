CREATE TABLE tb_tipodocumento
(
  id int identity NOT NULL,
  descricao varchar(30) NOT NULL,
  CONSTRAINT tb_tipodocumento_pkey PRIMARY KEY (id)  
)

CREATE TABLE tb_tipoendereco
(
  id int identity NOT NULL,
  descricao varchar(30) NOT NULL,
  CONSTRAINT tb_tipoendereco_pkey PRIMARY KEY (id)
)

CREATE TABLE tb_tipocurso
(
  id int identity NOT NULL,
  descricao varchar(30) NOT NULL,
  CONSTRAINT tb_tipocurso_pkey PRIMARY KEY (id)
)

CREATE TABLE tb_curso
(
  id int identity not null,   
  tipoCurso_id int not null, 
  nome varchar(50) NOT NULL,
  modeloCurso varchar(20) NOT NULL,

  CONSTRAINT tb_curso_pkey PRIMARY KEY (id), 

  CONSTRAINT curso_id_fk FOREIGN KEY (tipoCurso_id)
      REFERENCES tb_tipocurso (id)

)

CREATE TABLE tb_aluno
(
  id int identity NOT NULL,
  id_curso int  not null,
  dt_cadastro DateTime not null, 
  ra varchar(13) NOT NULL,
  nome varchar(50) NOT NULL,
  dt_nascimento date NOT NULL,
  CONSTRAINT tb_aluno_pkey PRIMARY KEY (id),
  Constraint id_curso_FK FOREIGN key(id_curso)
  REFERENCES tb_curso (id)
 
)

CREATE TABLE tb_endereco
(
  id int identity NOT NULL,   
  aluno_id int NOT NULL, 
  tpend_id int NOT NULL,
  cidade varchar(255),
  estado varchar(255),
  logradouro varchar(255),
  numero varchar(255),
  cep varchar(8),
  CONSTRAINT tb_endereco_pkey PRIMARY KEY (id), 
  CONSTRAINT tpend_id_fk FOREIGN KEY (tpend_id)
      REFERENCES tb_tipoendereco (id) ,
   CONSTRAINT aluno_id_fk FOREIGN KEY (aluno_id)
      REFERENCES tb_aluno (id) 
)

CREATE TABLE tb_documento
(
  id int identity NOT NULL,   
  aluno_id int NOT NULL, 
  tpdoc_id int NOT NULL,
  codigo varchar (11),
  validade date,
  CONSTRAINT tb_documento_pkey PRIMARY KEY (id), 
  
CONSTRAINT tpdoc_id_fk FOREIGN KEY (tpdoc_id)
      REFERENCES tb_tipodocumento (id) ,
   
CONSTRAINT idaluno_fk FOREIGN KEY (aluno_id)
      REFERENCES tb_aluno (id)  

)



CREATE TABLE tb_disciplina
(
  id int identity not null,   
  curso_id int not null, 
  aluno_id int NOT NULL, 
  nome varchar(50) NOT NULL,

  CONSTRAINT tb_disciplina_pkey PRIMARY KEY (id),

  CONSTRAINT alunoid_fk FOREIGN KEY (aluno_id)
      REFERENCES tb_aluno (id),

  CONSTRAINT cursoid_fk FOREIGN KEY (curso_id)
      REFERENCES tb_curso (id)  
)





--drop table tb_endereco
--drop table tb_tipoendereco
--drop table tb_disciplina
--drop table tb_documento
--drop table tb_tipodocumento
--drop table tb_curso
--drop table tb_tipocurso
--drop table tb_aluno


--select * from tb_aluno
--select * from tb_curso
--select * from tb_disciplina
--select * from tb_documento
--select * from tb_tipodocumento
--select * from tb_tipoendereco
--select * from tb_endereco
--select * from tb_tipocurso
