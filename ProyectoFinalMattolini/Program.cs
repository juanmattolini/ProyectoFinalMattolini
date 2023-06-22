using ProyectoFinalMattolini.ADO.NET;
using ProyectoFinalMattolini.Modelos;



//Producto producto = new Producto();

//List<Producto> lista = new List<Producto>();

//lista = TraerProducto.ListarProductos();

//foreach (var item in lista)
//{
//    Console.WriteLine("Id: " + item.Id);

//    Console.WriteLine("Descripcion: " + item.Descripciones);

//    Console.WriteLine("Costo: " + item.Costo);

//    Console.WriteLine("PrecioVenta: " + item.PrecioVenta);




//}

//Console.ReadKey();



//Usuario usuario = new Usuario();

//List<Usuario> lista = new List<Usuario>();

//lista = TraerUsuario.ListarUsuarios();

//foreach (var item in lista)
//{
//    Console.WriteLine("Id: " + item.Id);

//    Console.WriteLine("Nombre: " + item.Nombre);

//    Console.WriteLine("Apellido: " + item.Apellido);

//    Console.WriteLine("NombreUsuario: " + item.NombreUsuario);

//    Console.WriteLine("Contraseña: " + item.Contraseña);

//    Console.WriteLine("Mail" + item.Mail);



//}



//Console.ReadKey();




Venta venta = new Venta();

List<Venta> lista = new List<Venta>();

lista = TraerVenta.ListarVentas();

foreach (var item in lista)
{
    Console.WriteLine("Id: " + item.Id);

    Console.WriteLine("Comentarios: " + item.Comentarios);

}



Console.ReadKey();



//ProductoVendido productovendido = new ProductoVendido();

//List<ProductoVendido> lista = new List<ProductoVendido>();

//lista = TraerProductoVendido.Listarproductovendidos();

//foreach (var item in lista)
//{
//    Console.WriteLine("Id: " + item.Id);

//    Console.WriteLine("Stock: " + item.Stock);

//    Console.WriteLine("IdProducto: " + item.IdProducto);

//    Console.WriteLine("IdVenta: " + item.IdVenta);

//}



//Console.ReadKey();

