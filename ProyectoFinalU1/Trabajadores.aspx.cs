using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinalU1;
using System.Web.Caching;


namespace ProyectoFinalU1
{
	public partial class Trabajadores : System.Web.UI.Page
	{

        private ConexionMongoDB db = new ConexionMongoDB();

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack) CargarTrabajadores();
		}

        //evento que se ejecuta al cargar la pagina
        private void CargarTrabajadores()
        {
            var trabajadores = db.ObtenerTrabajadores();
            gridTrabajadores.DataSource = trabajadores;
            gridTrabajadores.DataBind();
        }

        //maneja los comandos de edicion y eliminacion en la tabla de trabajadores
        protected void gridTrabajadores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Editar")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gridTrabajadores.Rows[rowIndex];

                Label lblId = (Label)row.FindControl("lblId");
                string id=  lblId != null ? lblId.Text.Trim() : "";

                if (!string.IsNullOrEmpty(id) && id.Length == 24 && MongoDB.Bson.ObjectId.TryParse(id, out _))
                {
                    Response.Redirect($"TrabajadorForm.aspx?id={id}");
                }
                else System.Diagnostics.Debug.WriteLine("Error: ID no valida al seleccionar trabajador. ");
            }

            if (e.CommandName == "Eliminar")
            {
                string idTrabajador = e.CommandArgument.ToString();

                // Llamar a la función de eliminación en la base de datos
                db.EliminarTrabajador(idTrabajador);

                // Recargar la página para actualizar la lista
                Response.Redirect("Trabajadores.aspx");
            }
        }

                //redirige a la pagina para agregar un nuevo trabajador
                protected void btnAgregar_Click(object sender, EventArgs e)
                {
                    Response.Redirect("TrabajadorForm.aspx");
                }

                //maneja la eleccion de un trabajador en la tabla
                protected void gridTrabajadores_SelectedIndexChange(object sender, EventArgs e)
                {
                    string id = gridTrabajadores.SelectedRow.Cells[0].Text;
                    Response.Redirect($"TrabajadorForm.aspx?id={id}");
                    if(!string.IsNullOrEmpty(id) && id.Length == 24)
                    {
                        Response.Redirect($"TrabajadorForm.aspx?id={id}");
                    }
                }




    }
}










//if (e.CommandName == "Eliminar")
//    {
//        int rowIndex = Convert.ToInt32(e.CommandArgument);
//GridViewRow row = gridTrabajadores.Rows[rowIndex];
//
//Label lblId = (Label)row.FindControl("lblId");
//string id = lblId != null ? lblId.Text.Trim() : "";
//
//        if (!string.IsNullOrEmpty(id) && id.Length == 24 && MongoDB.Bson.ObjectId.TryParse(id, out _))
//        {
//            db.EliminarTrabajador(id);
//            CargarTrabajadores();
//
//}
//        else System.Diagnostics.Debug.WriteLine("Error: ID no valida al seleccionar trabajador. ");
//    }