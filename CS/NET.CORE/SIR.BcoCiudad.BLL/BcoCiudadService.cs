using SIR.BcoCiudad.BLL.DTO.File;
using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIR.BcoCiudad.BLL
{
    public class BcoCiudadService : Common.Interfaces.IBcoCiudadService
    {
        protected SIR.Common.Log.Logger Logger;
        protected SIR.BcoCiudad.Common.DTO.Config.Application Config;
        protected DAL.DAO DAO;

        public BcoCiudadService(SIR.Common.Log.Logger log, Common.DTO.Config.Application config)
        {
            this.Logger = log;
            this.Config = config;
            this.DAO = new DAL.DAO(config.ConnectionString);
        }

        public void ProcesarArchivos(bool reprocesar)
        {
            var files = ObtenerArchivosDesdeFTP();
        }

        /// <summary>
        /// Obtiene los archivos desde el FTP, los guarda localmente y devuelve la estructura FileRef con la referencia a los archivos descargados
        /// </summary>
        /// <returns></returns>
        private IEnumerable<FileRef> ObtenerArchivosDesdeFTP()
        {
            var ftp = new SIR.Common.FTP.FTPClient(
                DAO.Config.Get("ftpHost", Logger)?.Value,
                DAO.Config.Get("ftpUsername", Logger)?.Value,
                DAO.Config.Get("ftpPassword", Logger)?.Value,
                DAO.Config.Get("ftpPort", Logger)?.Convert<int>() ?? 21,
                DAO.Config.Get("ftpEnableSsl", Logger)?.Convert<bool>() ?? false
            );

            // Obtengo la configuración y obtengo la lista de archivos desde el FTP
            var ftpPath = DAO.Config.Get("ftpDir", Logger)?.Value;
            var files = ftp.GetFiles(ftpPath);

            // Verifico que pre-exista la carpeta local
            var localPath = DAO.Config.Get("localDir", Logger)?.Value;
            if (!System.IO.Directory.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, localPath)))
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, localPath));

            // Sólo se procesan los archivos que cumplen cierto criterio según el nombre
            var validFile = new Regex(@"^REND?BCBA(029|999)\d{6}.txt$", RegexOptions.IgnoreCase);
            var tasks = new Queue<Task<Response<FileRef>>>();
            foreach (var file in files.Where(f => validFile.IsMatch(f)))
            {
                tasks.Enqueue(new Task<Response<FileRef>>(ObtenerArchivoDesdeFTP, new { ftp, ftpPath, file, localPath }));
            }

            Logger.Info($"Se encontraron {tasks.Count} archivos a descargar desde el FTP.");

            // Descargo los archivos en paralelo y logueo los resultados.
            var results = new SIR.Common.Thread.TaskManager().ProcesarEnParalelo(tasks, 5);
            foreach (var res in results)
                Logger.Log(res);

            // Devuelvo sólo los archivos que no tuvieron problemas en procesarse
            return results.Where(p => !p.ExistsErrorMessages).Select(p => p.Data);
        }

        /// <summary>
        /// Obtiene un archivo desde FTP y devuelve el archivo parseado a objeto
        /// </summary>
        /// <param name="obj">{ ftp, ftpPath, file, localPath }</param>
        /// <returns></returns>
        private Response<FileRef> ObtenerArchivoDesdeFTP(dynamic obj)
        {
            try
            {
                var _ftp = (SIR.Common.FTP.FTPClient)((dynamic)obj).ftp;
                var _file = (string)((dynamic)obj).file;
                var _ftpPath = (string)((dynamic)obj).ftpPath;
                var _localPath = (string)((dynamic)obj).localPath;

                // obtengo el archivo desde el FTP
                var content = _ftp.Download($"{_ftpPath}/{_file}");

                // Versiono el archivo (el nuevo siempre queda con el nombre original y los anteriores se ván versionando)
                var version = 0;
                var localFilePathOriginal = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _localPath, _file);
                var localFileOriginal = new System.IO.FileInfo(localFilePathOriginal);
                var localFile = new System.IO.FileInfo(localFilePathOriginal);
                while (localFile.Exists)
                {
                    version++;
                    localFile = new System.IO.FileInfo($"{localFilePathOriginal}.{version:D3}");
                }
                if (version > 0)
                {
                    System.IO.File.Move(localFileOriginal.FullName, localFile.FullName);
                    Logger.Trace($"Se ha versionado el archivo existente '{localFileOriginal.Name}' a '{localFile.Name}'");
                }

                // Escribo el archivo en la carpeta local con el nombre original
                System.IO.File.WriteAllBytes(localFilePathOriginal, content);
                Logger.Info($"Se ha descargado el archivo {localFileOriginal.Name}");

                //Obtengo el archivo parseado a objeto
                var fileref = FileRef.Get(localFilePathOriginal, content);
                if (!fileref.ExistsErrorMessages)
                    Logger.Debug($"Se ha mapeado el archivo '{fileref.Data.FileName}'. Dependencias:{fileref.Data.Dependencias.Count}. Detalles:{fileref.Data.Detalles.Count}.");

                return fileref;
            }
            catch (Exception ex)
            {
                return new Response<FileRef>(ex);
            }
        }

        public void ExportarBUI()
        {
        }
    }
}
