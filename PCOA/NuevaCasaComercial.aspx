<%@ Page language="c#" Codebehind="NuevaCasaComercial.aspx.cs" AutoEventWireup="false" Inherits="Creditum.PCOA.NuevaCasaComercial" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Nueva Casa Comercial</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="Javascript">
			var RCMensaje = "CREDITUM, su plataforma de información crediticia";
			function DeshabilitarClickDerecho(btnClick)
			{
				if (navigator.appName == "Netscape" && btnClick.which == 3)
				{ 
					alert(RCMensaje);
					return false;
				}
				else if (navigator.appName == "Microsoft Internet Explorer" && event.button == 2)
				{
					alert(RCMensaje);
					return false;
				}
			}
			document.onmousedown = DeshabilitarClickDerecho;
		</script>
		<!-- Information generated and read by Xara Webstyle. Do not edit this line. [Integrate (Theme);CreditumStyle;Theme Color 1;2201395;themecolour1;Theme Color 2;8255934;themecolour2;Background Color;16053492;themecolour3]
-->
		<!-- Template design (c) Xara Ltd 2003 -->
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<style type="text/css">BODY { FONT-SIZE: 9px; COLOR: #000000; FONT-FAMILY: "Trebuchet MS", Arial, Sans-serif; BACKGROUND-COLOR: #f4f4f4 }
	TABLE { FONT: 9pt "trebuchet ms", arial, sans-serif }
	P { MARGIN: 0px 30px 0px 0px }
	BLOCKQUOTE { MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #000000; MARGIN-RIGHT: 0px }
	OL { MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #000000 }
	UL { MARGIN-TOP: 0px; LIST-STYLE-IMAGE: url(Home_files/Home_bullet.gif); MARGIN-BOTTOM: 0px; MARGIN-LEFT: 20px; COLOR: #000000 }
	A:link { COLOR: #277619 }
	A:visited { COLOR: #000000 }
	A:hover { COLOR: #33305b }
	H1 { MARGIN-TOP: 0px; FONT-WEIGHT: bold; FONT-SIZE: 16px; MARGIN-BOTTOM: 0px; PADDING-BOTTOM: 2px; MARGIN-LEFT: 20px; COLOR: #000000 }
	H2 { MARGIN-TOP: 0px; FONT-WEIGHT: bold; FONT-SIZE: 15px; MARGIN-BOTTOM: 0px; COLOR: #339721 }
	.hnavbg { BACKGROUND-IMAGE: url(Home_files/Home_hnavbar_bg.gif); BACKGROUND-REPEAT: repeat-x }
	.leftcolumn { BACKGROUND-IMAGE: url(Home_files/Home_border_left.gif); BACKGROUND-REPEAT: repeat-y }
	.rightcolumn { PADDING-LEFT: 15px; BACKGROUND: url(Home_files/Home_border_right.gif) repeat-y right 50% }
	.footer { BACKGROUND-IMAGE: url(Home_files/Home_footer_bg.gif); BACKGROUND-REPEAT: repeat-x }
		</style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<IMG style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" height="55" src="Home_files/Home_logo2.gif"
				border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_logo2.xws">&nbsp;
			<asp:Label id="lblUbicacion" style="Z-INDEX: 110; LEFT: 16px; POSITION: absolute; TOP: 176px"
				runat="server" Font-Size="X-Small">Ubicación</asp:Label>
			<asp:TextBox id="txtUbicacion" style="Z-INDEX: 104; LEFT: 80px; POSITION: absolute; TOP: 176px"
				runat="server" Height="128px" TextMode="MultiLine" Width="144px"></asp:TextBox>
			<asp:Label id="lblNit" style="Z-INDEX: 109; LEFT: 48px; POSITION: absolute; TOP: 144px" runat="server"
				Font-Size="X-Small">Nit</asp:Label>
			<asp:TextBox id="txtNit" style="Z-INDEX: 105; LEFT: 80px; POSITION: absolute; TOP: 144px" runat="server"></asp:TextBox>
			<asp:Label id="lblRif" style="Z-INDEX: 108; LEFT: 48px; POSITION: absolute; TOP: 112px" runat="server"
				Font-Size="X-Small">Rif</asp:Label>
			<asp:TextBox id="txtRif" style="Z-INDEX: 106; LEFT: 80px; POSITION: absolute; TOP: 112px" runat="server"></asp:TextBox>&nbsp;
			<asp:Label id="lblTitulo" style="Z-INDEX: 102; LEFT: 72px; POSITION: absolute; TOP: 24px" runat="server"
				Font-Size="Small">Nueva Casa Comercial</asp:Label>
			<asp:Label id="lblNombre" style="Z-INDEX: 103; LEFT: 24px; POSITION: absolute; TOP: 80px" runat="server"
				Font-Size="X-Small">Nombre</asp:Label>
			<asp:TextBox id="txtNombre" style="Z-INDEX: 107; LEFT: 80px; POSITION: absolute; TOP: 80px" runat="server"></asp:TextBox>
			<asp:Button id="btnAceptar" style="Z-INDEX: 111; LEFT: 120px; POSITION: absolute; TOP: 320px"
				runat="server" Font-Size="XX-Small" Text="Aceptar"></asp:Button>
			<asp:RequiredFieldValidator id="RequiredFieldValidatorNombre" style="Z-INDEX: 112; LEFT: 240px; POSITION: absolute; TOP: 88px"
				runat="server" Font-Size="X-Small" ErrorMessage="Se requiere un Nombre" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator>
			<asp:ValidationSummary id="ValidationSummaryCC" style="Z-INDEX: 113; LEFT: 16px; POSITION: absolute; TOP: 352px"
				runat="server" HeaderText="Errores Encontrados"></asp:ValidationSummary>
		</form>
	</body>
</HTML>
