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
         * Metodo para obtener el siguiente producto en espera y poner su informacion en la ventana.
         * Si no hay productos en espera, se regresa a ventana de Home
         */
        private void obtenerSiguiente()
        {
            Producto producto;

            producto = new Producto();
            producto = producto.obtenerSiguiente();//Obtiene el siguiente producto
            if (producto == null)//No hubo producto en espera. Entonces regresa a ventana Home
            {
                MessageBox.Show("Por el momento no hay productos por aprobar en espera");
                Home ventana = new Home();
                this.Close();
                ventana.Show();
            }
            else//Si hubo producto
            {
                //Agregar informacion a lugares respectivos
                lbNombre2.Content = producto.getNombre();
                lbDescripcion2.Content = producto.getDescripcion();
                lbPrecio2.Content = "$" + producto.getPrecio().ToString();
                lbNumeroProducto2.Content = producto.getIdProducto().ToString();
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
         * Si no hay productos y se presiona este boton, se muestra un mensaje y se regresa a la ventana Home.
         * @uses obtenerSiguiente();
         */
        private void btSiguiente_Click(object sender, RoutedEventArgs e)
        {
            Producto producto;
            int estado;

            try
            {
                //actualizar
                producto = new Producto(Int16.Parse(lbNumeroProducto2.ContentStringFormat));
                if (rbAprobar.IsChecked == true)
                    estado = 0;
                else
                    estado = 1;
                producto.actualizarEstado(estado);

                //Obtener siguiente producto
                obtenerSiguiente();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex);    
            }

            

        }

        /**
         * Regresa a la ventana de Home 
         */

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            Home ventana = new Home();
            this.Close();
            ventana.Show();
        }
    }
}
