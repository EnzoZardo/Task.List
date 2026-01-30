# Task.List
Aplicação básica de lista de tarefas com EFCore

Executar migrations:

cd ~/repo/Task.List

dotnet ef migrations add <nome-da-migration> \
  --project TaskList.Infrastructure \
  --startup-project TaskList

dotnet ef database update \
  --project TaskList.Infrastructure \
  --startup-project TaskList
