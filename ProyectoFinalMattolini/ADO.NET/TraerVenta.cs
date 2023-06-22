using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ProyectoFinalMattolini.Modelos;



namespace ProyectoFinalMattolini.ADO.NET
{



    public class TraerVenta
    {
   

        public static List<Venta> ListarVentas()
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



    }
}
