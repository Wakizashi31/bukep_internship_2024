<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BUKEP.Student.WebFormsCalculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Калькулятро</title>
    <link rel="stylesheet" href="Styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Калькулятор"></asp:Label>
            <br />
            <asp:TextBox CssClass="textBox" ID="TextBox1" runat="server" Text="0" ReadOnly="true"></asp:TextBox>
            <br />
            <asp:Button CssClass="button" ID="Button1" runat="server" Text="C" OnClick="ButtonClear_Click" />
            <asp:Button CssClass="button" ID="Button2" runat="server" Text="⌫" OnClick="ButtonDeleteChar_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button3" runat="server" Text="^" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button4" runat="server" Text="(" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button5" runat="server" Text=")" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button6" runat="server" Text="÷" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button7" runat="server" Text="7" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button8" runat="server" Text="8" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button9" runat="server" Text="9" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button10" runat="server" Text="x" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button11" runat="server" Text="6" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button12" runat="server" Text="5" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button13" runat="server" Text="4" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button14" runat="server" Text="-" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button15" runat="server" Text="3" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button16" runat="server" Text="2" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button17" runat="server" Text="1" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button18" runat="server" Text="+" OnClick="ButtonInput_Click" />
            <br />
            <asp:Button CssClass="button" ID="Button19" runat="server" Text="0" OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button20" runat="server" Text="," OnClick="ButtonInput_Click" />
            <asp:Button CssClass="button" ID="Button21" runat="server" Text="=" OnClick="ButtonResult_Click" />
            <br />
        </div>
    </form>
</body>
</html>
