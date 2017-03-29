using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GoogleThesaurus
{
    class ShowInfosController
    {
        static ShowInfosController showInfos;

        private ShowInfosController(){}

        /// <summary>
        /// getInstace pour singleton
        /// </summary>
        /// <returns>l'entité de ShowInfoController</returns>
        public static ShowInfosController getInstance()
        {
            if (showInfos == null)
                showInfos = new ShowInfosController();
            return showInfos;
        }

        /// <summary>
        /// Affichage des recherche dans l'interface graphique
        /// </summary>
        /// <param name="progressbar">la barre de chargement qui va montrer l'avancement de la recherche</param>
        /// <param name="lstView">la liste dans laquelle sera afficher les résultats</param>
        /// <param name="table">le nom de la table de la bdd dans la qeulle nous allons chercher les données</param>
        /// <param name="toSearch">le mot que l'utilisateur va rechercher</param>
        public void showKSearch(MaterialProgressBar progressbar, MaterialListView lstView,string table,string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();

            //on calcul la taille entière des résultats pour mettre la taille max de la progress bar
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData(table).ExecuteReader())
            {
                int lenght = 0;
                while (reader.Read())
                {
                    lenght++;
                }
                progressbar.Value = 0;
                progressbar.Maximum = lenght;
            }

            //executer la recherche dnas toutes les données de la talbe
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData(table).ExecuteReader())
            {
                while (reader.Read())
                {
                    //tester si le mot chercher match avec une partie du nom du fichier
                    if (Regex.IsMatch(reader.GetString(0), toSearch) ||
                    Regex.IsMatch(reader.GetString(1), toSearch) ||
                    Regex.IsMatch(reader.GetString(2), toSearch))
                    {
                        //ajouter dans un item a afficher dans la listview
                        ListViewItem item = new ListViewItem("");
                        item.SubItems.Add(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        lstViewItem.Add(item);
                    }

                    //rechercher dasn un fichier si le mot est présent
                    if (WebSiteModel.getInstance().searchOnWeb(toSearch, reader.GetString(0)+""+reader.GetString(1)+""+reader.GetString(2)))
                    {
                        //ajouter dans un item a afficher dans la listview
                        ListViewItem item = new ListViewItem("");
                        item.SubItems.Add(reader.GetString(0));
                        item.SubItems.Add(reader.GetString(1));
                        item.SubItems.Add(reader.GetString(2));
                        lstViewItem.Add(item);
                    }

                }

                //ajouter tous les fichiers trouvé dans la listview
                lstView.Items.AddRange(lstViewItem.ToArray());
            };
        }

        /// <summary>
        /// Affichage des résultat de la recherche sur le site web
        /// </summary>
        /// <param name="progressbar">la barre de chargement qui va montrer l'avancement de la recherche</param>
        /// <param name="lstView">la liste dans laquelle sera afficher les résultats</param>
        /// <param name="table">le nom de la table de la bdd dans la qeulle nous allons chercher les données</param>
        /// <param name="toSearch">le mot que l'utilisateur va rechercher</param>
        public void showWebSearch(MaterialProgressBar progressbar,MaterialListView lstView, string table, string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();
            List<string> contentWord = new List<string>();

            //calculer le nombre d'objet qu'il y aura dans la recherche et y mettre la taille max a la progressbar
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData(table).ExecuteReader())
            {
                int length = 0;
                while (reader.Read())
                {
                    length++;
                }
                progressbar.Maximum = length;
                progressbar.Value = 0;
            };

            //recupérer les données
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData(table).ExecuteReader())
            {
                while (reader.Read())
                {
                    progressbar.Value += 1;
                    //faire le recherche sur les pages et ajouter a la liste l'url de la page qui contient le mot cherché
                    if (WebSiteModel.getInstance().searchOnWeb(toSearch, reader.GetString(0)))
                    {
                        contentWord.Add(reader.GetString(0));
                    }
                }
            };

            //créer un item pour listview avec chaque site trouvé
            foreach (string url in contentWord)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(url);
                item.SubItems.Add(toSearch);
                item.SubItems.Add("Site Web");
                lstViewItem.Add(item);
            }
            //ajoute la list à l'affichage
            lstView.Items.AddRange(lstViewItem.ToArray());

        }
    }
}
