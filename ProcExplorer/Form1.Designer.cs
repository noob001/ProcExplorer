namespace ProcExplorer
{
    partial class Form1
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
            this.Refresh = new System.Windows.Forms.Button();
            this.Modules = new System.Windows.Forms.Button();
            this.parentlbl = new System.Windows.Forms.Label();
            this.ProcDataGrid = new System.Windows.Forms.DataGridView();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentName = new System.Windows.Forms.Label();
            this.SidInfo = new System.Windows.Forms.Label();
            this.SidLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OwnerName = new System.Windows.Forms.Label();
            this.OwnerNameLbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.ParentId = new System.Windows.Forms.Label();
            this.ParentIdLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ProcDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(12, 12);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(72, 23);
            this.Refresh.TabIndex = 0;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // Modules
            // 
            this.Modules.Location = new System.Drawing.Point(12, 58);
            this.Modules.Name = "Modules";
            this.Modules.Size = new System.Drawing.Size(72, 23);
            this.Modules.TabIndex = 1;
            this.Modules.Text = "Modules";
            this.Modules.UseVisualStyleBackColor = true;
            this.Modules.Click += new System.EventHandler(this.Modules_Click);
            // 
            // parentlbl
            // 
            this.parentlbl.AutoSize = true;
            this.parentlbl.Location = new System.Drawing.Point(12, 177);
            this.parentlbl.Name = "parentlbl";
            this.parentlbl.Size = new System.Drawing.Size(54, 17);
            this.parentlbl.TabIndex = 3;
            this.parentlbl.Text = "Parent:";
            // 
            // ProcDataGrid
            // 
            this.ProcDataGrid.AllowUserToAddRows = false;
            this.ProcDataGrid.AllowUserToDeleteRows = false;
            this.ProcDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProcDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProcDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProcDataGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.ProcDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PName,
            this.ID,
            this.PFullName,
            this.Type});
            this.ProcDataGrid.Location = new System.Drawing.Point(479, 12);
            this.ProcDataGrid.MaximumSize = new System.Drawing.Size(2000, 1000);
            this.ProcDataGrid.MultiSelect = false;
            this.ProcDataGrid.Name = "ProcDataGrid";
            this.ProcDataGrid.ReadOnly = true;
            this.ProcDataGrid.RowHeadersVisible = false;
            this.ProcDataGrid.RowTemplate.Height = 24;
            this.ProcDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProcDataGrid.Size = new System.Drawing.Size(689, 485);
            this.ProcDataGrid.TabIndex = 4;
            this.ProcDataGrid.SelectionChanged += new System.EventHandler(this.ProcDataGrid_SelectionChanged);
            // 
            // PName
            // 
            this.PName.HeaderText = "PName";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            this.PName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ID
            // 
            this.ID.HeaderText = "PID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // PFullName
            // 
            this.PFullName.HeaderText = "PFullName";
            this.PFullName.Name = "PFullName";
            this.PFullName.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ParentName
            // 
            this.ParentName.AutoSize = true;
            this.ParentName.Location = new System.Drawing.Point(174, 177);
            this.ParentName.Name = "ParentName";
            this.ParentName.Size = new System.Drawing.Size(0, 17);
            this.ParentName.TabIndex = 5;
            // 
            // SidInfo
            // 
            this.SidInfo.AutoSize = true;
            this.SidInfo.Location = new System.Drawing.Point(89, 210);
            this.SidInfo.Name = "SidInfo";
            this.SidInfo.Size = new System.Drawing.Size(0, 17);
            this.SidInfo.TabIndex = 7;
            // 
            // SidLbl
            // 
            this.SidLbl.AutoSize = true;
            this.SidLbl.Location = new System.Drawing.Point(12, 210);
            this.SidLbl.Name = "SidLbl";
            this.SidLbl.Size = new System.Drawing.Size(71, 17);
            this.SidLbl.TabIndex = 6;
            this.SidLbl.Text = "OwnerSID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            // 
            // OwnerName
            // 
            this.OwnerName.AutoSize = true;
            this.OwnerName.Location = new System.Drawing.Point(174, 245);
            this.OwnerName.Name = "OwnerName";
            this.OwnerName.Size = new System.Drawing.Size(0, 17);
            this.OwnerName.TabIndex = 9;
            // 
            // OwnerNameLbl
            // 
            this.OwnerNameLbl.AutoSize = true;
            this.OwnerNameLbl.Location = new System.Drawing.Point(12, 245);
            this.OwnerNameLbl.Name = "OwnerNameLbl";
            this.OwnerNameLbl.Size = new System.Drawing.Size(86, 17);
            this.OwnerNameLbl.TabIndex = 8;
            this.OwnerNameLbl.Text = "OwnerName";
            this.OwnerNameLbl.Click += new System.EventHandler(this.OwnerName_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 401);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 401);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 17);
            this.label10.TabIndex = 18;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(174, 368);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "label12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(174, 338);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 17);
            this.label13.TabIndex = 15;
            this.label13.Text = "label13";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 338);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "label14";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(174, 305);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 17);
            this.label15.TabIndex = 13;
            this.label15.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 305);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 17);
            this.label16.TabIndex = 12;
            this.label16.Text = "label16";
            // 
            // ParentId
            // 
            this.ParentId.AutoSize = true;
            this.ParentId.Location = new System.Drawing.Point(174, 151);
            this.ParentId.Name = "ParentId";
            this.ParentId.Size = new System.Drawing.Size(0, 17);
            this.ParentId.TabIndex = 21;
            // 
            // ParentIdLbl
            // 
            this.ParentIdLbl.AutoSize = true;
            this.ParentIdLbl.Location = new System.Drawing.Point(12, 151);
            this.ParentIdLbl.Name = "ParentIdLbl";
            this.ParentIdLbl.Size = new System.Drawing.Size(61, 17);
            this.ParentIdLbl.TabIndex = 20;
            this.ParentIdLbl.Text = "ParentId";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 569);
            this.Controls.Add(this.ParentId);
            this.Controls.Add(this.ParentIdLbl);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.OwnerName);
            this.Controls.Add(this.OwnerNameLbl);
            this.Controls.Add(this.SidInfo);
            this.Controls.Add(this.SidLbl);
            this.Controls.Add(this.ParentName);
            this.Controls.Add(this.ProcDataGrid);
            this.Controls.Add(this.parentlbl);
            this.Controls.Add(this.Modules);
            this.Controls.Add(this.Refresh);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Button Modules;
        private System.Windows.Forms.Label parentlbl;
        private System.Windows.Forms.DataGridView ProcDataGrid;
        private System.Windows.Forms.Label ParentName;
        private System.Windows.Forms.Label SidInfo;
        private System.Windows.Forms.Label SidLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label OwnerName;
        private System.Windows.Forms.Label OwnerNameLbl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Label ParentId;
        private System.Windows.Forms.Label ParentIdLbl;
    }
}

