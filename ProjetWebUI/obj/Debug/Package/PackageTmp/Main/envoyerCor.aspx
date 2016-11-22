<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="envoyerCor.aspx.vb" Inherits="ProjetWebUI.envoyerCor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>ارسال مراسلة</title>
<link href="../styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>

<form id="form1" runat="server">
<body id="b">
<div id="header">
	<img id="logo" alt="" src="../Img/logo.png" />
	<img id="titre" alt="" class="imgHeader" src="../Img/titre.png" /> </div>
<div id="menuBar">
	<span class="LabelMenuInactif">ارسال مراسلة</span>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="archiveCor.aspx">تتبع مراسلاتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="updateCompte.aspx">تعديل بياناتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="logout.aspx">تسجيل الخروج</a> </div>
<div id="center">
	
		<table class="tables" align="center">
			<tbody>
			<tr>
				<td>
				<asp:TextBox ID="objTB" runat="server" Width="261px"></asp:TextBox>
				</td>
				<td class="contentFont">عنوان المراسلة</td>
			</tr>
			<tr>
				<td>
				<asp:TextBox id="textCorTB" runat="server" height="173px" textmode="multiline" width="261px" />
				</td>
				<td class="contentFont">نص المراسلة</td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:Button ID="sendBT" runat="server" CssClass="centered" Text="ارسال"></asp:Button>
				</td>
			</tr>
            <tr>
				<td class="errors" colspan="2">
                <asp:Label ID="errLB" runat="server"></asp:Label>
				</td>
			</tr>
		</tbody>
		</table>
</div>
</body>
</form>
</html>