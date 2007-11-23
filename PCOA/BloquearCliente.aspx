<%@ Page CodeBehind="BloquearCliente.aspx.cs" Language="c#" AutoEventWireup="false" Inherits="Creditum.PCOA.BloquearCliente" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<HTML>
	<HEAD>
		<title>Creditum - Eliminar Cliente</title>
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
		<SCRIPT LANGUAGE="JavaScript" SRC="CargarPopUps.js">
		</SCRIPT>
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
	<body leftMargin="0" topMargin="5">
		<form id="Home" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="98%" align="center">
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="46" height="43"><IMG src="Home_files/Home_top_left.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_top_left.xws"></td>
											<td vAlign="top" width="64"><IMG src="Home_files/Home_spacer.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_spacer.xws"></td>
											<td class="hnavbg" vAlign="top">
												<script Webstyle4>document.write('<scr'+'ipt src="Home_files/xaramenu.js">'+'</scr'+'ipt>');document.write('<scr'+'ipt src="Home_files/home_hnavbar.js">'+'</scr'+'ipt>');/*img src="Home_files/Home_hnavbar.gif" moduleid="CreditumStyle (Project)\Home_hnavbar_off.xws"*/</script>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_top_right.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_top_right.xws"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" width="160">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="leftcolumn" vAlign="top" align="center" height="75">
															<div align="center"><IMG src="Home_files/Home_logo2.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_logo2.xws"></div>
														</td>
													</tr>
													<tr>
														<td>
															<script Webstyle4>document.write('<scr'+'ipt src="Home_files/xaramenu.js">'+'</scr'+'ipt>');document.write('<scr'+'ipt src="Home_files/home_vnavbar.js">'+'</scr'+'ipt>');/*img src="Home_files/Home_vnavbar.gif" moduleid="CreditumStyle (Project)\Home_vnavbar_off.xws"*/</script>
														</td>
													</tr>
												</table>
												<P>&nbsp;</P>
												<P align="justify">Web Site desarrollado con el poder de MYSQL y ASP.NET</P>
												<P><asp:hyperlink id="lnkMySql" runat="server" ImageUrl="Home_files/mysql.png" NavigateUrl="http://www.mysql.com">MySql</asp:hyperlink></P>
												<P><asp:hyperlink id="lnkASP" runat="server" ImageUrl="Home_files/ASPNET.gif" NavigateUrl="http://www.asp.net">ASP.NET</asp:hyperlink></P>
												<P>&nbsp;</P>
											</td>
											<td class="rightcolumn" vAlign="top">
												<P align="right"><asp:label id="lblTime" runat="server">Hoy</asp:label></P>
												<H1>
													Bloquear/Desbloquear&nbsp;Cliente</H1>
												<P>&nbsp;</P>
												<P><asp:label id="lblUser" runat="server"></asp:label></P>
												<P>
													<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label>
													<asp:label id="lblInfo" runat="server"></asp:label></P>
												<P>&nbsp;</P>
												<P><STRONG><EM>Paso1:</EM></STRONG> Seleccione&nbsp;el cliente y luego 
													presione&nbsp;Bloquear o Desbloquear&nbsp; para&nbsp;evitar o permitir el 
													acceso&nbsp;del cliente&nbsp;al sistema.</P>
												<P>&nbsp;</P>
												<P>
													Cliente</P>
												<P align="justify">
													<asp:DropDownList id="DropDownListCasa" runat="server" Width="328px" AutoPostBack="True"></asp:DropDownList></P>
												<P align="justify">&nbsp;</P>
												<P align="justify"><STRONG>Información de la&nbsp;Casa 
														Comercial&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</STRONG></P>
												<P align="justify">
													<asp:DataGrid id="DataGridCC" runat="server" Width="568px" Height="35px" PageSize="1" HorizontalAlign="Left"
														Visible="False" CellPadding="2" BorderStyle="None" BorderColor="Green">
														<AlternatingItemStyle BackColor="#C0FFC0"></AlternatingItemStyle>
														<ItemStyle Font-Size="XX-Small"></ItemStyle>
														<HeaderStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Left" BorderWidth="16px"
															ForeColor="Black" BorderStyle="Double" BorderColor="#404040" VerticalAlign="Middle" BackColor="SeaGreen"></HeaderStyle>
													</asp:DataGrid></P>
												<P align="justify">&nbsp;</P>
												<P align="justify">&nbsp;</P>
												<P align="justify">&nbsp;</P>
												<P align="justify"><STRONG></STRONG>&nbsp;</P>
												<P align="justify"><STRONG>Detalles de la Sucursal&nbsp; 
													(Cliente)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
												</STRONG>
												<P align="justify">
													<asp:DataGrid id="DataGridSuc" runat="server" Width="569px" Height="35px" PageSize="1" HorizontalAlign="Left"
														Visible="False" CellPadding="2" BorderStyle="None" BorderColor="Green">
														<AlternatingItemStyle BackColor="#C0FFC0"></AlternatingItemStyle>
														<ItemStyle Font-Size="XX-Small"></ItemStyle>
														<HeaderStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Left" BorderWidth="16px"
															ForeColor="Black" BorderStyle="Double" BorderColor="#404040" VerticalAlign="Middle" BackColor="SeaGreen"></HeaderStyle>
													</asp:DataGrid></P>
												<P>&nbsp;&nbsp;</P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>Porcentaje de descuento asignado actualmente:
													<asp:label id="lblPorcDesc" runat="server" ForeColor="Red"></asp:label></P>
												<P>Estatus del Cliente:
													<asp:label id="lblEstatus" runat="server" ForeColor="Black"></asp:label></P>
												<P>&nbsp;</P>
												<P>
													<asp:image id="Image1" runat="server" ImageUrl="Home_files/H_Separador.gif" Height="8px" Width="480px"></asp:image></P>
												<P>&nbsp;</P>
												<P>&nbsp;</P>
												<P>
												<P>
												<P>
												<P>
												<P>
													<asp:Button id="btnAceptar" runat="server" Text="Bloquear" Font-Size="XX-Small"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													<asp:Button id="btnDesblq" runat="server" Font-Size="XX-Small" Text="Desbloquear"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</P>
												<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</P>
												<P align="left">&nbsp;</P>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_left.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_bottom_left.xws"></td>
											<td class="footer">
												<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
														<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px">
																	<P align="left">&nbsp;
																		<asp:hyperlink id="lnkHome" runat="server" NavigateUrl="Home.aspx" ForeColor="White">HOME</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkWho" runat="server" NavigateUrl="Info\Quienes_somos.aspx" ForeColor="White">¿QUIENES SOMOS?</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkServ" runat="server" NavigateUrl="http://www.google.com" ForeColor="White">SERVICIOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkContactanos" runat="server" NavigateUrl="Info\Contactanos.aspx" ForeColor="White">CONTACTANOS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkLinks" runat="server" NavigateUrl="Info\Links.aspx" ForeColor="White">LINKS</asp:hyperlink>&nbsp;&nbsp;
																		<asp:hyperlink id="lnkHelp" runat="server" NavigateUrl="Info\Ayuda.aspx" ForeColor="White">AYUDA</asp:hyperlink></P>
																</BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE></BLOCKQUOTE>
											</td>
											<td vAlign="top" width="55"><IMG src="Home_files/Home_bottom_right.gif" border="0" editor="Webstyle4" moduleid="CreditumStyle (Project)\Home_bottom_right.xws"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
