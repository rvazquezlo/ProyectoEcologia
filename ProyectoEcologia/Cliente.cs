using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoEcologia
{
    class Cliente
    {
        private String nombre;

        /**
         * Constructor vacio
         */
        public Cliente()
        {

        }

        /**
         * Constructor con el atributo nombre
         */
        public Cliente(String nombre)
        {
            this.nombre = nombre;
        }

        /**
         * @return: nombre
         */
        public String getNombre()
        {
            return nombre;
        }

        /**
         * Cuenta el numero de clientes que hay dados de alta en la bd
         * @return: El numero de clientes dados de alta en la bd, -1 si hubo error
         */
        public int obtenerNumeroClientes()
        {
            SqlConnection conexion;
            SqlDataReader lector;
            SqlCommand comando;
            int numeroUsuarios;

            conexion = Conexion.agregarConexion();
            try
            {
                comando = new SqlCommand(String.Format("select count(Cliente.nombre) from Cliente"), conexion);
                lector = comando.ExecuteReader();
                numeroUsuarios = int.Parse(lector.GetString(0));
            }catch(Exception e)
            {
                MessageBox.Show("error: " + e);
                numeroUsuarios = -1;
            }
            conexion.Close();
            return numeroUsuarios;
        }
    }
}
