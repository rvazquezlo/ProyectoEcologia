using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoEcologia
{
    class Informacion
    {
        private String link;
        private String informacion;//son los datos ecologicos

        /**
         * Constructor vacio que asigna cadenas vacias a ambos atributos 
         */
        public Informacion()
        {
            link = "";
            informacion = "";
        }

        /**
         * Constructor con ambos atributos
         * @param: el link de una noticia, informacion escrita sobre ecologia
         */
        public Informacion(String link, String informacion)
        {
            this.link = link;
            this.informacion = informacion;
        }

        /**
         *@return: el link de una noticia que caracteriza al objeto de la clase Informacion
         */
        public String getLink()
        {
            return link;
        }

        /**
         * @return: datos ecologicos que caracterizan al objeto de la clase Informacion
         */
        public String getInformacion()
        {
            return informacion;
        }

        /** Force: stub apex javadoc comment
         * Se agregan los datos de Informacion a la bd
         * @param: el link de una noticia, informacion escrita sobre ecologia.
         * Se piden esos parametros por si una instancia de Informacion que ultilizo el constructor vacio llama al metodo
         *
         * @return: 0 si no se agrego la informacion, 1 si se agrego la informacion
         */
        public int agregarInformacion(String link, String informacion)
        {
            int agregado, id;
            SqlConnection conexion;
            SqlCommand comando, comando2;
            SqlDataReader lector;

            conexion = Conexion.agregarConexion();//se abre conexion con sql
            try
            {
                comando = new SqlCommand(String.Format("select max(idInformacion) from Informacion"), conexion);//query para poder general el idInformacion de la tupla que se va a agregar
                lector = comando.ExecuteReader();
                try//este try catch se utiliza en caso de que no hayan noticias. 
                {
                    lector.Read();
                    id = lector.GetInt32(0) + 1;
                    
                }catch(Exception ex)
                {
                    id = 1; //La primera informacion
                }
                comando2 = new SqlCommand(String.Format("insert into Informacion (idInformacion, datos, noticia) values ({0}, '{1}', '{2}')",
                id, link, informacion), conexion);//Se agregan datos a la bd. El idInformacion se genera con base en el anterior.
                lector.Close();
                agregado = comando2.ExecuteNonQuery();//Regresa el numero de filas modificadas en la bd
            }
            catch (Exception e)
            {
                agregado = 0;
                MessageBox.Show("error: " + e);//quitar
            }
            conexion.Close();//Se cierra conexion por seguridad
            return agregado;
        }
    }
}
