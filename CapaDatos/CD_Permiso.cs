using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    // Definición de la clase CD_Permiso dentro del espacio de nombres 'CapaDatos'
    public class CD_Permiso
    {
        // Método público que devuelve una lista de permisos para un usuario específico
        public List<Permiso> Listar(int idUsuario)
        {
            // Se inicializa una lista de objetos 'Permiso' llamada 'lista'
            List<Permiso> lista = new List<Permiso>();

            // Se establece una conexión con la base de datos utilizando la cadena de conexión definida en 'Conexion.cadena'
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                // Se realiza una petición hacia la base de datos
                // Se utiliza un bloque try-catch para manejar posibles problemas de conexión
                try
                {
                    // Se crea un objeto StringBuilder para construir la consulta SQL de forma dinámica
                    StringBuilder query = new StringBuilder();

                    // Se añade la primera línea de la consulta SQL que selecciona el IdRol y NombreMenu de la tabla PERMISO
                    query.AppendLine("select p.IdRol,p.NombreMenu from PERMISO p");

                    // Se añade una cláusula JOIN para unir la tabla PERMISO con la tabla ROL basándose en el IdRol
                    query.AppendLine("inner join ROL r on r.IdRol = p.IdRol");

                    // Se añade otra cláusula JOIN para unir la tabla ROL con la tabla USUARIO basándose en el IdRol
                    query.AppendLine("inner join USUARIO u on u.IdRol = r.IdRol");

                    // Se añade una condición WHERE para filtrar los resultados según el IdUsuario proporcionado
                    query.AppendLine("where u.IdUsuario = @idUsuario");

                    // Se crea un objeto SqlCommand que ejecutará la consulta SQL construida y se asocia con la conexión a la base de datos
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    // Se añade un parámetro a la consulta SQL con el valor de 'idUsuario'
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    // Se define que el tipo de comando es texto SQL
                    cmd.CommandType = CommandType.Text;

                    // Se abre la conexión a la base de datos
                    oconexion.Open();

                    // Se ejecuta la consulta y se obtiene un SqlDataReader para leer los resultados
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Se itera sobre los resultados devueltos por la consulta
                        while (dr.Read())
                        {
                            // Se añade un nuevo objeto 'Permiso' a la lista con los valores obtenidos de la consulta
                            lista.Add(new Permiso()
                            {
                                // Se crea un objeto 'Rol' con el IdRol obtenido del resultado y se asigna a la propiedad 'oRol' del permiso
                                oRol = new Rol() { IdRol = Convert.ToInt32(dr["IdRol"]) },

                                // Se asigna el valor de 'NombreMenu' obtenido del resultado al permiso
                                NombreMenu = dr["NombreMenu"].ToString(),
                            });
                        }
                    }
                }
                // Se captura cualquier excepción que ocurra durante la ejecución
                catch (Exception ex)
                {
                    // Si ocurre una excepción, se inicializa la lista como una lista vacía
                    lista = new List<Permiso>();
                }
            }

            // Se retorna la lista de permisos obtenidos
            return lista;
        }
    }
}