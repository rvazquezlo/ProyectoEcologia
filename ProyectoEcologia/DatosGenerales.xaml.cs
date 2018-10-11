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
            Cliente cliente;
            Producto producto;
            int numeroUsuarios, productosEspera, productosVendidos;

            try
            {
                cliente = new Cliente();
                producto = new Producto();
                numeroUsuarios = cliente.obtenerNumeroClientes();
                productosEspera = producto.contarProductosEnEspera();
                productosVendidos = producto.contarProductosVendidos();

                if ((numeroUsuarios + productosEspera + productosVendidos) >= 0)//no hubo error en ninguno
                {
                    lbNumeroUsuarios2.Content = numeroUsuarios.ToString();
                    lbProductosEnEspera2.Content = productosEspera.ToString();
                    lbProductosVendidos2.Content = lbProductosVendidos2.ToString();
                }
                else
                    MessageBox.Show("Error en las cuentas");//Quitar
                
            }catch(Exception ex)//No se produce ningun error
            {
                MessageBox.Show("error: " + ex);
            }
        }
    }
}
