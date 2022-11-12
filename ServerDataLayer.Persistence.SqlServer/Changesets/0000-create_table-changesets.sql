if not exists (select 1 from sysobjects where name = 'changesets' and xtype = 'U')
begin
  create table changesets
  (
      codigo_local bigint not null identity,
      checksum varchar(1000) not null,
	  file_name varchar(1000) not null,
      constraint pk_changesets primary key (codigo_local),
      constraint uk_changesets_checksum unique (checksum),
      constraint uk_changesets_file_name unique (file_name)
  )
end