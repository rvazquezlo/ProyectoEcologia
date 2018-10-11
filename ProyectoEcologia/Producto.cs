﻿using System;
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
        private Int16 idProducto;

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
        public Producto(double precio, String nombre, String descripcion, Int16 idProducto)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.idProducto = idProducto;
        }

        public Producto(Int16 idProducto)
        {
            this.idProducto = idProducto;
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
                    "select top 1 precio, nombre, descripcion, idProducto from Producto where estado like '%espera%'"),
                    conexion);//queda pendiente foto
                lector = comando.ExecuteReader();
                if (lector.Read())
                    siguiente = new Producto(lector.GetDouble(0), lector.GetString(1), lector.GetString(2), lector.GetInt16(3));
            }catch(Exception e)
            {
                MessageBox.Show("Error en clase Producto: " + e);//Quitar despues de prueba    
            }
            conexion.Close();
            return siguiente;
        }

        /** Baja y modificacion
         * @param estado: 0 si se aprobo un producto, 1 si no se aprobo
         * Si no se aprobo, es necesario dar de baja el producto de la bd.
         * Si se aprobo, se cambia el estado del producto a "en venta"
         * @return: 0 si no se modifico nada en la bd, 1 si se modifico un elemento de la bd
         */
        public int actualizarEstado(int estado)
        {
            int actualizado;
            SqlCommand comando;
            SqlConnection conexion;

            try
            {
                conexion = Conexion.agregarConexion();
                if (estado == 0)
                    comando = new SqlCommand(String.Format("update Producto set estado = 'en venta' where idProducto = {0}", idProducto), conexion);
                else
                    comando = new SqlCommand(String.Format("delete from Producto where idProducto = {0}", idProducto), conexion);
                actualizado = comando.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                actualizado = 0;
                MessageBox.Show("Error: " + e);
            }
            return actualizado;
        } 
    }
}
