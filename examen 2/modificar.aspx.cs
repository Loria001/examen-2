using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examen_2
{
    public partial class modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Buscar(string Description)
        {
            string numenc = txtNumenc.Text.Trim();

            string connectionString = "Data Source=DESKTOP-HP56UOF\\SQLEXPRESS02;Initial Catalog=Examen2;Integrated Security=True";
            string query = "SELECT * FROM encuesta WHERE numenc = @numenc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numenc", numenc);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            Tnombre1Existente.Text = reader["nombre"].ToString();
                            TapellidoExistente.Text = reader["apellidos"].ToString();
                            TfechaExistente.Text = reader["fechanaci"].ToString();
                            TedadExistente.Text = reader["edad"].ToString();
                            TcorreoExistente.Text = reader["correo"].ToString();
                            RadioButtonListCarroPropioExistente.SelectedValue = reader["carro"].ToString();

                            pnlModificar.Visible = true;
                        }
                    }
                    else
                    {
                        pnlModificar.Visible = false;

                        lblMensajeError.Text = "No se encontró ningún registro con ese numero de encuesta.";
                    }
                }
            }
        }



        private void Actualizar(string Description)
        {
            string numenc = txtNumenc.Text.Trim();

            string nombre = Tnombre1.Text.Trim();
            string apellidos = Tapellido.Text.Trim();
            string fechaNacimientoStr = Tfecha.Text.Trim();
            string edadStr = Tedad.Text.Trim();
            string correo = Tcorreo.Text.Trim();
            string carroPropio = RadioButtonListCarroPropio.SelectedValue;

            DateTime fechaNacimiento;
            if (!DateTime.TryParse(fechaNacimientoStr, out fechaNacimiento))
            {
                lblMensajeError.Text = "El formato de la fecha de nacimiento es inválido.";
                return;
            }

            int edad;
            if (!int.TryParse(edadStr, out edad))
            {
                lblMensajeError.Text = "La edad debe ser un número entero.";
                return;
            }

            if (edad < 18 || edad > 50)
            {
                lblMensajeError.Text = "La edad debe estar entre 18 y 50 años.";
                return;
            }

            string connectionString = "Data Source=DESKTOP-HP56UOF\\SQLEXPRESS02;Initial Catalog=Examen2;Integrated Security=True";
            string query = "UPDATE encuesta SET nombre = @nombre, apellidos = @apellidos, fechanaci = @fechaNacimiento, edad = @edad, correo = @correo, carro = @carro WHERE numenc = @numenc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@edad", edad);
                    command.Parameters.AddWithValue("@correo", correo);
                    command.Parameters.AddWithValue("@carro", carroPropio);
                    command.Parameters.AddWithValue("@numenc", numenc);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensajeError.Text = "Datos actualizados correctamente.";

                        pnlModificar.Visible = false;

                        txtNumenc.Text = "";
                    }
                    else
                    {
                        lblMensajeError.Text = "No se pudo actualizar el registro con el numenc especificado.";
                    }
                }
            }
        }





        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar(btnActualizar.Text);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar(btnBuscar.Text);
        }
    }
}