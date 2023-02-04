namespace labyrinthe
{
	partial class Choisir
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
			this.btnLb1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnLb1
			// 
			this.btnLb1.Location = new System.Drawing.Point(94, 24);
			this.btnLb1.Name = "btnLb1";
			this.btnLb1.Size = new System.Drawing.Size(312, 23);
			this.btnLb1.TabIndex = 0;
			this.btnLb1.Text = "button1";
			this.btnLb1.UseVisualStyleBackColor = true;
			// 
			// Choisir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnLb1);
			this.Name = "Choisir";
			this.Text = "Choisir";
			this.Load += new System.EventHandler(this.Choisir_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnLb1;
	}
}