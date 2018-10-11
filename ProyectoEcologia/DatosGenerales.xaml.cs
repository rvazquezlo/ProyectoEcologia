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
                numeroUsuarios = cliente.obtenerNumeroClientes();//obtener numero de usuarios a partir de un metodo en la clase Cliente
                productosEspera = producto.contarProductosEnEspera();//obtener numero de productos en espera de aprobacion a partir de un metodo en la clase Producto
                productosVendidos = producto.contarProductosVendidos();//obtener numero de productos vendidos a partir de un metodo en la clase Producto

                //Se utilizan tres condiciones, ya que seria incorrecto evaluar una suma de los resultados
                if (numeroUsuarios >= 0 &&  productosEspera >= 0 && productosVendidos >= 0)//no hubo error en ninguno, ya que cuando lo hay, cada metodo regresa -1
                {
                    //Poner la informacion en sus espacios designados en la ventana DatosGenerales
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
