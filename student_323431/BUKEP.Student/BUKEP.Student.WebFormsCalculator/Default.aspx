﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BUKEP.Student.WebFormsCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Главная страница</title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 500px; margin: 0 auto;">           
            <asp:Label ID="Label1" runat="server" Text="Калькулятор" font-size="2em"></asp:Label>
            <br />           
            <asp:TextBox CssClass="textBox" ID="displayText" runat="server" ReadOnly="True">0</asp:TextBox>
            <asp:Button CssClass="button" ID ="Save" runat="server" Text="M" OnClick="ButtonSaveResult" />
            <asp:Button CssClass="button" ID="NextResult" runat ="server" Text ="S>" OnClick="ButtonNextResult" />
            <asp:Button CssClass="button" ID="BeforeResult" runat ="server" Text ="<S" OnClick="ButtonBeforeResult" />
            <asp:Button CssClass="button" ID="ClearAllResult" runat ="server" Text ="MC" OnClick="DbClearResults" />
            <br />            
            <asp:Button CssClass ="button" ID="ButtonClear" runat="server" Text="C" OnClick="DeleteAll"/>
            <asp:Button CssClass ="button" ID="ButtonDeleteSymbol" runat="server" Text="⌫" OnClick ="DeleteSymbol"/>
            <br />
            <asp:Button CssClass ="button" ID="ButtonExponentiation" runat="server" Text="^" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonOpen" runat="server" Text="(" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonClose" runat="server" Text=")" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonDivision" runat="server" Text="/" OnClick="ButtonAddElement"/>
            <br />
            <asp:Button CssClass ="button" ID="Button7" runat="server" Text="7" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="Button8" runat="server" Text="8" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="Button9" runat="server" Text="9" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonMultiply" runat="server" Text="*" OnClick="ButtonAddElement"/>
            <br />
            <asp:Button CssClass ="button" ID="Button6" runat="server" Text="6" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="Button5" runat="server" Text="5" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="Button4" runat="server" Text="4" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonMinus" runat="server" Text="-" OnClick="ButtonAddElement"/>
            <br />
            <asp:Button CssClass ="button" ID="Button3" runat="server" Text="3" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="Button2" runat="server" Text="2" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="Button1" runat="server" Text="1" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonPlus" runat="server" Text="+" OnClick="ButtonAddElement"/>
            <br />
            <asp:Button CssClass ="button" ID="ButtonZero" runat="server" Text="0" OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonComma" runat="server" Text="," OnClick="ButtonAddElement"/>
            <asp:Button CssClass ="button" ID="ButtonResualt" runat="server" Text="=" OnClick="ButtonResult"/>  
        </div>
    </form>
</body>
</html>