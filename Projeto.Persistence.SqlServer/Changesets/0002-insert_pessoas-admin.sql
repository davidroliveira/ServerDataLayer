if not exists (select 1 from pessoas where codigo_local = 1)
begin
  set identity_insert pessoas on

  insert pessoas(codigo_local, codigo_universal, nome) values (1, 'ea021819-7072-41da-8350-18a7dd5c0c8e', 'Admin')

  set identity_insert pessoas off
end