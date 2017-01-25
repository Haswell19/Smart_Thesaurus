using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Smart_Thesaurus
{
    public partial class Affichage : MaterialForm
    {
        ControlerFileK controlerK;
        string path = @"K:\INF\Eleves\Temp";


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
                controlerK = ControlerFileK.getInstance(lstViewK);
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
            if (controlerK == null)
            {
                controlerK = ControlerFileK.getInstance(lstViewK);
            }
            controlerK.SearchWord(txtField.Text,path);
        }
    }
}
