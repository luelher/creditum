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
using System.Web.Security;
using GrupoEmporium.Datos;
using Creditum.Usuarios;
using GrupoEmporium.Mensajes;

namespace Creditum
{
	/// <summary>
	/// Descripción breve de ConsultasCreditos.
	/// </summary>
	public class ConsultasCreditos : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorCI;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.Label lblLogin;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorCI;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button btnDetalles;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.DataGrid DataGridDetalles;
		protected System.Web.UI.WebControls.DataGrid DataGridDatosPersonales;
		protected System.Web.UI.WebControls.Label lblDP;
		protected System.Web.UI.WebControls.Label lblCred;
		protected System.Web.UI.WebControls.ImageButton imgbtnImprimir;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			imgbtnImprimir.Attributes.Add("OnClick", @"window.print();");
			string scriptConfirmar = @"return confirm('Desea ver la información de la persona de CI:' + txtCedula.value + '?');";
			btnDetalles.Attributes.Add("OnClick", scriptConfirmar);
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
			this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnDetalles_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				DataSet ds = new DataSet();
				try
				{
					#region CargarConfig
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					#region Cargar Datos Personales
					//Query para buscar a la persona natural
					string strQuery = @"SELECT personas_naturales.CEDULA,CONCAT(personas_naturales.APELLIDO, ' ',personas_naturales.NOMBRE) AS NOMBRE,personas_naturales.NACIONALIDAD FROM personas_naturales WHERE((personas_naturales.CEDULA = '" 
						+ txtCedula.Text + @"'))";
					clsBD.EjecutarQuery(conn, strQuery, out ds, "DatosPersonales");
					DataGridDatosPersonales.DataSource = ds;
					DataGridDatosPersonales.DataBind();
					DataGridDatosPersonales.Visible = true;
					#endregion
					//Query para retornar la información crediticia
					#region SqlQuery Detalles
					strQuery = @"SELECT casas_comerciales.NOMBRE AS CASA_COMERCIAL,"
						+ @"clientes.NOMBRE AS SUCURSAL,"
						+ @"CONCAT(DAYOFMONTH(creditos.FECHA_COMPRA),'/',MONTH(creditos.FECHA_COMPRA),'/',YEAR(creditos.FECHA_COMPRA)) AS FECHA_COMPRA, "
						+ @"CONCAT(DAYOFMONTH(creditos.FECHA_OPERACION),'/',MONTH(creditos.FECHA_OPERACION),'/',YEAR(creditos.FECHA_OPERACION)) AS FECHA_OPERACION, "
						+ @"creditos.MONTO,"
						+ @"creditos.PAGO_MES,"
						+ @"creditos.NUM_GIROS AS GIROS,"
						+ @"creditos.EXPERIENCIA AS EXP, "
						+ "IF(creditos.ESTADO=0,'Activo','Cancelado') AS ESTADO "
						+ @"FROM creditos "
						+ @"INNER JOIN clientes_personas ON (creditos.ID_CLIENTE_PERSONA = clientes_personas.ID_CLIENTE_PERSONA) "
						+ @"INNER JOIN personas_naturales ON (clientes_personas.ID_PERSONA = personas_naturales.CEDULA) "
						+ @"INNER JOIN clientes ON (clientes_personas.ID_CLIENTE = clientes.ID_CLIENTE) "
						+ @"LEFT OUTER JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL = casas_comerciales.ID_CASA_COMERCIAL) "
						+ @"WHERE((clientes_personas.ID_PERSONA = '" + txtCedula.Text + @"')) " 
						+ @"ORDER BY creditos.FECHA_COMPRA DESC;";
					#endregion
					bool resp = clsBD.EjecutarQuery(conn, strQuery, out ds, "Detalles");
					if (ds.Tables[0].Rows.Count > 0)
					{
						//Enlazar DataGrid
						if (RegistrarConsultaOK(conn))
						{
							lblError.Text = "";
							DataGridDetalles.DataSource = ds;
							DataGridDetalles.DataBind();
							DataGridDetalles.Visible = true;
							lblCred.Visible = true;
							lblDP.Visible = true;
							imgbtnImprimir.Visible = true;
						}
						else
						{
							DataGridDetalles.Visible = false;
							DataGridDatosPersonales.Visible = false;
							lblCred.Visible = false;
							lblDP.Visible = false;
							imgbtnImprimir.Visible = false;
							lblError.Text = "Disculpe el servicio no esta disponible en estos momentos, su consulta no ha sido procesada";
						}
					}
					else
					{
						DataGridDetalles.Visible = false;
						DataGridDatosPersonales.Visible = false;
						lblCred.Visible = false;
						lblDP.Visible = false;
						imgbtnImprimir.Visible = false;
						//lblError.Text = "Disculpe la persona solicitada no esta registrada en nuestro sistema";
						RegistrarConsultasVacias(conn);
						MensajeWeb.Info("La persona solicitada no está registrada en el sistema", Page, "InfoNoExiste");
					}
				}
				catch
				{
					DataGridDetalles.Visible = false;
					DataGridDatosPersonales.Visible = false;
					lblCred.Visible = false;
					lblDP.Visible = false;
					imgbtnImprimir.Visible = false;
					lblError.Text = "Disculpe el servicio no esta disponible en estos momentos, su consulta no ha sido procesada";
				}
			}
		}

		/// <summary>
		/// Agrega la consulta para luego poder ser facturada
		/// </summary>
		/// <param name="cn">clsBDConexion conexion a la base de datos</param>
		/// <returns>true si la operacion fue satisfactoria</returns>
		private bool RegistrarConsultaOK(clsBDConexion cn)
		{
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			#region SQLInsert
				string strSqlInsert = @"INSERT INTO consultas("
					+ @"CEDULA_USUARIO,"
					+ @"ID_CLIENTE,"
					+ @"ID_PERSONA,"
					+ @"FECHA_HORA) "
					+ @"VALUES(" + usr.Cedula + @","
					+ usr.IDCliente + @","
					+ @"'" + txtCedula.Text + @"',"
					+ @"'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"');";
				#endregion	
			if (clsBD.EjecutarNonQuery(cn, strSqlInsert) == 0)
				return false;
			else
				return true;			
		}

		/// <summary>
		/// Agrega la consulta para luego poder ser facturada
		/// </summary>
		/// <param name="cn">clsBDConexion conexion a la base de datos</param>
		/// <returns>true si la operacion fue satisfactoria</returns>
		private bool RegistrarConsultasVacias(clsBDConexion cn)
		{
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			#region SQLInsert
			string strSqlInsert = @"INSERT INTO consultas_fallidas("
				+ @"CEDULA_USUARIO,"
				+ @"ID_CLIENTE,"
				+ @"ID_PERSONA,"
				+ @"FECHA_HORA) "
				+ @"VALUES(" + usr.Cedula + @","
				+ usr.IDCliente + @","
				+ @"'" + txtCedula.Text + @"',"
				+ @"'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"');";
			#endregion	
			if (clsBD.EjecutarNonQuery(cn, strSqlInsert) == 0)
				return false;
			else
				return true;
		}

		private void DataGridDatosPersonales_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


	}
}
