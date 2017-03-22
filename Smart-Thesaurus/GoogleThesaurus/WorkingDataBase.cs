using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleThesaurus
{
    class WorkingDataBase
    {
        static WorkingDataBase instance;
        static string strDataBaseName;
        SQLiteConnection myConnexion;

        private WorkingDataBase() { }

        /// <summary>
        /// Récuperer l'instance actuelle de cette classe
        /// </summary>
        /// <param name="_dataBase">la base de données sur la quelle vous voulez travailler</param>
        /// <returns>l'instance actuel de cette classe</returns>
        public static WorkingDataBase getInstance(string _dataBase)
        {
            if (instance == null)
                instance = new WorkingDataBase();
            strDataBaseName = _dataBase;
            return instance;
        }

        /// <summary>
        /// Créer une base de données
        /// </summary>
        public void createDataBase()
        {
            if (!File.Exists(strDataBaseName + ".sqlite"))
                SQLiteConnection.CreateFile(strDataBaseName+".sqlite");
        }

        /// <summary>
        /// Commencer la conneciton sur une base de donnée
        /// </summary>
        public void startConneciton()
        {
            myConnexion = new SQLiteConnection("Data Source=" + strDataBaseName + ".sqlite;Version=3;");
            myConnexion.Open();
        }

        /// <summary>
        /// Arreter la conneciton qui est en cour
        /// </summary>
        public void killConnection()
        {
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
            string sqlRequest = "delete from " + table+" WHERE 1=1";
            SQLiteCommand sqlDelete = new SQLiteCommand(sqlRequest, myConnexion);
            sqlDelete.ExecuteNonQuery();
        }

        public void creatInfrastructure(string tableToCreate)
        {
            if (myConnexion == null)
                startConneciton();
            SQLiteCommand request = new SQLiteCommand(tableToCreate, myConnexion);
            request.ExecuteNonQuery();
        }

        public void insertData(string table, string columnAndType, string valueToAdd)
        {
            if (myConnexion == null)
                startConneciton();
            string request = "insert into "+table+" ("+columnAndType+") values ("+valueToAdd+")";
            SQLiteCommand toExectue = new SQLiteCommand(request, myConnexion);
            toExectue.ExecuteNonQuery();    
        }

        public SQLiteCommand getData(string table)
        {
            string sqlRequest = "select * from " + table;
            return new SQLiteCommand(sqlRequest, myConnexion);
        }

        public void createInterfaceAndStoreData()
        {
            createDataBase();
            startConneciton();
            //DATA FROM K
            //tester si la table existe
            try
            {
                creatInfrastructure("create table t_files (path text,name text,extention text)");
            }
            catch
            {

            }
            //vider la talbe pour avoir les nouvelles données
            deleteAllTableData("t_files");
            //ajouter a la table les infomrations des fichiers
            foreach (string l in SearchOnFileK.getInstance().getAllFiles("*"))
            {
                insertData("t_files", "path, name, extention", "'" + SearchOnFileK.getInstance().getPath(l) + "','" + SearchOnFileK.getInstance().getFileName(l) + "','." + SearchOnFileK.getInstance().getExtention(l) + "'");
            }
            //END DATA FROM K
            //DATA FROM WEB
            //tester si la table existe
            try
            {
                creatInfrastructure("create table t_url (path text)");
            }
            catch
            {

            }
            //vider la talbe pour avoir les nouvelles données
            deleteAllTableData("t_url");
            //ajouter a la table les infomrations des fichiers
            foreach (string l in WebSiteSearch.getInstance().getAllUrls())
            {
                insertData("t_url", "path", "'" + l + "'");
            }
            //END DATA FROM WEB
        }
    }
}
