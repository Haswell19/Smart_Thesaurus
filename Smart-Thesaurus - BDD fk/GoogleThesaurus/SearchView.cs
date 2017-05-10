using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace GoogleThesaurus
{
    public partial class SearchView : MaterialForm
    {
        //nom de la bdd
        const string DBNAME = "dataK";
        //variable globale pour travailler dans n'importe quelle méthode avec
        Thread myThread;


        public SearchView()
        {
            InitializeComponent();
            //Créaton de la form material design
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue300, Accent.LightBlue100, TextShade.WHITE);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //désactiver le obuton sauvegarde
            btnSave.Visible
                = false;

            //créer le nouveau thread
            myThread = new Thread(CronWork);
            //démarer le thread
            myThread.Start();

        }

        /// <summary>
        /// Lancer en multiThread la tâche cron
        /// </summary>
        private void CronWork()
        {
            //créer le tache cron
            Cron cron = new Cron();
            cron.start();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            //suprimer toutes les ancienes données
            if (lstViewK.Items.Count != 0)
            {
                lstViewK.Items.Clear();
            }
            //rechercher ce que l'utilisateur désire dans le K et le site Web
            if (temp.Checked)
            {
                ShowInfosController.getInstance().showKSearch(progressBar, lstViewK, "t_files","t_wordK", searchWord.Text);
            }
            if (etml.Checked)
            {
                Thread thread = new Thread(() => ShowInfosController.getInstance(this).showWebSearch(progressBar, lstViewK, "t_url","t_wordSite", searchWord.Text));
                thread.Start();
            }
            if (educanet.Checked)
            {
               //TODO chercher les fichiers dans le classseur educanet
            }

        }

        private void lstViewK_DoubleClick(object sender, EventArgs e)
        {
            //recuperer l'item
            MaterialListView item = (MaterialListView)sender;

            //savoir si c'est une fichier ou un url
            if (item.SelectedItems[0].SubItems[3].Text != "Site Web")
            {
                //ouvrir le fichier
                FileKModel.getInstance().openFile(item.SelectedItems[0].SubItems[1].Text + item.SelectedItems[0].SubItems[2].Text + item.SelectedItems[0].SubItems[3].Text);
            }
            else
            {
                //lancer le navigateur
                System.Diagnostics.Process.Start(item.SelectedItems[0].SubItems[1].Text);
            }
        }

        /// <summary>
        /// Action quand la form est fermée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchView_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            //arreter le thread de sauvegarde dasn la bdd
            myThread.Abort();
        }

        /// <summary>
        /// Changer la taille max de la progressbar(pour les autres thread)
        /// </summary>
        /// <param name="max">valeur max de la progressbar</param>
        public void addMaxProgressBar(int max)
        {
            progressBar.Maximum = max;
            progressBar.Value = 0;
        }

        /// <summary>
        /// Incrementer la progressBar
        /// </summary>
        public void incrementProgressBar()
        {
            progressBar.Value++;
        }

        /// <summary>
        /// Charger les données dans la liste
        /// </summary>
        /// <param name="lst">liste de données a afficher</param>
        /// <param name="toSearch">le mot recherhcer</param>
        public void refreshList(List<string> lst,string toSearch)
        {
            List<ListViewItem> lstViewItem = new List<ListViewItem>();
            //créer un item pour listview avec chaque site trouvé
            foreach (string url in lst)
            {
                ListViewItem item = new ListViewItem("");
                item.SubItems.Add(url);
                item.SubItems.Add(toSearch);
                item.SubItems.Add("Site Web");
                lstViewItem.Add(item);
            }
            //ajoute la list à l'affichage
            lstViewK.Items.AddRange(lstViewItem.ToArray());
        }
        private void btnValidateStorage_Click(object sender, EventArgs e)
        {
            if (rdBtnDay.Checked)
            {
                btnSave.Visible = false;
                writeCron("4 11 * * * ");
            }
            else if (rdBtnHour.Checked)
            {
                btnSave.Visible = false;
                writeCron("0 * * * * ");
            }
            else if (rdBtnManuel.Checked)
            {
                btnSave.Visible = true;
            }
            else if (rdBtnPerso.Checked)
            {
                btnSave.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Process.Start("UpdateDataCron.exe");
        }

        private void writeCron(string expression)
        {
            string[] toWrite = { expression + " UpdateDataCron.exe"};
            System.IO.File.WriteAllLines(@"cron.tab", toWrite);

            //créer le nouveau thread
            myThread = new Thread(CronWork);
            //démarer le thread
            myThread.Start();


        }
    }
}
