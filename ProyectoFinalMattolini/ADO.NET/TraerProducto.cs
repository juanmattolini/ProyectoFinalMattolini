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



    public class TraerProducto
    {

 
        public static List<Producto> ListarProductos()
        {


            string connectionString = @"Server=swdmdzbaspi02;Database=SistemaGestion;Trusted_Connection=True;";
            var query = "SELECT Id,Descripciones,Costo,PrecioVenta,Stock,IdUsuario FROM Producto";

            var listaProductos = new List<Producto>();

            using (SqlConnection conect = new SqlConnection(connectionString))
            {
                conect.Open();
                using (SqlCommand comando = new SqlCommand(query, conect))
                {
                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        
                        while (dr.Read())
                        {

                            var producto = new Producto();
                            producto.Id = dr.GetInt64("Id");
                            producto.Descripciones = dr.GetString("Descripciones");
                            producto.Costo = dr.GetDecimal("Costo");
                            producto.PrecioVenta = dr.GetDecimal("PrecioVenta");
                            producto.Stock = dr.GetInt32("Stock");
                            producto.IdUsuario = dr.GetInt64("IdUsuario");
                            listaProductos.Add(producto);
                        }
                        
                    }
                   
                }

                
            }
           
            return listaProductos;
        }


    }
}