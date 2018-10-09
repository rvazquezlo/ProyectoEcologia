using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoEcologia
{
    class Producto
    {
        private String estado;
        private String categoria;
        private double precio;
        private String nombre;
        private String descripcion;

        /**
         * Constructor vacio
         */
        public Producto()
        {

        }

        /**
         * 
         */
        public Producto(String estado, String categoria, double precio, String nombre, String descripcion)
        {
            this.estado = estado;
            this.categoria = categoria;
            this.precio = precio;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
        
        /**
         * 
         */
        public Producto(double precio, String nombre, String descripcion)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.descripcion = descripcion;
        }

        public String getNombre()
        {
            return nombre;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public double getPrecio()
        {
            return precio;
        }

        /**
         * Regresa el siguiente producto en la bd que este en estado de espera
         */
        public Producto obtenerSiguiente()
        {
            SqlConnection conexion = Conexion.agregarConexion();
            SqlCommand comando;
            SqlDataReader lector;
            Producto siguiente;

            siguiente = null;
            try
            {
                comando = new SqlCommand(String.Format(
                    "select top 1 precio, nombre, descripcion from Producto where estado like '%espera%'"),
                    conexion);//queda pendiente foto
                lector = comando.ExecuteReader();
                if (lector.Read())
                    siguiente = new Producto(lector.GetDouble(0), lector.GetString(1), lector.GetString(2));
            }catch(Exception e)
            {
                MessageBox.Show("Error en clase Producto: " + e);//Quitar despues de prueba    
            }
            conexion.Close();
            return siguiente;
        }

        public int actualizarEstado()
        {
            int actualizado;
            SqlCommand comando;
            SqlConnection conexion;
            SqlDataReader lector;

            try
            {

            }catch
            {

            }

            return actualizado;
        } 
    }
}
