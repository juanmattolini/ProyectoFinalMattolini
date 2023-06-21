using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProyectoFinalMattolini.ADO.NET;


Productovendido productovendido = new Productovendido();

List<Productovendido> lista = new List<Productovendido>();

lista = productovendido.Listarproductovendidos();

foreach (var item in lista)
{
    Console.WriteLine("Id: " + item.Id);

    Console.WriteLine("Stock: " + item.Stock);

    Console.WriteLine("IdProducto: " + item.IdProducto);

    Console.WriteLine("IdVenta: " + item.IdVenta);

}



Console.ReadKey();

namespace ProyectoFinalMattolini.ADO.NET
{



    public class Productovendido
    {
        static void Main() { }
        public long Id { get; set; }
        public int Stock { get; set; }
        public decimal IdProducto { get; set; }
        public decimal IdVenta { get; set; }


        public List<Productovendido> Productovendidos { get; set; }

        public Productovendido()
        {
            Productovendidos = new List<Productovendido>();
        }

        public List<Productovendido> Listarproductovendidos()
        {




            string connectionString = @"Server=swdmdzbaspi02;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Stock,IdProducto,IdVenta FROM productovendido";
            var listaproductovendidos = new List<Productovendido>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            var productovendido = new Productovendido();
                            productovendido.Id = dr.GetInt64("Id");
                            productovendido.Stock = dr.GetInt32("Stock");
                            productovendido.IdProducto = dr.GetInt64("IdProducto");
                            productovendido.IdVenta = dr.GetInt64("IdVenta");
                            listaproductovendidos.Add(productovendido);
                        }

                    }

                }
            }
            return listaproductovendidos;
        }

        public Productovendido Getproductovendido(int id)
        {

            string connectionString = @"Server=swdmdzbaspi02;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Stock,IdProducto,IdVenta FROM productovendido WHERE Id=@pId";
            var productovendido = new Productovendido();

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

                            productovendido.Id = dr.GetInt64("Id");
                            productovendido.Stock = dr.GetInt32("Stock");
                            productovendido.IdProducto = dr.GetDecimal("IdProducto");
                            productovendido.IdVenta = dr.GetDecimal("IdVenta");

                        }
                    }

                }
            }
            return productovendido;
        }

    }
}
