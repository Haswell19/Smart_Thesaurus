﻿using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleThesaurus
{
    public partial class Form1 : MaterialForm
    {
        SearchOnFileK K;
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

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            /*WorkingDataBase db;
            db = WorkingDataBase.getInstance("myDB");
            db.createDataBase();
            db.startConneciton();
            db.creatInfrastructure("create table firstTable (nom text)");
            db.insertData("firstTable", "nom", "'salut'");
            db.getData("firstTable");*/

            if(K == null)
                K = SearchOnFileK.getInstance();

            K.storeToDB();
            ShowInfos.getInstance().showKSearch(lstViewK, "t_files",searchWord.Text);
        }

        private void lstViewK_DoubleClick(object sender, EventArgs e)
        {
            MaterialListView item = (MaterialListView)sender;
            K.openFile(item.SelectedItems[0].SubItems[1].Text + item.SelectedItems[0].SubItems[2].Text+ item.SelectedItems[0].SubItems[3].Text);
        }
    }
}
