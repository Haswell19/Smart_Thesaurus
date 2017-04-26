using System.Collections.Generic;
using System.Data.SQLite;

namespace UpdateDataCron
{
    class WebSiteModel
    {
        //constante de l'url
        const string WEBSITE = @"http://etml.ch";

        static WebSiteModel webSearch;

        private WebSiteModel() { }

        public static WebSiteModel getInstance()
        {
            if (webSearch == null)
                webSearch = new WebSiteModel();
            return webSearch;
        }

       /* public string[] ReadWord()
        {
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData("t_url").ExecuteReader())
            {
                while (reader.Read())
                {
                     reader.GetString(0)
                }
            }
        }*/

        /// <summary>
        /// récuperer tous les url
        /// </summary>
        /// <returns>list de tous les url</returns>
        public List<string> getAllUrls()
        {
            //utilisation de la DLL spider logic
            SpiderLogic.SpiderLogic spiderUrl = new SpiderLogic.SpiderLogic();
            //mettre tous les url dans la list allurl
            List<string> allUrl = new List<string>(spiderUrl.GetUrls(WEBSITE, true));

            List<string> correctUrl = new List<string>();

            //changer tous les url car la DLL les retourne avec http:/ ce qui n'est pas utilisable
            foreach (string str in allUrl)
            {
                string newstr = str.Replace("http:/", "http://");
                correctUrl.Add(newstr);
            }
            //retour de la list
            return correctUrl;
        }

        /// <summary>
        /// faire une recherche sur une page web
        /// </summary>
        /// <param name="word">mot a rechercher</param>
        /// <param name="url">la page sur laquelle faire la recherche</param>
        /// <returns>un bool si oui ou non le site contient le mot</returns>
        public bool searchOnWeb(string word, string url)
        {
            string webpageData;

            //faire cela car si ce n'est pas un fichier que le PC peut lire ça ne crash pas
            try
            {
                //lire la apge et mettre le tout dans une seul string
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                    webpageData = webClient.DownloadString(url);
                //tester si le mot cherhcer est contenu dans la page
                bool containsWord = webpageData.Contains(word);
                //retour du résultat
                return containsWord;
            }
            catch
            {
                return false;
            }
        }

    }
}
