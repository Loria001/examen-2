using System;
using System.Data.SqlClient;

namespace examen_2
{
    public partial class consultar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNumenc.Text.Trim() == "")
            {
                lblMensajeError.Text = "Por favor, ingresa un numero de encuesta válido.";
                return;
            }

            int numenc;
            if (!int.TryParse(txtNumenc.Text.Trim(), out numenc))
            {
                lblMensajeError.Text = "El valor de numero de encuesta no es válido.";
                return;
            }

            // Verificar si el registro existe antes de borrarlo
            if (RegistroExiste(numenc))
            {
                // Mostrar mensaje de registro encontrado
                lblMensajeError.Text = "Registro encontrado.";
                btnConfirmarBorrar.Visible = true; // Mostrar el botón de confirmación de borrado
            }
            else
            {
                // Mostrar mensaje de registro no encontrado
                lblMensajeError.Text = "No se encontró ningún registro con el numero de encusta especificado.";
            }
        }

        protected void btnBorrarRegistro_Click(object sender, EventArgs e)
        {
            // No se requiere lógica aquí, la lógica está en btnBuscar_Click
        }

        protected void btnConfirmarBorrar_Click(object sender, EventArgs e)
        {
            if (txtNumenc.Text.Trim() == "")
            {
                lblMensajeError.Text = "Por favor, ingresa un numero de encuesta válido.";
                return;
            }

            int numenc;
            if (!int.TryParse(txtNumenc.Text.Trim(), out numenc))
            {
                lblMensajeError.Text = "El valor de numero de encuesta no es válido.";
                return;
            }

            // Borrar el registro de la base de datos
            if (BorrarRegistro(numenc))
            {
                // Borrado exitoso
                lblMensajeError.Text = "Registro borrado correctamente.";
                txtNumenc.Text = ""; // Limpiar txtNumenc
                btnConfirmarBorrar.Visible = false; // Ocultar el botón de confirmación de borrado
            }
            else
            {
                // Error al borrar el registro
                lblMensajeError.Text = "Error al borrar el registro. Inténtalo de nuevo.";
            }
        }


        // Método para verificar si un registro existe en la base de datos
        private bool RegistroExiste(int numenc)
        {
            string connectionString = "Data Source=DESKTOP-HP56UOF\\SQLEXPRESS02;Initial Catalog=Examen2;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM encuesta WHERE numenc = @numenc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numenc", numenc);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Método para borrar un registro de la base de datos
        private bool BorrarRegistro(int numenc)
        {
            string connectionString = "Data Source=DESKTOP-HP56UOF\\SQLEXPRESS02;Initial Catalog=Examen2;Integrated Security=True";
            string query = "DELETE FROM encuesta WHERE numenc = @numenc";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@numenc", numenc);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
