# Task List 📝

Aplicação para gerenciamento de tarefas, composta por:

- **Frontend**: Vue 3 + Vuetify  
- **Backend**: ASPNET (.NET 10) + EF Core + SQLite  

A aplicação segue uma estrutura monorepo, com frontend e backend no mesmo repositório.

---

## 📁 Estrutura do Projeto

Task.List
├── src
│ ├── frontend
│ │ └── (Vue 3 + Vuetify + Typescript)
│ └── backend
│ └── (.NET 10 + EF Core + SQLite)


---

## 🛠️ Tecnologias Utilizadas

### Frontend
- Node.js
- Vue 3
- Vuetify
- Vite

### Backend
- .NET 10
- ASP.NET Web API
- Entity Framework Core
- SQLite
- Swagger (OpenAPI)

---

## ✅ Pré-requisitos

Antes de começar, certifique-se de ter instalado:

### Frontend
- **Node.js** (versão LTS recomendada)
- **npm**

Verifique com:
```bash
node -v
npm -v
Backend

.NET SDK 10

Verifique com:

dotnet --version
```

## Como rodar o projeto
Ter o repositório o repositório

```bash
cd Task.List
```

### Backend (API)
 Acessar o backend
```bash
cd src/backend
```
Restaurar dependências
```bash
dotnet restore
```

### Banco de Dados (SQLite)
O projeto utiliza SQLite, e o banco é criado automaticamente via Entity Framework Core.

Para excutar as migrations:

```bash
dotnet ef database update \
  --project TaskList.Infrastructure \
  --startup-project TaskList
```
Exemplo de string de conexão (appsettings.json):

### Rodar a API
```bash
dotnet run
```
A API ficará disponível em algo como em https://localhost:5131

### Frontend (Vue + Vuetify)
Em outro terminal, acessar o frontend
```bash
cd src/frontend
```

Instalar dependências
```bash
npm install
```
ou

Rodar o frontend
```bash
npm run dev
```

O frontend ficará disponível em:

http://localhost:5173