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
using Creditum.Usuarios;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de Precios.
	/// </summary>
	public class Precios : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button btnAceptar;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.Label lblP1;
		protected System.Web.UI.WebControls.TextBox txtP1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorP1;
		protected System.Web.UI.WebControls.Label lblP2;
		protected System.Web.UI.WebControls.TextBox txtP2;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorP2;
		protected System.Web.UI.WebControls.Label lblP3;
		protected System.Web.UI.WebControls.TextBox txtP3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorP3;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorP4;
		protected System.Web.UI.WebControls.TextBox txtP4;
		protected System.Web.UI.WebControls.Label lblP4;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorF;
		protected System.Web.UI.WebControls.TextBox txtF;
		protected System.Web.UI.WebControls.Label lblF;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator1;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator2;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator3;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator4;
		protected System.Web.UI.WebControls.RangeValidator RangeValidator5;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if (usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR)))
				{}	//lblUser.Text = "Usuario: " + usr.Nombre + " " + usr.Apellido;
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			string scriptConfirmar = @"return confirm('Desea guardar los cambios?');";
			btnAceptar.Attributes.Add("OnClick", scriptConfirmar);
			if (!Page.IsPostBack)
			{
				#region Cargar Info
				CargarPrecios();
				#endregion
			}
			
		}

		private void CargarPrecios()
		{
			DataSet ds;
			btnAceptar.Enabled = false;
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				string strSQLQuery = @"SELECT PRECIO_OK1,PRECIO_OK2,PRECIO_OK3,PRECIO_OK4, PRECIO_FALLIDA FROM empresa_conf ";
					
				#region Ejecutar Query
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "P"))
				{
					if (ds.Tables["P"].Rows.Count == 1)
					{
						txtP1.Text = ds.Tables["P"].Rows[0].ItemArray[0].ToString();
						txtP2.Text = ds.Tables["P"].Rows[0].ItemArray[1].ToString();
						txtP3.Text = ds.Tables["P"].Rows[0].ItemArray[2].ToString();
						txtP4.Text = ds.Tables["P"].Rows[0].ItemArray[3].ToString();
						txtF.Text  = ds.Tables["P"].Rows[0].ItemArray[4].ToString();
						btnAceptar.Enabled = true;
					}
					else
						lblError.Text = "Error: Consulta Incorrecta";
				}
				else
					lblError.Text = "Error: Sistema no disponible";
				#endregion
			}
			catch
			{
				lblError.Text = "Error: Sistema no disponible";
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
						@"UPDATE empresa_conf SET PRECIO_OK1=" + txtP1.Text + ","
						+ "PRECIO_OK2=" + txtP2.Text + ","
						+ "PRECIO_OK3=" + txtP3.Text + ","
						+ "PRECIO_OK4=" + txtP4.Text + ","
						+ "PRECIO_FALLIDA=" + txtF.Text + " ";
					if (clsBD.EjecutarNonQuery(conn, strSQLUPDATE) >= 0)
					{
						#region Limpiar y cerrar
						btnAceptar.Enabled = false;
						txtP1.Text = "";
						txtP2.Text = "";
						txtP3.Text = "";
						txtP4.Text = "";
						txtF.Text = "";
						MensajeWeb.Info("Los precios de las consultas han sido actualizados satisfactoriamente", Page, "InfoOK1");
						Page.RegisterStartupScript("cerrar",@"<script language='javascript'>document.location.href=""PanelControlOA.aspx""</script>");
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
	}
}
