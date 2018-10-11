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
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        /**
         * Dependiendo de la opcion seleccionada, se abre la ventana correspondiente 
         */
        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            if(rbAprobar.IsChecked == true)
            {
                Alta ventana = new Alta();
                this.Hide();
                ventana.Show();
            }
            else if(rbInfoGeneral.IsChecked == true)
            {
                DatosGenerales ventana = new DatosGenerales();
                this.Hide();
                ventana.Show();
            }
            else if(rbModificarInfo.IsChecked == true)
            {
                Modificar ventana = new Modificar();
                this.Hide();
                ventana.Show();
            }
            else if (rbBuscarProductos.IsChecked == true)
            {
                Buscar ventana = new Buscar();
                this.Hide();
                ventana.Show();
            }
            //no se usa else simple porque si no se selecciona ninguna opcion, se queda en la misma ventana
            else if (rbSalir.IsChecked == true) 
            {
                MainWindow ventana = new MainWindow();
                this.Close();
                ventana.Show();//Manda de regreso a ventana de Inicio de sesion
            }

        }
    }
}
