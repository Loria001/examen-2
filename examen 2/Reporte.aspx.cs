using System;

namespace examen_2
{
    public partial class Reporte : System.Web.UI.Page
    {
        public int EncuestasRealizadas { get; set; }
        public int PersonasConCarro { get; set; }
        public int PersonasSinCarro { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            EncuestasRealizadas = int.Parse(Request.QueryString["encuestas"] ?? "0");
            PersonasConCarro = int.Parse(Request.QueryString["carro"] ?? "0");
            PersonasSinCarro = int.Parse(Request.QueryString["sinCarro"] ?? "0");
        }
    }
}
