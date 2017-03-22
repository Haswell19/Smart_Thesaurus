using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleThesaurus
{
    class ShowInfos
    {
        static ShowInfos showInfos;

        private ShowInfos(){}

        public static ShowInfos getInstance()
        {
            if (showInfos == null)
                showInfos = new ShowInfos();
            return showInfos;
        }

        public void showKSearch(MaterialProgressBar progressbar, MaterialListView lstView,string table,string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();
            using (SQLiteDataReader reader = WorkingDataBase.getInstance("dataK").getData(table).ExecuteReader())
            {
                int lenght = 0;
                while (reader.Read())
                {
                    lenght++;
                }
                progressbar.Value = 0;
                progressbar.Maximum = lenght;
            }

                    using (SQLiteDataReader reader = WorkingDataBase.getInstance("dataK").getData(table).ExecuteReader())
            {
                while (reader.Read())
                {
                    if (Regex.IsMatch(reader.GetString(0), toSearch) ||
                    Regex.IsMatch(reader.GetString(1), toSearch) ||
                    Regex.IsMatch(reader.GetString(2), toSearch))
                    {
                        ListViewItem item = new ListViewItem("");
                        item.SubItems.Add(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        lstViewItem.Add(item);
                    }
                   /* try
                    {
                        string webpageData;
                        using (WebClient webClient = new WebClient())
                            webpageData = webClient.DownloadString(reader.GetString(0)+reader.GetString(1)+reader.GetString(2));
                        bool containsWord = webpageData.Contains(toSearch);
                        progressbar.Value += 1;
                        if (containsWord)
                        {
                            ListViewItem item = new ListViewItem("");
                            item.SubItems.Add(reader.GetString(0));
                            item.SubItems.Add(reader.GetString(1));
                            item.SubItems.Add(reader.GetString(2));
                            lstViewItem.Add(item);
                        }
                        
                    }
                    catch
                    {
                    }*/

                }
                lstView.Items.AddRange(lstViewItem.ToArray());
            };
        }

        public void showWebSearch(MaterialProgressBar progressbar,MaterialListView lstView, string table, string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();
            List<string> contentWord = new List<string>();
            using (SQLiteDataReader reader = WorkingDataBase.getInstance("dataK").getData(table).ExecuteReader())
            {
                int length = 0;
                while (reader.Read())
                {
                    length++;
                }
                progressbar.Maximum = length;
                progressbar.Value = 0;
            };
            using (SQLiteDataReader reader = WorkingDataBase.getInstance("dataK").getData(table).ExecuteReader())
            {
                while (reader.Read())
                {
                    progressbar.Value += 1;
                    if (WebSiteSearch.getInstance().searchOnWeb(toSearch, reader.GetString(0)))
                    {
                        contentWord.Add(reader.GetString(0));
                    }
                }
            };

            foreach (string url in contentWord)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(url);
                item.SubItems.Add(toSearch);
                item.SubItems.Add("Site Web");
                lstViewItem.Add(item);
            }
            lstView.Items.AddRange(lstViewItem.ToArray());

        }
    }
}
