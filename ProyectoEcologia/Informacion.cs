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
        private String informacion;

        public Informacion()
        {

        }

        public Informacion(String link, String informacion)
        {
            this.link = link;
            this.informacion = informacion;
        }

        /** Force: stub apex javadoc comment
         * 
         * @return: 0 si no se agrego la informacion, 1 si se agrego la informacion
         */
        public int agregarInformacion(String link, String informacion)
        {
            int agregado;
            SqlConnection conexion;
            SqlCommand comando, comando2;
            SqlDataReader lector;

            conexion = Conexion.agregarConexion();
            try
            {
                comando = new SqlCommand(String.Format("select bottom 1 idInformacion from Informacion"), conexion);
                lector = comando.ExecuteReader();
                comando2 = new SqlCommand(String.Format("insert into Informacion (idInformacion, datos, noticia) values ({0}, '{1}', '{2}')",
                lector.GetInt16(0) + 1, link, informacion), conexion);
                agregado = comando2.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                agregado = 0;
                MessageBox.Show("error: " + e);//quitar
            }
            conexion.Close();
            return agregado;
        }
    }
}
