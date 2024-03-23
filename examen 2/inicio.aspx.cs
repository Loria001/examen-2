using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace examen_2
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            agregar(Bagregar.Text);
        }

        private void agregar(string Description)
        {
            string nombre = Tnombre1.Text.Trim();
            string apellidos = Tapellido.Text.Trim();
            string fechaNacimientoStr = Tfecha.Text.Trim();
            string edadStr = Tedad.Text.Trim();
            string correo = Tcorreo.Text.Trim();
            string carroPropio = RadioButtonListCarroPropio.SelectedValue;

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(fechaNacimientoStr) ||
                string.IsNullOrEmpty(edadStr) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(carroPropio))
            {
                lblMensajeError.Text = "Todos los campos son obligatorios.";
                return;
            }

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

            string query = "INSERT INTO encuesta (nombre, apellidos, fechanaci, edad, correo, carro) VALUES (@nombre, @apellidos, @fechaNacimiento, @edad, @correo, @carro)";

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

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        lblMensajeExito.Text = "Datos insertados correctamente en la tabla encuesta.";
                        Tnombre1.Text = "";
                        Tapellido.Text = "";
                        Tfecha.Text = "";
                        Tedad.Text = "";
                        Tcorreo.Text = "";
                        RadioButtonListCarroPropio.ClearSelection();
                    }
                    else
                    {
                        lblMensajeError.Text = "Error al insertar datos en la tabla encuesta.";
                    }
                }
            }
        }





        protected void Llenargrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();  
                using (SqlCommand command = new SqlCommand("SELECT * FROM bodega"))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                            adapter.Fill(dataTable);
                            GridView1.DataSource = dataTable;
                            GridView1.DataBind();
                        }
                    }
                }

            catch (Exception ex) 
            {
                string errorMessage = "Error al ingresar datos: " + ex.Message;
                string script = "<script>alert('" + errorMessage + "');</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(),"ErrorAlert",script);
            }
            finally 
            {
             
                if(connection != null && connection.State != ConnectionState.Closed) 
                {
                    connection.Close();
                }
            }
        }
    }
}


