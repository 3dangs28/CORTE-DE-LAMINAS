using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cortes_de_Lamina;

namespace Cortes_de_Lamina
{
    public partial class Comp_Lamina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Image1.ImageUrl = "Lamina.aspx?w=" + txtPliegoAncho.Text + "&h=" + txtPliegoAlto.Text + "&w1=" + txtCorteAncho.Text + "&h1=" + txtCorteAlto.Text;
            Image1.DataBind();
        }

        protected void txtCorteAncho_TextChanged(object sender, EventArgs e)
        {

        }
    }
}