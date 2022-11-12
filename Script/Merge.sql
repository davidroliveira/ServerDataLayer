declare @schema varchar(max) = 'dbo'
declare @tabela varchar(max) = 'pessoas'

declare @colunas_cte varchar(max)
 select @colunas_cte = coalesce(@colunas_cte + ', ' ,'') + char(13) + '                        @' + column_name + ' ' + column_name
   from information_schema.columns
  where table_name = @tabela
    and table_schema = @schema
    and column_name <> 'codigo_local'
  order by ordinal_position

declare @set_update varchar(max)
 select @set_update = coalesce(@set_update + ', ' ,'') + char(13) + '                         Destino.' + column_name + ' = Origem.' + column_name
   from information_schema.columns
  where table_name = @tabela
    and table_schema = @schema
    and column_name <> 'codigo_local'
  order by ordinal_position

declare @colunas_insert varchar(max)
 select @colunas_insert = coalesce(@colunas_insert + ', ' ,'') + char(13) + '                      ' + column_name
   from information_schema.columns
  where table_name = @tabela
    and table_schema = @schema
    and column_name <> 'codigo_local'
  order by ordinal_position

declare @values_insert varchar(max)
 select @values_insert = coalesce(@values_insert + ', ' ,'') + char(13) + '                      Origem.' + column_name
   from information_schema.columns
  where table_name = @tabela
    and table_schema = @schema
    and column_name <> 'codigo_local'
  order by ordinal_position

declare @output varchar(max)
 select @output = coalesce(@output + ', ' ,'') + char(13) + '                   inserted.' + column_name
   from information_schema.columns
  where table_name = @tabela
    and table_schema = @schema    
  order by ordinal_position

select 
'            with cte' + Char(13) +
'              as (select ' + @colunas_cte + ')' + Char(13) +
'            merge' + Char(13) +
'              ' + @tabela + ' as Destino' + Char(13) +
'            using' + Char(13) +
'              cte AS Origem on (Origem.codigo_universal = Destino.codigo_universal)' + Char(13) +
'            when matched then' + Char(13) +
'              update set ' + @set_update + Char(13) +
'            when not matched then' + Char(13) +
'              insert (' + @colunas_insert + ')' + Char(13) +
'              values (' + @values_insert + ')' + Char(13) +
'            output ' + @output + ';'