<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="updateCompte.aspx.vb" Inherits="ProjetWebUI.updateCompte" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <title>تعديل البيانات</title>
    <link href="../styles/MainStyle.css" rel="stylesheet" type="text/css" />
</head>
<form id="form1" runat="server">
<body id="b">

<div id="header">
	<img id="logo" alt="" src="../Img/logo.png" />
	<img id="titre" alt="" class="imgHeader" src="../Img/titre.png" /> </div>
<div id="menuBar">
	<a class="LabelMenu" href="envoyerCor.aspx">ارسال مراسلة</a>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="archiveCor.aspx">تتبع مراسلاتكم</a>&nbsp; |&nbsp;&nbsp;
	<span class="LabelMenuInactif">تعديل بياناتكم</span>&nbsp; |&nbsp;&nbsp;
	<a class="LabelMenu" href="../default.aspx">تسجيل الخروج</a> </div>
<div id="center">
		<div class="CentreDiv" id="RubRep">
			<div class="titleRubRep">
			</div>
			<div id="ctl00_MainContent_MenuChambreRep" class="contenuRubRep">
				<img alt="" height="1px" src="../img/vide.png" width="24px" /><span class="bulleRouge">•</span><a class="contenuRubRep" href="updatepwd.aspx"> 
				تغيير كلمة المرور</a> <br />
				<br />
				<br />
				<img alt="" height="1px" src="../img/vide.png" width="38px" /><span class="bulleRouge">•</span><a class="contenuRubRep" href="updatepre.aspx"> 
				تحديث معلومات الرئيس </a><br />
				<br />
				<br />
				<img alt="" height="1px" src="../img/vide.png" width="76px" /><span class="bulleRouge">•</span><a class="contenuRubRep" href="updateass.aspx"> 
				تعديل بيانات الجمعية </a><br />
			</div>
		</div>

</div>

</body>
</form>
</html>
