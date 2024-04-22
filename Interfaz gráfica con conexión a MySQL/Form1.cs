using Formulario_simple.DataAccess;
using System;
using System.Windows.Forms;

namespace Formulario_simple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion dataAccess = new Conexion();

            string servidor = txtServidor.Text;
            string bd = txtBd.Text;
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            string cadena = $"Server={servidor}; Database={bd}; Uid={usuario}; Pwd={contrasena};";

            if (dataAccess.IntentoConexion(cadena))
            {
                dgvDatos.DataSource = dataAccess.ObtenerDatos(cadena);
            }
            else
            {
                MessageBox.Show("No se puede establecer la conexion");
            }
        }
    }
}
