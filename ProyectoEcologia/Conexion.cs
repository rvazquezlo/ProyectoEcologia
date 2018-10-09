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
        public static SqlConnection agregarConexion()
        {
            SqlConnection conexion;

            try
            {
                conexion = new SqlConnection("Copy paste la direccion de base de datos");
                conexion.Open();
                MessageBox.Show("Conectado");//Quitar despues de pruebas
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

            try
            {
                conexion = Conexion.agregarConexion();
                comando = new SqlCommand(String.Format("select nombre from Categoria"), conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    cb.Items.Add(lector["nombre"].ToString());//Lo que esta en columna nombre se mete al combo
                }
                cb.SelectedIndex = 0; //El combo empieza mostrando el primer elemento
                lector.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error. No se pudo llenar el combo " + e);//Quitar
            }
        }

    }
}
