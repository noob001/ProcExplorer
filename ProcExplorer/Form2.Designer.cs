namespace ProcExplorer
{
    partial class Form2
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
            this.Modules = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Modules
            // 
            this.Modules.FormattingEnabled = true;
            this.Modules.ItemHeight = 16;
            this.Modules.Location = new System.Drawing.Point(12, 12);
            this.Modules.Name = "Modules";
            this.Modules.Size = new System.Drawing.Size(295, 516);
            this.Modules.TabIndex = 0;
            this.Modules.SelectedIndexChanged += new System.EventHandler(this.Modules_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 561);
            this.Controls.Add(this.Modules);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Modules;
    }
}