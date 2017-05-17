using System;
using System.Diagnostics;
using System.IO;

namespace UpdateDataCron
{
    class FileKModel
    {
        const string PATH = @"K:\INF\Eleves\Temp";

        static FileKModel searchOnK;
        static DataBaseModel dbWork;

        private FileKModel() { }

        public static FileKModel getInstance()
        {
            if (searchOnK == null)
                searchOnK = new FileKModel();
            if (dbWork == null)
                dbWork = DataBaseModel.getInstance("dataK");
            return searchOnK;
        }

        /// <summary>
        /// Récuperer touts les fichiers du K
        /// </summary>
        /// <param name="search">option de rechercher pour les fichier du K ("*" = touts les fichiers)</param>
        /// <returns>Liste qui contient tous les résultats de la recherche</returns>
        public string[] getAllFiles(string search)
        {
            string[] lstFiles = Directory.GetFiles(PATH, search, SearchOption.AllDirectories);
            return lstFiles;
        }

        /// <summary>
        /// Enlever le chemin et l'extension du fichier
        /// </summary>
        /// <param name="name">la string avec le chemin et l'extention</param>
        /// <returns>nom du fichier</returns>
        public string getFileName(string name)
        {
            string[] str;
            //enlever l'extenton du fichier s'il en a une
            if (getExtention(name).Length != 0)
            {
                name = name.Replace(getExtention(name), "");
            }

            if (name[name.Length - 1] == '.')
            {
                name = name.Remove(name.Length - 1);
            }
            //enlever tout le chemin qui se ttrouve avant le nom du fichier
            str = name.Split('\\');
            return str[str.Length - 1];
        }

        /// <summary>
        /// recupère l'extention du fichier
        /// </summary>
        /// <param name="file">la string avec le nom</param>
        /// <returns>seulement l'extention</returns>
        public string getExtention(string file)
        {
            //tester s'il contient une extention
            if (file.Contains("."))
            {
                string[] extention;
                //retourenre le string pour que l'extention soit au début
                file = reverseString(file);
                //enlever le diviser la string avec les . donc après l'extention
                extention = file.Split('.');
                //stocker l'extention
                file = reverseString(extention[0]);
                //si la string est plsu grande que 4 caractère ce n'est pas une extention

            }
            else
            {
                file = "";
            }
            return file;
        }

        /// <summary>
        /// Méthode utiliser pour retourener une string
        /// </summary>
        /// <param name="file">string a retourner</param>
        /// <returns>la string retournée</returns>
        private static string reverseString(string file)
        {
            //stocker la string caractère par caractère et retourner le tableau
            char[] arr = file.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// Récuperer le chemin d'accés au fichier
        /// </summary>
        /// <param name="file">le fichier</param>
        /// <returns>le chemin</returns>
        public string getPath(string file)
        {
            string path = "";
            //on récupère l'extention
            string extention = getExtention(file);
            //on récupère le nom du fichier
            string name = getFileName(file);

            //on enlève le nom et l'extention du fichier
            path = file.Replace(name + "." + extention, "");
            //retour du chemin
            return path;
        }

        /// <summary>
        /// Ouvrir un fichier
        /// </summary>
        /// <param name="fileAndPath">le chemin d'accés ainsi que son nom</param>
        public void openFile(string fileAndPath)
        {
            //ouverture du fichier
            ProcessStartInfo psi = new ProcessStartInfo(fileAndPath);
            Process.Start(psi);
        }
    }
}
