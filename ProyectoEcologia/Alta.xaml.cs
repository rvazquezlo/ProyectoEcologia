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
    /// Lógica de interacción para Alta.xaml
    /// </summary>
    public partial class Alta : Window
    {
        public Alta()
        {
            InitializeComponent();
        }

        /**
         * Metodo para obtener el siguiente producto en espera
         */
        private void obtenerSiguiente()
        {
            Producto producto;

            producto = new Producto();
            producto = producto.obtenerSiguiente();
            if (producto == null)
                MessageBox.Show("Por el momento no hay productos por aprobar en espera");
            else
            {
                lbNombre2.Content = producto.getNombre();
                lbDescripcion2.Content = producto.getDescripcion();
                lbPrecio2.Content = "$" + producto.getPrecio().ToString();
            }
        }

        /** 
         * En cuanto se carga la ventana, aparece la informacion del primer producto a aprobar.
         * Ademas, aparece el radio button de Aprobar seleccionado por default.
         */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            obtenerSiguiente();
            rbAprobar.IsChecked = true;
        }

        /**
         * Se llama al metodo obtenerSiguiente y se actualiza el estado del producto en la bd. 
         */
        private void btSiguiente_Click(object sender, RoutedEventArgs e)
        {
            //Actualizar
        }
    }
}
