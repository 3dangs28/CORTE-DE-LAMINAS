<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comp_Lamina.aspx.cs" Inherits="Cortes_de_Lamina.Comp_Lamina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body background="paper.jpg">
    <form id="form1" runat="server">
        <div>
        <center>
            <h1><asp:Label ID="Label1" runat="server" Text="Corte de Lamina de Papel" Font-Names="Copperplate Gothic Bold"></asp:Label></h1>
        </center>
    </div> 
        <div style="width: 295px; height: 459px; background-color:#000099; float:left; margin-left: 182px; margin-top: 11px;">
            <div style="width: 265px; height: 70px; margin-left: 15px; margin-top: 10px">
                <center><h2>Tamaño del Pliego</h2></center>
                Ancho&nbsp; <asp:TextBox ID="txtPliegoAncho" runat="server">85</asp:TextBox>
            </div>
            <div style="width: 265px; margin-left: 15px; margin-top: 5px">Alto&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtPliegoAlto" runat="server">110</asp:TextBox>
            </div>
            <div style="width: 265px; height: 74px; margin-left: 15px; margin-top: 15px">
                <center><h2>Tamaño de Corte</h2></center>
                Ancho&nbsp;
                <asp:TextBox ID="txtCorteAncho" runat="server" OnTextChanged="txtCorteAncho_TextChanged">32</asp:TextBox>
            </div>
            <div style="width: 265px; height: 27px; margin-left: 15px">

                Alto&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCorteAlto" runat="server">23</asp:TextBox>
            </div>
            <div style="height: 33px; margin-top: 13px">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 16px" Text="Calcular" Width="158px" />
            </div>
     </div>
        <div style="margin-top: 11px; width: 728px; height: 461px; background-color:#000099; margin-left: 9px; float:left;">

            <table style="margin-top: 0px; width: 100%;">
                <tr>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Lamina.aspx?w=50&h=50" style="margin-top: 0px" />
                </td>   
            </tr>
</table>
        </div>          
             
    </form>    
    </body>
</html>
