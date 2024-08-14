using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;

using CapaEntidad;


namespace CapaDatos
{
    public class CD_Usuario
    {
        //Este método nos permite listar todos los usuario que tenemos en nuestra base de datos

        //Este método los tiene que llamar nuestra capa de negocio
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                //Realizamos la peticion hacia la base de datos
                //Agregamos un try por si tenemos problemas con la conexion hacia la base datos
                try
                {

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select u.IdUsuario,u.Documento,u.NombreCompleto,u.Correo,u.Clave,u.Estado,r.IdRol,r.Descripcion from usuario u");
                    query.AppendLine("inner join rol r on r.IdRol = u.IdRol");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {

                            lista.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                Documento = dr["Documento"].ToString(),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"]),
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]), Descripcion = dr["Descripcion"].ToString() }
                            });

                        }

                    }


                }
                catch (Exception ex)
                {

                    lista = new List<Usuario>();
                }
            }

            return lista;
        }
    }
}




// La capa de entidad es la encargada de la comunicación entre todas las capas es el encargado de enviar todos los datos
// Como la capa entidad va hacer utilizada por todas las capas vamos añadir esa referencia a todas las capaas
//Añadimos dicha referencia a la capa de datos, negocio y presentacion


//La capa de presentacion unicamente tiene que tener comunicacion con la capa de negocio

// La capa de Negocio va a actuar de intermediario entre la capa de datos y la capa de presentacion o sea agregamos la referencia hacia la capa de datos
