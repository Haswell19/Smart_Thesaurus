using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SpiderLogic;
using System.IO;
using MaterialSkin.Controls;

namespace Smart_Thesaurus
{
    class WorkWithWebSite
    {
        static WorkWithWebSite webService;

        private WorkWithWebSite()
        {

        }

        public static WorkWithWebSite getInstance()
        {
            if (webService == null)
            {
                webService = new WorkWithWebSite();
                return webService;
            }
            return webService;
        }

        public void DownloadFile()
        {
            //lien du site
            string url = "http://etml.ch";
            WebClient client = new WebClient();
            SpiderLogic.SpiderLogic spiderUrl = new SpiderLogic.SpiderLogic();

            //stocker les url (une fois sous mauvais forme puis ce sera transformé
            List<string> allUrls = new List<string>(spiderUrl.GetUrls(url, true));
            List<string> correctUrl = new List<string>();

            foreach (string str in allUrls)
            {
                string newstr = str.Replace("http:/", "http://");
                correctUrl.Add(newstr);
            }

            for (int i = 0; i < correctUrl.Count; i++)
            {

                Uri myUri = new Uri(correctUrl[i]);
                string name = System.IO.Path.GetFileName(myUri.LocalPath);
                if (name.Contains(".html") || name.Contains(".php"))
                {
                    client.DownloadFile(myUri, name);
                }
                else
                {
                    client.DownloadFile(myUri, name + ".html");
                }

            }
            List<string> htmlFiles = new List<string>(getHTMLfilesOnDirectory(Directory.GetCurrentDirectory()));
        }

        /// <summary>
        /// Lecture de la ligne et stocker l'index du fichier et celui de la ligne dans le dictionnaire.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="files"></param>
        /// <param name="lstView"></param>
        public void searchWord(string word, List<string> files, MaterialListView lstView)
        {
            List<int> indexWordFounds = new List<int>();
            Dictionary<int, int> indexWordAndLines = new Dictionary<int, int>();
            for (int i = 0; i < files.Count(); i++)
            {
                for (int j = 0; j < File.ReadAllLines(files[i]).Count(); j++)
                {
                    string line = File.ReadAllLines(files[i])[j];
                    if (line.Contains(word))
                    {
                        indexWordAndLines.Add(i, j);
                    }
                }
            }
            FileStream inFile = new FileStream(@"H:\C#\Chapter.14\FriendInfo.txt", FileMode.Open, FileAccess.Read);
        }

        public List<string> getHTMLfilesOnDirectory(string path)
        {
            List<string> htmlNames = new List<string>();

            string[] fileName = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (string str in fileName)
            {
                /*string file = WorkWithFileK.getInstance().getFileName(str);
                file += "."+WorkWithFileK.getInstance().getExtention(str);*/
                htmlNames.Add(str);
            }

            return htmlNames;
        }
    }
}
