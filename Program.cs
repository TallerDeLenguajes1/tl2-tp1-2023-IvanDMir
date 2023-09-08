﻿
using System.Reflection.Metadata;
using Programa;


internal class Program
{
    private static void Main(string[] args)
    {
        var listaCadeterias = new List<Cadeteria>();
        var listaCadetes = new List<Cadete>();
        listaCadetes = CargarCadetes("Cadetes.csv");
        listaCadeterias=CargarCadeterias("Cadeteria.csv", listaCadetes);

        Console.WriteLine("Ingrese el nombre de la cadeteria con la que desea trabajar");
        var nombreCadeteria = Console.ReadLine();
        Cadeteria cadeteriaSeleccionada = listaCadeterias.FirstOrDefault(l=>l.Nombre==nombreCadeteria);
        if(cadeteriaSeleccionada!=null)
        {
        var ingresar="";
        var nroDePedido=0;
       // cadeteriaSeleccionada.Mostrar();
        cadeteriaSeleccionada.MostrarNombreCadeteria();
        cadeteriaSeleccionada.MostrarTelefonoCadeteria();
        cadeteriaSeleccionada.MostrarCadetesCadeteria();
        
        while(ingresar!="f")
        {
            Console.WriteLine("Seleccione una opcion:");
            Console.WriteLine("a) Dar de alta el pedido");
            Console.WriteLine("b) Asignarlo a un cadete");
            Console.WriteLine("c) Cambiarlo de estado");
            Console.WriteLine("d) Reasignar el pedido a otro cadete");
            Console.WriteLine("e) Ver cuanto debe cobrar un cadete por id");
            Console.WriteLine("f) Salir");
            ingresar=Console.ReadLine();
            switch (ingresar)
            {
                    case "a":
                        CrearPedido(nroDePedido,cadeteriaSeleccionada);
                        nroDePedido+=1;
                        break;
                    case "b":
                        AsignarPedidoACadete(cadeteriaSeleccionada);
            
                        break;
                    case "c":
                        CambiarDeEstado(cadeteriaSeleccionada);
                        break;
                    case "d":
                        ReasignarPedido(cadeteriaSeleccionada);
                        break;
                    case "e":
                        JornalACobraPorID(cadeteriaSeleccionada);
                        break;
               
                }
        }
        }
        else
        {
            Console.WriteLine("No se encontró la cadeteria");
        }


    }
     private static void JornalACobraPorID(Cadeteria cadeteriaSeleccionada)
    {
        Console.WriteLine("Ingrese el id del cadete que desea ver cuanto cobra");
        var a = Console.ReadLine();
        int id;
        bool anda1 = int.TryParse(a, out id);
        if (anda1)
        {
            var totalACobrar = cadeteriaSeleccionada.jornalACobrar(id);
            Console.WriteLine($"El cadete debe cobrar {totalACobrar}");
        }
    }

     private static void ReasignarPedido(Cadeteria cadeteriaSeleccionada)
    {
        Console.WriteLine("Ingrese el nro del pedido que desea reasignar");
        List<Pedido> pedidosPendientes=cadeteriaSeleccionada.PedidosPendientes();
        foreach(Pedido Pendiente in pedidosPendientes){
            Pendiente.Mostrar();
        }
        var a = Console.ReadLine();
        int numero;
        bool Funca = int.TryParse(a, out numero);
        if (Funca)
        {
            Console.WriteLine("Ingrese el id del cadete al que desea ingresar el pedido");
            var b = Console.ReadLine();
            int id;
            bool anda2 = int.TryParse(b, out id);
            if (anda2)
            {
                cadeteriaSeleccionada.AsignarCadetePorID(id, numero);
            }
            else
            {
                Console.WriteLine("No se encuentra el cadete");
            }
        }
    }

    private static void CambiarDeEstado(Cadeteria CadeteriaSeleccionada)
    {   
        Console.WriteLine("Seleccione El pedido a cambiar");
        List<Pedido> pedidosPendientes=CadeteriaSeleccionada.PedidosPendientes();
        foreach(Pedido Pendiente in pedidosPendientes){
            Pendiente.Mostrar();
        }
        var Seleccion = Console.ReadLine();
        int numero;
        bool funciona = int.TryParse(Seleccion,out numero);
        if (funciona){
            var PedidoElegido = CadeteriaSeleccionada.ListadoPedidos.FirstOrDefault(l => l.Numero == numero);
            if (PedidoElegido != null && PedidoElegido.Estado == Estados.pendiente){
                Console.WriteLine("Seleccione el estado en que desea colocar el pedido");
                Console.WriteLine("1. Rechazado");
                Console.WriteLine("2. Aceptado");
                var SeleccionEstado = Console.ReadLine();
                if (SeleccionEstado == "1"){
                    CadeteriaSeleccionada.ListadoPedidos.Remove(PedidoElegido);
                    PedidoElegido.RechazarPedido();
                    PedidoElegido = null;
                    
                }else if (SeleccionEstado == "2"){
                    CadeteriaSeleccionada.aceptarPedido(PedidoElegido.Numero);
                    
                }

            }
        }else {
            Console.WriteLine("Pedido ya Entregado o no creado");
        }
        
        
    }

    private static void AsignarCadete(Cadeteria cadeteriaSeleccionada, int numero)
    {
        var PedidoElegido = cadeteriaSeleccionada.ListadoPedidos.FirstOrDefault(l => l.Numero == numero);
        if (PedidoElegido != null){
            Console.WriteLine("Ingrese el id del cadete ");
            string opcion = Console.ReadLine();
            int IdElegida;
            bool Funca = int.TryParse(opcion,out IdElegida);
            if(Funca){
                cadeteriaSeleccionada.AsignarCadetePorID(IdElegida,numero);
                
            }


        }
        
    }
     private static void AsignarPedidoACadete(Cadeteria cadeteriaSeleccionada)
    {
        List<Pedido> pedidosPendientes=cadeteriaSeleccionada.PedidosPendientes();
        foreach(Pedido Pendiente in pedidosPendientes){
            Pendiente.Mostrar();
        }
        Console.WriteLine("Seleccione el numero de pedido que desea utilizar");
        var a = Console.ReadLine();
        int numero;
        bool Funca = int.TryParse(a, out numero);
        if (Funca)
        {
            AsignarCadete(cadeteriaSeleccionada, numero);
        }
    }

    public static List<Cadeteria> CargarCadeterias(string ruta, List<Cadete> listaCad)
        {
            var ListaCadeterias = new List<Cadeteria>();
            var Archivos = new Archivos();
            var datos = Archivos.Leer(ruta);
            if (datos != null && datos.Any())
            {
                foreach (var Cadeteria in datos)
                {
                    if (Cadeteria == null)
                    {
                        break;
                    }
                    var nuevacadeteria = new Cadeteria(Cadeteria[0], Cadeteria[1],listaCad);
                    ListaCadeterias.Add(nuevacadeteria);
                }
            }
            return ListaCadeterias;
        }

        public static List<Cadete> CargarCadetes(string ruta)
    {
        var Archivos = new Archivos();
        Cadete nuevoCadete;
        var nuevaLista = new List<Cadete>();
        var listaCsv = Archivos.Leer(ruta);
        
        if (listaCsv != null && listaCsv.Any()) {
            int id=0;
            foreach (var cadete in listaCsv) {
                if(cadete == null)
                    break;
                nuevoCadete = new Cadete(id,cadete[0],cadete[1],cadete[2]);
                nuevaLista.Add(nuevoCadete);
                id+=1;
            }
        } else {
            Console.WriteLine("\n(no se encontraron cadetes para cargar)");
        }
        return nuevaLista;
    }
    public static void CrearPedido(int nroDePedido,Cadeteria cadeteriaSeleccionada)
        {
        Console.WriteLine("Ingrese el nombre del cliente");
        string nombreCliente = Console.ReadLine();
        Console.WriteLine("Ingrese la direccion donde vive");
        string direccionCliente = Console.ReadLine();
        Console.WriteLine("Ingrese el telefono del cliente");
        string telefonoCliente = Console.ReadLine();
        Console.WriteLine("Ingrese los datos de Referencia");
        string datosReferencia = Console.ReadLine();
        var datosCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferencia);
        Console.WriteLine("Ingrese l nombre que tenga del pedido");
        string observaciones = Console.ReadLine();
        var PedidoTomado = new Pedido(nroDePedido, observaciones, datosCliente);
        cadeteriaSeleccionada.ListadoPedidos.Add(PedidoTomado);
        }

  
}