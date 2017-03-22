namespace GoogleThesaurus
{
    partial class Form1
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
            this.searchWord = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.lstViewK = new MaterialSkin.Controls.MaterialListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // searchWord
            // 
            this.searchWord.Depth = 0;
            this.searchWord.Hint = "";
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
            this.searchWord.UseSystemPasswordChar = false;
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(601, 105);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(99, 36);
            this.materialFlatButton1.TabIndex = 2;
            this.materialFlatButton1.Text = "Recherche";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
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
            this.columnHeader4.Text = "Nom";
            this.columnHeader4.Width = 209;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 105;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 505);
            this.Controls.Add(this.lstViewK);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.searchWord);
            this.Name = "Form1";
            this.Text = "GoogleThesaurus";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField searchWord;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
        private MaterialSkin.Controls.MaterialListView lstViewK;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

