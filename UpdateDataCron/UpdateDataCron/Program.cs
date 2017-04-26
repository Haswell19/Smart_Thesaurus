using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateDataCron
{
    class Program
    {
        //nom de la bdd
        const string DBNAME = "dataK";

        static void Main(string[] args)
        {
            //créer la bdd et son interface si elle n'existe pas
            DataBaseModel.getInstance(DBNAME).createInterfaceAndStoreData();
        }
    }
}
