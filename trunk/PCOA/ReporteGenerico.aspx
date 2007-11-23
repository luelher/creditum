<%@ Page language="c#" Codebehind="ReporteGenerico.aspx.cs" AutoEventWireup="false" Inherits="Creditum.PCOA.ReporteGenerico" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Creditum - Perfil de Usuarios</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
		<form id="Form1" method="post" runat="server">
			<p></p>
			<P>&nbsp;</P>
			<P>
				<TABLE id="Table1" height="437" width="658" align="center" border="0">
					<TBODY>
						<TR>
							<TD width="103">
								<DIV align="center"><IMG height="110" src="FacturasDia_files/logo.gif" width="103"></DIV>
							</TD>
							<TD colSpan="2">
								<DIV align="center"><IMG src="FacturasDia_files/Header.gif" border="0" moduleid="ReporteCreditum (Project)\Header.xws"
										editor="Webstyle4"></DIV>
							</TD>
						</TR>
						<TR>
							<TD style="WIDTH: 486px; HEIGHT: 20px" width="486" colSpan="2"></TD>
							<TD style="HEIGHT: 20px">
								<P align="center">&nbsp;<FONT size="2"><STRONG>Fecha de Emisión:</STRONG></FONT></P>
							</TD>
						</TR>
						<TR>
							<TD width="486" colSpan="2" style="WIDTH: 486px"></TD>
							<TD>
								<P align="center">&nbsp;
									<asp:label id="lblTime" runat="server">Hoy</asp:label></P>
							</TD>
						</TR>
						<TR>
							<TD colSpan="3">
								<P align="center"><FONT size="5"><asp:label id="LabelTitulo" runat="server" Font-Size="Large" Width="646px"></asp:label></FONT></P>
							</TD>
						</TR>
						<TR>
							<TD colSpan="3">&nbsp;
								<DIV align="center"><asp:datagrid id="DataGridDetalle" runat="server" Font-Size="X-Small" Width="673px" Visible="False"
										PageSize="1" HorizontalAlign="Left" CellPadding="2" BorderStyle="None" Height="35px" BorderColor="Green">
										<AlternatingItemStyle BackColor="#C0FFC0"></AlternatingItemStyle>
										<ItemStyle Font-Size="X-Small"></ItemStyle>
										<HeaderStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Left" BorderWidth="16px" ForeColor="Black"
											BorderStyle="Double" BorderColor="#404040" VerticalAlign="Middle" BackColor="SeaGreen"></HeaderStyle>
										<FooterStyle Font-Size="X-Small"></FooterStyle>
									</asp:datagrid></DIV>
								<P align="center">&nbsp;
									<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></P>
							</TD>
						</TR>
						<TR>
							<TD>&nbsp;
								<asp:hyperlink id="lnkPC" runat="server" ForeColor="Green" Font-Size="XX-Small" NavigateUrl="panelcontrolOA.aspx">Panel de Control</asp:hyperlink></TD>
							<TD width="378" style="WIDTH: 378px">
								<asp:LinkButton id="LinkExportar" runat="server">Exportar</asp:LinkButton></TD>
							<TD>
								<P align="right">&nbsp;
									<asp:imagebutton id="imgbtnImprimir" runat="server" ImageUrl="FacturasDia_files/impresora.gif" CausesValidation="False"></asp:imagebutton></P>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</P>
		</form>
	</body>
</HTML>
