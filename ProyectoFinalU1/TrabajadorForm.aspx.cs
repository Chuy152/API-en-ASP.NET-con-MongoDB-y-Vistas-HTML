using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalU1;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Ajax.Utilities;

namespace ProyectoFinalU1
{
	public partial class TrabajadorForm : System.Web.UI.Page
	{

		private ConexionMongoDB db = new ConexionMongoDB();
		private string trabajadorId = "";

		//evento que se ejecuta al cargar la pagina
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack && Request.QueryString["id"]!=null)
			{

				trabajadorId = Request.QueryString["id"].Trim();
				if(ObjectId.TryParse(trabajadorId,out _))
				{
					ViewState["TrabajadorId"] = trabajadorId;
					CargarTrabajador(trabajadorId);
				}

			}
		}

		//carga los datos del cargador en los campos del formulario
		private void CargarTrabajador (string id)
		{
			Trabajador trabajador = db.ObtenerTrabajador(id);
			if (trabajador != null)
			{

				txtNombre.Text = trabajador.nombre;
				txtPuesto.Text = trabajador.puesto;
				ViewState["Pagos"] = trabajador.pagos;
				CargarPagosGrid();

			}
		}

		//carga la lista de pagos del trabajador en la interfaz
		private void CargarPagosGrid()
		{
			if (ViewState["Pagos"] != null)
			{
				List<PagoNomina> pagos = (List<PagoNomina>)ViewState["Pagos"];
				gridPagos.DataSource = pagos;
				gridPagos.DataBind();
			}
		}

		//guarda un nuevo trabajador o actualiza uno existente en la base de datos
		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			Trabajador trabajador = new Trabajador
			{
				nombre = txtNombre.Text,
				puesto = txtPuesto.Text,
				pagos = ViewState["Pagos"] != null ? (List<PagoNomina>)ViewState["Pagos"]:
				new List<PagoNomina>()
			};
			if (ViewState["TrabajadorId"] == null)
			{
				db.AgregarTrabajador(trabajador);
				ViewState["TrabajadorId"] = trabajador.Id;
			}
			else
			{
				trabajador.Id = ViewState["TrabajadorId"].ToString();
				db.ActualizarTrabajdor(trabajador.Id,trabajador);
			}
			Response.Redirect("Trabajadores.aspx");
		}

		//agrega un nuevo pago a la lista de pagos del trabajador actual
		protected void btnAgregarPago_Click(object sender, EventArgs e)
		{
			if (ViewState["Pagos"] == null)
				ViewState["Pagos"] = new List<PagoNomina>();

			List<PagoNomina> pagos = (List<PagoNomina>)ViewState["Pagos"];
			pagos.Add(new PagoNomina
			{
					fecha = Convert.ToDateTime(txtFechaPago.Text),
					monto = Convert.ToDecimal(txtMontoPago.Text)
			});

			ViewState["Pagos"] = pagos;
			CargarPagosGrid();
		}

		//regresa a la lista de trabajadores sin guardar cambios
		protected void btnVolver_Click(object sender, EventArgs e)
		{
			Response.Redirect("Trabajadores.aspx");
		}

    }
}