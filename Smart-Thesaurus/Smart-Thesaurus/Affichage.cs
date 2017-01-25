using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace Smart_Thesaurus
{
    public partial class Affichage : MaterialForm
    {
        ControlerFileK ct;
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

        private void btnKIndex_Click(object sender, EventArgs e)
        {
            ct.getInstance();
           ct.indexationFiles(path,lstViewK);            
        }

        private void lstView_DoubleClickCell(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < lstViewK.Items.Count; i++)
            {
                if (lstViewK.Items[i].Selected == true)
                {
                    ct.OpenFile(i);
                }
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (ct == null)
            {
                ct.getInstance();
            }
            ct.SearchWord(txtField.Text, lstViewK);
        }
    }
}
