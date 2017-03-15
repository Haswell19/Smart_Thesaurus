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
            SQLiteConnection.CreateFile(strDataBaseName+".sqlite");
        }

        /// <summary>
        /// Commencer la conneciton sur une base de donnée
        /// </summary>
        public void startConneciton()
        {
            //if (!File.Exists(strDataBaseName + ".sqlite"))
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
    }
}
