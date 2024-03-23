<%@ Page Title="Sistema de encuestas" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="modificar.aspx.cs" Inherits="examen_2.modificar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1>Modificar datos de una encuesta</h1>
    </div>
    <div>
        <asp:Label runat="server" Text="Buscar por numero de encuesta:" AssociatedControlID="txtNumenc" />
        <asp:TextBox ID="txtNumenc" runat="server" CssClass="form-control" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
        <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>

    </div>

    <asp:Panel ID="pnlModificar" runat="server" Visible="false">
        <div>
            <asp:Label runat="server" Text="Nombre:" AssociatedControlID="Tnombre1Existente" />
            <asp:TextBox ID="Tnombre1Existente" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>
        <div>
            <asp:Label runat="server" Text="Apellidos:" AssociatedControlID="TapellidoExistente" />
            <asp:TextBox ID="TapellidoExistente" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>
        <div>
            <asp:Label runat="server" Text="Fecha de nacimiento:" AssociatedControlID="TfechaExistente" />
            <asp:TextBox ID="TfechaExistente" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>
        <div>
            <asp:Label runat="server" Text="Edad:" AssociatedControlID="TedadExistente" />
            <asp:TextBox ID="TedadExistente" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>
        <div>
            <asp:Label runat="server" Text="Correo electrónico:" AssociatedControlID="TcorreoExistente" />
            <asp:TextBox ID="TcorreoExistente" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>
        <div>
            <asp:Label runat="server" Text="Carro propio:" AssociatedControlID="RadioButtonListCarroPropioExistente" />
            <asp:RadioButtonList ID="RadioButtonListCarroPropioExistente" runat="server" CssClass="form-control" RepeatDirection="Horizontal" Enabled="false">
                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>
            <asp:Label runat="server" Text="Nuevo Nombre:" AssociatedControlID="Tnombre1" />
            <asp:TextBox ID="Tnombre1" runat="server" CssClass="form-control" />
        </div>
        <div>
            <asp:Label runat="server" Text="Nuevo Apellidos:" AssociatedControlID="Tapellido" />
            <asp:TextBox ID="Tapellido" runat="server" CssClass="form-control" />
        </div>
        <div>
            <asp:Label runat="server" Text="Nueva Fecha de nacimiento:" AssociatedControlID="Tfecha" />
            <asp:TextBox ID="Tfecha" runat="server" CssClass="form-control" />
        </div>
        <div>
            <asp:Label runat="server" Text="Nueva Edad:" AssociatedControlID="Tedad" />
            <asp:TextBox ID="Tedad" runat="server" CssClass="form-control" />
        </div>
        <div>
            <asp:Label runat="server" Text="Nuevo Correo electrónico:" AssociatedControlID="Tcorreo" />
            <asp:TextBox ID="Tcorreo" runat="server" CssClass="form-control" />
        </div>
        <div>
            <asp:Label runat="server" Text="Nuevo Carro propio:" AssociatedControlID="RadioButtonListCarroPropio" />
            <asp:RadioButtonList ID="RadioButtonListCarroPropio" runat="server" CssClass="form-control" RepeatDirection="Horizontal">
                <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                <asp:ListItem Text="No" Value="No"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-success" />
    </asp:Panel>
</asp:Content>
