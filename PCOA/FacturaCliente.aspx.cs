using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;
using Creditum.Usuarios;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de FacturaCliente.
	/// </summary>
	public class FacturaCliente : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton imgbtnImprimir;
		protected System.Web.UI.WebControls.HyperLink lnkPC;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label lblConsultaV;
		protected System.Web.UI.WebControls.Label lblConsultaF;
		protected System.Web.UI.WebControls.Repeater rptrFacturas;

		protected DataSet ds;
		protected string IDCliente;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
				{
					IDCliente = Request.Params["id"].ToString();
				}
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			imgbtnImprimir.Attributes.Add("OnClick", @"window.print();");
			if (!Page.IsPostBack)
			{
				ds = new DataSet();
				TablaPrecios();
				lblConsultaV.Text = ds.Tables["Precios"].Rows[0]["PRECIO_OK1"].ToString() + "Bs(100 consultas), "
					+ ds.Tables["Precios"].Rows[0]["PRECIO_OK2"].ToString() + "Bs(200 consultas), "
					+ ds.Tables["Precios"].Rows[0]["PRECIO_OK3"].ToString() + "Bs(300 consultas), "
					+ ds.Tables["Precios"].Rows[0]["PRECIO_OK4"].ToString() + "Bs(400 consultas)";
				lblConsultaF.Text = ds.Tables["Precios"].Rows[0]["PRECIO_FALLIDA"].ToString() + "Bs";
				if (ClientesFacturar())
				{		
					InsertarFacturas();
				}
					MostrarFacturas();
			}
		}

		#region Código generado por el Diseñador de Web Forms
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: llamada requerida por el Diseñador de Web Forms ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private bool ClientesFacturar()
		{
			DataSet ds1;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds1);
				#endregion
				#region SQL Select
				string strSQLQuery = "SELECT clientes_conf.ID_CLIENTE AS ID_CLIENTE,"
					+ @"CONCAT_WS('-',casas_comerciales.NOMBRE,clientes.NOMBRE) AS NOMBRE_CLIENTE,"
					+ "clientes.RIF AS RIF,"
					+ "clientes.NIT AS NIT,"
					+ "clientes.DIRECCION AS DIRECCION,"
					+ "clientes.TELEFONO AS TELEFONO,"
					+ "clientes_conf.DESCUENTO AS DESCUENTO "
					+ "FROM clientes_conf "
					+ @"INNER JOIN clientes ON (clientes_conf.ID_CLIENTE = clientes.ID_CLIENTE) "
					+ @"LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL=casas_comerciales.ID_CASA_COMERCIAL) "
					//+ @"LEFT JOIN facturas ON (clientes_conf.ID_CLIENTE = facturas.ID_CLIENTE) "
					+ @"WHERE clientes_conf.ID_CLIENTE=" + IDCliente;
				#endregion
				#region Ejecutar Query
				if (clsBD.EjecutarQuery(conn,strSQLQuery, ds, "Clientes"))
				{
					if (ds.Tables["Clientes"].Rows.Count > 0)
					{
						return true;
					}
					else
					{
						//MensajeWeb.Info("No hay facturas para hoy", Page, "InfoError2");
						//Response.Redirect(@"PanelControlOA.aspx");
						return false;
					}
				}
				else
				{
					MensajeWeb.Info("Error, el sistema no esta disponible", Page, "InfoError8");
					Response.Redirect(@"PanelControlOA.aspx");
					return false;
				}
				#endregion
			}
			catch
			{
				MensajeWeb.Info("Error, el sistema no esta disponible", Page, "InfoError6");
				Response.Redirect(@"PanelControlOA.aspx");
				return false;
			}
		}

		private bool TablaPrecios()
		{
			DataSet ds1;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds1);
				#endregion
				#region SQL Select
				string strSQLQuery = "SELECT PRECIO_OK1,PRECIO_OK2, PRECIO_OK3,"
					+ "PRECIO_OK4, PRECIO_FALLIDA "
					+ "FROM empresa_conf";
				#endregion
				#region Ejecutar Query
				if (clsBD.EjecutarQuery(conn,strSQLQuery, ds, "Precios"))
				{
					if (ds.Tables["Precios"].Rows.Count == 1)
					{
						return true;
					}
					else
					{
						MensajeWeb.Info("Error leyendo los precios de las consulta", Page, "InfoError5");
						Response.Redirect(@"PanelControlOA.aspx");
						return false;
					}
				}
				else
				{
					MensajeWeb.Info("Error, el sistema no esta disponible", Page, "InfoError6");
					Response.Redirect(@"PanelControlOA.aspx");
					return false;
				}
				#endregion
			}
			catch
			{
				MensajeWeb.Info("Error, el sistema no esta disponible", Page, "InfoError6");
				Response.Redirect(@"PanelControlOA.aspx");
				return false;
			}
		}

		private bool InsertarFacturas()
		{
			DataSet ds1;
			DataTable dt1;
			string strSqlInsert;
			string strValidas;
			string strFallidas;
			string PrecioOK;
			string PrecioFallida;
			string TotalV;
			string TotalF;
			string Descuento;
			string TotalD;
			string Total;
			string ID_Factura;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds1);
				#endregion
				foreach (DataRow dr in ds.Tables["Clientes"].Rows)
				{
					#region Calcular Valores
					strValidas = ObtenerValidas(dr["ID_CLIENTE"].ToString(), conn);
					strFallidas = ObtenerInvalidas(dr["ID_CLIENTE"].ToString(), conn);
					PrecioOK = ObtenerPrecioOK(Convert.ToInt32(strValidas));
					PrecioFallida = ds.Tables["Precios"].Rows[0]["PRECIO_FALLIDA"].ToString();
					Descuento = dr["DESCUENTO"].ToString();
					TotalV = ((int)(Convert.ToInt32(strValidas) * Convert.ToInt32(PrecioOK))).ToString();
					TotalF = ((int)(Convert.ToInt32(strFallidas) * Convert.ToInt32(PrecioFallida))).ToString();
					TotalD = ((float)((Convert.ToDouble(TotalV)*(1f - (float)(Convert.ToInt32(Descuento)/100f))))).ToString();
					Total = ((float)(Convert.ToDouble(TotalD) + Convert.ToInt32(TotalF))).ToString();
					TotalD = TotalD.Replace(",",".");
					Total = Total.Replace(",",".");

					#endregion
					
					#region SQL Insert
					strSqlInsert = "INSERT INTO facturas(ID_CLIENTE,FECHA_HASTA,PRECIO_OK,"
						+ "PRECIO_FALLIDA,VALIDAS,TOTALV,FALLIDAS,TOTALF,DESCUENTO,TOTALD,"
						+ "TOTAL) VALUES(" 
						+ dr["ID_CLIENTE"].ToString() + ","
						+ "CURRENT_DATE()" + ","
						+ PrecioOK + "," + PrecioFallida + "," + strValidas + ","
						+ TotalV + "," + strFallidas + "," + TotalF + ","
						+ Descuento + "," + TotalD + "," + Total + ");";
					clsBD.EjecutarNonQuery(conn, strSqlInsert);
					#endregion
					#region Obtener ID de Factura
					string strSQL = "SELECT MAX(ID_FACTURA) FROM facturas;";
					clsBD.EjecutarQuery(conn,strSQL, out dt1);
					ID_Factura = dt1.Rows[0][0].ToString();
					#endregion
					#region Insertar Consultas OK

					string strInsertOK = "INSERT INTO detalle_facturas(ID_FACTURA,CEDULA_USUARIO,ID_PERSONA,FECHA_HORA,STATUS) "
						+ "SELECT " + ID_Factura + ", CEDULA_USUARIO,ID_PERSONA,FECHA_HORA,1 FROM consultas "
						+ "WHERE ID_CLIENTE = " + dr["ID_CLIENTE"].ToString();
					clsBD.EjecutarNonQuery(conn, strInsertOK);

					#endregion
					#region Insertar Consultas Fallidas

					string strInsertBad = "INSERT INTO detalle_facturas(ID_FACTURA,CEDULA_USUARIO,ID_PERSONA,FECHA_HORA,STATUS) "
						+ "SELECT " + ID_Factura + ", CEDULA_USUARIO,ID_PERSONA,FECHA_HORA,0 FROM consultas_fallidas "
						+ "WHERE ID_CLIENTE = " + dr["ID_CLIENTE"].ToString();
					clsBD.EjecutarNonQuery(conn, strInsertBad);

					#endregion
					#region Borrar Consultas
					string strDel1 = "DELETE FROM consultas "
						+ "WHERE ID_CLIENTE = " + dr["ID_CLIENTE"].ToString();
					clsBD.EjecutarNonQuery(conn, strDel1);
					string strDel2 = "DELETE FROM consultas_fallidas "
						+ "WHERE ID_CLIENTE = " + dr["ID_CLIENTE"].ToString();
					clsBD.EjecutarNonQuery(conn, strDel2);
					#endregion
				}
				return true;
			}
			catch
			{
				return false;
			}
		}

		private string ObtenerValidas(string strCliente, clsBDConexion conex)
		{
			string strValidas;
			DataTable mydt;
			try
			{
				string strSQL = "SELECT COUNT(ID_CLIENTE) FROM consultas "
					+ "WHERE (ID_CLIENTE =" + strCliente + ") "
					+ "GROUP BY (ID_CLIENTE);";
				if (clsBD.EjecutarQuery(conex,strSQL, out mydt))
				{
					if (mydt.Rows.Count == 1)
					{
						strValidas = mydt.Rows[0][0].ToString();
						return strValidas;
					}
					else
						return "0";
				}
				else
					return " ";
			}
			catch
			{
				return " ";
			}
		}

		private string ObtenerInvalidas(string strCliente, clsBDConexion conex)
		{
			string strInValidas;
			DataTable mydt;
			try
			{
				string strSQL = "SELECT COUNT(ID_CLIENTE) FROM consultas_fallidas "
					+ "WHERE (ID_CLIENTE =" + strCliente + ") "
					+ "GROUP BY (ID_CLIENTE);";
				if (clsBD.EjecutarQuery(conex,strSQL, out mydt))
				{
					if (mydt.Rows.Count == 1)
					{
						strInValidas = mydt.Rows[0][0].ToString();
						return strInValidas;
					}
					else
						return "0";
				}
				else
					return " ";
			}
			catch
			{
				return " ";
			}
		}

		private string ObtenerPrecioOK(int intValidas)
		{
			if (intValidas <= 100)
				return ds.Tables["Precios"].Rows[0]["PRECIO_OK1"].ToString();
			else if ((intValidas > 100) && (intValidas <= 200))
				return ds.Tables["Precios"].Rows[0]["PRECIO_OK2"].ToString();
			else if ((intValidas > 200) && (intValidas <= 300))
				return ds.Tables["Precios"].Rows[0]["PRECIO_OK3"].ToString();
			else
				return ds.Tables["Precios"].Rows[0]["PRECIO_OK4"].ToString();
		}
	
		private bool MostrarFacturas()
		{
			DataTable mydt;
			DataSet ds1;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds1);
				#endregion
				#region SQL Select
				string strSQLQuery = "SELECT facturas.ID_FACTURA AS ID_FACTURA,"
					+ @"CONCAT_WS('-',casas_comerciales.NOMBRE,clientes.NOMBRE) AS NOMBRE_CLIENTE,"
					+ "clientes.RIF AS RIF,"
					+ "clientes.NIT AS NIT,"
					+ "clientes.DIRECCION AS DIRECCION,"
					+ "clientes.TELEFONO AS TELEFONO,"
					+ "facturas.DESCUENTO AS DESCUENTO,"
					+ "facturas.VALIDAS AS VALIDAS,"
					+ "facturas.TOTALV AS TOTALV,"
					+ "facturas.TOTALD AS TOTALD,"
					+ "facturas.FALLIDAS AS FALLIDAS,"
					+ "facturas.TOTALF AS TOTALF,"
					+ "facturas.TOTAL AS TOTAL "
					+ "FROM facturas "
					+ @"INNER JOIN clientes ON (facturas.ID_CLIENTE = clientes.ID_CLIENTE) "
					+ @"LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL=casas_comerciales.ID_CASA_COMERCIAL) "
					+ @"WHERE("
					+ @"(facturas.FECHA_HASTA = CURRENT_DATE()) AND (facturas.ID_CLIENTE=" + IDCliente + ")"
					+ @");";
				#endregion
				clsBD.EjecutarQuery(conn,strSQLQuery, out mydt);
				if (mydt.Rows.Count == 0)
					MensajeWeb.Info("No hay ordenes de facturación para este cliente", Page, "InfoError2");
				rptrFacturas.DataSource = mydt;
				this.DataBind();
				return true;
			}
			catch
			{
				MensajeWeb.Info("Error, el sistema no puede mostrar las facturas generadas", Page, "InfoError12");
				return false;
			}
		}

	}
}
