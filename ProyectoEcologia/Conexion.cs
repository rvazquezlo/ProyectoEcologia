using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoEcologia
{
    class Conexion
    {
        /**
         * Metodo que se utiliza para abir conexion con sql
         */
        public static SqlConnection agregarConexion()
        {
            SqlConnection conexion;

            try
            {
                conexion = new SqlConnection("Data Source=112SALAS04;Initial Catalog=NatureYou;Persist Security Info=True;User ID=sa;Password=sqladmin");//cambiar dependiendo de la maquina que se utilice
                conexion.Open();
            }
            catch (Exception e)
            {
                conexion = null;
                MessageBox.Show("no conectado" + e);//Quitar despues de pruebas
            }
            return conexion;
        }

        /**
         * Llena el combo box de las categorias
         */
        public void llenarCombo(ComboBox cb)
        {
            SqlCommand comando;
            SqlDataReader lector;
            SqlConnection conexion;

            conexion = Conexion.agregarConexion();
            try
            {
                comando = new SqlCommand(String.Format("select nombre from Categoria"), conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                    cb.Items.Add(lector["nombre"].ToString());//Lo que esta en columna nombre se mete al combo
                cb.SelectedIndex = 0; //El combo empieza mostrando el primer elemento
                lector.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error. No se pudo llenar el combo " + e);//Quitar
            }
            conexion.Close();//se cierra conexion por seguridad
        }

    }
}
