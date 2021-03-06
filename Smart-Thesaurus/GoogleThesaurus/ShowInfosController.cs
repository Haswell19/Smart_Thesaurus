﻿using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GoogleThesaurus
{
    class ShowInfosController
    {
        static ShowInfosController showInfos;
        static SearchView formToModify;
        private delegate void incrementPB();
        private delegate void maxPB(int i);
        private delegate void addList(List<string> lst, string searched);

        private ShowInfosController() { }

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

        public static ShowInfosController getInstance(SearchView form)
        {
            formToModify = form;
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
        public void showKSearch(MaterialProgressBar progressbar, MaterialListView lstView, string table, string tableToJoin, string toSearch)
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
            if (tableToJoin != "")
            {
                //executer la recherche dnas toutes les données de la talbe
                using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getWordAndFileFromK().ExecuteReader())
                {
                    List<string> founded = new List<string>();
                    while (reader.Read())
                    {
                        //tester si le mot chercher match avec une partie du nom du fichier et/ou les mots de la BDD
                        if ((Regex.IsMatch(reader.GetString(1), toSearch) ||
                        Regex.IsMatch(reader.GetString(2), toSearch) ||
                        Regex.IsMatch(reader.GetString(3), toSearch) ||
                        Regex.IsMatch(reader.GetString(5), toSearch)) && !founded.Contains(reader.GetString(2)))
                        {
                            //ajouter dans un item a afficher dans la listview
                            ListViewItem item = new ListViewItem("");
                            item.SubItems.Add(reader.GetString(1));
                            item.SubItems.Add(reader.GetString(2));
                            item.SubItems.Add(reader.GetString(3));
                            lstViewItem.Add(item);
                            founded.Add(reader.GetString(2));
                        }
                    }

                    //ajouter tous les fichiers trouvé dans la listview
                    lstView.Items.AddRange(lstViewItem.ToArray());
                };
            }
            else
            {
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
                        }//rechercher dasn un fichier si le mot est présent
                        else if (WebSiteModel.getInstance().searchOnWeb(toSearch, reader.GetString(0) + "" + reader.GetString(1) + "" + reader.GetString(2)))
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
        }

        /// <summary>
        /// Affichage des résultat de la recherche sur le site web
        /// </summary>
        /// <param name="progressbar">la barre de chargement qui va montrer l'avancement de la recherche</param>
        /// <param name="lstView">la liste dans laquelle sera afficher les résultats</param>
        /// <param name="table">le nom de la table de la bdd dans la qeulle nous allons chercher les données</param>
        /// <param name="toSearch">le mot que l'utilisateur va rechercher</param>
        public void showWebSearch(MaterialProgressBar progressbar, MaterialListView lstView, string table, string tableToJoin ,string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();
            List<string> contentWord = new List<string>();

            //calculer le nombre d'objet qu'il y aura dans la recherche et y mettre la taille max a la progressbar
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getWordAndUrl().ExecuteReader())
            {
                int length = 0;
                while (reader.Read())
                {
                    length++;
                }
                //modifier la progessbar depuisl e thread princiapl
                formToModify.Invoke(new maxPB(formToModify.addMaxProgressBar), reader.StepCount);
            };

            if (tableToJoin == "")
            { 
            //recupérer les données
            using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getData(table).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //modifier la progessbar depuisl e thread princiapl
                        formToModify.Invoke(new incrementPB(formToModify.incrementProgressBar));

                        //faire le recherche sur les pages et ajouter a la liste l'url de la page qui contient le mot cherché
                        if (WebSiteModel.getInstance().searchOnWeb(toSearch, reader.GetString(0)))
                        {
                            contentWord.Add(reader.GetString(0));
                        }
                    }
                };
            }
            else
            {


                using (SQLiteDataReader reader = DataBaseModel.getInstance("dataK").getWordAndUrl().ExecuteReader())
                {
                    List<string> founded = new List<string>();
                    while (reader.Read())
                    {
                        //modifier la progessbar depuisl e thread princiapl
                        formToModify.Invoke(new incrementPB(formToModify.incrementProgressBar));

                        //rechercher si le mot est contenu dans l'url ou dans les mots dans la bdd
                        if ((Regex.IsMatch(reader.GetString(1),toSearch)||
                            Regex.IsMatch(reader.GetString(3),toSearch)) && !founded.Contains(reader.GetString(1)))
                        {
                            //ajouter a la liste des mots
                            contentWord.Add(reader.GetString(1));

                            founded.Add(reader.GetString(1));
                        }

                    }
                }
                //afficher les résultat de la recherche dans la listeview depuis le thread principal
                formToModify.Invoke(new addList(formToModify.refreshList), contentWord, toSearch);

            }
        }
    }
}

