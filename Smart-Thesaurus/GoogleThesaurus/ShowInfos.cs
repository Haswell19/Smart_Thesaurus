using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
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

        public void showKSearch(MaterialListView lstView,string table,string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();
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
                   
                }
                lstView.Items.AddRange(lstViewItem.ToArray());
            };
        }

        public void showWebSearch(MaterialListView lstView, string table, string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();
            List<string> contentWord = new List<string>();
            using (SQLiteDataReader reader = WorkingDataBase.getInstance("dataK").getData(table).ExecuteReader())
            {
                while (reader.Read())
                {
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
