using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                
                StreamWriter writer = new StreamWriter(archivo);
                writer.Write(datos.ToString(), Encoding.UTF8);
                writer.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

    }
}
