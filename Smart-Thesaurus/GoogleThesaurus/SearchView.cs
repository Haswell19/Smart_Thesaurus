using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Threading;

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
            //créer la bdd et son interface si elle n'existe pas
            //DataBaseModel.getInstance(DBNAME).createInterfaceAndStoreData();

            //créer le nouveau thread
            myThread = new Thread(CronWork);
            //démarer le thread
            myThread.Start();

        }

        private void CronWork()
        {
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
            ShowInfosController.getInstance().showKSearch(progressBar, lstViewK, "t_files", searchWord.Text);
            ShowInfosController.getInstance().showWebSearch(progressBar, lstViewK, "t_url", searchWord.Text);

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

        private void SearchView_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            myThread.Abort();
        }
    }
}
