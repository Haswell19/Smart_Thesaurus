using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Smart_Thesaurus
{
    public partial class Affichage : MaterialForm
    {
        WorkWithFileK controlerK;
        string path = @"K:\INF\Eleves\Temp";
        const string CRONMSG = @"
*   *    *   *   *  
┬ ┬ ┬ ┬ ┬
│ │ │ │ │
│ │ │ │ │
│ │ │ │ └ jour de la semaine (0 - 6)
│ │ │ │   (dimanche=0 )
│ │ │ └── mois (1 - 12)
│ │ └──── jour du mois (1 - 31)
│ └────── heure (0 - 23)
└──────── min (0 - 59)

`* * * * *`        Chaque min.
`0 * * * *`        chaque heure.
`0,1,2 * * * *`    chaque heure à 0, 1, and 2 min.
`*/2 * * * *`      chaque deux min.
`1-55 * * * *`     chauqe min entre 1 & 55 min.
`* 1,10,20 * * *`  1, 10 & 20 heures.
        ";


        public Affichage()
        {            

            InitializeComponent();
            //Créaton de la form material design
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue600, Primary.Blue700, Primary.Blue300, Accent.LightBlue100, TextShade.WHITE);

        }

        /// <summary>
        /// évènement du clique sur le bouton "Afficher K:\"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKIndex_Click(object sender, EventArgs e)
        {
            
            if (controlerK == null)
            {
                controlerK = WorkWithFileK.getInstance(lstViewK);
            }
           controlerK.indexationFiles(path);            
        }

        /// <summary>
        /// évènement du double clique sur un élèment de la liste view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstView_DoubleClickCell(object sender, MouseEventArgs e)
        {
            //passer a la méthode quel élèment est sélèctionner et l'ouvrir
            for (int i = 0; i < lstViewK.Items.Count; i++)
            {
                if (lstViewK.Items[i].Selected == true)
                {
                    controlerK.OpenFile(i);
                }
            }
        }

        /// <summary>
        /// évènement du clique sur le boutn de recherche dans le K
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            //controler que controlerk soit pas null sinon lui mettre une valeur
            if (controlerK == null)
            {
                controlerK = WorkWithFileK.getInstance(lstViewK);
            }
            //lancer la recherche
            controlerK.SearchWord(txtField.Text,path);
        }

        private void cbBoxMaj_SelectedIndexChanged(object sender, EventArgs e)
        {
            //controler que controlerk soit pas null sinon lui mettre une valeur
            if (controlerK == null)
            {
                controlerK = WorkWithFileK.getInstance(lstViewK);
            }
            //activer le bouton de mise a jour manuel
            if (cbBoxMaj.SelectedIndex == 0) { btnDataMaj.Enabled= true; }

            if (cbBoxMaj.SelectedIndex != 0 && cbBoxMaj.SelectedIndex != 3)
            {
                //lancer le changer de mode de mise a jour
                controlerK.changeUpdateType(cbBoxMaj.SelectedIndex);
            }
            else if (cbBoxMaj.SelectedIndex == 3)
            {
                //demander comment mettre a jour le cron
                string cronDate = Interaction.InputBox("Comment mettre à jour ? "+CRONMSG, "CRON mise à jour", "");

            }


        }

        private void btnDataMaj_Click(object sender, EventArgs e)
        {
            //controler que controlerk soit pas null sinon lui mettre une valeur
            if (controlerK == null)
            {
                controlerK = WorkWithFileK.getInstance(lstViewK);
            }
            controlerK.storeDataInXML();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            WorkWithWebSite work = WorkWithWebSite.getInstance();
            work.DownloadFile();
        }
    }
}
