if not exists (select 1 from sysobjects where name = 'pessoas' and xtype = 'U')
begin
  create table pessoas
  (
      codigo_local bigint not null identity,
      codigo_universal uniqueidentifier not null,
      nome varchar(1000) not null,
      constraint pk_pessoas primary key (codigo_local),
      constraint uk_pessoas_codigo_universal unique (codigo_universal)
  )

  create index ix_pessoas_nome on pessoas (nome)

end