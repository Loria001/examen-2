<%@ Page Title="Sistema de encuestas" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="consultar.aspx.cs" Inherits="examen_2.consultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mt-5">
        <h1>Reporte de encuestas</h1>
    </div>

    <div class="text-center mt-3"> 
        <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click" CssClass="btn btn-primary btn-lg" />
    </div>

    <div class="text-center mt-3"> 
        <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
