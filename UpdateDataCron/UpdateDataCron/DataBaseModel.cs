using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using UpdateDataCron;
using System.Text.RegularExpressions;

namespace UpdateDataCron
{
    class DataBaseModel
    {
        static DataBaseModel instance;
        static string strDataBaseName;
        SQLiteConnection myConnexion;

        private DataBaseModel() { }

        /// <summary>
        /// Récuperer l'instance actuelle de cette classe
        /// </summary>
        /// <param name="_dataBase">la base de données sur la quelle vous voulez travailler</param>
        /// <returns>l'instance actuel de cette classe</returns>
        public static DataBaseModel getInstance(string _dataBase)
        {
            //créer une inistance si elle n'existe pas
            if (instance == null)
                instance = new DataBaseModel();
            strDataBaseName = _dataBase;
            return instance;
        }

        /// <summary>
        /// Créer une base de données
        /// </summary>
        public void createDataBase()
        {
            //créer la base de données si elle n'existe pas
            if (!File.Exists(strDataBaseName + ".sqlite"))
                SQLiteConnection.CreateFile(strDataBaseName + ".sqlite");
        }

        /// <summary>
        /// Commencer la conneciton sur une base de donnée
        /// </summary>
        public void startConneciton()
        {
            //ouverture d'une connexion a la bdd
            myConnexion = new SQLiteConnection("Data Source=" + strDataBaseName + ".sqlite;Version=3;");
            myConnexion.Open();
        }

        /// <summary>
        /// Arreter la conneciton qui est en cour
        /// </summary>
        public void killConnection()
        {
            //arret de la connexion
            myConnexion.Close();
        }

        /// <summary>
        /// Supprimer toutes les données d'une table afin d'avoir les données à jour
        /// par exemple si des fichiers sont supprimer ou ne pas avoir deux fois 
        /// la même entrée
        /// </summary>
        /// <param name="table">nom de la table</param>
        public void deleteAllTableData(string table)
        {
            //s'il n'y a pas de connexion la créer
            if (myConnexion == null)
                startConneciton();
            //supprimer les données d'une table
            string sqlRequest = "delete from " + table + " WHERE 1=1";
            SQLiteCommand sqlDelete = new SQLiteCommand(sqlRequest, myConnexion);
            sqlDelete.ExecuteNonQuery();
        }

        /// <summary>
        /// Créer la table
        /// </summary>
        /// <param name="tableToCreate">nom de la table</param>
        public void creatInfrastructure(string tableToCreate)
        {
            //s'il n'y a pas de connexion la créer
            if (myConnexion == null)
                startConneciton();
            //faire la requete et l'executer
            SQLiteCommand request = new SQLiteCommand(tableToCreate, myConnexion);
            request.ExecuteNonQuery();
        }

        /// <summary>
        /// ajouter des données a une talbe
        /// </summary>
        /// <param name="table">nom de la table</param>
        /// <param name="columnAndType">nom de colonne et le type</param>
        /// <param name="valueToAdd">les données ajouter</param>
        public void insertData(string table, string columnAndType, string valueToAdd)
        {
            //s'il n'y a pas de connexion la créer
            if (myConnexion == null)
                startConneciton();
            //créer la requete et l'executer
            string request = "insert into " + table + " (" + columnAndType + ") values (" + valueToAdd + ")";
            SQLiteCommand toExectue = new SQLiteCommand(request, myConnexion);
            toExectue.ExecuteNonQuery();
        }

        /// <summary>
        /// récupérer les données
        /// </summary>
        /// <param name="table">nom de la table</param>
        /// <returns>les données reçue</returns>
        public SQLiteCommand getData(string table)
        {
            //s'il n'y a pas de connexion la créer
            if (myConnexion == null)
                startConneciton();
            //récuperer les données
            string sqlRequest = "select * from " + table;
            return new SQLiteCommand(sqlRequest, myConnexion);
        }

        /// <summary>
        /// Créer la structure de la bdd
        /// </summary>
        public void createInterfaceAndStoreData()
        {
            createDataBase();
            startConneciton();
            //DATA FROM K
            //tester si la table existe
            try
            {
                creatInfrastructure("create table t_files (fileid  INTEGER PRIMARY KEY AUTOINCREMENT,path text,name text,extention text)");
            }
            catch
            {

            }
            //vider la talbe pour avoir les nouvelles données
            deleteAllTableData("t_files");
            //ajouter a la table les infomrations des fichiers
            foreach (string l in FileKModel.getInstance().getAllFiles("*"))
            {
                insertData("t_files", "path, name, extention", "'" + FileKModel.getInstance().getPath(l) + "','" + FileKModel.getInstance().getFileName(l) + "','." + FileKModel.getInstance().getExtention(l) + "'");
            }
            //END DATA FROM K
            //DATA FROM WEB
            //tester si la table existe
            try
            {
                creatInfrastructure("create table t_url (webid  INTEGER PRIMARY KEY AUTOINCREMENT,path text)");
            }
            catch
            {

            }
            //vider la talbe pour avoir les nouvelles données
            deleteAllTableData("t_url");
            //ajouter a la table les infomrations des fichiers
            foreach (string l in WebSiteModel.getInstance().getAllUrls())
            {
                insertData("t_url", "path", "'" + l + "'");
            }
            //END DATA FROM WEB
            //WORD FORM FILES
            //tester si la table existe ou pas
            try
            {
                creatInfrastructure("create table t_wordK (wordid  INTEGER PRIMARY KEY AUTOINCREMENT,word text,wordToFile INTEGER,  FOREIGN KEY(wordToFile) REFERENCES t_files(fileid))");
            }
            catch { }
            //vider la talbe pour avoir les nouvelles données
            deleteAllTableData("t_wordK");
            //ajouter les données
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData("t_files").ExecuteReader())
            {
                string fileData;
                while (reader.Read())
                {
                    //lire le fichier
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                        
                            fileData = webClient.DownloadString(reader.GetString(1) + reader.GetString(2) + reader.GetString(3));

                            string[] word = fileData.Split(' ');
                            for (int i = 0; i < word.Length; i++)
                            {
                                if (word[i] != "")
                                {
                                    if (word[i].Contains(@"\"))
                                    {
                                        word[i] = word[i].Replace(@"\", @"\\");
                                    }
                                    if (word[i].Contains(@"'"))
                                    {
                                        word[i] = word[i].Replace(@"'", @"");
                                    }
                                }
                        try
                        {
                            insertData("t_wordK", "word,wordToFile", "'" + word[i] + "',(SELECT fileid from t_files where name = '" + reader.GetString(2) + "')");
                            }
                        catch
                        { }
                    }

                }

            }

        
    
            //END WORD FROM FILES
            //WORD FORM WEB
            //tester si la table existe ou pas
            try
            {
                creatInfrastructure("create table t_wordSite (wordid  INTEGER PRIMARY KEY AUTOINCREMENT,word text,wordToURL INTEGER,  FOREIGN KEY(wordToURL) REFERENCES t_url(webid))");
}
            catch { }
            //vider la talbe pour avoir les nouvelles données
            deleteAllTableData("t_wordSite");
            //ajouter les données
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData("t_url").ExecuteReader())
            {
                string fileData;
                while (reader.Read())
                {
                    try
                    {
                        //lire l'url
                        using (System.Net.WebClient webClient = new System.Net.WebClient())
                        fileData = webClient.DownloadString(reader.GetString(1));
                    fileData = Regex.Replace(fileData, "<.*?>", string.Empty);
                        fileData = deleteHTMLchar(fileData);

                        insertData("t_wordSite", "word,wordToUrl", "'"+fileData+"',(SELECT webid from t_url where path = '" + reader.GetString(1) + "')");
                     }
                    catch
                    { }
                }

            }

        }

        public string deleteHTMLchar(string toModify)
{
    if (toModify.Contains("\t"))
    {
        toModify = toModify.Replace("\t", "");
    }
    if (toModify.Contains("\n"))
    {
        toModify = toModify.Replace("\n", "");
    }
    if (toModify.Contains("\r"))
    {
        toModify = toModify.Replace("\r", "");
    }
    if (toModify.Contains("'"))
    {
        toModify = toModify.Replace("'", "");
    }
    return toModify;
}
    }

}
