namespace GoogleThesaurus
{
    partial class SearchView
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchView));
            this.searchWord = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnSearch = new MaterialSkin.Controls.MaterialFlatButton();
            this.lstViewK = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.progressBar = new MaterialSkin.Controls.MaterialProgressBar();
            this.etml = new System.Windows.Forms.CheckBox();
            this.educanet = new System.Windows.Forms.CheckBox();
            this.temp = new System.Windows.Forms.CheckBox();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.typeDeSauvegardeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quotidienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chaqueHeureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personnalisélangageCRONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnValidateStorage = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rdBtnPerso = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdBtnManuel = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdBtnHour = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdBtnDay = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialContextMenuStrip1.SuspendLayout();
            this.materialTabControl1.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // searchWord
            // 
            this.searchWord.Depth = 0;
            this.searchWord.Hint = "Entrez votre recherche";
            this.searchWord.Location = new System.Drawing.Point(7, 9);
            this.searchWord.MaxLength = 32767;
            this.searchWord.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchWord.Name = "searchWord";
            this.searchWord.PasswordChar = '\0';
            this.searchWord.SelectedText = "";
            this.searchWord.SelectionLength = 0;
            this.searchWord.SelectionStart = 0;
            this.searchWord.Size = new System.Drawing.Size(689, 23);
            this.searchWord.TabIndex = 1;
            this.searchWord.TabStop = false;
            this.searchWord.Tag = "";
            this.searchWord.UseSystemPasswordChar = false;
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.Depth = 0;
            this.btnSearch.Icon = null;
            this.btnSearch.Location = new System.Drawing.Point(596, 41);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = false;
            this.btnSearch.Size = new System.Drawing.Size(99, 36);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Recherche";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // lstViewK
            // 
            this.lstViewK.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstViewK.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
            this.lstViewK.Depth = 0;
            this.lstViewK.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lstViewK.FullRowSelect = true;
            this.lstViewK.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewK.Location = new System.Drawing.Point(7, 86);
            this.lstViewK.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lstViewK.MouseState = MaterialSkin.MouseState.OUT;
            this.lstViewK.Name = "lstViewK";
            this.lstViewK.OwnerDraw = true;
            this.lstViewK.Size = new System.Drawing.Size(689, 297);
            this.lstViewK.TabIndex = 6;
            this.lstViewK.UseCompatibleStateImageBehavior = false;
            this.lstViewK.View = System.Windows.Forms.View.Details;
            this.lstViewK.DoubleClick += new System.EventHandler(this.lstViewK_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nom";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Chemin";
            this.columnHeader2.Width = 363;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Nom/Recherche";
            this.columnHeader4.Width = 209;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 117;
            // 
            // progressBar
            // 
            this.progressBar.Depth = 0;
            this.progressBar.Location = new System.Drawing.Point(133, 60);
            this.progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(456, 5);
            this.progressBar.TabIndex = 7;
            // 
            // etml
            // 
            this.etml.AutoSize = true;
            this.etml.Location = new System.Drawing.Point(66, 38);
            this.etml.Name = "etml";
            this.etml.Size = new System.Drawing.Size(60, 17);
            this.etml.TabIndex = 8;
            this.etml.Text = "etml.ch";
            this.etml.UseVisualStyleBackColor = true;
            // 
            // educanet
            // 
            this.educanet.AutoSize = true;
            this.educanet.Location = new System.Drawing.Point(7, 60);
            this.educanet.Name = "educanet";
            this.educanet.Size = new System.Drawing.Size(120, 17);
            this.educanet.TabIndex = 9;
            this.educanet.Text = "Classeur educanet2";
            this.educanet.UseVisualStyleBackColor = true;
            // 
            // temp
            // 
            this.temp.AutoSize = true;
            this.temp.Location = new System.Drawing.Point(7, 38);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(53, 17);
            this.temp.TabIndex = 10;
            this.temp.Text = "Temp";
            this.temp.UseVisualStyleBackColor = true;
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.typeDeSauvegardeToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(180, 26);
            // 
            // typeDeSauvegardeToolStripMenuItem
            // 
            this.typeDeSauvegardeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manuelToolStripMenuItem,
            this.quotidienToolStripMenuItem,
            this.chaqueHeureToolStripMenuItem,
            this.personnalisélangageCRONToolStripMenuItem});
            this.typeDeSauvegardeToolStripMenuItem.Name = "typeDeSauvegardeToolStripMenuItem";
            this.typeDeSauvegardeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.typeDeSauvegardeToolStripMenuItem.Text = "Type de sauvegarde";
            // 
            // manuelToolStripMenuItem
            // 
            this.manuelToolStripMenuItem.Name = "manuelToolStripMenuItem";
            this.manuelToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.manuelToolStripMenuItem.Text = "Manuel";
            // 
            // quotidienToolStripMenuItem
            // 
            this.quotidienToolStripMenuItem.Name = "quotidienToolStripMenuItem";
            this.quotidienToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.quotidienToolStripMenuItem.Text = "Quotidien";
            // 
            // chaqueHeureToolStripMenuItem
            // 
            this.chaqueHeureToolStripMenuItem.Name = "chaqueHeureToolStripMenuItem";
            this.chaqueHeureToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.chaqueHeureToolStripMenuItem.Text = "Chaque heure";
            // 
            // personnalisélangageCRONToolStripMenuItem
            // 
            this.personnalisélangageCRONToolStripMenuItem.Name = "personnalisélangageCRONToolStripMenuItem";
            this.personnalisélangageCRONToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.personnalisélangageCRONToolStripMenuItem.Text = "Personnalisé (langage CRON)";
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(-12, 64);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(759, 33);
            this.materialTabSelector1.TabIndex = 11;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabSearch);
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(1, 103);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(703, 403);
            this.materialTabControl1.TabIndex = 12;
            // 
            // tabSearch
            // 
            this.tabSearch.BackColor = System.Drawing.Color.White;
            this.tabSearch.Controls.Add(this.lstViewK);
            this.tabSearch.Controls.Add(this.searchWord);
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Controls.Add(this.temp);
            this.tabSearch.Controls.Add(this.progressBar);
            this.tabSearch.Controls.Add(this.educanet);
            this.tabSearch.Controls.Add(this.etml);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(710, 553);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Recherche";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnValidateStorage);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.rdBtnPerso);
            this.tabPage2.Controls.Add(this.rdBtnManuel);
            this.tabPage2.Controls.Add(this.rdBtnHour);
            this.tabPage2.Controls.Add(this.rdBtnDay);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(695, 377);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Choix du mode de mise à jour";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnValidateStorage
            // 
            this.btnValidateStorage.AutoSize = true;
            this.btnValidateStorage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnValidateStorage.Depth = 0;
            this.btnValidateStorage.Icon = null;
            this.btnValidateStorage.Location = new System.Drawing.Point(83, 294);
            this.btnValidateStorage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnValidateStorage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnValidateStorage.Name = "btnValidateStorage";
            this.btnValidateStorage.Primary = false;
            this.btnValidateStorage.Size = new System.Drawing.Size(76, 36);
            this.btnValidateStorage.TabIndex = 6;
            this.btnValidateStorage.Text = "Valider";
            this.btnValidateStorage.UseVisualStyleBackColor = true;
            this.btnValidateStorage.Click += new System.EventHandler(this.btnValidateStorage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GoogleThesaurus.Properties.Resources.giphy__1_;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(321, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // rdBtnPerso
            // 
            this.rdBtnPerso.AutoSize = true;
            this.rdBtnPerso.Depth = 0;
            this.rdBtnPerso.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdBtnPerso.Location = new System.Drawing.Point(83, 231);
            this.rdBtnPerso.Margin = new System.Windows.Forms.Padding(0);
            this.rdBtnPerso.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdBtnPerso.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdBtnPerso.Name = "rdBtnPerso";
            this.rdBtnPerso.Ripple = true;
            this.rdBtnPerso.Size = new System.Drawing.Size(109, 30);
            this.rdBtnPerso.TabIndex = 3;
            this.rdBtnPerso.Text = "Personnalisé";
            this.rdBtnPerso.UseVisualStyleBackColor = true;
            // 
            // rdBtnManuel
            // 
            this.rdBtnManuel.AutoSize = true;
            this.rdBtnManuel.Depth = 0;
            this.rdBtnManuel.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdBtnManuel.Location = new System.Drawing.Point(83, 172);
            this.rdBtnManuel.Margin = new System.Windows.Forms.Padding(0);
            this.rdBtnManuel.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdBtnManuel.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdBtnManuel.Name = "rdBtnManuel";
            this.rdBtnManuel.Ripple = true;
            this.rdBtnManuel.Size = new System.Drawing.Size(75, 30);
            this.rdBtnManuel.TabIndex = 2;
            this.rdBtnManuel.Text = "Manuel";
            this.rdBtnManuel.UseVisualStyleBackColor = true;
            // 
            // rdBtnHour
            // 
            this.rdBtnHour.AutoSize = true;
            this.rdBtnHour.Depth = 0;
            this.rdBtnHour.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdBtnHour.Location = new System.Drawing.Point(83, 116);
            this.rdBtnHour.Margin = new System.Windows.Forms.Padding(0);
            this.rdBtnHour.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdBtnHour.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdBtnHour.Name = "rdBtnHour";
            this.rdBtnHour.Ripple = true;
            this.rdBtnHour.Size = new System.Drawing.Size(114, 30);
            this.rdBtnHour.TabIndex = 1;
            this.rdBtnHour.Text = "Chaque heure";
            this.rdBtnHour.UseVisualStyleBackColor = true;
            // 
            // rdBtnDay
            // 
            this.rdBtnDay.AutoSize = true;
            this.rdBtnDay.Checked = true;
            this.rdBtnDay.Depth = 0;
            this.rdBtnDay.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdBtnDay.Location = new System.Drawing.Point(83, 64);
            this.rdBtnDay.Margin = new System.Windows.Forms.Padding(0);
            this.rdBtnDay.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdBtnDay.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdBtnDay.Name = "rdBtnDay";
            this.rdBtnDay.Ripple = true;
            this.rdBtnDay.Size = new System.Drawing.Size(88, 30);
            this.rdBtnDay.TabIndex = 0;
            this.rdBtnDay.TabStop = true;
            this.rdBtnDay.Text = "Quotidien";
            this.rdBtnDay.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(596, 52);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(103, 36);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Mise à jour";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(716, 518);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchView";
            this.Sizable = false;
            this.Text = "GoogleThesaurus";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchView_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.materialTabControl1.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField searchWord;
        private MaterialSkin.Controls.MaterialFlatButton btnSearch;
        private MaterialSkin.Controls.MaterialListView lstViewK;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private MaterialSkin.Controls.MaterialProgressBar progressBar;
        private System.Windows.Forms.CheckBox etml;
        private System.Windows.Forms.CheckBox educanet;
        private System.Windows.Forms.CheckBox temp;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem typeDeSauvegardeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quotidienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chaqueHeureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personnalisélangageCRONToolStripMenuItem;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialRadioButton rdBtnDay;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private MaterialSkin.Controls.MaterialRadioButton rdBtnManuel;
        private MaterialSkin.Controls.MaterialRadioButton rdBtnHour;
        private MaterialSkin.Controls.MaterialRadioButton rdBtnPerso;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialFlatButton btnValidateStorage;
    }
}

