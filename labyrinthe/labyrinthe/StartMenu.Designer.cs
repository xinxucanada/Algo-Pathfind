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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// BtStart
			// 
			this.BtStart.Location = new System.Drawing.Point(138, 279);
			this.BtStart.Name = "BtStart";
			this.BtStart.Size = new System.Drawing.Size(84, 23);
			this.BtStart.TabIndex = 0;
			this.BtStart.Text = "Generer";
			this.BtStart.UseVisualStyleBackColor = true;
			this.BtStart.Click += new System.EventHandler(this.BtStart_Click);
			// 
			// TbRows
			// 
			this.TbRows.Location = new System.Drawing.Point(138, 122);
			this.TbRows.Name = "TbRows";
			this.TbRows.Size = new System.Drawing.Size(100, 20);
			this.TbRows.TabIndex = 1;
			this.TbRows.Text = "20";
			// 
			// TbCols
			// 
			this.TbCols.Location = new System.Drawing.Point(138, 178);
			this.TbCols.Name = "TbCols";
			this.TbCols.Size = new System.Drawing.Size(100, 20);
			this.TbCols.TabIndex = 2;
			this.TbCols.Text = "20";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(79, 125);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Rows:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(79, 185);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Cols:";
			// 
			// StartMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 385);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TbCols);
			this.Controls.Add(this.TbRows);
			this.Controls.Add(this.BtStart);
			this.Name = "StartMenu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtStart;
        private System.Windows.Forms.TextBox TbRows;
        private System.Windows.Forms.TextBox TbCols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

