using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public delegate void Progress(int progreso);
        public delegate void DownloadComplete(string html);

        public event Progress Progreso;
        public event DownloadComplete DescargaCompletada;


        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.Progreso(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.html = e.Result;
            this.DescargaCompletada(this.html);
        }
    }
}
