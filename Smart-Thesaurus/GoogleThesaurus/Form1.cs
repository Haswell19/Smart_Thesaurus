using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleThesaurus
{
    public partial class Form1 : MaterialForm
    {
        SearchOnFileK K;
        const string DBNAME = "dataK";
        public Form1()
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
            WorkingDataBase.getInstance(DBNAME).createInterfaceAndStoreData();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (lstViewK.Items.Count != 0)
            {
                lstViewK.Items.Clear();
            }
            ShowInfos.getInstance().showKSearch(progressBar, lstViewK,"t_files", searchWord.Text);
            ShowInfos.getInstance().showWebSearch(progressBar, lstViewK,"t_url", searchWord.Text);

        }

        private void lstViewK_DoubleClick(object sender, EventArgs e)
        {
            MaterialListView item = (MaterialListView)sender;

            if (item.SelectedItems[0].SubItems[3].Text != "Site Web")
            {
                K.openFile(item.SelectedItems[0].SubItems[1].Text + item.SelectedItems[0].SubItems[2].Text + item.SelectedItems[0].SubItems[3].Text);
            }
            else
            {
                System.Diagnostics.Process.Start(item.SelectedItems[0].SubItems[1].Text);
            }
        }
    }
}
