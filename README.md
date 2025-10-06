# Sistema de Librería - Backend + Frontend

Este proyecto implementa un **Sistema de Gestión de Librería** completo con arquitectura de microservicios, utilizando **.NET Core Web API** como Backend y **ASP.NET WebForms** como Frontend.

## 🏗️ Arquitectura del Sistema

### Backend (API REST)
- **Tecnología**: .NET Core 8.0 Web API
- **Base de Datos**: SQL Server con Entity Framework Core (Code First)
- **Documentación**: Swagger/OpenAPI
- **Arquitectura**: N-Capas (Models, Controllers, Services, Data)

### Frontend (Cliente Web)
- **Tecnología**: ASP.NET WebForms
- **UI Framework**: Bootstrap 5
- **Comunicación**: HTTP/JSON con la API REST
- **Validaciones**: Cliente y servidor

## 📋 Características Principales

### ✅ Entidades del Sistema
- **Author**: Id, Name, BirthDate, Nationality
- **Book**: Id, Title, Genre, PublishDate, Pages (1-1000), Publisher, ISBN, Price (1-1000), Language, AuthorId (FK)

### ✅ Funcionalidades CRUD Completas
- **Gestión de Autores**: Crear, Leer, Actualizar, Eliminar
- **Gestión de Libros**: Crear, Leer, Actualizar, Eliminar
- **Búsqueda Avanzada**: Filtros por título, género y autor
- **Validaciones**: Rangos, fechas, campos obligatorios

### ✅ Arquitectura N-Capas
- **Presentación**: WebForms con Master Pages y User Controls
- **Entidades**: Modelos con validaciones de datos
- **Negocio/Servicios**: Lógica de negocio en servicios
- **Datos**: Entity Framework Core con Code First

## 🚀 Instalación y Configuración

### Prerrequisitos
- .NET 8.0 SDK
- SQL Server (LocalDB incluido)
- Visual Studio 2022 o VS Code

### 1. Configuración de la Base de Datos

```bash
# Navegar al directorio del Backend
cd Backend

# Instalar dependencias
dotnet restore

# Crear la base de datos
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 2. Configuración del Backend

```bash
# Ejecutar el Backend
cd Backend
dotnet run
```

El Backend estará disponible en:
- **HTTP**: http://localhost:7000
- **Swagger UI**: http://localhost:7000/swagger

### 3. Configuración del Frontend

```bash
# Ejecutar el proyecto WebForms
cd Frontend
# Abrir Frontend.sln en Visual Studio y ejecutar con F5
```

El frontend estará disponible en:
- **HTTPS**: https://localhost:44392
- **Páginas principales**:
  - Autores: https://localhost:44392/Pages/Authors.aspx
  - Libros: https://localhost:44392/Pages/Books.aspx

## 📚 Endpoints del Backend

### Autores
- `GET /api/authors` - Obtener todos los autores
- `GET /api/authors/{id}` - Obtener autor por ID
- `POST /api/authors` - Crear nuevo autor
- `PUT /api/authors/{id}` - Actualizar autor
- `DELETE /api/authors/{id}` - Eliminar autor

### Libros
- `GET /api/books` - Obtener todos los libros
- `GET /api/books/{id}` - Obtener libro por ID
- `GET /api/books/search` - Buscar libros con filtros
- `POST /api/books` - Crear nuevo libro
- `PUT /api/books/{id}` - Actualizar libro
- `DELETE /api/books/{id}` - Eliminar libro

## 🎯 Características Técnicas

### Backend (API)
- **Entity Framework Core**: Code First con migraciones
- **Swagger**: Documentación automática de la API
- **CORS**: Configurado para permitir requests del frontend
- **Validaciones**: Data Annotations en modelos
- **Servicios**: Inyección de dependencias
- **Async/Await**: Operaciones asíncronas

### Frontend (WebForms)
- **Master Pages**: Layout consistente
- **User Controls**: Componentes reutilizables
- **Validaciones**: RequiredFieldValidator, RangeValidator, CompareValidator
- **Bootstrap**: UI moderna y responsive
- **HTTP Client**: Comunicación con la API
- **Modales**: Formularios en ventanas emergentes

## 🔧 Validaciones Implementadas

### Campos Obligatorios
- Todos los campos de Author y Book son requeridos
- Validaciones en cliente (WebForms) y servidor (API)

### Rangos Numéricos
- **Páginas**: 1-1000
- **Precio**: 1-1000

### Fechas
- **Fecha de nacimiento**: No puede ser futura
- **Fecha de publicación**: No puede ser futura

### Longitud de Campos
- **Nombre**: Máximo 100 caracteres
- **Nacionalidad**: Máximo 50 caracteres
- **Título**: Máximo 200 caracteres
- **Editorial**: Máximo 100 caracteres
- **ISBN**: Máximo 20 caracteres
- **Idioma**: Máximo 50 caracteres

## 🎨 Interfaz de Usuario

### Páginas Principales
- **Books.aspx**: Gestión completa de libros con búsqueda
- **Authors.aspx**: Gestión completa de autores
- **Master Page**: Navegación y layout consistente

### Componentes Reutilizables
- **BookSearch**: Control de búsqueda con múltiples filtros
- **BookForm**: Formulario completo para libros con validaciones

### Características de UX
- **Modales**: Formularios en ventanas emergentes
- **Búsqueda**: Filtros por título, género y autor
- **Confirmaciones**: Diálogos de confirmación para eliminación
- **Mensajes**: Alertas de éxito y error
- **Responsive**: Diseño adaptable a diferentes pantallas

## 🏛️ Arquitectura de Microservicios

### Separación de Responsabilidades
- **Backend (API REST)**: Lógica de negocio y acceso a datos
- **Frontend (WebForms)**: Presentación y experiencia de usuario
- **Comunicación**: HTTP/JSON entre capas

### Beneficios
- **Escalabilidad**: Cada servicio puede escalarse independientemente
- **Mantenibilidad**: Código organizado en capas bien definidas
- **Testabilidad**: Servicios pueden probarse por separado
- **Flexibilidad**: Fácil cambio de tecnologías en cada capa

## 🔄 Migración y Nueva Estructura

### ✅ Migración Completada
El proyecto ha sido migrado exitosamente de la estructura original a una nueva arquitectura optimizada:

**Antes:**
```
Libreria-InvestYPrincipal-Web/ (Proyecto original con problemas)
```

**Ahora:**
```
Backend/ (Backend API)
Frontend/ (Frontend WebForms)
```

### 🔧 Cambios Realizados
- **✅ Namespaces**: Actualizados de `Libreria_InvestYPrincipal_Web` a `Frontend`
- **✅ Referencias**: Corregidas todas las dependencias y using statements
- **✅ Operaciones asíncronas**: Implementadas correctamente con `Async="true"`
- **✅ User Controls**: Accesibilidad y referencias corregidas
- **✅ URLs de Backend**: Configuradas para `http://localhost:7000/api`
- **✅ ContentPlaceHolder**: Agregado `head` en Site.Master

### 🚀 URLs de Acceso
- **Backend (API)**: http://localhost:7000
- **Swagger UI**: http://localhost:7000/swagger
- **Frontend WebForms**: https://localhost:44392
- **Páginas principales**:
  - Autores: https://localhost:44392/Pages/Authors.aspx
  - Libros: https://localhost:44392/Pages/Books.aspx
- **Documentación Backend**: Disponible en Swagger UI

## 📊 Estructura del Proyecto

```
Libreria-InvestYPrincipal-Api/
├── Backend/                               # Backend API
│   ├── Controllers/                       # Controladores REST
│   ├── Models/                           # Entidades del dominio
│   ├── Services/                         # Lógica de negocio
│   ├── Data/                             # Contexto de EF
│   └── Program.cs                        # Configuración del Backend
├── Frontend/                             # Frontend WebForms
│   └── Frontend/                         # Proyecto WebForms
│       ├── Pages/                        # Páginas principales
│       ├── MasterPages/                  # Layouts
│       ├── UserControls/                 # Componentes reutilizables
│       ├── Dto/                          # Data Transfer Objects
│       └── Web.config                    # Configuración del frontend
└── README.md                             # Este archivo
```

## 🧪 Testing

### Swagger UI
- Acceder a http://localhost:7000/swagger
- Probar todos los endpoints directamente
- Ver documentación automática del Backend

### Postman
- Importar colección desde el archivo `.http`
- Probar flujos completos de CRUD
- Validar respuestas y códigos de estado

## 🚀 Despliegue

### Desarrollo Local
1. Ejecutar el Backend: `dotnet run` en el directorio del Backend
2. Ejecutar el frontend: F5 en Visual Studio (abrir Frontend.sln)
3. Acceder a http://localhost:7000/swagger para probar el Backend
4. Acceder a https://localhost:44392 para usar la aplicación

### Producción
- **Backend**: Desplegar en Azure App Service o IIS
- **Frontend**: Desplegar en IIS
- **Base de Datos**: SQL Server en Azure o servidor dedicado

## 📝 Notas de Desarrollo

### Tecnologías Utilizadas
- **.NET Core 8.0**: Framework principal
- **Entity Framework Core 9.0**: ORM
- **Swagger**: Documentación de API
- **Bootstrap 5**: Framework CSS
- **Newtonsoft.Json**: Serialización JSON

### Patrones Implementados
- **Repository Pattern**: A través de Entity Framework
- **Dependency Injection**: En Program.cs
- **N-Layer Architecture**: Separación clara de responsabilidades
- **RESTful API**: Endpoints siguiendo convenciones REST

## 🤝 Contribución

1. Fork el proyecto
2. Crear una rama para la feature (`git checkout -b feature/AmazingFeature`)
3. Commit los cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para detalles.

## 👥 Autores

- **Desarrollador Principal**: [Tu Nombre]
- **Proyecto**: Sistema de Librería - TP API Web
- **Institución**: [Nombre de la Institución]

---

**Nota**: Este proyecto demuestra la implementación de una arquitectura de microservicios moderna con .NET Core y WebForms, siguiendo las mejores prácticas de desarrollo y diseño de software.
