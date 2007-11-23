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
	/// Descripción breve de HistorialFacturas.
	/// </summary>
	public class HistorialFacturas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFHistorial;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Repeater rptrFacturas;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.HyperLink lnkPC;
		protected System.Web.UI.WebControls.ImageButton imgbtnImprimir;
	
		protected DataSet ds;
		protected string Fecha;

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
					Fecha = Request.Params["ff"].ToString();
				}
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			imgbtnImprimir.Attributes.Add("OnClick", @"window.print();");
			if (!Page.IsPostBack)
			{
				lblFHistorial.Text = Fecha;
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
					+ @"facturas.FECHA_HASTA = '" + Fecha + "'"
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
