<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="main.aspx.vb" Inherits="ProjetWebUI.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<link href="../styles/MainStyle.css" rel="stylesheet" type="text/css" />
<title>الصفحة الرئيسية</title>
</head>

<body id="b">

<div id="header">
	<img id="logo" alt="" src="../Img/logo.png" />
	<img id="titre" alt="" class="imgHeader" src="../Img/titre.png" /> </div>
<div id="menuBar">
	<a class="LabelMenu" href="envoyerCor.aspx">ارسال مراسلة</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="archiveCor.aspx">تتبع مراسلاتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="updateCompte.aspx">تعديل بياناتكم</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="logout.aspx">تسجيل الخروج</a> </div>
<div id="center">
	<form id="form1" runat="server" align="center">
		<p class="contentFont">مرحبا في حساب</p>
		<br />
		<asp:Label CssClass="centered" ID="nomLB" runat="server" Text=""></asp:Label>
	</form>
</div>

</body>

</html>

