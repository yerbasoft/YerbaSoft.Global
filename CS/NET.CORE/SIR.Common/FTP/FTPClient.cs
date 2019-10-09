using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SIR.Common.FTP
{
    public class FTPClient
    {
        private string Host { get; set; }
        private string User { get; set; }
        private string Pass { get; set; }
        private int Port { get; set; }
        private bool Ssl { get; set; }
        
        public FTPClient(string hostIP, string userName, string password, int port = 21, bool enableSsl = false)
        {
            this.Host = hostIP;
            this.Port = port;
            this.Ssl = enableSsl;
            this.User = userName;
            this.Pass = password;
        }

        /// <summary>
        /// Descarga un archivo desde el FTP
        /// </summary>
        /// <param name="filePath">ruta relativa al archivo en el FTP</param>
        /// <returns></returns>
        public byte[] Download(string filePath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.DownloadFile, filePath);
            var res = (FtpWebResponse)req.GetResponse();
            var str = res.GetResponseStream();

            byte[] buffer = new byte[4 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = str.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                buffer = ms.ToArray();
            }            

            return buffer;
        }

        /// <summary>
        /// Sube un archivo a un FTP
        /// </summary>
        /// <param name="filePath">ruta relativa al archivo en el FTP</param>
        /// <param name="content">contenido binario del archivo</param>
        public void Upload(string filePath, byte[] content)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.UploadFile, filePath);
            var str = req.GetRequestStream();
            str.Write(content, 0, content.Length);
            str.Close();
        }

        /// <summary>
        /// Elimina un archivo del FTP
        /// </summary>
        /// <param name="filePath">ruta relativa al archivo en el FTP</param>
        public void Delete(string filePath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.DeleteFile, filePath);
            var res = (FtpWebResponse)req.GetResponse();
            res.Close();
        }

        /// <summary>
        /// Renombra un archivo o directorio en el servidor FTP
        /// </summary>
        /// <param name="originalPath">ruta relativa al archivo o directorio a cambiar</param>
        /// <param name="newPath">nueva ruta relativa del archivo o directorio</param>
        public void Rename(string originalPath, string newPath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.Rename, originalPath);
            req.RenameTo = newPath;
            var res = (FtpWebResponse)req.GetResponse();
            res.Close();
        }

        /// <summary>
        /// Devuelve la información de la fecha del archivo en el FTP
        /// </summary>
        /// <param name="filePath">ruta relativa al archivo en el FTP</param>
        /// <returns></returns>
        public string GetFileDateTime(string filePath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.GetDateTimestamp, filePath);
            var res = (FtpWebResponse)req.GetResponse();
            var str = res.GetResponseStream();

            string info = string.Empty;
            using (var reader = new StreamReader(str))
            {
                info = reader.ReadToEnd();
            }
            str.Close();
            res.Close();

            return info;
        }

        /// <summary>
        /// Devuelve el tamaño en bytes del archivo en el FTP
        /// </summary>
        /// <param name="filePath">ruta relativa al archivo en el FTP</param>
        /// <returns></returns>
        public string GetFileSize(string filePath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.GetFileSize, filePath);
            var res = (FtpWebResponse)req.GetResponse();
            var str = res.GetResponseStream();

            string info = string.Empty;
            using (var reader = new StreamReader(str))
            {
                info = reader.ReadToEnd();
            }
            str.Close();
            res.Close();

            return info;
        }

        /// <summary>
        /// Crea un nuevo directorio en el FTP
        /// </summary>
        /// <param name="dirPath">ruta relativa al directorio en el FTP</param>
        public void CreateDirectory(string dirPath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.MakeDirectory, dirPath);
            var res = (FtpWebResponse)req.GetResponse();
            res.Close();
        }

        /// <summary>
        /// Devuelve la lista de archivos disponibles en un directorio en el FTP
        /// </summary>
        /// <param name="dirPath">ruta relativa del directorio</param>
        /// <returns></returns>
        public string[] GetFiles(string dirPath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.ListDirectory, dirPath);
            var res = (FtpWebResponse)req.GetResponse();
            var str = res.GetResponseStream();

            string files = string.Empty;
            using (var reader = new StreamReader(str))
            {
                while (reader.Peek() != -1)
                {
                    files += reader.ReadLine() + "|";
                }
            }
            str.Close();
            res.Close();

            return files.Split('|');
        }

        /// <summary>
        /// Devuelve la lista de archivos disponibles con detalles en un directorio en el FTP
        /// </summary>
        /// <param name="dirPath">ruta relativa del directorio</param>
        /// <returns></returns>
        public string[] GetFilesDetallado(string dirPath)
        {
            var req = GetFtpRequest(WebRequestMethods.Ftp.ListDirectoryDetails, dirPath);
            var res = (FtpWebResponse)req.GetResponse();
            var str = res.GetResponseStream();

            string files = string.Empty;
            using (var reader = new StreamReader(str))
            {
                while (reader.Peek() != -1)
                {
                    files += reader.ReadLine() + "|";
                }
            }
            str.Close();
            res.Close();

            return files.Split('|');
        }

        private FtpWebRequest GetFtpRequest(string method, string remoteFileOrDir)
        {
            var url = new Uri($"ftp://{this.Host}:{this.Port}/{remoteFileOrDir}");

            var req = (FtpWebRequest)FtpWebRequest.Create(url);
            req.EnableSsl = this.Ssl;

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback((a,b,c,d) => { return true; });

            req.Credentials = new NetworkCredential(this.User, this.Pass);

            req.UseBinary = true;
            req.UsePassive = true;
            req.KeepAlive = true;
            req.Method = method;

            return req;
        }

        private static bool MyCertValidationCb(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }

}
