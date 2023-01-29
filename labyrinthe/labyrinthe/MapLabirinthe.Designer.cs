namespace labyrinthe
{
    partial class MapLabirinthe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.BtnDFS = new System.Windows.Forms.Button();
			this.BtBFS = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.BtRecursion = new System.Windows.Forms.Button();
			this.BtClear = new System.Windows.Forms.Button();
			this.BtBack = new System.Windows.Forms.Button();
			this.LbClose = new System.Windows.Forms.Label();
			this.BtnRegenerate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.BtnSave = new System.Windows.Forms.Button();
			this.BtnLoad = new System.Windows.Forms.Button();
			this.BtnManuel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// BtnDFS
			// 
			this.BtnDFS.Location = new System.Drawing.Point(1017, 581);
			this.BtnDFS.Name = "BtnDFS";
			this.BtnDFS.Size = new System.Drawing.Size(125, 23);
			this.BtnDFS.TabIndex = 0;
			this.BtnDFS.Text = "DFS (meilleure chemin)";
			this.BtnDFS.UseVisualStyleBackColor = true;
			this.BtnDFS.Click += new System.EventHandler(this.BtnDFS_Click);
			// 
			// BtBFS
			// 
			this.BtBFS.Location = new System.Drawing.Point(1017, 620);
			this.BtBFS.Name = "BtBFS";
			this.BtBFS.Size = new System.Drawing.Size(125, 23);
			this.BtBFS.TabIndex = 1;
			this.BtBFS.Text = "BFS";
			this.BtBFS.UseVisualStyleBackColor = true;
			this.BtBFS.Click += new System.EventHandler(this.BtBFS_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1017, 668);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(125, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "A*";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// BtRecursion
			// 
			this.BtRecursion.Location = new System.Drawing.Point(1017, 539);
			this.BtRecursion.Name = "BtRecursion";
			this.BtRecursion.Size = new System.Drawing.Size(125, 27);
			this.BtRecursion.TabIndex = 5;
			this.BtRecursion.Text = "DFS (première arrivée)";
			this.BtRecursion.UseVisualStyleBackColor = true;
			this.BtRecursion.Click += new System.EventHandler(this.BtRecursion_Click);
			// 
			// BtClear
			// 
			this.BtClear.Location = new System.Drawing.Point(1017, 712);
			this.BtClear.Name = "BtClear";
			this.BtClear.Size = new System.Drawing.Size(125, 23);
			this.BtClear.TabIndex = 4;
			this.BtClear.Text = "Clear";
			this.BtClear.UseVisualStyleBackColor = true;
			this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
			// 
			// BtBack
			// 
			this.BtBack.Location = new System.Drawing.Point(1017, 757);
			this.BtBack.Name = "BtBack";
			this.BtBack.Size = new System.Drawing.Size(125, 23);
			this.BtBack.TabIndex = 3;
			this.BtBack.Text = "Back";
			this.BtBack.UseVisualStyleBackColor = true;
			// 
			// LbClose
			// 
			this.LbClose.AutoSize = true;
			this.LbClose.Location = new System.Drawing.Point(1170, -2);
			this.LbClose.Name = "LbClose";
			this.LbClose.Size = new System.Drawing.Size(12, 13);
			this.LbClose.TabIndex = 7;
			this.LbClose.Text = "x";
			this.LbClose.Click += new System.EventHandler(this.LbClose_Click);
			// 
			// BtnRegenerate
			// 
			this.BtnRegenerate.Location = new System.Drawing.Point(1017, 799);
			this.BtnRegenerate.Name = "BtnRegenerate";
			this.BtnRegenerate.Size = new System.Drawing.Size(125, 23);
			this.BtnRegenerate.TabIndex = 8;
			this.BtnRegenerate.Text = "ReGenerer";
			this.BtnRegenerate.UseVisualStyleBackColor = true;
			this.BtnRegenerate.Click += new System.EventHandler(this.BtnRegenerate_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.DarkGreen;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(1013, 373);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Current Visite";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.DarkBlue;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label2.Location = new System.Drawing.Point(1013, 417);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(106, 20);
			this.label2.TabIndex = 10;
			this.label2.Text = "Essayer          ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.OrangeRed;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label3.Location = new System.Drawing.Point(1013, 456);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 20);
			this.label3.TabIndex = 11;
			this.label3.Text = "Meilleur Chemin";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Black;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label4.Location = new System.Drawing.Point(1013, 495);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 20);
			this.label4.TabIndex = 12;
			this.label4.Text = "Sans sotire";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label5.Location = new System.Drawing.Point(1013, 330);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 20);
			this.label5.TabIndex = 13;
			this.label5.Text = "Pas visite";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.OliveDrab;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label6.Location = new System.Drawing.Point(899, 861);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 31);
			this.label6.TabIndex = 14;
			this.label6.Text = "Sortir";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.DarkRed;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label7.Location = new System.Drawing.Point(-1, -2);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(94, 31);
			this.label7.TabIndex = 15;
			this.label7.Text = "Entrée";
			// 
			// BtnSave
			// 
			this.BtnSave.Location = new System.Drawing.Point(1017, 843);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(125, 23);
			this.BtnSave.TabIndex = 16;
			this.BtnSave.Text = "Sauvgarder Labyrinthe";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// BtnLoad
			// 
			this.BtnLoad.Location = new System.Drawing.Point(1017, 883);
			this.BtnLoad.Name = "BtnLoad";
			this.BtnLoad.Size = new System.Drawing.Size(125, 23);
			this.BtnLoad.TabIndex = 17;
			this.BtnLoad.Text = "Load Labyrinthe";
			this.BtnLoad.UseVisualStyleBackColor = true;
			this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
			// 
			// BtnManuel
			// 
			this.BtnManuel.Location = new System.Drawing.Point(1017, 926);
			this.BtnManuel.Name = "BtnManuel";
			this.BtnManuel.Size = new System.Drawing.Size(125, 23);
			this.BtnManuel.TabIndex = 18;
			this.BtnManuel.Text = "Manuel";
			this.BtnManuel.UseVisualStyleBackColor = true;
			this.BtnManuel.Click += new System.EventHandler(this.BtnManuel_Click);
			// 
			// MapLabirinthe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 961);
			this.Controls.Add(this.BtnManuel);
			this.Controls.Add(this.BtnLoad);
			this.Controls.Add(this.BtnSave);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.BtnRegenerate);
			this.Controls.Add(this.LbClose);
			this.Controls.Add(this.BtRecursion);
			this.Controls.Add(this.BtClear);
			this.Controls.Add(this.BtBack);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.BtBFS);
			this.Controls.Add(this.BtnDFS);
			this.Name = "MapLabirinthe";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MapLabirinthe";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapLabirinthe_FormClosed);
			this.Load += new System.EventHandler(this.MapLabirinthe_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapLabirinthe_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MapLabirinthe_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDFS;
        private System.Windows.Forms.Button BtBFS;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BtRecursion;
        private System.Windows.Forms.Button BtClear;
        private System.Windows.Forms.Button BtBack;
		private System.Windows.Forms.Label LbClose;
		private System.Windows.Forms.Button BtnRegenerate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnLoad;
		private System.Windows.Forms.Button BtnManuel;
	}
}