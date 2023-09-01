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

        public int Numero { get => numero; set => numero = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public Cliente NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public Estados Estado { get => estado; set => estado = value; }

        public Pedido(int numero, string nombre, Cliente cliente)
        {
            this.numero=numero;
            this.nombre=nombre;
            this.nombreCliente=cliente;
            this.estado=Estados.pendiente;
        }

        public Pedido()
        {
            this.numero=0;
            this.nombre="";
            this.nombreCliente=new Cliente();
            this.estado=Estados.pendiente;
        }

        public void Mostrar()
        {
            Console.WriteLine($"numero: {this.numero}");
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine("---------------Datos del cliente----------------\n");
            this.NombreCliente.Mostrar();
            Console.WriteLine($"Estado: {this.estado}");
        }

        public void AceptarPedido()
        {
            this.estado=Estados.aceptado;
        }

        public void RechazarPedido()
        {
            this.estado=Estados.rechazado;
        }
    }
}