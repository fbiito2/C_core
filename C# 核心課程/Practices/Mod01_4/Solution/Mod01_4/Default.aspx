<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UploadImage.aspx">上載檔案</asp:HyperLink>
            <br />
            <asp:ListBox ID="lst" runat="server" AutoPostBack="True" Height="129px" Width="307px" OnSelectedIndexChanged="lst_SelectedIndexChanged"></asp:ListBox>
            <br />
            <asp:Image ID="img" runat="server"></asp:Image>

        </div>
    </form>
</body>
</html>
