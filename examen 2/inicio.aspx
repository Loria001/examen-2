<%@ Page Title="Sistema de encuestas" Language="C#" MasterPageFile="~/menu.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="examen_2.inicio" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <h1 class="text-center">Ingresar</h1>
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                <div style="margin-top: 20px;">
                    <div class="form-group">
                        <label for="Tnombre1">Nombre:</label>
                        <asp:TextBox ID="Tnombre1" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Tapellido">Apellidos:</label>
                        <asp:TextBox ID="Tapellido" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Tfecha">Fecha de nacimiento:</label>
                        <asp:TextBox ID="Tfecha" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Tedad">Edad:</label>
                        <asp:TextBox ID="Tedad" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="Tcorreo">Correo electrónico:</label>
                        <asp:TextBox ID="Tcorreo" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Carro propio:</label>
                        <asp:RadioButtonList ID="RadioButtonListCarroPropio" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Sí" Value="Si"></asp:ListItem>
                            <asp:ListItem Text="No" Value="No"></asp:ListItem>
                        </asp:RadioButtonList>
                        <div>
                            <asp:Label ID="lblMensajeError" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lblMensajeExito" runat="server" Text="" ForeColor="Green"></asp:Label>
                        </div>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="Bagregar" runat="server" Text="Ingresar" OnClick="Bagregar_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


