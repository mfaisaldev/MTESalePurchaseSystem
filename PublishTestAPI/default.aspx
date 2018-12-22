<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="APITesting._default" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frmGet" runat="server">
        <div>
            <h1>GET</h1>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="labURL" runat="server" Text="Request URL  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtApiURL" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btn" runat="server" Text="GET" OnClick="btn_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labOutput" runat="server" Text="Response Body  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtResponseBody" runat="server" Width="400px" TextMode="MultiLine" Height="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labOutputCode" runat="server" Text="Response Code  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtResponseCode" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <div>
            <h1>POST</h1>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="labURL1" runat="server" Text="Request URL  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtApiURL1" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labInput1" runat="server" Text="Request  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRequest1" runat="server" Width="400px" TextMode="MultiLine" Height="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnPOST" runat="server" Text="POST" OnClick="btnPOST_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labOutput1" runat="server" Text="Response Body  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtResponseBody1" runat="server" Width="400px" TextMode="MultiLine" Height="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labOutputCode1" runat="server" Text="Response Code  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtResponseCode1" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
        <div>
            <h1>PATCH /PUT </h1>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="labURL2" runat="server" Text="Request URL  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtApiURL2" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labInput2" runat="server" Text="Request  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtRequest2" runat="server" Width="400px" TextMode="MultiLine" Height="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnPUT" runat="server" Text="PUT" OnClick="btnPUT_Click" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labOutput2" runat="server" Text="Response Body  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtResponseBody2" runat="server" Width="400px" TextMode="MultiLine" Height="300px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="labOutputCode2" runat="server" Text="Response Code  "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtResponseCode2" runat="server" Width="400px"></asp:TextBox></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
