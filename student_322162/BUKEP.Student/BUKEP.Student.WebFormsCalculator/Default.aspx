<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BUKEP.Student.WebFormsCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Калькулятро</title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="container">
            <asp:Label CssClass="nameProgram" ID="NameProgram" runat="server" Text="Калькулятор"></asp:Label>
            <br />
            <asp:TextBox CssClass="displayText" ID="DisplayText" runat="server" Text="0" ReadOnly="true"></asp:TextBox>
            <br />
            <asp:Button CssClass="button" ID="ButtonClear" runat="server" Text="C" OnClick="ButtonClear_Click" />
            <asp:Button CssClass="button" ID="ButtonDeleteChar" runat="server" Text="⌫" OnClick="ButtonDeleteChar_Click" />
            <br />
            <asp:Button CssClass="button" ID="ButtonDegre" runat="server" Text="^" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonBracetOpen" runat="server" Text="(" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonBracetClose" runat="server" Text=")" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonDivision" runat="server" Text="÷" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button7" runat="server" Text="7" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button8" runat="server" Text="8" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button9" runat="server" Text="9" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonMultiplication" runat="server" Text="x" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button6" runat="server" Text="6" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button5" runat="server" Text="5" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button4" runat="server" Text="4" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonMinus" runat="server" Text="-" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button3" runat="server" Text="3" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button2" runat="server" Text="2" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="1" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonPlus" runat="server" Text="+" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="ButtonZero" runat="server" Text="0" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonComma" runat="server" Text="," OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="ButtonEqually" runat="server" Text="=" OnClick="ButtonResult_Click" />
            <br />
        </div>
    </form>
</body>
</html>
