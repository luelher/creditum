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

namespace Creditum.PCCA
{
	/// <summary>
	/// Descripción breve de HistorialFacturasC.
	/// </summary>
	public class HistorialFacturasC : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFHistorial;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Repeater rptrFacturas;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.HyperLink lnkPC;
		protected System.Web.UI.WebControls.Label lblValida;
		protected System.Web.UI.WebControls.Label lblFallida;
		protected System.Web.UI.WebControls.ImageButton imgbtnImprimir;
	
		protected DataSet ds;
		protected string Mes;
		protected string Ano;
		protected string Cliente;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.CONSULTOR_ADMINISTRADOR)))
				{
					Cliente = usr.IDCliente.ToString();
					Mes = Request.Params["mf"].ToString();
					Ano = Request.Params["af"].ToString();
				}
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			imgbtnImprimir.Attributes.Add("OnClick", @"window.print();");
			if (!Page.IsPostBack)
			{
				lblFHistorial.Text = Mes + " - " + Ano;
				MostrarFacturas();
			}
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
					+ "facturas.TOTAL AS TOTAL,"
					+ "facturas.PRECIO_OK AS PRECIO_OK,"
					+ "facturas.PRECIO_FALLIDA AS PRECIO_FALLIDA "
					+ "FROM facturas "
					+ @"INNER JOIN clientes ON (facturas.ID_CLIENTE = clientes.ID_CLIENTE) "
					+ @"LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL=casas_comerciales.ID_CASA_COMERCIAL) "
					+ @"WHERE("
					+ @"MONTH(facturas.FECHA_HASTA) = " + Mes + " AND YEAR(facturas.FECHA_HASTA) = " + Ano + " "
					+ "AND facturas.ID_CLIENTE = " + Cliente
					+ @");";
				#endregion
				clsBD.EjecutarQuery(conn,strSQLQuery, out mydt);
				if (mydt.Rows.Count == 0)
					MensajeWeb.Info("No hay ordenes de facturación de este mes", Page, "InfoError2");
				else
				{
					lblFallida.Text = mydt.Rows[0]["PRECIO_FALLIDA"].ToString();
					lblValida.Text = mydt.Rows[0]["PRECIO_OK"].ToString();
				}
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
	}
}
