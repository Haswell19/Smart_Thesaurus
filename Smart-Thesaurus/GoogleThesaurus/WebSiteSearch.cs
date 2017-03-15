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
        const String WEBSITE = @"http:\\etml.ch";
        static WebSiteSearch webSearch;

        private WebSiteSearch() { }

        public static WebSiteSearch getInstance()
        {
            if (webSearch == null)
                webSearch = new WebSiteSearch();
            return webSearch;
        }

        public void searchOnWeb(string word)
        {
            SpiderLogic.SpiderLogic spiderUrl = new SpiderLogic.SpiderLogic();
            List<string> allUrl = new List<string>(spiderUrl.GetUrls(WEBSITE, true));
            List<string> correctUrl = new List<string>();

            foreach (string str in allUrl)
            {
                string newstr = str.Replace("http:/", "http://");
                correctUrl.Add(newstr);
            }

            string webpageData;
            using (System.Net.WebClient webClient = new System.Net.WebClient())
                webpageData = webClient.DownloadString("http://www.cnn.com");

            var containsWord = webpageData.Contains(word);
        }

        /// <summary>
        /// Returns all urls in string content
        /// [Includes javascrip:, mailto:, other domains too]
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string[] GetAllUrls(string str)
        {
            string pattern = @"<a.*?href=[""'](?<url>.*?)[""'].*?>(?<name>.*?)</a>";

            System.Text.RegularExpressions.MatchCollection matches
                = System.Text.RegularExpressions.Regex.Matches(str, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            string[] matchList = new string[matches.Count];

            int c = 0;

            foreach (System.Text.RegularExpressions.Match match in matches)
                matchList[c++] = match.Groups["url"].Value;

            return matchList;
        }
    }
}
