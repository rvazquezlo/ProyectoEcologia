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
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar()
        {
            InitializeComponent();
        }

        /**
         * A partir de los datos ingresados por el usuario, se agrega una nueva tupla a la entidad Informacion en la bd
         */
        private void btModificar_Click(object sender, RoutedEventArgs e)
        {
            Informacion info;

            try
            {
                info = new Informacion();
                if (info.agregarInformacion(tbLink.Text, tbDatosBasura.Text) == 1)//se agrego a la bd
                    MessageBox.Show("Informacion agregada correctamente");
                else
                    MessageBox.Show("Error: No se agrego informacion"); //quitar
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex); //quitar
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
    }
}
