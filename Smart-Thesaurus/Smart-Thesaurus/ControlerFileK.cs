﻿using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin.Controls;

namespace Smart_Thesaurus
{
    class ControlerFileK
    {
        ControlerFileK controlerK;
        string[] lstFiles;
        ListViewItem[] lstItem;
        string path;
        MaterialListView _lstView;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_lstBox"></param>
        private ControlerFileK()
        {
           

        }

        /// <summary>
        /// Avoir une seul instance de COntroller K
        /// </summary>
        /// <returns>contrller K</returns>
        public ControlerFileK getInstance()
        {
            if (controlerK == null)
            {
                //faire un new ControlerFileK et y cherhcer les infos
                controlerK = new ControlerFileK();

            }
            return controlerK;
        }

        /// <summary>
        /// Chercher un mot dsan tous les fichiers présents
        /// </summary>
        /// <param name="_toSearch"></param>
        /// <param name="_lstView"></param>
        public void SearchWord(string _toSearch,MaterialListView _lstView)
        {
            
            bool[] index =new bool[this._lstView.Items.Count];
            

            _lstView.Items.Clear();
            _lstView.Items.AddRange(lstItem);
            
        }

        /// <summary>
        /// Indexer tous les fichiers du K
        /// </summary>
        /// <param name="_path"></param>
        public void indexationFiles(string _path,MaterialListView _lstBox)
        {
            //tester si la personne est connectée au K ou pas
            try
            {
                _lstView = _lstBox;
                _lstView.Items.Clear();
                //recupérer tous les fihciers du K
                lstFiles = Directory.GetFiles(_path, "*", SearchOption.AllDirectories);

                //faire une liste d'élèments à afficher
                lstItem = new ListViewItem[lstFiles.Length];

                //stocker le nom, chemin  et extension du fichier
                for (int i = 0; i < lstFiles.Length; i++)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(lstFiles[i].Replace(getFileName(lstFiles[i]) + getExtention(lstFiles[i]), ""));
                    item.SubItems.Add(getFileName(lstFiles[i].Replace(".", "")));
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
                string file = lstFiles[index];
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

