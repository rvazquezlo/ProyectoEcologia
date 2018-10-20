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
         * Constructor vacio. Asigna un String vacio al atributo nombre
         */
        public Cliente()
        {
            nombre = "";
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

            numeroUsuarios = -1;//se asigna un numero irreal para alertar de error
            conexion = Conexion.agregarConexion();//abrir conexion
            try
            {
                comando = new SqlCommand(String.Format("select count(Cliente.nombre) from Cliente"), conexion);//query
                lector = comando.ExecuteReader();//ejecutar
                if (lector.Read())
                    numeroUsuarios = lector.GetInt32(0);
                //obtener informacion de la consulta de sql
                lector.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("error: " + e);
            }
            conexion.Close();
            return numeroUsuarios;
        }
    }
}
