<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="default.aspx.vb" Inherits="ProjetWebUI._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>تسجيل الدخول</title>
<link href="styles/MyStyle.css" rel="stylesheet" type="text/css" />
<link href="styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<form id="form1" runat="server">
<body id="b">

<div id="up">
	<img id="logo" alt="" src="Img/logo.png" />
	<img id="titre" alt="" class="imgHeader" src="Img/titre.png" /> </div>
<div id="right">
	<a id="externLink" href="other">مراسلتنا</a> </div>
<div id="below">
	
		<table align="center" class="tables">
			<tbody>
			<tr>
				<td colspan="2">
				<asp:TextBox id="userNameTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>
				إسم المستخدم
				</td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:TextBox id="mdpTB" runat="server" style="width: 120px; height: 18px;" TextMode="Password"></asp:TextBox>
				</td>
				<td>
				كلمة المرور
				</td>
			</tr>
			<tr>
				<td>
				<asp:Button id="okBT" runat="server" style="width: 49px; height: 21px;" Text="دخول"></asp:Button>
				</td>
				<td>
				<asp:Button id="inscriptionBT" runat="server" style="width 49px; height: 21px" Text="التسجيل بالموقع"></asp:Button>
				</td>
			</tr>
            <tr class="errors">
            <td colspan="2"> <asp:Label ClientIDMode="Static" runat="server" id="erreurLB" Text=""></asp:Label> </td>
            </tr>
		</tbody>
		</table>
	
</div>
</body>
</form>
</html>
