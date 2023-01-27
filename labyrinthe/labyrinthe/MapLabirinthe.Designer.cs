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
			this.SuspendLayout();
			// 
			// BtnDFS
			// 
			this.BtnDFS.Location = new System.Drawing.Point(1026, 616);
			this.BtnDFS.Name = "BtnDFS";
			this.BtnDFS.Size = new System.Drawing.Size(75, 23);
			this.BtnDFS.TabIndex = 0;
			this.BtnDFS.Text = "DFS";
			this.BtnDFS.UseVisualStyleBackColor = true;
			this.BtnDFS.Click += new System.EventHandler(this.BtnDFS_Click);
			// 
			// BtBFS
			// 
			this.BtBFS.Location = new System.Drawing.Point(1026, 667);
			this.BtBFS.Name = "BtBFS";
			this.BtBFS.Size = new System.Drawing.Size(75, 23);
			this.BtBFS.TabIndex = 1;
			this.BtBFS.Text = "BFS";
			this.BtBFS.UseVisualStyleBackColor = true;
			this.BtBFS.Click += new System.EventHandler(this.BtBFS_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1026, 725);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 2;
			this.button3.Text = "A*";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// BtRecursion
			// 
			this.BtRecursion.Location = new System.Drawing.Point(1026, 775);
			this.BtRecursion.Name = "BtRecursion";
			this.BtRecursion.Size = new System.Drawing.Size(75, 23);
			this.BtRecursion.TabIndex = 5;
			this.BtRecursion.Text = "Recursion";
			this.BtRecursion.UseVisualStyleBackColor = true;
			// 
			// BtClear
			// 
			this.BtClear.Location = new System.Drawing.Point(1026, 825);
			this.BtClear.Name = "BtClear";
			this.BtClear.Size = new System.Drawing.Size(75, 23);
			this.BtClear.TabIndex = 4;
			this.BtClear.Text = "Clear";
			this.BtClear.UseVisualStyleBackColor = true;
			this.BtClear.Click += new System.EventHandler(this.BtClear_Click);
			// 
			// BtBack
			// 
			this.BtBack.Location = new System.Drawing.Point(1026, 876);
			this.BtBack.Name = "BtBack";
			this.BtBack.Size = new System.Drawing.Size(75, 23);
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
			this.BtnRegenerate.Location = new System.Drawing.Point(1026, 573);
			this.BtnRegenerate.Name = "BtnRegenerate";
			this.BtnRegenerate.Size = new System.Drawing.Size(75, 23);
			this.BtnRegenerate.TabIndex = 8;
			this.BtnRegenerate.Text = "ReGenerer";
			this.BtnRegenerate.UseVisualStyleBackColor = true;
			this.BtnRegenerate.Click += new System.EventHandler(this.BtnRegenerate_Click);
			// 
			// MapLabirinthe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1184, 961);
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
	}
}