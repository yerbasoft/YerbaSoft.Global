using SIR.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIR.BcoCiudad.BLL.DTO.File
{
    public class FileRef
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public FileHeader Header { get; set; }
        public IList<FileDependencia> Dependencias { get; set; } = new List<FileDependencia>();
        public IList<FileDetalle> Detalles { get; set; } = new List<FileDetalle>();

        private FileRef() { }

        public static Response<FileRef> Get(string filePath) => Get(filePath, System.IO.File.ReadAllBytes(filePath));
        public static Response<FileRef> Get(string filePath, byte[] content)
        {
            var fileref = new FileRef() { FilePath = filePath, FileName = new System.IO.FileInfo(filePath).Name };
            var response = new Response<FileRef>(true).SetData(fileref);
            var alltext = Encoding.UTF8.GetString(content);
            var rows = alltext.Split(new char[] { '\r', '\n' }).Where(p => !string.IsNullOrEmpty(p));

            var splitter = new SIR.Common.Batch.BatchSplitter();
            foreach (var row in rows)
            {
                switch (row.Substring(0, 2))
                {
                    case FileHeader.Index:
                        var header = splitter.Deserialize<FileHeader>(row);
                        response.Add(header);

                        if (fileref.Header != null)
                            return new Response<FileRef>($"El archivo {fileref.FilePath} posee más de un registro con índice de Cabecera.");

                        fileref.Header = header.Data;
                        break;

                    case FileDependencia.Index:
                        var dependencia = splitter.Deserialize<FileDependencia>(row);
                        response.Add(dependencia);

                        fileref.Dependencias.Add(dependencia.Data);
                        break;

                    case FileDetalle.Index:
                        var detalle = splitter.Deserialize<FileDetalle>(row);
                        response.Add(detalle);

                        fileref.Detalles.Add(detalle.Data);
                        break;
                }
            }

            return response;
        }
    }
}