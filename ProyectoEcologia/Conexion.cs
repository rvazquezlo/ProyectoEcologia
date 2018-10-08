using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
