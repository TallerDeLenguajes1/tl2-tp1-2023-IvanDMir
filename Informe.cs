namespace Programa {
    public class Informe {
        private double Ganado;
        private double EnviosPorCadete;
        private int total;

        private void CalcularMontoGanadoyEnvios(List<Pedido> ListaPedido){
            int envios =0;
            foreach(var pedido in ListaPedido){
                if (pedido.Estado == Estados.aceptado){
                    envios++;
                }
            }
            this.Ganado = envios*500;
            this.total = envios;
        }
        private void calcularEnviosPorCadete(List<Cadete> listadoCadetes)
        {
            this.EnviosPorCadete=this.Ganado/listadoCadetes.Count();
        }
           public Informe(List<Pedido> listadoPedidos, List<Cadete> listadoCadetes)
        {
            CalcularMontoGanadoyEnvios(listadoPedidos);
            calcularEnviosPorCadete(listadoCadetes);
            
        }
         public void MostrarInforme(List<Cadete> listadoCadetes)
        {
            Console.WriteLine(".-.--.-.-.-.-.-.-INFORME.--.-.-.-.-.-.-");
            Console.WriteLine($"CANT ENVIOS: {this.total}");
            Console.WriteLine($"MONTO GANADO: {this.Ganado}");
            Console.WriteLine($"CANTIDAD PROMEDIO GANADA POR CADETE: {this.EnviosPorCadete}");
        }
    }
}