<%@ Page Title="" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="examen_2.Reporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1>Reporte de Encuestas</h1>
        <p>Cantidad de Encuestas Realizadas: <%= Request.QueryString["encuestas"] %></p>
        <p>Cantidad de Personas con Carro Propio: <%= Request.QueryString["carro"] %></p>
        <p>Cantidad de Personas sin Carro Propio: <%= Request.QueryString["sinCarro"] %></p>
    </div>
</asp:Content>
