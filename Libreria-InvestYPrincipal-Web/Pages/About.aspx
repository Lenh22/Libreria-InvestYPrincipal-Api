<%@ Page Title="Acerca de" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Libreria_InvestYPrincipal_Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title">Acerca de este proyecto</h2>
        <p>
            Esta aplicación es un trabajo practico de Programacion avanzada 2 de la Lic. 
            El sistema implementa un <b>ABM de Libros</b> y un <b>ABM de Autores</b>, 
            utilizando una arquitectura por capas y comunicación con una 
            <b>API REST en .NET Core</b> con Entity Framework (Code First)
        </p>
        <p>
            El frontend está desarrollado en <b>ASP.NET WebForms (.NET Framework)</b>, 
            mientras que el backend está en <b>ASP.NET Core Web API</b>. 
            Ambos proyectos se mantienen separados y la comunicación se realiza a través de llamadas HTTP.
        </p>
        <p>
            Funcionalidades principales:
            <ul>
                <li>Alta, baja, modificacion y listado de Libros</li>
                <li>Alta, baja, modificacion y listado de Autores</li>
                <li>Búsqueda avanzada de libros por multiples criterios</li>
                <li>Relación 1 Autor → N Libros</li>
                <li>Validaciones (fechas, rangos, campos obligatorios)</li>
                <li>Swagger UI para pruebas de la API</li>
                <li>Y quizas mas pero veremos mas adelante</li>
            </ul>
        </p>
    </main>
</asp:Content>
