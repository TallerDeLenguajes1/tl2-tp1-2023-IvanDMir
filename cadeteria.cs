
namespace Programa
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        
        private List<Pedido> listadoPedidos;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
       public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
     public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Cadeteria(string nombre, string celular, List<Cadete> listaCadete)
        {
            this.nombre = nombre;
            this.telefono =celular;
            this.listadoCadetes = new List<Cadete>();
            this.listadoCadetes.AddRange(listaCadete);
            this.listadoPedidos = new List<Pedido>();
        }
         public Cadeteria()
        {
            this.nombre="";
            this.telefono="";
            this.listadoCadetes=new List<Cadete>();
            this.listadoPedidos=new List<Pedido>(); 
        }

        public void Mostrar()
        {
            int cont = 1;
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Telefono: {this.telefono}");
            foreach (var cadete in listadoCadetes)
            {
                Console.WriteLine($".-.-.-.-.-CLIENTE {cont}-.--..--.-.");
                cadete.Mostrar();
                cont += 1;
            }
        }
        
        public void CrearPedido(int nroDePedido)
        {
        Console.WriteLine("Ingrese el nombre del cliente");
        var nombreCliente = Console.ReadLine();
        Console.WriteLine("Ingrese la direccion donde vive");
        var direccionCliente = Console.ReadLine();
        Console.WriteLine("Ingrese el telefono del cliente");
        var telefonoCliente = Console.ReadLine();
        Console.WriteLine("Ingrese los datos de Referencia");
        var datosReferencia = Console.ReadLine();
        var datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
        Console.WriteLine("Ingrese l nombre que tenga del pedido");
        var observaciones = Console.ReadLine();
        var PedidoTomado = new Pedido(nroDePedido, observaciones, datosCliente);
        this.listadoPedidos.Add(PedidoTomado);
        }

        public void tomarPedido(Pedido PedidoTomado){
            this.listadoPedidos.Add(PedidoTomado);
        }

        public double jornalACobrar(int idDelCadete){
            int PedidosEntregados = 0;
            var cadete = this.listadoCadetes.FirstOrDefault(l=>l.Id==idDelCadete);
            if (cadete !=null){
                foreach (var pedido in this.listadoPedidos){
                    if (pedido.CadeteResponsable==cadete && pedido.Estado==Estados.aceptado){
                           PedidosEntregados += 1;
                    }
                }
             
            }else {
                Console.WriteLine("Cadete no encontrado");
            }
            double Jornal = 500* PedidosEntregados;
            return Jornal;
        }
    public void AsignarCadetePorID(int idCadete, int idPedido){
         var cadete = this.listadoCadetes.FirstOrDefault(l=>l.Id==idCadete);
         var pedido = this.listadoPedidos.FirstOrDefault(l=>l.Numero==idPedido);
         if (cadete != null && pedido !=null){
            pedido.asignarCadete(cadete);
         }else{
              Console.WriteLine("No se encuentra el cliente");
         }
           
            }
             public void aceptarPedido(int idPedido){
            var pedido = this.listadoPedidos.FirstOrDefault(l=>l.Numero==idPedido);
            if(pedido != null){
                pedido.AceptarPedido();
            }
       }
  
        public void MostrarPedidosPendientes(){
            foreach ( var pedido in this.listadoPedidos)
            {
                if (pedido.Estado == Estados.pendiente){
                    pedido.Mostrar();
                }
            }
        }
    }   
}