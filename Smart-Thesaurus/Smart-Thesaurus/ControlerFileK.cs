﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin.Controls;
using System.Text.RegularExpressions;
using System.Data;

namespace Smart_Thesaurus
{
    class ControlerFileK
    {
        static ControlerFileK controlerK;
        string[] lstFiles;
        ListViewItem[] lstItem;
        string path;
        static protected MaterialListView _lstView;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_lstBox"></param>
        private ControlerFileK() {}

        /// <summary>
        /// Avoir une seul instance de COntroller K
        /// </summary>
        /// <returns>contrller K</returns>
        public static ControlerFileK getInstance(MaterialListView _lstBox)
        {
            if (controlerK == null)
            {
                //faire un new ControlerFileK et y cherhcer les infos
                controlerK = new ControlerFileK();
                _lstView = _lstBox;
            }

            return controlerK;
        }

        /// <summary>
        /// Chercher un mot dsan tous les fichiers présents
        /// </summary>
        /// <param name="_toSearch"></param>
        /// <param name="_lstView"></param>
        public void SearchWord(string _toSearch, string _path)
        {
            //avoir tous les élments avec les informations pour pouvoir chercher partout
            indexationFiles(_path);
            //nouvelle liste d'item
            ListViewItem[] searchedItem;

            bool[] index = new bool[lstItem.Length];

            int nbrSearchedItem = 0;

            for (int i = 0; i < lstItem.Length; i++)
            {
                //tester les 3 collones pour afficher les élèments
                if (Regex.IsMatch(_lstView.Items[i].SubItems[1].Text, _toSearch)||
                    Regex.IsMatch(_lstView.Items[i].SubItems[2].Text,_toSearch)||
                    Regex.IsMatch(_lstView.Items[i].SubItems[3].Text,_toSearch))
                {
                    //mettre tru dans un tableau et incrémenter une variable
                    index[i] = true;
                    nbrSearchedItem++;
                }
                else
                {
                    index[i] = false;
                }
            }
            
            //definir la taille du tableau des élèments 
            searchedItem = new ListViewItem[nbrSearchedItem];
            //lstFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            nbrSearchedItem = 0;
            for (int i = 0; i < lstItem.Length; i++)
            {
                if (index[i])
                {
                    //créer un item s'il contient le mot choisit
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(lstFiles[i].Replace(getFileName(lstFiles[i]) + getExtention(lstFiles[i]), ""));
                    item.SubItems.Add(getFileName(lstFiles[i].Replace("."+ getExtention(lstFiles[i]), "")));
                    item.SubItems.Add(getExtention(lstFiles[i]));
                    searchedItem[nbrSearchedItem] = item;
                    nbrSearchedItem++;
                }
            }
            //suprimer tout de la liste view et afficher les nouveau items
            _lstView.Items.Clear();
            _lstView.Items.AddRange(searchedItem);
            lstItem = searchedItem;
            
        }


       public void storeDataInDataSet(string _path)
        {
            /*DataSet dataSet = new DataSet();
            DataSetTemp dataTmp = new DataSetTemp();
            dataTmp.Tables["t_fileTemp"];*/
        }

        /// <summary>
        /// Indexer tous les fichiers du K
        /// </summary>
        /// <param name="_path"></param>
        public void indexationFiles(string _path)
        {
            //tester si la personne est connectée au K ou pas
            try
            {
                path = _path;
                _lstView.Items.Clear();
                //recupérer tous les fihciers du K
                lstFiles = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

                //faire une liste d'élèments à afficher
                lstItem = new ListViewItem[lstFiles.Length];

                //stocker le nom, chemin  et extension du fichier
                for (int i = 0; i < lstFiles.Length; i++)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(lstFiles[i].Replace(getFileName(lstFiles[i]) + getExtention(lstFiles[i]), ""));
                    item.SubItems.Add(getFileName(lstFiles[i].Replace("."+ getExtention(lstFiles[i]), "")));
                    item.SubItems.Add(getExtention(lstFiles[i]));
                    lstItem[i] = item;
                }
                //ajouter tout le tableau a la liste view
                _lstView.Items.AddRange(lstItem);
            }
            catch
            {
                //infomraer l'utilisatuer qu'il n'est pas connecté au K
                MessageBox.Show("Vous n'êtes pas connecté au K:\\");
            }
        }

        /// <summary>
        /// ouvrir le fichier
        /// </summary>
        /// <param name="index"></param>
        public void OpenFile(int index)
        {
            //problème que l'applicaiton crash si l'utilisateur
            //ferme le fihcier
            try
            {
                //recupérer le fichier
                string file = _lstView.Items[index].SubItems[1].Text+"\\"+ _lstView.Items[index].SubItems[2].Text+"."+ _lstView.Items[index].SubItems[3].Text;
                //ouvrir le fichier
                ProcessStartInfo psi = new ProcessStartInfo(file);
                Process.Start(psi);
            }
            catch { }

        }

        /// <summary>
        /// Enlever le chemin et l'extension du fichier
        /// </summary>
        /// <param name="name">la string avec le chemin et l'extention</param>
        /// <returns>nom du fichier</returns>
        public string getFileName(string name)
        {

            string[] str;
            //enlever l'extenton du fichier s'il en a une
            if (getExtention(name).Length != 0)
            {
                name = name.Replace(getExtention(name), "");
            }
            //enlever tout le chemin qui se ttrouve avant le nom du fichier
            str = name.Split('\\');
            return str[str.Length - 1];
        }

        /// <summary>
        /// recupère l'extention du fichier
        /// </summary>
        /// <param name="file">la string avec le nom</param>
        /// <returns>seulement l'extention</returns>
        public string getExtention(string file)
        {
            //tester s'il contient une extention
            if (file.Contains("."))
            {
                string[] extention;
                //retourenre le string pour que l'extention soit au début
                file = reverseString(file);
                //enlever le diviser la string avec les . donc après l'extention
                extention = file.Split('.');
                //stocker l'extention
                file = reverseString(extention[0]);
                //si la string est plsu grande que 4 caractère ce n'est pas une extention
                if (file.Length > 4)
                {
                    file = "";
                }
            }
            else
            {
                file = "";
            }
            return file;
        }

        /// <summary>
        /// Méthode utiliser pour retourener une string
        /// </summary>
        /// <param name="s">string a retourner</param>
        /// <returns>la string retournée</returns>
        public static string reverseString(string s)
        {
            //stocker la string caractère par caractère et retourner le tableau
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}

