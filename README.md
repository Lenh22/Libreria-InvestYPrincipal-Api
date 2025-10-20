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

El proyecto sigue un **patrón de arquitectura por capas** con separación clara de responsabilidades:

### Backend (API)
- **`Controllers/`** - Controladores REST que manejan las peticiones HTTP y validaciones
- **`Services/`** - Lógica de negocio e interfaces para operaciones de datos
- **`Models/`** - Entidades del dominio (Book, Author) con validaciones de datos
- **`Dto/`** - Objetos de transferencia de datos para la comunicación API
- **`Data/`** - Contexto de Entity Framework y datos de inicialización (SeedData)

### Frontend (Web Forms)
- **`Pages/`** - Páginas ASPX para la interfaz de usuario (Authors.aspx, Books.aspx)
- **`UserControls/`** - Controles reutilizables (BookForm.ascx, BookSearch.ascx)
- **`Dto/`** - DTOs compartidos entre frontend y backend

### Flujo de datos
1. **Frontend** realiza peticiones HTTP al **Backend API**
2. **Controllers** procesan las peticiones y delegan a **Services**
3. **Services** implementan la lógica de negocio y acceden a la **Base de datos** via **Entity Framework**
4. Los **DTOs** facilitan la transferencia de datos entre capas
5. **CORS** configurado para permitir comunicación entre frontend y backend

### Características técnicas
- **Inyección de dependencias** para servicios
- **Validación de modelos** con Data Annotations
- **Manejo de referencias circulares** en JSON
- **Seeding automático** de datos de prueba al iniciar la aplicación
- **Búsquedas dinámicas** con filtros opcionales