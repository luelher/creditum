<%@ Page CodeBehind="PerfilUsuarios.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Creditum.PerfilUsuarios" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Creditum - Perfil de Usuarios</title>
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
	.rightcolumn { PADDING-LEFT: 15px; BACKGROUND: url(Home_files/Home_border_right.gif) }
	.footer { BACKGROUND-IMAGE: url(Home_files/Home_footer_bg.gif); BACKGROUND-REPEAT: repeat-x }
	</style>
	</HEAD>
	<body>
		<form id="PerfilUsuarios" method="post" runat="server">
			<table height="437" width="658" align="center" border="0">
				<tr>
					<td width="103">
						<div align="center"><IMG height="110" src="Miperfil_files/logo.gif" width="103"></div>
					</td>
					<td colSpan="2">
						<div align="center"><IMG src="Miperfil_files/Header.gif" border="0" moduleid="ReporteCreditum (Project)\Header.xws"
								editor="Webstyle4"></div>
					</td>
				</tr>
				<tr>
					<td width="544" colSpan="2">&nbsp;<STRONG><FONT size="2">Solicitante:</FONT></STRONG>
						<asp:label id="lblSolicitante" runat="server"></asp:label></td>
					<td>
						<P align="center">&nbsp;<FONT size="2"><STRONG>Fecha de Emisión:</STRONG></FONT></P>
					</td>
				</tr>
				<tr>
					<td width="544" colSpan="2"><STRONG><FONT size="2">&nbsp;Cliente:</FONT></STRONG>
						<asp:label id="lblCliente" runat="server"></asp:label></td>
					<td>
						<P align="center">&nbsp;
							<asp:label id="lblTime" runat="server">Hoy</asp:label></P>
					</td>
				</tr>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<tr>
					<td colSpan="3">
						<p align="center"><font size="5">Reporte de Usuarios</font></p>
					</td>
				</tr>
				<TR>
					<TD width="544" colSpan="2"></TD>
					<TD width="254"></TD>
				</TR>
				<tr>
					<td width="544" colSpan="2">&nbsp;<STRONG>Listado de Usuarios</STRONG></td>
					<td width="254">&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="3">&nbsp;
						<DIV align="center">
							<asp:datagrid id="DataGridUsuarios" runat="server" Height="35px" PageSize="1" HorizontalAlign="Left"
								Visible="False" CellPadding="2" BorderStyle="None" Width="691px" BorderColor="Green">
								<AlternatingItemStyle BackColor="#C0FFC0"></AlternatingItemStyle>
								<ItemStyle Font-Size="XX-Small"></ItemStyle>
								<HeaderStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Left" BorderWidth="16px"
									ForeColor="Black" BorderStyle="Double" BorderColor="#404040" VerticalAlign="Middle" BackColor="SeaGreen"></HeaderStyle>
							</asp:datagrid></DIV>
						<P align="center">&nbsp;
							<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></P>
					</td>
				</tr>
				<tr>
					<td>&nbsp;
						<asp:hyperlink id="lnkPC" runat="server" ForeColor="Green" Font-Size="XX-Small" NavigateUrl="pcoa/panelcontrolOA.aspx">Panel de Control</asp:hyperlink></td>
					<td width="422"></td>
					<td>
						<P align="right">&nbsp;
							<asp:ImageButton id="imgbtnImprimir" runat="server" ImageUrl="Miperfil_files/impresora.gif" CausesValidation="False"></asp:ImageButton></P>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
