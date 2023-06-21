using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProyectoFinalMattolini.ADO.NET;


Usuario usuario = new Usuario();

List<Usuario> lista = new List<Usuario>();

lista = usuario.ListarUsuarios();

foreach (var item in lista)
{
    Console.WriteLine("Id: " + item.Id);

    Console.WriteLine("Nombre: " + item.Nombre);

    Console.WriteLine("Apellido: " + item.Apellido);

    Console.WriteLine("NombreUsuario: " + item.NombreUsuario);

    Console.WriteLine("Contraseña: " + item.Contraseña);

    Console.WriteLine("Mail" + item.Mail);



}



Console.ReadKey();

namespace ProyectoFinalMattolini.ADO.NET
{



    public class Usuario
    {
        static void Main() { }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Mail { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public Usuario()
        {

            Usuarios = new List<Usuario>();
        }

        public List<Usuario> ListarUsuarios()
        {
            string connectionString = @"Server=swdmdzbaspi02;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario";
            var listaUsuarios = new List<Usuario>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var usuario = new Usuario();
                            usuario.Id = dr.GetInt64("Id");
                            usuario.Nombre = dr.GetString("Nombre");
                            usuario.Apellido = dr.GetString("Apellido");
                            usuario.NombreUsuario = dr.GetString("NombreUsuario");
                            usuario.Contraseña = dr.GetString("Contraseña");
                            usuario.Mail = dr.GetString("Mail");
                            listaUsuarios.Add(usuario);
                        }

                    }

                }
            }
            return listaUsuarios;
        }

        public Usuario GetUsuario(int id)
        {

            string connectionString = @"Server=swdmdzbaspi02;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Nombre,Apellido,NombreUsuario,Contraseña,Mail FROM Usuario WHERE Id=@pId";
            var usuario = new Usuario();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "@pId";
                    parametro.DbType = DbType.Int32;
                    parametro.Value = Id;
                    comando.Parameters.Add(parametro);

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {


                            usuario.Id = dr.GetInt64("Id");
                            usuario.Nombre = dr.GetString("Nombre");
                            usuario.Apellido = dr.GetString("Apellido");
                            usuario.NombreUsuario = dr.GetString("NombreUsuario");
                            usuario.Contraseña = dr.GetString("Contraseña");
                            usuario.Mail = dr.GetString("Mail");


                        }
                    }

                }
            }
            return usuario;
        }

    }
}

