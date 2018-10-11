using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProyectoEcologia
{
    /// <summary>
    /// Lógica de interacción para DatosGenerales.xaml
    /// </summary>
    public partial class DatosGenerales : Window
    {
        public DatosGenerales()
        {
            InitializeComponent();
        }

        /**
         * Regresa a ventana de Home y cierra esta 
        */
        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            Home ventana = new Home();
            this.Close();
            ventana.Show();
        }

        /**
         * En cuanto se cargue la ventana se muestra toda la informacion utilizando las clases Cliente y Producto
        */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
