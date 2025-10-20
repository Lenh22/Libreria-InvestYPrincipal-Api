# 📚 Librería InvestYPrincipal API

## 📘 Descripción general

Esta aplicación es un **sistema de gestión de librería** que permite administrar un catálogo de libros y autores. El sistema está compuesto por una **API REST** desarrollada en .NET 8 y un **frontend web** en ASP.NET Web Forms que consume la API.

La aplicación permite realizar operaciones CRUD completas sobre libros y autores, incluyendo búsquedas avanzadas por título, género y nombre de autor. El sistema está diseñado para gestionar información bibliográfica completa incluyendo metadatos como ISBN, editorial, fecha de publicación, precio y idioma.

## ⚙️ Tecnologías

### Backend API
- **.NET 8.0** - Framework principal
- **ASP.NET Core Web API** - Para la construcción de la API REST
- **Entity Framework Core 9.0.9** - ORM para acceso a datos
- **SQL Server LocalDB** - Base de datos relacional
- **Swagger/OpenAPI 9.0.4** - Documentación automática de la API
- **System.Text.Json** - Serialización JSON con manejo de referencias circulares

### Frontend Web
- **ASP.NET Web Forms 4.7.2** - Framework web tradicional de Microsoft
- **Bootstrap 5.2.3** - Framework CSS para diseño responsivo
- **jQuery 3.7.0** - Librería JavaScript
- **Newtonsoft.Json 13.0.3** - Serialización JSON en el frontend
- **Microsoft.AspNet.FriendlyUrls 1.0.2** - URLs amigables

### Herramientas de Desarrollo
- **Entity Framework Tools 9.0.9** - Migraciones y scaffolding
- **Microsoft.CodeDom.Providers.DotNetCompilerPlatform 2.0.1** - Compilación dinámica

## 🚀 Inicio rápido

### Requisitos previos
- **.NET 8.0 SDK** instalado
- **SQL Server LocalDB** (incluido con Visual Studio)
- **Visual Studio 2022** o **Visual Studio Code** (recomendado)

### Ejecutar la API Backend

1. **Navegar al directorio del backend:**
   ```bash
   cd Backend
   ```

2. **Restaurar dependencias:**
   ```bash
   dotnet restore
   ```

3. **Crear y aplicar migraciones de base de datos:**
   ```bash
   # Crear la migración inicial
   dotnet ef migrations add InitialCreate
   
   # Aplicar migraciones a la base de datos
   dotnet ef database update
   ```

4. **Ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

5. **Acceder a la documentación de la API:**
   - Swagger UI: `https://localhost:7000/swagger`
   - API Base URL: `https://localhost:7000/api`

### Ejecutar el Frontend Web

1. **Navegar al directorio del frontend:**
   ```bash
   cd Frontend/Frontend
   ```

2. **Abrir en Visual Studio:**
   ```bash
   start Frontend.sln
   ```

3. **Ejecutar el proyecto** (F5 o Ctrl+F5)

4. **Acceder a la aplicación:**
   - URL: `http://localhost:5000` o `https://localhost:44392`

### Variables de entorno

La aplicación utiliza la siguiente cadena de conexión por defecto:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=LibraryDB;Trusted_Connection=True;"
}
```

### Endpoints principales

- **Autores:** `GET/POST/PUT/DELETE /api/authors`
- **Libros:** `GET/POST/PUT/DELETE /api/books`
- **Búsqueda de libros:** `GET /api/books/search?title={title}&genre={genre}&authorName={authorName}`

### Comandos útiles de Entity Framework

```bash
# Crear una nueva migración
dotnet ef migrations add NombreDeLaMigracion

# Aplicar migraciones pendientes
dotnet ef database update

# Revertir la última migración
dotnet ef database update MigracionAnterior

# Limpiar completamente la base de datos
dotnet ef database drop --force

# Ver el estado de las migraciones
dotnet ef migrations list
```

## 🧱 Arquitectura

El proyecto sigue un **patrón de arquitectura por capas** con separación clara de responsabilidades y comunicación HTTP entre componentes.

### Diagrama de Comunicación

```
┌─────────────────────────────────────────────────────────────────┐
│                        FRONTEND (Web Forms)                     │
├─────────────────────────────────────────────────────────────────┤
│  Pages/           │  UserControls/     │  Dto/                 │
│  ├─ Authors.aspx  │  ├─ BookForm.ascx  │  ├─ AuthorDto.cs      │
│  └─ Books.aspx    │  └─ BookSearch.ascx│  └─ BookDto.cs        │
└─────────────────────┬───────────────────────────────────────────┘
                      │ HTTP Requests (REST API)
                      │ JSON over HTTPS
                      ▼
┌─────────────────────────────────────────────────────────────────┐
│                        BACKEND (Web API)                        │
├─────────────────────────────────────────────────────────────────┤
│  Controllers/      │  Services/        │  Models/              │
│  ├─ AuthorsController│  ├─ AuthorService │  ├─ Author.cs        │
│  └─ BooksController  │  └─ BookService   │  └─ Book.cs          │
│                     │                   │                      │
│  Dto/               │  Data/            │                      │
│  ├─ AuthorDto.cs    │  ├─ LibraryDbContext│                    │
│  └─ BookDto.cs      │  └─ SeedData.cs   │                      │
└─────────────────────┬───────────────────────────────────────────┘
                      │ Entity Framework Core
                      │ LINQ Queries
                      ▼
┌─────────────────────────────────────────────────────────────────┐
│                    SQL SERVER LOCALDB                           │
│  ┌─────────────┐    ┌─────────────┐    ┌─────────────────────┐  │
│  │   Authors   │    │    Books    │    │   Relationships     │  │
│  │             │◄───┤             │    │   (Foreign Keys)    │  │
│  │ - Id        │    │ - Id        │    │                     │  │
│  │ - Name      │    │ - Title     │    │ AuthorId → Authors  │  │
│  │ - BirthDate │    │ - AuthorId  │    │                     │  │
│  │ - Nationality│   │ - ISBN      │    │                     │  │
│  └─────────────┘    └─────────────┘    └─────────────────────┘  │
└─────────────────────────────────────────────────────────────────┘
```

### Comunicación entre Componentes

#### 🔄 **Frontend ↔ Backend**
- **Protocolo**: HTTP/HTTPS con JSON
- **Método**: Peticiones REST (GET, POST, PUT, DELETE)
- **CORS**: Configurado para permitir comunicación cross-origin
- **Endpoints**: 
  - `https://localhost:7000/api/authors`
  - `https://localhost:7000/api/books`

#### 🏗️ **Arquitectura por Capas del Backend**

**1. Capa de Presentación (`Controllers/`)**
- **Función**: Recibe peticiones HTTP y maneja respuestas
- **Componentes específicos**:
  - `AuthorsController` - Maneja operaciones CRUD de autores
  - `BooksController` - Maneja operaciones CRUD de libros y búsquedas
- **Comunicación**: 
  - Recibe JSON del Frontend
  - Valida datos con Data Annotations
  - Delega lógica de negocio a Services
  - Retorna DTOs serializados en JSON

**2. Capa de Lógica de Negocio (`Services/`)**
- **Función**: Implementa reglas de negocio y validaciones
- **Componentes específicos**:
  - `IAuthorService` / `AuthorService` - Lógica de negocio para autores
  - `IBookService` / `BookService` - Lógica de negocio para libros
- **Comunicación**:
  - Recibe entidades de Controllers
  - Valida ISBN único, fechas, relaciones
  - Accede a datos via Entity Framework
  - Retorna entidades procesadas

**3. Capa de Acceso a Datos (`Data/`)**
- **Función**: Gestiona persistencia y consultas a BD
- **Componentes específicos**:
  - `LibraryDbContext` - Contexto de Entity Framework
  - `SeedData` - Datos de inicialización (autores y libros de prueba)
- **Comunicación**:
  - `LibraryDbContext` maneja conexiones SQL Server
  - LINQ queries se traducen a SQL
  - Entity Framework maneja mapeo objeto-relacional

**4. Capa de Modelos (`Models/`)**
- **Función**: Define entidades del dominio
- **Componentes específicos**:
  - `Author` - Entidad autor con validaciones (nombre, fecha nacimiento, nacionalidad)
  - `Book` - Entidad libro con validaciones (título, ISBN, precio, páginas, etc.)
- **Comunicación**:
  - `Author` y `Book` con relaciones Foreign Key
  - Validaciones con Data Annotations
  - Serialización JSON con `JsonIgnore` para referencias circulares

**5. Capa de Transferencia (`Dto/`)**
- **Función**: Objetos de transferencia de datos entre capas
- **Componentes específicos**:
  - `AuthorDto` - DTO para transferencia de datos de autores
  - `BookDto` - DTO para transferencia de datos de libros
  - `CreateBookDto` / `UpdateBookDto` - DTOs específicos para operaciones de libros
- **Comunicación**:
  - Facilita la transferencia segura de datos entre Frontend y Backend
  - Evita exposición directa de entidades de dominio
  - Permite versionado independiente de la API

### Frontend (Web Forms)

**1. Capa de Presentación (`Pages/`)**
- **Función**: Páginas web que interactúan con el usuario
- **Componentes específicos**:
  - `Authors.aspx` - Página para gestión de autores
  - `Books.aspx` - Página para gestión de libros
- **Comunicación**:
  - Renderiza la interfaz de usuario
  - Captura eventos del usuario
  - Realiza peticiones AJAX al Backend API

**2. Capa de Controles (`UserControls/`)**
- **Función**: Controles reutilizables para funcionalidades específicas
- **Componentes específicos**:
  - `BookForm.ascx` - Formulario para crear/editar libros
  - `BookSearch.ascx` - Control de búsqueda de libros
- **Comunicación**:
  - Encapsula lógica de UI reutilizable
  - Maneja validaciones del lado cliente
  - Comunica con páginas padre via eventos

**3. Capa de Transferencia (`Dto/`)**
- **Función**: DTOs compartidos con el Backend
- **Componentes específicos**:
  - `AuthorDto.cs` - DTO para autores (compartido con Backend)
  - `BookDto.cs` - DTO para libros (compartido con Backend)
- **Comunicación**:
  - Deserializa respuestas JSON del Backend
  - Serializa datos para envío al Backend
  - Mantiene consistencia de tipos entre Frontend y Backend

#### 📦 **Paquetes y Dependencias**

**Backend Dependencies:**
- `Microsoft.EntityFrameworkCore.SqlServer` → Conexión a BD
- `Swashbuckle.AspNetCore` → Documentación API
- `System.Text.Json` → Serialización JSON

**Frontend Dependencies:**
- `Newtonsoft.Json` → Deserialización JSON de respuestas API
- `Bootstrap` → UI responsiva
- `jQuery` → Peticiones AJAX a la API

### Flujo de Datos Detallado

1. **Usuario interactúa** con páginas ASPX (Authors.aspx, Books.aspx)
2. **UserControls** capturan datos y realizan peticiones AJAX
3. **HTTP Request** → Backend API (Controllers)
4. **Controllers** validan y delegan a Services
5. **Services** aplican lógica de negocio y acceden a BD
6. **Entity Framework** ejecuta queries SQL
7. **SQL Server** retorna datos
8. **Response JSON** → Frontend via HTTP
9. **UI se actualiza** con datos recibidos

### Características Técnicas de Comunicación
- **Inyección de dependencias** para desacoplar capas
- **DTOs** para transferencia segura de datos
- **Validación en múltiples capas** (Frontend + Backend)
- **Manejo de errores** con códigos HTTP estándar
- **CORS** para comunicación cross-origin
- **Seeding automático** de datos de prueba