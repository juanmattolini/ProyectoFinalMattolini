using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProyectoFinalMattolini.ADO.NET;


Venta venta = new Venta();

List<Venta> lista = new List<Venta>();

lista = venta.ListarVentas();

foreach (var item in lista)
{
    Console.WriteLine("Id: " + item.Id);

    Console.WriteLine("Comentarios: " + item.Comentarios);

}



Console.ReadKey();

namespace ProyectoFinalMattolini.ADO.NET
{



    public class Venta
    {
        static void Main() { }
        public long Id { get; set; }
        public string Comentarios { get; set; }



        public List<Venta> Ventas { get; set; }

        public Venta()
        {
            Ventas = new List<Venta>();
        }

        public List<Venta> ListarVentas()
        {




            string connectionString = @"Server=swdmdzbaspi02;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Comentarios FROM Venta";
            var listaVentas = new List<Venta>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var venta = new Venta();
                            venta.Id = dr.GetInt64("Id");
                            venta.Comentarios = dr.GetString("Comentarios");

                            listaVentas.Add(venta);
                        }

                    }

                }
            }
            return listaVentas;
        }

        public Venta GetVenta(int id)
        {

            string connectionString = @"Server=swdmdzbaspi02;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Comentarios FROM Venta WHERE Id=@pId";
            var venta = new Venta();

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

                            venta.Id = dr.GetInt64("Id");
                            venta.Comentarios = dr.GetString("Comentarios");


                        }
                    }

                }
            }
            return venta;
        }

    }
}
