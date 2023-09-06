using System;
using System.IO;
using System.Collections;

namespace Programa
{
    public enum Estados{
        aceptado,
        pendiente,
        rechazado
    }
    public class Pedido
    {
        private int numero;
        private string nombre;
        private Cliente nombreCliente;
        private Estados estado;
        private Cadete? cadeteResponsable;

        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public Estados Estado { get => estado; set => estado = value; }
         public Cadete? CadeteResponsable { get => cadeteResponsable; set => cadeteResponsable = value; }

        public Pedido(int numero, string nombre, Cliente cliente)
        {
            this.numero=numero;
            this.nombre=nombre;
            this.nombreCliente=cliente;
            this.estado=Estados.pendiente;
            this.CadeteResponsable = null;
        }

        public Pedido()
        {
            this.numero=0;
            this.nombre="";
            this.nombreCliente=new Cliente();
            this.estado=Estados.pendiente;
            this.cadeteResponsable = null;
        }

        public void Mostrar()
        {
            Console.WriteLine($"numero: {this.numero}");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine("---------------Datos del cliente----------------\n");
            this.NombreCliente.Mostrar();
            Console.WriteLine($"Estado: {this.estado}");
             if(this.cadeteResponsable==null)
            {
                Console.WriteLine("No tiene cadete asignado");
            }else
            {
                Console.WriteLine($"Cadete Asignado: {this.cadeteResponsable.Nombre}");
            }
        }

        public void asignarCadete(Cadete CadeteAsignado){
            this.cadeteResponsable = CadeteAsignado;
        }
        public void AceptarPedido()
        {
            if(this.estado == Estados.pendiente){
            this.estado=Estados.aceptado;
            if (this.estado == Estados.rechazado){
                Console.WriteLine("Este pedido ha sido rechazado");
            }
        }
        }

        public void RechazarPedido()
        {
            this.estado=Estados.rechazado;
            this.cadeteResponsable = null;
        }
    }
}