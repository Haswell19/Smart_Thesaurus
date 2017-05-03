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
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchWord
            // 
            this.searchWord.Depth = 0;
            this.searchWord.Hint = "Entrez votre recherche";
            this.searchWord.Location = new System.Drawing.Point(12, 73);
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
            this.btnSearch.Location = new System.Drawing.Point(601, 105);
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
            this.lstViewK.Location = new System.Drawing.Point(12, 150);
            this.lstViewK.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lstViewK.MouseState = MaterialSkin.MouseState.OUT;
            this.lstViewK.Name = "lstViewK";
            this.lstViewK.OwnerDraw = true;
            this.lstViewK.Size = new System.Drawing.Size(689, 343);
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
            this.progressBar.Location = new System.Drawing.Point(141, 124);
            this.progressBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(453, 5);
            this.progressBar.TabIndex = 7;
            // 
            // etml
            // 
            this.etml.AutoSize = true;
            this.etml.Location = new System.Drawing.Point(71, 102);
            this.etml.Name = "etml";
            this.etml.Size = new System.Drawing.Size(60, 17);
            this.etml.TabIndex = 8;
            this.etml.Text = "etml.ch";
            this.etml.UseVisualStyleBackColor = true;
            // 
            // educanet
            // 
            this.educanet.AutoSize = true;
            this.educanet.Location = new System.Drawing.Point(12, 124);
            this.educanet.Name = "educanet";
            this.educanet.Size = new System.Drawing.Size(120, 17);
            this.educanet.TabIndex = 9;
            this.educanet.Text = "Classeur educanet2";
            this.educanet.UseVisualStyleBackColor = true;
            // 
            // temp
            // 
            this.temp.AutoSize = true;
            this.temp.Location = new System.Drawing.Point(12, 102);
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
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(180, 48);
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
            this.manuelToolStripMenuItem.Click += new System.EventHandler(this.manuelToolStripMenuItem_Click);
            // 
            // quotidienToolStripMenuItem
            // 
            this.quotidienToolStripMenuItem.Name = "quotidienToolStripMenuItem";
            this.quotidienToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.quotidienToolStripMenuItem.Text = "Quotidien";
            this.quotidienToolStripMenuItem.Click += new System.EventHandler(this.quotidienToolStripMenuItem_Click);
            // 
            // chaqueHeureToolStripMenuItem
            // 
            this.chaqueHeureToolStripMenuItem.Name = "chaqueHeureToolStripMenuItem";
            this.chaqueHeureToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.chaqueHeureToolStripMenuItem.Text = "Chaque heure";
            this.chaqueHeureToolStripMenuItem.Click += new System.EventHandler(this.chaqueHeureToolStripMenuItem_Click);
            // 
            // personnalisélangageCRONToolStripMenuItem
            // 
            this.personnalisélangageCRONToolStripMenuItem.Name = "personnalisélangageCRONToolStripMenuItem";
            this.personnalisélangageCRONToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.personnalisélangageCRONToolStripMenuItem.Text = "Personnalisé (langage CRON)";
            this.personnalisélangageCRONToolStripMenuItem.Click += new System.EventHandler(this.personnalisélangageCRONToolStripMenuItem_Click);
            // 
            // SearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(713, 505);
            this.Controls.Add(this.temp);
            this.Controls.Add(this.educanet);
            this.Controls.Add(this.etml);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lstViewK);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchView";
            this.Sizable = false;
            this.Text = "GoogleThesaurus";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SearchView_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.materialContextMenuStrip1.ResumeLayout(false);
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
    }
}

