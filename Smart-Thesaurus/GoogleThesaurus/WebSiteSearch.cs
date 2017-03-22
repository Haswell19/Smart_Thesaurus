using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpiderLogic;
namespace GoogleThesaurus
{
    class WebSiteSearch
    {
        const String WEBSITE = @"http://etml.ch";
        static WebSiteSearch webSearch;

        private WebSiteSearch() { }

        public static WebSiteSearch getInstance()
        {
            if (webSearch == null)
                webSearch = new WebSiteSearch();
            return webSearch;
        }

        public List<string> getAllUrls()
        {
            SpiderLogic.SpiderLogic spiderUrl = new SpiderLogic.SpiderLogic();
            List<string> allUrl = new List<string>(spiderUrl.GetUrls(WEBSITE, true));
            List<string> correctUrl = new List<string>();

            foreach (string str in allUrl)
            {
                string newstr = str.Replace("http:/", "http://");
                correctUrl.Add(newstr);
            }

            return correctUrl;
        }

        public bool searchOnWeb(string word, string url)
        {
            string webpageData;

            using (System.Net.WebClient webClient = new System.Net.WebClient())
                webpageData = webClient.DownloadString(url);

            bool containsWord = webpageData.Contains(word);
            return containsWord;
        }

    }
}
