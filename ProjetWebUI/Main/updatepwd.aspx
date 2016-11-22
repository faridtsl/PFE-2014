<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="updatepwd.aspx.vb" Inherits="ProjetWebUI.updatepwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="../styles/MainStyle.css" rel="stylesheet" type="text/css" />
    <title>تحديث كلمة المرور</title>
</head>

<body id="b">
<div id="header">
	<img id="logo" alt="" src="../Img/logo.png" />
	<img id="titre" alt="" class="imgHeader" src="../Img/titre.png" /> </div>
<div id="menuBar">
	<a class="LabelMenu" href="envoyerCor.aspx">ارسال مراسلة</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="archiveCor.aspx">تتبع مراسلاتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="updateCompte.aspx">تعديل بياناتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="../default.aspx">تسجيل الخروج</a> </div>
<div id="center">
<form id="form1" runat="server">
		<table class="tables" align="center">
			<thead>
			<tr>
				<th colspan="3" class="contentFont">تعديل كلمة المرور</th>
			</tr>
			</thead>
			<tbody>
			<tr>
				<td colspan="2">
				<asp:TextBox id="amdpTB" runat="server" style="width: 120px; height: 18px;" TextMode="Password"></asp:TextBox>
				</td>
				<td>
				كلمة المرور القديمة
				</td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:TextBox id="nmdpTB" runat="server" style="width: 120px; height: 18px;" TextMode="Password"></asp:TextBox>
				</td>
				<td>
				كلمة المرور الجديدة
				</td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:TextBox id="cnmdpTB" runat="server" style="width: 120px; height: 18px;" TextMode="Password"></asp:TextBox>
				</td>
				<td>
				تأكيد كلمة المرور
				</td>
			</tr>

			<tr>
				<td colspan="2">
				<asp:Button id="okBT" runat="server" style="width: 49px; height: 21px;" Text="تأكيد"></asp:Button>
				</td>
			</tr>

            <tr>
				<td class="errors" colspan="3">
				<asp:Label ID="errLB" runat="server"></asp:Label>
				</td>
			</tr>

		</tbody>
		</table>
</form>
</div>
</body>
</html>
