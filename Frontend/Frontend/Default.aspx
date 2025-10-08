<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Frontend._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Hero Section -->
    <div class="hero-section bg-gradient-primary text-white py-5 mb-5">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-8">
                    <h1 class="display-4 fw-bold mb-4 text-white">
                        <i class="fas fa-book-open me-3"></i>InvestYPrincipal Library
                    </h1>
                    <p class="lead mb-4 text-white">
                        A modern and efficient library management system built with ASP.NET Web Forms (.NET Framework 4.7.2) and .NET Core 8.0 API. 
                        Manage your book catalog and authors with ease using our intuitive interface.
                    </p>
                    <div class="d-flex gap-3">
                        <asp:HyperLink ID="hlBooks" runat="server" NavigateUrl="~/Pages/Books.aspx" CssClass="btn btn-light btn-lg">
                            <i class="fas fa-book me-2"></i>Manage Books
                        </asp:HyperLink>
                        <asp:HyperLink ID="hlAuthors" runat="server" NavigateUrl="~/Pages/Authors.aspx" CssClass="btn btn-outline-light btn-lg">
                            <i class="fas fa-user-edit me-2"></i>Manage Authors
                        </asp:HyperLink>
                    </div>
                </div>
                <div class="col-lg-4 text-center">
                    <i class="fas fa-library fa-10x opacity-75 text-white"></i>
                </div>
            </div>
        </div>
    </div>

    <!-- Features Section -->
    <div class="container">
        <div class="row mb-5">
            <div class="col-12 text-center">
                <h2 class="section-title">
                    <i class="fas fa-star me-2"></i>Key Features
                </h2>
                <p class="text-muted">Discover what makes our library management system special</p>
            </div>
        </div>

        <div class="row g-4 mb-5">
            <div class="col-md-4">
                <div class="card h-100 shadow-sm">
                    <div class="card-body text-center p-4">
                        <div class="feature-icon mb-3">
                            <i class="fas fa-book fa-3x text-primary"></i>
                        </div>
                        <h5 class="card-title">Book Management</h5>
                        <p class="card-text text-muted">
                            Complete book catalog management with detailed information including title, genre, 
                            publication date, pages, publisher, ISBN, price, and language.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card h-100 shadow-sm">
                    <div class="card-body text-center p-4">
                        <div class="feature-icon mb-3">
                            <i class="fas fa-user-edit fa-3x text-success"></i>
                        </div>
                        <h5 class="card-title">Author Management</h5>
                        <p class="card-text text-muted">
                            Manage author information including name, birth date, and nationality. 
                            Link authors to their books for complete catalog organization.
                        </p>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="card h-100 shadow-sm">
                    <div class="card-body text-center p-4">
                        <div class="feature-icon mb-3">
                            <i class="fas fa-search fa-3x text-info"></i>
                        </div>
                        <h5 class="card-title">Advanced Search</h5>
                        <p class="card-text text-muted">
                            Powerful search functionality to find books by title, author, genre, 
                            or any other criteria. Quick and efficient book discovery.
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <!-- Technology Stack -->
        <div class="row mb-5">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-gradient-primary text-white">
                        <h4 class="mb-0">
                            <i class="fas fa-code me-2"></i>Technology Stack
                        </h4>
                    </div>
                    <div class="card-body">
                        <div class="row g-4">
                            <div class="col-md-6">
                                <h6 class="text-primary mb-3">
                                    <i class="fas fa-server me-2"></i>Backend
                                </h6>
                                <ul class="list-unstyled">
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>.NET Core 8.0</strong> - Modern, cross-platform framework
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>Entity Framework Core 8.0</strong> - Object-relational mapping
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>RESTful API</strong> - Clean, scalable web services
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>Swagger/OpenAPI</strong> - API documentation
                                    </li>
                                </ul>
                            </div>
                            <div class="col-md-6">
                                <h6 class="text-primary mb-3">
                                    <i class="fas fa-desktop me-2"></i>Frontend
                                </h6>
                                <ul class="list-unstyled">
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>ASP.NET Web Forms (.NET Framework 4.7.2)</strong> - Rapid web development
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>Bootstrap 5.2.3</strong> - Responsive design framework
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>Font Awesome 6.4.0</strong> - Professional icons
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>jQuery 3.7.0</strong> - DOM manipulation and AJAX
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>Newtonsoft.Json 13.0.3</strong> - JSON serialization
                                    </li>
                                    <li class="mb-2">
                                        <i class="fas fa-check text-success me-2"></i>
                                        <strong>Custom CSS</strong> - Modern, professional styling
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- API Documentation Section -->
        <div class="row mb-5">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-gradient-success text-white">
                        <h4 class="mb-0">
                            <i class="fas fa-file-code me-2"></i>API Documentation
                        </h4>
                    </div>
                    <div class="card-body">
                        <div class="row align-items-center">
                            <div class="col-md-8">
                                <h5 class="text-success mb-3">
                                    <i class="fas fa-book-open me-2"></i>Swagger UI
                                </h5>
                                <p class="text-muted mb-3">
                                    Explore our RESTful API documentation with Swagger UI. Test endpoints, 
                                    view request/response schemas, and understand the complete API structure.
                                </p>
                                <div class="d-flex flex-wrap gap-2">
                                    <span class="badge bg-primary">REST API</span>
                                    <span class="badge bg-info">Interactive Docs</span>
                                    <span class="badge bg-success">Test Endpoints</span>
                                    <span class="badge bg-warning text-dark">OpenAPI 3.0</span>
                                </div>
                            </div>
                            <div class="col-md-4 text-center">
                                <div class="swagger-icon mb-3">
                                    <i class="fas fa-code fa-4x text-success"></i>
                                </div>
                                <a href="http://localhost:7000/swagger" target="_blank" class="btn btn-success btn-lg">
                                    <i class="fas fa-external-link-alt me-2"></i>Open Swagger UI
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Project Structure -->
        <div class="row mb-5">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-gradient-primary text-white">
                        <h4 class="mb-0">
                            <i class="fas fa-sitemap me-2"></i>Project Structure
                        </h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <h6 class="text-primary mb-3">
                                    <i class="fas fa-folder me-2"></i>Backend (API)
                                </h6>
                                <div class="project-structure">
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-warning me-2"></i>
                                        <strong>Controllers/</strong> - REST API endpoints
                                    </div>
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-warning me-2"></i>
                                        <strong>Models/</strong> - Domain entities
                                    </div>
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-warning me-2"></i>
                                        <strong>Services/</strong> - Business logic
                                    </div>
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-warning me-2"></i>
                                        <strong>Data/</strong> - Entity Framework context
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <h6 class="text-primary mb-3">
                                    <i class="fas fa-folder me-2"></i>Frontend (Web Forms)
                                </h6>
                                <div class="project-structure">
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-info me-2"></i>
                                        <strong>Pages/</strong> - Main application pages
                                    </div>
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-info me-2"></i>
                                        <strong>UserControls/</strong> - Reusable components
                                    </div>
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-info me-2"></i>
                                        <strong>Dto/</strong> - Data transfer objects
                                    </div>
                                    <div class="structure-item">
                                        <i class="fas fa-folder text-info me-2"></i>
                                        <strong>Content/</strong> - CSS and styling
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Getting Started -->
        <div class="row mb-5">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-gradient-warning text-dark">
                        <h4 class="mb-0">
                            <i class="fas fa-rocket me-2"></i>Getting Started
                        </h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <h6 class="text-warning mb-3">
                                    <i class="fas fa-play me-2"></i>Quick Start
                                </h6>
                                <ol class="list-group list-group-numbered">
                                    <li class="list-group-item d-flex justify-content-between align-items-start">
                                        <div class="ms-2 me-auto">
                                            <div class="fw-bold">Start the Backend API</div>
                                            Run the API server on port 7000
                                        </div>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between align-items-start">
                                        <div class="ms-2 me-auto">
                                            <div class="fw-bold">Access the Frontend</div>
                                            Open the web application in your browser
                                        </div>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between align-items-start">
                                        <div class="ms-2 me-auto">
                                            <div class="fw-bold">Start Managing</div>
                                            Add authors and books to your library
                                        </div>
                                    </li>
                                </ol>
                            </div>
                            <div class="col-md-6">
                                <h6 class="text-warning mb-3">
                                    <i class="fas fa-link me-2"></i>API Endpoints
                                </h6>
                                <div class="api-endpoints">
                                    <div class="endpoint-item">
                                        <code class="text-primary">GET /api/books</code>
                                        <span class="text-muted ms-2">- Get all books</span>
                                    </div>
                                    <div class="endpoint-item">
                                        <code class="text-primary">POST /api/books</code>
                                        <span class="text-muted ms-2">- Create new book</span>
                                    </div>
                                    <div class="endpoint-item">
                                        <code class="text-primary">GET /api/authors</code>
                                        <span class="text-muted ms-2">- Get all authors</span>
                                    </div>
                                    <div class="endpoint-item">
                                        <code class="text-primary">POST /api/authors</code>
                                        <span class="text-muted ms-2">- Create new author</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Call to Action -->
        <div class="row">
            <div class="col-12 text-center">
                <div class="card bg-gradient-primary text-white">
                    <div class="card-body py-5">
                        <h3 class="mb-4">Ready to Get Started?</h3>
                        <p class="lead mb-4">Start managing your library today with our intuitive and powerful system.</p>
                        <div class="d-flex justify-content-center gap-3">
                            <asp:HyperLink runat="server" NavigateUrl="~/Pages/Books.aspx" CssClass="btn btn-light btn-lg">
                                <i class="fas fa-book me-2"></i>Manage Books
                            </asp:HyperLink>

                            <asp:HyperLink runat="server" NavigateUrl="~/Pages/Authors.aspx" CssClass="btn btn-outline-light btn-lg">
                                <i class="fas fa-user-edit me-2"></i>Manage Authors
                            </asp:HyperLink>
                            <asp:HyperLink ID="hlSwagger" runat="server" NavigateUrl="http://localhost:7000/swagger" target="_blank" CssClass="btn btn-outline-light btn-lg">
                                <i class="fas fa-code me-2"></i>API Docs
                            </asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>