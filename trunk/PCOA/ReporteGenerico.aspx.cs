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
using System.Xml;
using GrupoEmporium.Datos;
using GrupoEmporium.Mensajes;
using Creditum.Usuarios;
using AODL.Document;
using AODL.Document.SpreadsheetDocuments;

namespace Creditum.PCOA
{
	/// <summary>
	/// Descripción breve de ReporteGenerico
	/// </summary>
	public class ReporteGenerico : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton imgbtnImprimir;
		protected System.Web.UI.WebControls.HyperLink lnkPC;
		protected System.Web.UI.WebControls.Label lblError;
		protected System.Web.UI.WebControls.Label lblTime;
		protected System.Web.UI.WebControls.Label LabelTitulo;
		protected System.Web.UI.WebControls.DataGrid DataGridDetalle;

		protected DataSet ds;
		protected DataTable dt;
		protected System.Web.UI.WebControls.LinkButton LinkExportar;
		protected DataView dv;
	
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
				}
				else
					Response.Redirect(@"../Home.aspx");
			}
			else
				Response.Redirect(@"../Home.aspx");
			imgbtnImprimir.Attributes.Add("OnClick", @"window.print();");
			if (!Page.IsPostBack)
			{
				dv = (DataView)Session["dvreporte"];
				//dt = dv.Table;
				LabelTitulo.Text = "Reporte " + Session["tabla"].ToString();

				DataGridDetalle.Visible = true;
				DataGridDetalle.Enabled = true;
				DataGridDetalle.DataSource = dv;
				DataGridDetalle.DataBind();

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
			this.LinkExportar.Click += new System.EventHandler(this.LinkExportar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void LinkExportar_Click(object sender, System.EventArgs e)
		{
			dv = (DataView)Session["dvreporte"];
			dt = dv.Table;


			SpreadsheetDocument hojacalculo = new SpreadsheetDocument();

			//XmlNode nodo = new XmlNode();
			DataSet ds = new DataSet();
			ds.Tables.Add(dt.Clone());
			ds.AcceptChanges();
			XmlDataDocument nodo = new XmlDataDocument(ds);

			AODL.Document.Content.Tables.Table tabla = new AODL.Document.Content.Tables.Table(hojacalculo,nodo.FirstChild);
			
			//int i = hojacalculo.TableCollection.Add(tabla);

			hojacalculo.Load("balance.ods");

			hojacalculo.SaveTo("prueba.ods");


		}

	}
}
