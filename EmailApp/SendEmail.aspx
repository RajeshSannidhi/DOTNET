<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendEmail.aspx.cs" Inherits="SendEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Email.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td colspan="2">Please Provide Recipient Information</td>
                </tr>
                <tr>
                    <td>
                        <label>To:</label></td>
                    <td>
                        <input id="txtTo" runat="server" type="email" style="width: 300px;" required />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>CC:</label></td>
                    <td>
                        <input id="txtCC" runat="server" type="email" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Bcc:</label></td>
                    <td>
                        <input id="txtBcc" runat="server" type="email" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Subject:</label></td>
                    <td>
                        <input id="txtSubject" runat="server" type="text" style="width: 300px;" required />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Body:</label></td>
                    <td>
                        <input id="txtBody" runat="server" type="text" style="width: 300px; height: 250px;" required />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSend" runat="server" Text="SEND" OnClick="btnSend_Click" class="button"></asp:Button></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
