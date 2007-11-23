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

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de ConsultasTelefonicas.
	/// </summary>
	public class ConsultasTelefonicas : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.Label lblLogin;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorCI;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Button btnDetalles;
		protected System.Web.UI.WebControls.DataGrid DataGridDetalles;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.ValidationSummary Validationsummary1;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorCI;
		protected System.Web.UI.WebControls.Label lblErrorCliente;
		protected System.Web.UI.WebControls.TextBox txtCedulaCliente;
		protected System.Web.UI.WebControls.Button btnVerCliente;
		protected System.Web.UI.WebControls.DataGrid DataGridCliente;
		protected System.Web.UI.WebControls.HyperLink lnkHelp;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.DataGrid DataGridDatosPersonales;
		protected System.Web.UI.WebControls.Label lblDP;
		protected System.Web.UI.WebControls.Label lblCred;
		protected Usuario UsrTelefonico;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Introducir aquí el código de usuario para inicializar la página
			lblTime.Text = System.DateTime.Now.ToLongDateString();
			MetodosComunes mc = new MetodosComunes();
			Usuario usr = mc.LeerCookie(@"c:\Config.xml", User.Identity.Name);
			if (usr != null)
			{
				if ((!usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR_ADMINISTRADOR))) && (!usr.PermitirAcceso(Convert.ToByte(Usuario.Nivel_Usuario.OPERADOR))))
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			string scriptConfirmar = @"return confirm('Desea ver la información de la persona de CI:' + txtCedula.value + '?\n\r"
				+ @"La consullta será cargada al usuario de CI:' + txtCedulaCliente.value);";
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
			this.btnVerCliente.Click += new System.EventHandler(this.btnVerCliente_Click);
			this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnVerCliente_Click(object sender, System.EventArgs e)
		{
		
			int intCedulaCliente = 0;
			DataSet ds = new DataSet();
			DataGridDetalles.Visible = false;
			btnDetalles.Enabled = false;
			DataGridCliente.Visible = false;
			try
			{intCedulaCliente = Convert.ToInt32(txtCedulaCliente.Text);}
			catch
			{lblErrorCliente.Text = "Cedula Inválida";}
			try
			{
				if ((intCedulaCliente>=1000000) && (intCedulaCliente<=100000000))
				{
					#region CargarConfig
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					//Query para buscar al cliente (usuario)
					string strSQLQuery =
						@"SELECT usuarios.CEDULA,usuarios.NOMBRE,usuarios.APELLIDO,usuarios.ID_CLIENTE,clientes.NOMBRE AS SUCURSAL,casas_comerciales.NOMBRE AS CASA,usuarios.ID_NIVEL FROM usuarios INNER JOIN clientes ON (usuarios.ID_CLIENTE = clientes.ID_CLIENTE) LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL = casas_comerciales.ID_CASA_COMERCIAL) WHERE((usuarios.CEDULA=" 
						+ txtCedulaCliente.Text + @"));";
					clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Cliente");
					if (ds.Tables[0].Rows.Count == 1)
					{
						//Crear el objeto Usuario Telefónico
						#region UsuarioTelefonico
						UsrTelefonico = new Usuario(ds.Tables["Cliente"].Rows[0].ItemArray[0].ToString(),
							ds.Tables["Cliente"].Rows[0].ItemArray[1].ToString(),
							ds.Tables["Cliente"].Rows[0].ItemArray[2].ToString(),
							Convert.ToInt32(ds.Tables["Cliente"].Rows[0].ItemArray[3]),
							ds.Tables["Cliente"].Rows[0].ItemArray[4].ToString(),
							ds.Tables["Cliente"].Rows[0].ItemArray[5].ToString(),
							Convert.ToByte(ds.Tables["Cliente"].Rows[0].ItemArray[6]));
						#endregion

						strSQLQuery =
							@"SELECT usuarios.CEDULA,usuarios.NOMBRE,usuarios.APELLIDO,clientes.NOMBRE AS SUCURSAL,casas_comerciales.NOMBRE AS CASA FROM usuarios INNER JOIN clientes ON (usuarios.ID_CLIENTE = clientes.ID_CLIENTE) LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL = casas_comerciales.ID_CASA_COMERCIAL) WHERE((usuarios.CEDULA=" 
							+ txtCedulaCliente.Text + @"));";
						clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Cliente");
						lblErrorCliente.Text = "";
						DataGridCliente.DataSource = ds;
						DataGridCliente.DataBind();
						DataGridCliente.Visible = true;
						btnDetalles.Enabled = true;
					}
					else
						//lblErrorCliente.Text = "El Cliente no esta registrado";
						MensajeWeb.Info("La persona solicitada no está registrada en el sistema", Page, "InfoNoExiste");
				}
				else
					lblErrorCliente.Text = "Cédula Inválida";
			}
			catch
			{
				lblErrorCliente.Text = "Disculpe, el sistema no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el sistema no está disponible en este momento", Page, "InfoNoExiste");
			}
			
		}


		private void btnDetalles_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				int intCedulaCliente = 0;
				try
				{intCedulaCliente = Convert.ToInt32(txtCedulaCliente.Text);}
				catch
				{lblErrorCliente.Text = "Cedula Inválida";}		
				if ((intCedulaCliente>=1000000) && (intCedulaCliente<=100000000))
				{
					DataSet ds = new DataSet();
					try
					{
						#region CargarConfig
						clsBDConexion conn = MetodosComunes.Conectar(out ds);
						#endregion
						#region UsuarioTelefonico
						//Query para buscar al cliente (usuario)
						DataSet ds1 = new DataSet();
						string strSQLQuery =
							@"SELECT usuarios.CEDULA,usuarios.NOMBRE,usuarios.APELLIDO,usuarios.ID_CLIENTE,clientes.NOMBRE AS SUCURSAL,casas_comerciales.NOMBRE AS CASA,usuarios.ID_NIVEL FROM usuarios INNER JOIN clientes ON (usuarios.ID_CLIENTE = clientes.ID_CLIENTE) LEFT JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL = casas_comerciales.ID_CASA_COMERCIAL) WHERE((usuarios.CEDULA=" 
							+ txtCedulaCliente.Text + @"));";
						clsBD.EjecutarQuery(conn,strSQLQuery, out ds1, "Cliente");
						//Crear el objeto Usuario Telefónico
			
						UsrTelefonico = new Usuario(ds1.Tables["Cliente"].Rows[0].ItemArray[0].ToString(),
							ds1.Tables["Cliente"].Rows[0].ItemArray[1].ToString(),
							ds1.Tables["Cliente"].Rows[0].ItemArray[2].ToString(),
							Convert.ToInt32(ds1.Tables["Cliente"].Rows[0].ItemArray[3]),
							ds1.Tables["Cliente"].Rows[0].ItemArray[4].ToString(),
							ds1.Tables["Cliente"].Rows[0].ItemArray[5].ToString(),
							Convert.ToByte(ds1.Tables["Cliente"].Rows[0].ItemArray[6]));
						#endregion
						#region Cargar Datos Personales
						//Query para buscar a la persona natural
						string strQuery = @"SELECT personas_naturales.CEDULA,CONCAT(personas_naturales.APELLIDO, ' ',personas_naturales.NOMBRE) AS NOMBRE,personas_naturales.NACIONALIDAD FROM personas_naturales WHERE((personas_naturales.CEDULA = '" 
							+ txtCedula.Text + @"'))";
						clsBD.EjecutarQuery(conn, strQuery, out ds, "Datos Personales");
						DataGridDatosPersonales.DataSource = ds;
						DataGridDatosPersonales.DataBind();
						DataGridDatosPersonales.Visible = true;
						#endregion
						//Query para retornar la información crediticia
						#region SqlQuery Detalles
						strQuery = @"SELECT casas_comerciales.NOMBRE AS CASA_COMERCIAL, "
							+ @"clientes.NOMBRE AS SUCURSAL, "
							+ @"CONCAT(DAYOFMONTH(creditos.FECHA_COMPRA),'/',MONTH(creditos.FECHA_COMPRA),'/',YEAR(creditos.FECHA_COMPRA)) AS FECHA_COMPRA, "
							+ @"CONCAT(DAYOFMONTH(creditos.FECHA_OPERACION),'/',MONTH(creditos.FECHA_OPERACION),'/',YEAR(creditos.FECHA_OPERACION)) AS FECHA_OPERACION, "
							+ @"creditos.MONTO, "
							+ @"creditos.PAGO_MES, "
							+ @"creditos.NUM_GIROS AS GIROS, "
							+ @"creditos.EXPERIENCIA AS EXP, "
							+ "IF(creditos.ESTADO=0,'Activo','Cancelado') AS ESTADO "
							+ @"FROM creditos "
							+ @"INNER JOIN clientes_personas ON (creditos.ID_CLIENTE_PERSONA = clientes_personas.ID_CLIENTE_PERSONA) "
							+ @"INNER JOIN personas_naturales ON (clientes_personas.ID_PERSONA = personas_naturales.CEDULA) "
							+ @"INNER JOIN clientes ON (clientes_personas.ID_CLIENTE = clientes.ID_CLIENTE) "
							+ @"LEFT OUTER JOIN casas_comerciales ON (clientes.ID_CASA_COMERCIAL = casas_comerciales.ID_CASA_COMERCIAL) "
							+ @"WHERE((clientes_personas.ID_PERSONA = '" + txtCedula.Text + @"'));";
						#endregion
						clsBD.EjecutarQuery(conn, strQuery, out ds, "Detalles");
						if (ds.Tables[0].Rows.Count > 0)
						{
							if (RegistrarConsultaOK(conn))
							{
								lblError.Text = "";
								DataGridDetalles.DataSource = ds;
								DataGridDetalles.DataBind();
								DataGridDetalles.Visible = true;
								lblCred.Visible = true;
								lblDP.Visible = true;
								btnDetalles.Enabled = false;
							}
							else
							{
								btnDetalles.Enabled = false;
								DataGridDetalles.Visible = false;
								DataGridDatosPersonales.Visible = false;
								lblCred.Visible = false;
								lblDP.Visible = false;
								//MensajeWeb.Info("Disculpe, el sistema no está disponible en este momento", Page, "Error2");
								lblErrorCliente.Text = "Disculpe, el sistema no está disponible en este momento, su consulta no ha sido procesada";
							}
						}
						else
						{
							DataGridDetalles.Visible = false;
							DataGridDatosPersonales.Visible = false;
							lblCred.Visible = false;
							lblDP.Visible = false;
							//btnDetalles.Enabled = false;
							//lblError.Text = "Disculpe la persona solicitada no esta registrada en nuestro sistema";
							RegistrarConsultasVacias(conn);
							MensajeWeb.Info("La persona solicitada no está registrada en el sistema", Page, "InfoNoExiste");
						}
					}
					catch
					{
						btnDetalles.Enabled = false;
						DataGridDetalles.Visible = false;
						DataGridDatosPersonales.Visible = false;
						lblCred.Visible = false;
						lblDP.Visible = false;
						if (UsrTelefonico == null)
							MensajeWeb.Info("El Usuario de Cedula " + txtCedulaCliente.Text + " no está registrado en el sistema", Page, "InfoNoExiste");
						else
							lblErrorCliente.Text = "Disculpe, el sistema no está disponible en este momento, su consulta no ha sido procesada";
						//MensajeWeb.Info("Disculpe, el sistema no está disponible en este momento", Page, "Error3");
					}
				}
				else
					lblErrorCliente.Text = "Cedula Inválida";
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
			#region SQLInsert
			string strSqlInsert = @"INSERT INTO consultas("
				+ @"CEDULA_USUARIO,"
				+ @"ID_CLIENTE,"
				+ @"ID_PERSONA,"
				+ @"FECHA_HORA) "
				+ @"VALUES(" + UsrTelefonico.Cedula + @","
				+ UsrTelefonico.IDCliente + @","
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
				+ @"VALUES(" + UsrTelefonico.Cedula + @","
				+ UsrTelefonico.IDCliente + @","
				+ @"'" + txtCedula.Text + @"',"
				+ @"'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"');";
			#endregion	
			if (clsBD.EjecutarNonQuery(cn, strSqlInsert) == 0)
				return false;
			else
				return true;
		}

	}
}
