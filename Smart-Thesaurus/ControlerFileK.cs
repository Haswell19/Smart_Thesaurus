using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using MaterialSkin.Controls;

namespace Smart_Thesaurus
{
    class ControlerFileK
    {
        string[] lstFiles;
        ListViewItem[] lstItem;
        string path = @"K:\INF\Eleves\Temp";
        MaterialListView _lstView;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_lstBox"></param>
        public ControlerFileK(MaterialListView _lstBox)
        {
            _lstView = _lstBox;
            _lstView.Items.Clear();
            FileSearch(path);
        }


        /// <summary>
        /// Chercher un mot dsan tous les fichiers présents
        /// </summary>
        /// <param name="_toSearch"></param>
        /// <param name="_lstView"></param>
        public void SearchWord(string _toSearch,MaterialListView _lstView)
        {
            
            bool[] index =new bool[this._lstView.Items.Count];
            
            int tablLenght = 0;
            for (int i = 0; i < this._lstView.Items.Count-1; i++)
             {
                 if (this._lstView.FindItemWithText(_toSearch) != null)
                 {
                     index[i] = true;
                     ListViewItem item = new ListViewItem("");
                     item.SubItems.Add(lstFiles[i].Replace(getFileName(lstFiles[i]) + getExtention(lstFiles[i]), ""));
                     item.SubItems.Add(getFileName(lstFiles[i].Replace(".", "")));
                     item.SubItems.Add(getExtention(lstFiles[i]));
                     lstItem[i] = item;
                    tablLenght++;
                 }
                 else
                 {
                     index[i] = false;
                 }
             }

            /* foreach (ListViewItem listViewItem in _lstView.Items)
             {
                 if (listViewItem.SubItems[1].Text.Contains(_toSearch)|| listViewItem.SubItems[2].Text.Contains(_toSearch) || listViewItem.SubItems[3].Text.Contains(_toSearch))
                 {
                     index[listViewItem.Index]=true;
                     tablLenght++;
                 }
             }*/
            /*ListViewItem[] lstItems = new ListViewItem[tablLenght];
            for (int i = 0; i < lstFiles.Length; i++)
            {
                if (index[i])
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(lstFiles[i].Replace(getFileName(lstFiles[i]) + getExtention(lstFiles[i]), ""));
                    item.SubItems.Add(getFileName(lstFiles[i].Replace(".", "")));
                    item.SubItems.Add(getExtention(lstFiles[i]));
                    lstItem[i] = item;
                }
            }*/
            _lstView.Items.Clear();
            _lstView.Items.AddRange(lstItem);
            
        }

        public void FileSearch(string _path)
        {
            try
            {
                lstFiles = Directory.GetFiles(_path, "*", SearchOption.AllDirectories);
                lstItem = new ListViewItem[lstFiles.Length];
                for (int i = 0; i < lstFiles.Length; i++)
                {
                    ListViewItem item = new ListViewItem("");
                    item.SubItems.Add(lstFiles[i].Replace(getFileName(lstFiles[i]) + getExtention(lstFiles[i]), ""));
                    item.SubItems.Add(getFileName(lstFiles[i].Replace(".", "")));
                    item.SubItems.Add(getExtention(lstFiles[i]));
                    lstItem[i] = item;
                }
                _lstView.Items.AddRange(lstItem);
            }
            catch
            {
                MessageBox.Show("Vous n'êtes pas connecté au H\n\n\n\n\n\n\n\n\n\n\nSKUUUUUUUUUUUUUUUUUUUUUUUUUUUUUH");
            }
        }

        public void OpenFile(int index)
        {
            try
            {
                string file = lstFiles[index];

                ProcessStartInfo psi = new ProcessStartInfo(file);
                Process.Start(psi);
            }
            catch { }

        }

        public string getFileName(string name)
        {
            string[] str;
            if (getExtention(name).Length != 0)
            {
                name = name.Replace(getExtention(name), "");
            }
            str = name.Split('\\');
            return str[str.Length - 1];
        }

        public string getExtention(string file)
        {
            if (file.Contains("."))
            {
                string[] extention;
                file = reverseString(file);
                extention = file.Split('.');
                file = reverseString(extention[0]);
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

        public static string reverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}

