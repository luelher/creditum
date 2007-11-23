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
	/// Descripción breve de MSucursal.
	/// </summary>
	public class MSucursal : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorEmail;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorCel;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorTelf;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.Label lblFax;
		protected System.Web.UI.WebControls.TextBox txtFax;
		protected System.Web.UI.WebControls.Label lblCelular;
		protected System.Web.UI.WebControls.TextBox txtTelf;
		protected System.Web.UI.WebControls.Label LabelTelf;
		protected System.Web.UI.WebControls.TextBox txtCel;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DropDownListCasa;
		protected System.Web.UI.WebControls.Label lblUbicacion;
		protected System.Web.UI.WebControls.TextBox txtUbicacion;
		protected System.Web.UI.WebControls.Label lblNit;
		protected System.Web.UI.WebControls.TextBox txtNit;
		protected System.Web.UI.WebControls.Label lblRif;
		protected System.Web.UI.WebControls.TextBox txtRif;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorNombre;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryCC;
		protected System.Web.UI.WebControls.TextBox txtCC;
		protected string SucIndice;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
				{
				}
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			string scriptConfirmar = @"return confirm('Desea guardar los cambios?');";
			btnAceptar.Attributes.Add("OnClick", scriptConfirmar);
			//Leer el índice de la Sucursal pasado como parámetro a la página
			SucIndice = Request.Params["Index"].ToString();
			if (!Page.IsPostBack)
			{
				#region Cargar Info
				CargarInfo(SucIndice);
				#endregion
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
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				DataSet ds;
				try
				{
					#region CargarConfig
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					string strSQLUPDATE =
						@"UPDATE clientes SET NOMBRE='" + txtNombre.Text + "',"
						+ "RIF='" + txtRif.Text + "',"
						+ "NIT='" + txtNit.Text + "',"
						+ "DIRECCION='" + txtUbicacion.Text + "',"
						+ "TELEFONO='" + txtTelf.Text + "',"
						+ "CELULAR='" + txtCel.Text + "',"
						+ "FAX='" + txtFax.Text + "',"
						+ "EMAIL='" + txtEmail.Text + "' "
						+ @"WHERE ID_CLIENTE=" + SucIndice + ";";
					if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) >= 0)
					{
						#region Limpiar y cerrar
						btnAceptar.Enabled = false;
						txtNombre.Text = "";
						txtRif.Text = "";
						txtNit.Text = "";
						txtUbicacion.Text = "";
						txtTelf.Text = "";
						txtCel.Text = "";
						txtFax.Text = "";
						txtEmail.Text = "";
						MensajeWeb.Info("El cliente ha sido actualizado satisfactoriamente, gracias por utilizar CREDITUM", Page, "InfoOK1");
						Page.RegisterStartupScript("cerrar","<script language='javascript'>window.close();</script>");
						#endregion
					}
					else
					{
						MensajeWeb.Info("Error actualizando los datos, el sistema no está disponible en este momento", Page, "InfoError5");
						//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible o\n\rel Nivel de usuario actual es el mismo", Page, "Update2");
					}

				}
				catch
				{
					MensajeWeb.Info("Error actualizando los datos, el sistema no está disponible en este momento", Page, "InfoError2");
					//MensajeWeb.Info(@"Error actualizando los datos. Causas posibles:\n\rEl sistema puede que no esté disponible", Page, "Update3");
				}
			}
		}

		private void CargarInfo(string Indice)
		{
			DataSet ds;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				string strSQLQuery = @"SELECT clientes.NOMBRE,clientes.RIF,clientes.NIT,clientes.DIRECCION,clientes.TELEFONO,clientes.CELULAR,clientes.FAX,clientes.EMAIL,casas_comerciales.NOMBRE AS CC FROM clientes "
					+ @"LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL=casas_comerciales.ID_CASA_COMERCIAL) "
					+ "WHERE ID_CLIENTE=" + Indice;
				#region Ejecutar Query
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Suc"))
				{
					if (ds.Tables["Suc"].Rows.Count == 1)
					{
						txtNombre.Text = ds.Tables["Suc"].Rows[0].ItemArray[0].ToString();
						txtRif.Text = ds.Tables["Suc"].Rows[0].ItemArray[1].ToString();
						txtNit.Text = ds.Tables["Suc"].Rows[0].ItemArray[2].ToString();
						txtUbicacion.Text = ds.Tables["Suc"].Rows[0].ItemArray[3].ToString();
						txtTelf.Text = ds.Tables["Suc"].Rows[0].ItemArray[4].ToString();
						txtCel.Text = ds.Tables["Suc"].Rows[0].ItemArray[5].ToString();
						txtFax.Text = ds.Tables["Suc"].Rows[0].ItemArray[6].ToString();
						txtEmail.Text = ds.Tables["Suc"].Rows[0].ItemArray[7].ToString();
						if (ds.Tables["Suc"].Rows[0].ItemArray[8].ToString() != "")
							txtCC.Text = ds.Tables["Suc"].Rows[0].ItemArray[8].ToString();
					}
					else
						Response.Redirect(@"Error.aspx?msg=Error: Consulta incorrecta");
				}
				else
					Response.Redirect(@"Error.aspx?msg=Error: Sistema no disponible");
				#endregion
			}
			catch
			{
				Response.Redirect(@"Error.aspx?msg=Error: Sistema no disponible");
			}
		}
	}
}
