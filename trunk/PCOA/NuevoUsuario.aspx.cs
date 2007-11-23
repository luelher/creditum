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
using Creditum.Usuarios;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de NuevoUsuario.
	/// </summary>
	public class NuevoUsuario : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.HyperLink lnkMySql;
		protected System.Web.UI.WebControls.HyperLink lnkASP;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label lblUser;
		protected System.Web.UI.WebControls.HyperLink lnkNuevoCliente;
		protected System.Web.UI.WebControls.HyperLink lnkModificarCliente;
		protected System.Web.UI.WebControls.HyperLink lnkEliminarCliente;
		protected System.Web.UI.WebControls.HyperLink lnkNuevoUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkModificarUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkEliminarUsuario;
		protected System.Web.UI.WebControls.HyperLink lnkInfoCredito;
		protected System.Web.UI.WebControls.HyperLink lnkConsultasTelefonicas;
		protected System.Web.UI.WebControls.HyperLink lnkHome;
		protected System.Web.UI.WebControls.HyperLink lnkWho;
		protected System.Web.UI.WebControls.HyperLink lnkServ;
		protected System.Web.UI.WebControls.HyperLink lnkContactanos;
		protected System.Web.UI.WebControls.HyperLink lnkLinks;
		protected System.Web.UI.WebControls.DropDownList DropDownListCasa;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblCedula;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.ValidationSummary ValidationSummaryHome;
		protected System.Web.UI.WebControls.TextBox txtCedula;
		protected System.Web.UI.WebControls.RangeValidator RangeValidatorCI;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidatorCI;
		protected System.Web.UI.WebControls.Label lblNac;
		protected System.Web.UI.WebControls.DropDownList DropDownNacionalidad;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorNombre;
		protected System.Web.UI.WebControls.Label lblApellido;
		protected System.Web.UI.WebControls.TextBox txtApellido;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredfieldvalidatorApellido;
		protected System.Web.UI.WebControls.Label lblTelf;
		protected System.Web.UI.WebControls.TextBox txtTelef;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCelular;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList DropDownListNivel;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtPWD;
		protected System.Web.UI.WebControls.Button btnInsertar;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorTelf;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidatorCel;
		protected System.Web.UI.WebControls.Label lblInfo;
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
					lblUser.Text = "Usuario: " + usr.Nombre + " " + usr.Apellido;
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");

			if (!Page.IsPostBack) 
			{
				CargarClientes();
				DropDownListCasa_SelectedIndexChanged(sender, e);
			}
			#region Confirmaciones
			MensajeWeb.ConfirmacionMensajeCustom(
				new string[]{
								@"'Está seguro que desea agregar el usuario: '"
								+ @"+ txtNombre.value + ' ' + txtApellido.value + ', CI: ' + txtCedula.value + '?'"
							},
				Page,
				new string[]{"miBoton"},
				new string[]{"Insertar"},
				"ConfirmarInsertar");
			btnInsertar.Attributes.Add("OnClick", "miBoton=this.value; ");
			DropDownListCasa.Attributes.Add("OnChange", "miBoton=this.value; ");
			#endregion
		}


		private bool CargarClientes()
		{
			DataSet ds = new DataSet();
			try
			{
				#region CargarConfig
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				#region Consulta
				string strSQLQuery =
					@"SELECT clientes_conf.ID_CLIENTE,"
					+ @"CONCAT_WS('-',casas_comerciales.NOMBRE,clientes.NOMBRE) AS CLIENTE "
					+ "FROM casas_comerciales "
					+ @"RIGHT OUTER JOIN clientes ON (casas_comerciales.ID_CASA_COMERCIAL = clientes.ID_CASA_COMERCIAL) "
					+ @"INNER JOIN clientes_conf ON (clientes.ID_CLIENTE = clientes_conf.ID_CLIENTE) ";
				#endregion
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Clientes"))
				{
					for (int i=0;i<ds.Tables["Clientes"].Rows.Count;i++)
					{
						ListItem lstItm = new ListItem(ds.Tables["Clientes"].Rows[i].ItemArray[1].ToString(), ds.Tables["Clientes"].Rows[i].ItemArray[0].ToString()); 
						DropDownListCasa.Items.Add(lstItm);						
					}
					return true;
				}
				else
				{
					lblError.Text = "Disculpe, el servicio no está disponible en este momento";
					//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error1");
					return false;
				}
			}
			catch
			{				
				lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error2");
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
			this.DropDownListCasa.SelectedIndexChanged += new System.EventHandler(this.DropDownListCasa_SelectedIndexChanged);
			this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnInsertar_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{	
				lblInfo.Text = "";
				lblError.Text = "";
				DataSet ds = new DataSet();
				try
				{
					#region CargarConfig
					ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
					clsBDConexion conn = MetodosComunes.Conectar(out ds);
					#endregion
					#region SqlInsert
					string strInsert = 
						@"INSERT INTO usuarios(CEDULA,ID_CLIENTE,PWD,NOMBRE,APELLIDO,TELEFONO,CELULAR,NACIONALIDAD,ID_NIVEL,FECHA) "
						+ @"VALUES("
						+ txtCedula.Text + ","
						+ DropDownListCasa.SelectedValue + ","
						+ @"PASSWORD('" + txtPWD.Text + @"'),"
						+ "'" + txtNombre.Text + "',"
						+ "'" + txtApellido.Text + "',"
						+ "'" + txtTelef.Text + "',"
						+ "'" + txtCelular.Text + "',"
						+ "'" + DropDownNacionalidad.SelectedValue + "',"
						+ DropDownListNivel.SelectedValue + ","
						+ "'" + DateTime.Now.ToString("yyyy-MM-dd") + "'"
						+ @");";
					#endregion
					if (clsBD.EjecutarNonQuery(conn, strInsert) == -1)
						lblError.Text = "No se pudo agregar el nuevo usuario, verifique si éste ya existe";
						//MensajeWeb.Info("No se pudo agregar el nuevo usuario, verifique si éste ya existe", Page, "InfoYaExiste1");
					else
					{
						lblError.Text = "";
						lblInfo.Text = "El usuario ha sido registrado satisfactoriamente";
						txtCedula.Text = "";
						txtNombre.Text = "";
						txtApellido.Text = "";
						txtTelef.Text = "";
						txtCelular.Text = "";
						//MensajeWeb.Info("El usuario ha sido registrado satisfactoriamente, gracias por utilizar CREDITUM", Page, "InfoOK1");

					}
				}
				catch
				{
					//MensajeWeb.Info("No se pudo agregar el nuevo usuario, el sistema no esta disponible en estos momentos", Page, "InfoError5");
					lblError.Text = "No se pudo agregar el nuevo usuario, el sistema no esta disponible en estos momentos";
					lblInfo.Text = "";
				}
			}
		}

		private void DropDownListCasa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DataSet ds = new DataSet();
			DropDownListNivel.Items.Clear();
			try
			{
				#region CargarConfig
				ds.ReadXml(@"c:\Config.xml", XmlReadMode.ReadSchema);
				clsBDConexion conn = MetodosComunes.Conectar(out ds);
				#endregion
				
				string strSQLQuery;
				strSQLQuery = @"SELECT ID_CLIENTE FROM empresa_conf;";
				if (clsBD.EjecutarQuery(conn,strSQLQuery, out ds, "Empresa"))
				{	
					#region Validar si el cliente es la empresa
					if (ds.Tables["Empresa"].Rows[0].ItemArray[0].ToString() == DropDownListCasa.SelectedValue.ToString())
					{
						ListItem lstItm = new ListItem("OPERADOR ADMINISTRADOR", "1"); 
						DropDownListNivel.Items.Add(lstItm);
						lstItm = new ListItem("OPERADOR", "2"); 
						DropDownListNivel.Items.Add(lstItm);						
					}
					else
					{
						ListItem lstItm = new ListItem("CONSULTOR ADMINISTRADOR", "4"); 
						DropDownListNivel.Items.Add(lstItm);
						lstItm = new ListItem("CONSULTOR", "3"); 
						DropDownListNivel.Items.Add(lstItm);
					}
					#endregion
				}
				else
					lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error3");
			}
			catch
			{
				lblError.Text = "Disculpe, el servicio no está disponible en este momento";
				//MensajeWeb.Info("Disculpe, el servicio no está disponible en estos momentos", Page, "Error4");
			}
		}
	}
}
