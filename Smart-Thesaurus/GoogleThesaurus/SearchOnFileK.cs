using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleThesaurus
{
    class SearchOnFileK
    {
        const string PATH = @"K:\INF\Eleves\Temp";

        static SearchOnFileK searchOnK;
        static WorkingDataBase dbWork;

        private SearchOnFileK() { }

        public static SearchOnFileK getInstance()
        {
            if (searchOnK == null)
                searchOnK = new SearchOnFileK();
            if (dbWork == null)
                dbWork = WorkingDataBase.getInstance("dataK");
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
        /// Stocker les fichiers dans la DB
        /// </summary>
        public void storeToDB()
        {
            //mettre en place l'environnement
            dbWork.createDataBase();
            dbWork.startConneciton();

            //tester si la table existe
            try
            {
                dbWork.creatInfrastructure("create table t_files (path text,name text,extention text)");
            }
            catch
            {
                
            }

            //ajouter a la table les infomrations des fichiers
            foreach (string l in getAllFiles("*"))
            {
                dbWork.insertData("t_files", "path, name, extention", "'" + getPath(l) + "','" + getFileName(l) + "','." + getExtention(l) + "'");
            }
        }

        /// <summary>
        /// Enlever le chemin et l'extension du fichier
        /// </summary>
        /// <param name="name">la string avec le chemin et l'extention</param>
        /// <returns>nom du fichier</returns>
        private string getFileName(string name)
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
        private string getExtention(string file)
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
                if (file.Length > 4)
                {
                    file = "";
                }
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

        private string getPath(string file)
        {
            string path = "";
            string extention = getExtention(file);
            string name = getFileName(file);

            path = file.Replace(name + "." + extention, "");

            return path;
        }

        public void openFile(string fileAndPath)
        {
            ProcessStartInfo psi = new ProcessStartInfo(fileAndPath);
            Process.Start(psi);
     
        }
    }
}
