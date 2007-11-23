<%@ Page language="c#" Codebehind="FacturaCliente.aspx.cs" AutoEventWireup="false" Inherits="Creditum.PCOA.FacturaCliente" %>
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
								<DIV align="center"><IMG src="FacturasDia_files/Header.gif" border="0" editor="Webstyle4" moduleid="ReporteCreditum (Project)\Header.xws"></DIV>
							</TD>
						</TR>
						<TR>
							<TD width="544" colSpan="2">&nbsp;<STRONG><FONT size="2">Costo de la consulta válida:</FONT></STRONG>
								<asp:label id="lblConsultaV" runat="server"></asp:label></TD>
							<TD>
								<P align="center">&nbsp;<FONT size="2"><STRONG>Fecha de Emisión:</STRONG></FONT></P>
							</TD>
						</TR>
						<TR>
							<TD width="544" colSpan="2"><STRONG><FONT size="2">&nbsp;Costo de la consulta fallida:</FONT></STRONG>
								<asp:label id="lblConsultaF" runat="server"></asp:label></TD>
							<TD>
								<P align="center">&nbsp;
									<asp:label id="lblTime" runat="server">Hoy</asp:label></P>
							</TD>
						</TR>
						<TR>
							<TD colSpan="3"></TD>
						</TR>
						<TR>
							<TD colSpan="3">
								<P align="center"><FONT size="5">Reporte de Órdenes de Facturación</FONT></P>
							</TD>
						</TR>
						<TR>
							<TD width="544" colSpan="2"></TD>
							<TD width="254"></TD>
						</TR>
						<TR>
							<TD width="544" colSpan="2">&nbsp;<STRONG>Listado de Órdenes de Facturación</STRONG></TD>
							<TD width="254">&nbsp;</TD>
						</TR>
						<TR>
							<TD colSpan="3">&nbsp;
								<DIV align="center"><asp:repeater id="rptrFacturas" runat="server">
										<ItemTemplate>
											<tr bgcolor="#f4f4f4" width="200">
												<td>
													<font size="1"><a href='../DetalleFactura.aspx?IDFACTURA=<%# DataBinder.Eval(Container.DataItem,"ID_FACTURA") %>' >
															<%# DataBinder.Eval(Container.DataItem, "ID_FACTURA") %>
														</a></font>
												</td>
												<td>
													<font size="1">
														<br>
														<%# DataBinder.Eval(Container.DataItem, "NOMBRE_CLIENTE") %>
														<br>
														<font style="FONT-WEIGHT: bold">Rif: </font>
														<%# DataBinder.Eval(Container.DataItem, "RIF") %>
														<br>
														<font style="FONT-WEIGHT: bold">Nit: </font>
														<%# DataBinder.Eval(Container.DataItem, "NIT") %>
														<br>
														<font style="FONT-WEIGHT: bold">Dir: </font>
														<%# DataBinder.Eval(Container.DataItem, "DIRECCION") %>
														<br>
														<font style="FONT-WEIGHT: bold">Tlf: </font>
														<%# DataBinder.Eval(Container.DataItem, "TELEFONO") %>
												</td>
												<td>
													<font size="1"><font style="FONT-WEIGHT: bold" color="SeaGreen" size="3">
															<%# DataBinder.Eval(Container.DataItem, "VALIDAS") %>
														</font>
														<br>
														<font style="FONT-WEIGHT: bold">Total: </font>
														<%# DataBinder.Eval(Container.DataItem, "TOTALV") %>
														Bs </font>
												</td>
												<td>
													<font size="1"><font style="FONT-WEIGHT: bold" color="#0000ff" size="3">
															<%# DataBinder.Eval(Container.DataItem, "DESCUENTO") %>
															% </font>
														<br>
														<font style="FONT-WEIGHT: bold">Total: </font>
														<%# DataBinder.Eval(Container.DataItem, "TOTALD") %>
														Bs </font>
												</td>
												<td>
													<font size="1"><font style="FONT-WEIGHT: bold" color="#ff0000" size="3">
															<%# DataBinder.Eval(Container.DataItem, "FALLIDAS") %>
														</font>
														<br>
														<font style="FONT-WEIGHT: bold">Total: </font>
														<%# DataBinder.Eval(Container.DataItem, "TOTALF") %>
														Bs </font>
												</td>
												<td>
													<font style="FONT-WEIGHT: bold">
														<%# DataBinder.Eval(Container.DataItem, "TOTAL") %>
														Bs </font>
												</td>
											</tr>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<tr bgcolor="#C0FFC0">
												<td>
													<font size="1"><a href='../DetalleFactura.aspx?IDFACTURA=<%# DataBinder.Eval(Container.DataItem,"ID_FACTURA") %>' >
															<%# DataBinder.Eval(Container.DataItem, "ID_FACTURA") %>
														</a></font>
												</td>
												<td>
													<font size="1">
														<br>
														<%# DataBinder.Eval(Container.DataItem, "NOMBRE_CLIENTE") %>
														<br>
														<font style="FONT-WEIGHT: bold">Rif: </font>
														<%# DataBinder.Eval(Container.DataItem, "RIF") %>
														<br>
														<font style="FONT-WEIGHT: bold">Nit: </font>
														<%# DataBinder.Eval(Container.DataItem, "NIT") %>
														<br>
														<font style="FONT-WEIGHT: bold">Dir: </font>
														<%# DataBinder.Eval(Container.DataItem, "DIRECCION") %>
														<br>
														<font style="FONT-WEIGHT: bold">Tlf: </font>
														<%# DataBinder.Eval(Container.DataItem, "TELEFONO") %>
													</font>
												</td>
												<td>
													<font size="1"><font style="FONT-WEIGHT: bold" color="SeaGreen" size="3">
															<%# DataBinder.Eval(Container.DataItem, "VALIDAS") %>
														</font>
														<br>
														<font style="FONT-WEIGHT: bold">Total: </font>
														<%# DataBinder.Eval(Container.DataItem, "TOTALV") %>
														Bs </font>
												</td>
												<td>
													<font size="1"><font style="FONT-WEIGHT: bold" color="#0000ff" size="3">
															<%# DataBinder.Eval(Container.DataItem, "DESCUENTO") %>
															% </font>
														<br>
														<font style="FONT-WEIGHT: bold">Total: </font>
														<%# DataBinder.Eval(Container.DataItem, "TOTALD") %>
														Bs </font>
												</td>
												<td>
													<font size="1"><font style="FONT-WEIGHT: bold" color="#ff0000" size="3">
															<%# DataBinder.Eval(Container.DataItem, "FALLIDAS") %>
														</font>
														<br>
														<font style="FONT-WEIGHT: bold">Total: </font>
														<%# DataBinder.Eval(Container.DataItem, "TOTALF") %>
														Bs </font>
												</td>
												<td>
													<font style="FONT-WEIGHT: bold">
														<%# DataBinder.Eval(Container.DataItem, "TOTAL") %>
														Bs </font>
												</td>
											</tr>
										</AlternatingItemTemplate>
										<HeaderTemplate>
											<table width="640" bgcolor="SeaGreen" cellspacing="0">
												<tr bgcolor="SeaGreen">
													<td align="left">
														<font size="1"><b>FACTURA</b></font>
													</td>
													<td align="left">
														<font size="1"><b>DATOS DEL CLIENTE</b></font>
													</td>
													<td align="left">
														<font size="1"><b>VÁLIDAS</b></font>
													</td>
													<td align="left">
														<font size="1"><b>DESCUENTO</b></font>
													</td>
													<td align="left">
														<font size="1"><b>FALLIDAS</b></font>
													</td>
													<td align="left">
														<font size="1"><b>TOTAL</b></font>
													</td>
												</tr>
										</HeaderTemplate>
										<FooterTemplate>
											<tr>
												<td colspan="5" align="center">
												</td>
											</tr>
				</TABLE>
			</FooterTemplate> </asp:repeater></DIV>
			<P align="center">&nbsp;
				<asp:label id="lblError" runat="server" ForeColor="Red"></asp:label></P>
			</TD></TR>
			<TR>
				<TD>&nbsp;
					<asp:hyperlink id="lnkPC" runat="server" ForeColor="Green" NavigateUrl="panelcontrolOA.aspx" Font-Size="XX-Small">Panel de Control</asp:hyperlink></TD>
				<TD width="422"></TD>
				<TD>
					<P align="right">&nbsp;
						<asp:imagebutton id="imgbtnImprimir" runat="server" CausesValidation="False" ImageUrl="FacturasDia_files/impresora.gif"></asp:imagebutton></P>
				</TD>
			</TR>
			</TBODY></TABLE></P></form>
	</body>
</HTML>
