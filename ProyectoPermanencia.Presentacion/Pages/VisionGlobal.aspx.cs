using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace ProyectoPermanencia.Presentacion
{
    public partial class VisionGlobal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            try
            {
                if (!IsPostBack)
                {
                    CargarGrilla();
                }
                else
                {
                    //lblMensaje.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "Ocurrio un error inesperado favor contactese con el administrado";
            }*/
        }

       

        private void CargarGrilla()
        {
            //var objetoNegocio = new Negocio();
            //grvGlobal.DataSource = objetoNegocio.consultaScore();
            //grvGlobal.DataBind();
        }

        protected void btoFiltrar_Click(object sender, EventArgs e)
        {
           
        }

        protected void grvGlobal_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.grvGlobal.SelectedRow;

            String auxRut = row.Cells[1].Text;

            Response.Redirect("WebConsultaScoreAlumno.aspx?auxRut = " + auxRut);
        }

        protected void btoFiltrarPorRut_Click(object sender, EventArgs e)
        {
            ProyectoPermanencia.Negocio.Negocio auxNegocio = new ProyectoPermanencia.Negocio.Negocio();

            //this.GridViewScore.DataMember =
            this.grvGlobal.DataSource = auxNegocio.consultaScore(this.txtRut.Text, this.ddlJornada.ToString());
            this.grvGlobal.DataBind();
        }

        protected void ddlJornada_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlJornada.SelectedValue.ToString();
        }
    }
}