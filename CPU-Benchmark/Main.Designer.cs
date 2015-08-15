namespace CPU_Benchmark
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxLinpack = new System.Windows.Forms.ListBox();
            this.btnStartLinpack = new System.Windows.Forms.Button();
            this.listBoxWhetstone = new System.Windows.Forms.ListBox();
            this.btnStartWhetstone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxLinpack
            // 
            this.listBoxLinpack.FormattingEnabled = true;
            this.listBoxLinpack.Location = new System.Drawing.Point(12, 70);
            this.listBoxLinpack.Name = "listBoxLinpack";
            this.listBoxLinpack.Size = new System.Drawing.Size(238, 368);
            this.listBoxLinpack.TabIndex = 5;
            // 
            // btnStartLinpack
            // 
            this.btnStartLinpack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLinpack.Location = new System.Drawing.Point(12, 9);
            this.btnStartLinpack.Name = "btnStartLinpack";
            this.btnStartLinpack.Size = new System.Drawing.Size(238, 50);
            this.btnStartLinpack.TabIndex = 4;
            this.btnStartLinpack.Text = "Start Linpack CPU-Benchmark";
            this.btnStartLinpack.UseVisualStyleBackColor = true;
            this.btnStartLinpack.Click += new System.EventHandler(this.btnStartLinpack_Click);
            // 
            // listBoxWhetstone
            // 
            this.listBoxWhetstone.FormattingEnabled = true;
            this.listBoxWhetstone.Location = new System.Drawing.Point(256, 70);
            this.listBoxWhetstone.Name = "listBoxWhetstone";
            this.listBoxWhetstone.Size = new System.Drawing.Size(238, 368);
            this.listBoxWhetstone.TabIndex = 7;
            // 
            // btnStartWhetstone
            // 
            this.btnStartWhetstone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartWhetstone.Location = new System.Drawing.Point(256, 9);
            this.btnStartWhetstone.Name = "btnStartWhetstone";
            this.btnStartWhetstone.Size = new System.Drawing.Size(238, 50);
            this.btnStartWhetstone.TabIndex = 6;
            this.btnStartWhetstone.Text = "Start Whetstone CPU-Benchmark";
            this.btnStartWhetstone.UseVisualStyleBackColor = true;
            this.btnStartWhetstone.Click += new System.EventHandler(this.btnStartWhetstone_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 447);
            this.Controls.Add(this.listBoxWhetstone);
            this.Controls.Add(this.btnStartWhetstone);
            this.Controls.Add(this.listBoxLinpack);
            this.Controls.Add(this.btnStartLinpack);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".NET CPU-Benchmark";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLinpack;
        private System.Windows.Forms.Button btnStartLinpack;
        private System.Windows.Forms.ListBox listBoxWhetstone;
        private System.Windows.Forms.Button btnStartWhetstone;
    }
}

