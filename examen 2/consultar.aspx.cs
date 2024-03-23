using System;
using System.Data.SqlClient;

namespace examen_2
{
    public partial class consultar : System.Web.UI.Page
    {

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            int encuestasRealizadas = 0;
            int personasConCarro = 0;
            int personasSinCarro = 0;

            string connectionString = "Data Source=DESKTOP-HP56UOF\\SQLEXPRESS02;Initial Catalog=Examen2;Integrated Security=True";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryEncuestas = "SELECT COUNT(*) FROM encuesta";
                    SqlCommand commandEncuestas = new SqlCommand(queryEncuestas, connection);

                    string queryConCarro = "SELECT COUNT(*) FROM encuesta WHERE carro = 'Si'";
                    SqlCommand commandConCarro = new SqlCommand(queryConCarro, connection);

                    string querySinCarro = "SELECT COUNT(*) FROM encuesta WHERE carro = 'No'";
                    SqlCommand commandSinCarro = new SqlCommand(querySinCarro, connection);

                    connection.Open();

                    encuestasRealizadas = (int)commandEncuestas.ExecuteScalar();
                    personasConCarro = (int)commandConCarro.ExecuteScalar();
                    personasSinCarro = (int)commandSinCarro.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al generar el reporte: " + ex.Message;
                return;
            }

            string urlReporte = $"Reporte.aspx?encuestas={encuestasRealizadas}&carro={personasConCarro}&sinCarro={personasSinCarro}";

            ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", $"<script>window.open('{urlReporte}','_blank');</script>");
        }


    }
}
