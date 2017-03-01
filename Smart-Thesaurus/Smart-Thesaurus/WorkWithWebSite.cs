using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SpiderLogic;

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
            string url = "http://etml.ch";
            WebClient client = new WebClient();
            SpiderLogic.SpiderLogic spiderUrl = new SpiderLogic.SpiderLogic();
            List<string> allUrls = new List<string>(spiderUrl.GetUrls(url, true));
            List<string> correctUrl = new List<string>();
            foreach (string str in allUrls)
            {
                string newstr  = str.Replace("http:/", "http://");
                correctUrl.Add(newstr);
            }
            
            for (int i = 0; i < correctUrl.Count; i++)
            {
                
                Uri myUri = new Uri(correctUrl[i]);
                client.DownloadFileAsync(myUri, "page"+i+".html");
            }
            
        }
    }
}
