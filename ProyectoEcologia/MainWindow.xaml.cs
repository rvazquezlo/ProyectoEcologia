using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoEcologia
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbUsuario.Focus();
        }

        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conexion;
            SqlCommand comando;
            SqlDataReader lector;

            try
            {
                conexion = Conexion.agregarConexion();
                comando = new SqlCommand(String.Format("select contrasena from Usuario where idUsuario = '{0}'",
                    tbUsuario.Text), conexion);
                lector = comando.ExecuteReader();
                if (lector.Read()) //hubo una contrasena para el usuario ingresado
                {
                    if (lector.GetString(0).Equals(pboxContrasena.Password.ToString()))
                    {

                    }
                }
            }catch(Exception ex)
            {

            }
            
        }
    }
}
