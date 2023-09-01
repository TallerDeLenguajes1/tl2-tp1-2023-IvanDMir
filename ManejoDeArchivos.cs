using System;
using System.IO;
using System.Collections;

namespace Programa
{
   public class Archivos
   {
    public static List<string[]>? Leer(string nombreArchivo)
    {
        var Lectura = new List<string[]>();
        if (File.Exists(nombreArchivo)) {
            var archivo = new FileStream(nombreArchivo, FileMode.Open);
            var strReader = new StreamReader(archivo);
            var linea = "";
            while ((linea = strReader.ReadLine()) != null) {
                string[] arregloLinea = linea.Split(',');
                Lectura.Add(arregloLinea);
            }
            strReader.Close();
        }
        else {
            Console.WriteLine("Archivo no encontrado: {0}", nombreArchivo);
            return null;
        }
        return Lectura;
    }
   } 
}