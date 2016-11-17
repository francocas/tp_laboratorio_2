using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                StreamWriter writer = new StreamWriter(archivo);
                XmlSerializer ser = new XmlSerializer(datos.GetType());
                ser.Serialize(writer, datos);
                writer.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                reader.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }

    }
}
