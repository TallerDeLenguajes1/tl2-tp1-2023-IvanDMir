using System;
using System.IO;
using System.Collections;
namespace Programa
{
    public class Cliente
    {
        private string nombre;
        private string direccion;
        private string telefono;
        private string datosReferenciaDireccion;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        public Cliente(string name, string adress, string phone, string adressReferences){
            this.nombre=name;
            this.direccion=adress;
            this.telefono=phone;
            this.datosReferenciaDireccion=adressReferences;
        }

        public Cliente()
        {
            this.nombre="";
            this.direccion="";
            this.telefono="";
            this.datosReferenciaDireccion="";
        }
        public void Mostrar()
        {
            Console.WriteLine($"Nombre: {this.nombre}");
            Console.WriteLine($"Direccion: {this.direccion}");
            Console.WriteLine($"telefono: {this.telefono}");
            Console.WriteLine($"datosReferenciaDireccion: {this.datosReferenciaDireccion}");
        }
    }
}