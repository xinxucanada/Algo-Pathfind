namespace labyrinthe
{
    partial class StartMenu
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
            this.BtStart = new System.Windows.Forms.Button();
            this.TbRows = new System.Windows.Forms.TextBox();
            this.TbCols = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtStart
            // 
            this.BtStart.Location = new System.Drawing.Point(114, 282);
            this.BtStart.Name = "BtStart";
            this.BtStart.Size = new System.Drawing.Size(75, 23);
            this.BtStart.TabIndex = 0;
            this.BtStart.Text = "Start";
            this.BtStart.UseVisualStyleBackColor = true;
            this.BtStart.Click += new System.EventHandler(this.BtStart_Click);
            // 
            // TbRows
            // 
            this.TbRows.Location = new System.Drawing.Point(100, 123);
            this.TbRows.Name = "TbRows";
            this.TbRows.Size = new System.Drawing.Size(100, 20);
            this.TbRows.TabIndex = 1;
            // 
            // TbCols
            // 
            this.TbCols.Location = new System.Drawing.Point(100, 179);
            this.TbCols.Name = "TbCols";
            this.TbCols.Size = new System.Drawing.Size(100, 20);
            this.TbCols.TabIndex = 2;
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TbCols);
            this.Controls.Add(this.TbRows);
            this.Controls.Add(this.BtStart);
            this.Name = "StartMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtStart;
        private System.Windows.Forms.TextBox TbRows;
        private System.Windows.Forms.TextBox TbCols;
    }
}

