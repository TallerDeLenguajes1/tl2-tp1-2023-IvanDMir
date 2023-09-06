using System.Text.Json;
namespace Programa {

    public abstract class Manipular {
        public virtual List<Cadete>? LeerArchivoDeCadetes (string nombreArchivo){
            return null;
        }
        public virtual List<Cadeteria>? LeerArchivoDeCadeteria(string nombreArchivo,List<Cadete> ListaCadetes){
            return null;
        }
    }
    public class ArchivosCSV : Manipular {
        private List<string[]>? LecturaCsv(string nombreArchivo){
            var Lectura = new List<string[]> ();
            if (File.Exists(nombreArchivo)){
                var archivo = new FileStream(nombreArchivo,FileMode.Open);
                var strReader = new StreamReader(archivo);
                var linea = "";
                while ((linea = strReader.ReadLine()) != null){
                        string[] arrayLine = linea.Split(',');
                        Lectura.Add(arrayLine);
                }
                strReader.Close();
            }else {
                Console.WriteLine("No existe tal archivo: {0}",nombreArchivo);
                return null;
            }
            return Lectura;
        }
        public override List<Cadete>? LeerArchivoDeCadetes(string nombreArchivo)
        {
            var listaCsv = this.LecturaCsv(nombreArchivo);
            var Lista = new List<Cadete> ();
            if (listaCsv != null){
                int id = 0;
                foreach (var Cadete in listaCsv){
                    if (Cadete == null){
                        break;
                    }
                    var nuevoCadete = new Cadete(id,Cadete[0],Cadete[1],Cadete[2]);
                    Lista.Add(nuevoCadete);
                    id += 1;
                }
            }
            else {
                Console.WriteLine("No hay cadetes anotados");
            }
            return Lista;
        }
         public override List<Cadeteria>? LeerArchivoDeCadeteria(string nombreArchivo,List<Cadete> ListaCadetes)
        {
            var listaCsv = Archivos.Leer(nombreArchivo);
            var Lista = new List<Cadeteria> ();
            if (listaCsv != null){
                foreach (var Cadeteria in listaCsv){
                    if (Cadeteria == null){
                        break;
                    }
                    var nuevaCadeteria = new Cadeteria(Cadeteria[0],Cadeteria[1],ListaCadetes);
                    Lista.Add(nuevaCadeteria);
                  
                }
            }
            return Lista;
            }
          
        }
        public class ManipulacionJSON : Manipular {
        public override List<Cadete>? LeerArchivoDeCadetes(string nombreArchivo)
        {
            List<Cadete>? ListaCadetes;
            string Archivo = "";
            using ( var AbrirArchivo = new FileStream(nombreArchivo,FileMode.Open)){
                using (var strReader = new StreamReader(AbrirArchivo)){
                    Archivo = strReader.ReadToEnd();
                    AbrirArchivo.Close();
                }
            ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(Archivo);
            }
            return ListaCadetes;
        }
         public override List<Cadeteria>? LeerArchivoDeCadeteria(string rutaDeArchivo, List<Cadete> ListaCadetes){
            List<Cadeteria>? listaCadeteria;
            string documento;
            using (var archivoOpen = new FileStream(rutaDeArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    documento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
                listaCadeteria = JsonSerializer.Deserialize<List<Cadeteria>>(documento);
                if(listaCadeteria!=null)
                {
                    foreach (var Cadetes in listaCadeteria)
                {
                    Cadetes.ListadoCadetes.AddRange(ListaCadetes);
                }
                }
                
            }
            return (listaCadeteria);
        }
    }

    }
