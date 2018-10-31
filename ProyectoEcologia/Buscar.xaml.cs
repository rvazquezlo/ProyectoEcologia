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
    /// Lógica de interacción para Buscar.xaml
    /// </summary>
    public partial class Buscar : Window
    {
        public Buscar()
        {
            InitializeComponent();
        }

        /**
         * Se llena combo box de categorias en cuanto la ventana se carga 
         */
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Conexion.llenarCombo(cbCategorias);//metodo en conexion que llena combo
            }
            catch(Exception ex)//no necesario
            {
                MessageBox.Show("error: " + ex);
            }
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
         * Al dar click en buscar se muestran todos los productos de dicha categoria
         */
        private void btBuscar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto;

            try
            {
                producto = new Producto();
                dgProductos.ItemsSource = producto.buscarProductoPorCategoria(cbCategorias.SelectedIndex + 1);//carga lista de productos
            }
            catch(Exception ex)
            {
                MessageBox.Show("error: " + ex);
            }
        }
    }
}
