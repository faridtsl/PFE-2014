<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="updatepre.aspx.vb" Inherits="ProjetWebUI.updatepre" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link href="../styles/MainStyle.css" rel="stylesheet" type="text/css" />
    <title>تحديث معلومات الرئيس</title>
</head>
<form id="form1" runat="server">
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
		<table align="center" class="tables">
			<thead>
			<tr>
				<th colspan="3" class="contentFont">تعديل بيانات الرئيس</th>
			</tr>
			</thead>
			<tbody>
			<tr>
				<td colspan="2">
				<asp:TextBox id="nomPreTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>
				الاسم
				</td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:TextBox id="prenomTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>
				الاسم الشخصي
				</td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:TextBox id="telPreTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>
				الهاتف
				</td>
			</tr>
			<tr>
				<td colspan="2">
				<asp:TextBox id="agePreTB" runat="server" style="width: 120px; height: 18px;"></asp:TextBox>
				</td>
				<td>
				السن
				</td>
			</tr>
			<tr>
				<td colspan="3">
				<asp:RadioButton GroupName="genre" ID="mRB" runat="server" Text="ذكر"></asp:RadioButton>
				<asp:RadioButton GroupName="genre" ID="fRB" runat="server" Text="انثى"></asp:RadioButton>
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
</div>
</body>
</form>
</html>
