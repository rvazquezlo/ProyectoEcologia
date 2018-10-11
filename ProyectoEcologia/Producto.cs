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
        private Int16 idProducto;

        /**
         * Constructor vacio que asigna cadenas vacias a los atributos de tipo String y un 0 a los atributos de tipo numerico
         */
        public Producto()
        {

            estado = "";
            categoria = "";
            precio = 0;
            nombre = "";
            descripcion = "";
            idProducto = 0;
    }

        /**
         * Constructor con algunos atributos. Los demas se llenan con cadenas vacias o ceros
         * @param: estado del producto (en espera, en venta, vendido), categoria a la que pertenece, precio de venta, nombre que asigna el vendedor, descripcion que da el vendedor
         */
        public Producto(String estado, String categoria, double precio, String nombre, String descripcion)
        {
            this.estado = estado;
            this.categoria = categoria;
            this.precio = precio;
            this.nombre = nombre;
            this.descripcion = descripcion;
            idProducto = 0;
        }

        /**
          * Constructor con algunos atributos. Los demas se llenan con cadenas vacias o ceros
          * @param: precio de venta, nombre que asigna el vendedor, descripcion que da el vendedor, numero unico que identifica al producto
          */
        public Producto(double precio, String nombre, String descripcion, Int16 idProducto)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.idProducto = idProducto;
            categoria = "";
            estado = "";
        }

        /**
         * Constructor con algunos atributos. Los demas se llenan con cadenas vacias o ceros
         * @param: precio de venta, nombre que asigna el vendedor, descripcion que da el vendedor, numero unico que identifica al producto
         */
        public Producto(double precio, String nombre, String descripcion, String estado)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.estado = estado;
            idProducto = 0;
            categoria = "";
        }

        /**
         * Constructos unicamente con idProducto
         * @param: numero unico que identifica al producto
         */
        public Producto(Int16 idProducto)
        {
            this.idProducto = idProducto;
        }

        /**
         * @return: nombre que asigna el vendedor
         */
        public String getNombre()
        {
            return nombre;
        }

        /**
         * @return: descripcion que da el vendedor
         */
        public String getDescripcion()
        {
            return descripcion;
        }

        /**
         * @return: precio de venta
         */
        public double getPrecio()
        {
            return precio;
        }

        /**
         * @return: numero unico que identifica al producto
         */
        public Int16 getIdProducto()
        {
            return idProducto;
        }

        /**
         * @return: categoria a la que pertenece
         */
        public String getCategoria()
        {
            return categoria;
        }

        /**
         * @return: estado del producto (en espera, en venta, vendido)
         */
        public String getEstado()
        {
            return estado;
        }

        /**
         * @return: el siguiente producto en la bd que este en estado de espera, null si hubo error o si no hay productos en estado "en espera"
         */
        public Producto obtenerSiguiente()
        {
            SqlConnection conexion;
            SqlCommand comando;
            SqlDataReader lector;
            Producto siguiente;

            siguiente = null;//Se asigna por default
            conexion = Conexion.agregarConexion();//conectar con sql
            try
            {
                comando = new SqlCommand(String.Format(
                    "select top 1 (precio, nombre, descripcion, idProducto) from Producto where estado like '%espera%'"),
                    conexion);//query para obtener todos los datos del primer producto de la bd que aparezca en estado "en espera"
                lector = comando.ExecuteReader();
                if (lector.Read())//Si se encontraron datos para la consulta solicitada en la bd
                    siguiente = new Producto(lector.GetDouble(0), lector.GetString(1), lector.GetString(2), lector.GetInt16(3));//se agregan datos a un objeto de tipo producto
                lector.Close();
            }catch(Exception e)
            {
                MessageBox.Show("Error en clase Producto: " + e);//Quitar despues de prueba    
            }
            conexion.Close();//se cierra por seguridad
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

            conexion = Conexion.agregarConexion();//abrir conexion
            try
            {
                if (estado == 0)//se aprobo
                    comando = new SqlCommand(String.Format("update Producto set estado = 'en venta' where idProducto = {0}", idProducto), conexion);//cambiar el estado de "en espera" a "en venta" en la bd
                else
                    comando = new SqlCommand(String.Format("delete from Producto where idProducto = {0}", idProducto), conexion);//se elimina el producto negado de la bd
                actualizado = comando.ExecuteNonQuery();//El numero de filas afectadas (debe ser 1)
            }
            catch(Exception e)
            {
                actualizado = 0;
                MessageBox.Show("Error: " + e);
            }
            conexion.Close();//se cierra por seguridad
            return actualizado;
        } 

        /**
         * Cuenta los productos vendidos en la bd
         * @return: un entero que representa el numero de productos vendidos, -1 si hubo algun error
         */
        public int contarProductosVendidos()
        {
            int productosVendidos;
            SqlConnection conexion;
            SqlCommand comando;
            SqlDataReader lector;

            conexion = Conexion.agregarConexion();//se abre conexion
            try
            {
                comando = new SqlCommand(String.Format("select count(estado) from Producto where estado like '%vendido%'"), conexion);//Query para contar productos en estado "vendido"
                lector = comando.ExecuteReader();
                productosVendidos = int.Parse(lector.GetString(0));//se guarda el resultado de la consulta (numero de productos en estado "vendidos")
                lector.Close();
            }catch(Exception e)
            {
                productosVendidos = -1;//Se asigna un numero irreal para la situacion que alerta de error
                MessageBox.Show("Error: " + e);
            }
            conexion.Close();//Se cierra por seguridad
            return productosVendidos;
        }

        /**
        * Cuenta los productos en espera en la bd
        * @return: un entero que representa el numero de productos en espera, -1 si hubo algun error
        */
        public int contarProductosEnEspera()
        {
            int productosEspera;
            SqlConnection conexion;
            SqlCommand comando;
            SqlDataReader lector;

            conexion = Conexion.agregarConexion();
            try
            {
                comando = new SqlCommand(String.Format("select count(estado) from Producto where estado like '%espera%'"), conexion);
                lector = comando.ExecuteReader();
                productosEspera = int.Parse(lector.GetString(0));
            }
            catch (Exception e)
            {
                productosEspera = -1;
                MessageBox.Show("Error: " + e);
            }
            conexion.Close();
            return productosEspera;
        }

        /**
         * Busca los productos por el nombre de categoria
         * @param: nombre de la categoria que se busca
         * @return: lista de productos, null si hubo error
         */
        public List<Producto> buscarProductoPorCategoria(int idCategoria)
        {
            SqlConnection conexion;
            SqlCommand comando;
            SqlDataReader lector;
            List<Producto> productos;
            Producto producto;

            conexion = Conexion.agregarConexion();
            productos = new List<Producto>();
            try
            {
                comando = new SqlCommand(String.Format
                    ("select nombre, descripcion, precio, estado from Producto where idCategoria = {0}", idCategoria), conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    producto = new Producto(lector.GetDouble(2), lector.GetString(0), lector.GetString(1), lector.GetString(3));
                    productos.Add(producto);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e);
            }
            conexion.Close();
            return productos;
        }
    }
}
