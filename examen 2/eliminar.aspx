<%@ Page Title="Sistema de encuestas" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="consultar.aspx.cs" Inherits="examen_2.consultar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1>Eliminar registro</h1>
    </div>

    <div>
        <asp:Label runat="server" Text="Buscar por numero de encuesta:" AssociatedControlID="txtNumenc" />
        <asp:TextBox ID="txtNumenc" runat="server" CssClass="form-control" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

    <div class="text-center mt-3">
        <asp:Button ID="btnBorrarRegistro" runat="server" Text="Borrar Registro" OnClick="btnBorrarRegistro_Click" CssClass="btn btn-danger" />
        <asp:Button ID="btnConfirmarBorrar" runat="server" Text="Confirmar Borrar" OnClick="btnConfirmarBorrar_Click" Visible="false" CssClass="btn btn-warning" />
    </div>
</asp:Content>
