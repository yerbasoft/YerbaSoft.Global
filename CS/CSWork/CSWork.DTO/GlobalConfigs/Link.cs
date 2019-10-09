using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSWork.DTO.GlobalConfigs
{
    public class Link
    {
        /// <summary>
        /// Nombre a Mostrar para el Link
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Indica si Éste objeto es un SubMenu
        /// </summary>
        public bool IsSubMenu { get; set; }

        #region Folder
        /// <summary>
        /// Indica si Path es el acceso a una carpeta
        /// </summary>
        public bool IsFolder { get; set; }

        /// <summary>
        /// Sólo para "IsFolder=true" -> true: Muestra el contenido de la carpeta como subitems. False: Representa un link a la carpeta
        /// </summary>
        public bool ShowFolderContent { get; set; }
        /// <summary>
        /// Sólo para "IsFolder=true" && ShowFolderContent -> Indica si se deben mostrar las subcarpetas en cascada
        /// </summary>
        public bool ShowSubFolders { get; set; }
        /// <summary>
        /// Sólo para "IsFolder=true" && ShowFolderContent -> Indica si se debe agrear un menú de "Abrir Carpeta"
        /// </summary>
        public bool ShowOpenFolder { get; set; }
        /// <summary>
        /// Sólo para "IsFolder=true" && ShowFolderContent -> Indica el filtro que se deberá utilizar para obtener los archivos dentro de la carpeta (no aplica a subcarpetas)
        /// </summary>
        public string FolderFileFilter { get; set; }

        #endregion
        /// <summary>
        /// Indica si Path es la ruta a un archivo
        /// </summary>
        public bool IsFile { get; set; }
        /// <summary>
        /// Indica que el Link en realidad es un separador de menú
        /// </summary>
        public bool IsSeparator { get; set; }

        /// <summary>
        /// Valor del Link
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Icono que se utilizará para motrar el elemento. puede ser una ruta a un archivo o puede referirse al nombre del recurso local embebido
        /// </summary>
        public string Icon { get; set; }

        public List<Link> SubLinks { get; set; } = new List<Link>();

        public static Link GetNew(bool isSubMenu = false, bool isFolder = false, bool isFile = false, bool isSeparator = false)
        {
            var link = new Link();
            link.IsSubMenu = isSubMenu;
            link.IsFolder = isFolder;
            link.IsFile = isFile;
            link.IsSeparator = isSeparator;
            if (isSubMenu)
            {
                link.Icon = "Open_Folder";
                link.Name = "Nueva Carpeta";
            } else if (isFolder)
            {
                link.Name = "Nueva Carpeta";
                link.Icon = "Open_Folder_yellow";
                link.ShowFolderContent = true;
                link.ShowSubFolders = true;
                link.FolderFileFilter = "*.*";
            } else if (isFile)
            {
                link.Name = "Nuevo Archivo";
                link.Icon = "file";
            } else if(isSeparator)
            {
                link.Name = "---";
                link.Icon = "minus";
            }

            return link;
        }

        public Link FindParent(Link find)
        {
            if (SubLinks.Any(p => p == find))
                return this;

            foreach (var link in SubLinks)
            {
                var founded = link.FindParent(find);
                if (founded != null)
                    return founded;
            }

            return null;
        }
    }
}
