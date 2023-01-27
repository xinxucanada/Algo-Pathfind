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
            this.RdFacile = new System.Windows.Forms.RadioButton();
            this.RdMoyen = new System.Windows.Forms.RadioButton();
            this.RdDifficile = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RdFou = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtStart
            // 
            this.BtStart.Location = new System.Drawing.Point(152, 281);
            this.BtStart.Name = "BtStart";
            this.BtStart.Size = new System.Drawing.Size(75, 23);
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
            // 
            // TbCols
            // 
            this.TbCols.Location = new System.Drawing.Point(138, 178);
            this.TbCols.Name = "TbCols";
            this.TbCols.Size = new System.Drawing.Size(100, 20);
            this.TbCols.TabIndex = 2;
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
            // RdFacile
            // 
            this.RdFacile.AutoSize = true;
            this.RdFacile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdFacile.Location = new System.Drawing.Point(80, 100);
            this.RdFacile.Name = "RdFacile";
            this.RdFacile.Size = new System.Drawing.Size(79, 28);
            this.RdFacile.TabIndex = 5;
            this.RdFacile.TabStop = true;
            this.RdFacile.Text = "Facile";
            this.RdFacile.UseVisualStyleBackColor = true;
            this.RdFacile.CheckedChanged += new System.EventHandler(this.RdFacile_CheckedChanged);
            // 
            // RdMoyen
            // 
            this.RdMoyen.AutoSize = true;
            this.RdMoyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdMoyen.Location = new System.Drawing.Point(80, 156);
            this.RdMoyen.Name = "RdMoyen";
            this.RdMoyen.Size = new System.Drawing.Size(86, 28);
            this.RdMoyen.TabIndex = 6;
            this.RdMoyen.TabStop = true;
            this.RdMoyen.Text = "Moyen";
            this.RdMoyen.UseVisualStyleBackColor = true;
            // 
            // RdDifficile
            // 
            this.RdDifficile.AutoSize = true;
            this.RdDifficile.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdDifficile.Location = new System.Drawing.Point(80, 212);
            this.RdDifficile.Name = "RdDifficile";
            this.RdDifficile.Size = new System.Drawing.Size(86, 28);
            this.RdDifficile.TabIndex = 7;
            this.RdDifficile.TabStop = true;
            this.RdDifficile.Text = "Difficile";
            this.RdDifficile.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.RdFou);
            this.panel1.Controls.Add(this.RdFacile);
            this.panel1.Controls.Add(this.RdDifficile);
            this.panel1.Controls.Add(this.RdMoyen);
            this.panel1.Location = new System.Drawing.Point(466, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 356);
            this.panel1.TabIndex = 8;
            // 
            // RdFou
            // 
            this.RdFou.AutoSize = true;
            this.RdFou.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdFou.Location = new System.Drawing.Point(80, 267);
            this.RdFou.Name = "RdFou";
            this.RdFou.Size = new System.Drawing.Size(62, 28);
            this.RdFou.TabIndex = 8;
            this.RdFou.TabStop = true;
            this.RdFou.Text = "Fou";
            this.RdFou.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(75, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Load Map";
            // 
            // StartMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbCols);
            this.Controls.Add(this.TbRows);
            this.Controls.Add(this.BtStart);
            this.Name = "StartMenu";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtStart;
        private System.Windows.Forms.TextBox TbRows;
        private System.Windows.Forms.TextBox TbCols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RdFacile;
        private System.Windows.Forms.RadioButton RdMoyen;
        private System.Windows.Forms.RadioButton RdDifficile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RdFou;
    }
}

