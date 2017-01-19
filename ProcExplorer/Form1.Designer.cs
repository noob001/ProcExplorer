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
            this.ParentName = new System.Windows.Forms.Label();
            this.SidInfo = new System.Windows.Forms.Label();
            this.SidLbl = new System.Windows.Forms.Label();
            this.DEP = new System.Windows.Forms.Label();
            this.DEPLbl = new System.Windows.Forms.Label();
            this.OwnerName = new System.Windows.Forms.Label();
            this.OwnerNameLbl = new System.Windows.Forms.Label();
            this.DisallowStrippedImages = new System.Windows.Forms.Label();
            this.DisallowStrippedImagesLbl = new System.Windows.Forms.Label();
            this.HighEntropy = new System.Windows.Forms.Label();
            this.HighEntropyLbl = new System.Windows.Forms.Label();
            this.ForceRelocateImages = new System.Windows.Forms.Label();
            this.forceRelocateImagesLbl = new System.Windows.Forms.Label();
            this.BottomUpRandomization = new System.Windows.Forms.Label();
            this.BottomUpRandomizationLbl = new System.Windows.Forms.Label();
            this.ParentId = new System.Windows.Forms.Label();
            this.ParentIdLbl = new System.Windows.Forms.Label();
            this.AslrLbl = new System.Windows.Forms.Label();
            this.groupsButton = new System.Windows.Forms.Button();
            this.IntegrityLvl = new System.Windows.Forms.Label();
            this.IntegrityLvlLbl = new System.Windows.Forms.Label();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Integrity = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Type,
            this.Integrity});
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
            this.ProcDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProcDataGrid_CellContentClick);
            this.ProcDataGrid.SelectionChanged += new System.EventHandler(this.ProcDataGrid_SelectionChanged);
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
            // DEP
            // 
            this.DEP.AutoSize = true;
            this.DEP.Location = new System.Drawing.Point(174, 277);
            this.DEP.Name = "DEP";
            this.DEP.Size = new System.Drawing.Size(0, 17);
            this.DEP.TabIndex = 11;
            // 
            // DEPLbl
            // 
            this.DEPLbl.AutoSize = true;
            this.DEPLbl.Location = new System.Drawing.Point(12, 277);
            this.DEPLbl.Name = "DEPLbl";
            this.DEPLbl.Size = new System.Drawing.Size(36, 17);
            this.DEPLbl.TabIndex = 10;
            this.DEPLbl.Text = "DEP";
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
            // 
            // DisallowStrippedImages
            // 
            this.DisallowStrippedImages.AutoSize = true;
            this.DisallowStrippedImages.Location = new System.Drawing.Point(198, 431);
            this.DisallowStrippedImages.Name = "DisallowStrippedImages";
            this.DisallowStrippedImages.Size = new System.Drawing.Size(0, 17);
            this.DisallowStrippedImages.TabIndex = 19;
            // 
            // DisallowStrippedImagesLbl
            // 
            this.DisallowStrippedImagesLbl.AutoSize = true;
            this.DisallowStrippedImagesLbl.Location = new System.Drawing.Point(12, 431);
            this.DisallowStrippedImagesLbl.Name = "DisallowStrippedImagesLbl";
            this.DisallowStrippedImagesLbl.Size = new System.Drawing.Size(157, 17);
            this.DisallowStrippedImagesLbl.TabIndex = 18;
            this.DisallowStrippedImagesLbl.Text = "DisallowStrippedImages";
            // 
            // HighEntropy
            // 
            this.HighEntropy.AutoSize = true;
            this.HighEntropy.Location = new System.Drawing.Point(198, 398);
            this.HighEntropy.Name = "HighEntropy";
            this.HighEntropy.Size = new System.Drawing.Size(0, 17);
            this.HighEntropy.TabIndex = 17;
            // 
            // HighEntropyLbl
            // 
            this.HighEntropyLbl.AutoSize = true;
            this.HighEntropyLbl.Location = new System.Drawing.Point(12, 398);
            this.HighEntropyLbl.Name = "HighEntropyLbl";
            this.HighEntropyLbl.Size = new System.Drawing.Size(86, 17);
            this.HighEntropyLbl.TabIndex = 16;
            this.HighEntropyLbl.Text = "HighEntropy";
            this.HighEntropyLbl.Click += new System.EventHandler(this.label12_Click);
            // 
            // ForceRelocateImages
            // 
            this.ForceRelocateImages.AutoSize = true;
            this.ForceRelocateImages.Location = new System.Drawing.Point(198, 368);
            this.ForceRelocateImages.Name = "ForceRelocateImages";
            this.ForceRelocateImages.Size = new System.Drawing.Size(0, 17);
            this.ForceRelocateImages.TabIndex = 15;
            // 
            // forceRelocateImagesLbl
            // 
            this.forceRelocateImagesLbl.AutoSize = true;
            this.forceRelocateImagesLbl.Location = new System.Drawing.Point(12, 368);
            this.forceRelocateImagesLbl.Name = "forceRelocateImagesLbl";
            this.forceRelocateImagesLbl.Size = new System.Drawing.Size(149, 17);
            this.forceRelocateImagesLbl.TabIndex = 14;
            this.forceRelocateImagesLbl.Text = "ForceRelocateImages ";
            this.forceRelocateImagesLbl.Click += new System.EventHandler(this.forceRelocateImagesLbl_Click);
            // 
            // BottomUpRandomization
            // 
            this.BottomUpRandomization.AutoSize = true;
            this.BottomUpRandomization.Location = new System.Drawing.Point(198, 335);
            this.BottomUpRandomization.Name = "BottomUpRandomization";
            this.BottomUpRandomization.Size = new System.Drawing.Size(0, 17);
            this.BottomUpRandomization.TabIndex = 13;
            // 
            // BottomUpRandomizationLbl
            // 
            this.BottomUpRandomizationLbl.AutoSize = true;
            this.BottomUpRandomizationLbl.Location = new System.Drawing.Point(12, 335);
            this.BottomUpRandomizationLbl.Name = "BottomUpRandomizationLbl";
            this.BottomUpRandomizationLbl.Size = new System.Drawing.Size(164, 17);
            this.BottomUpRandomizationLbl.TabIndex = 12;
            this.BottomUpRandomizationLbl.Text = "BottomUpRandomization";
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
            // AslrLbl
            // 
            this.AslrLbl.AutoSize = true;
            this.AslrLbl.Location = new System.Drawing.Point(12, 306);
            this.AslrLbl.Name = "AslrLbl";
            this.AslrLbl.Size = new System.Drawing.Size(52, 17);
            this.AslrLbl.TabIndex = 22;
            this.AslrLbl.Text = "ASLR :";
            // 
            // groupsButton
            // 
            this.groupsButton.Location = new System.Drawing.Point(100, 12);
            this.groupsButton.Name = "groupsButton";
            this.groupsButton.Size = new System.Drawing.Size(75, 23);
            this.groupsButton.TabIndex = 23;
            this.groupsButton.Text = "Groups";
            this.groupsButton.UseVisualStyleBackColor = true;
            this.groupsButton.Click += new System.EventHandler(this.groupsButton_Click);
            // 
            // IntegrityLvl
            // 
            this.IntegrityLvl.AutoSize = true;
            this.IntegrityLvl.Location = new System.Drawing.Point(207, 108);
            this.IntegrityLvl.Name = "IntegrityLvl";
            this.IntegrityLvl.Size = new System.Drawing.Size(0, 17);
            this.IntegrityLvl.TabIndex = 25;
            this.IntegrityLvl.Click += new System.EventHandler(this.label1_Click);
            // 
            // IntegrityLvlLbl
            // 
            this.IntegrityLvlLbl.AutoSize = true;
            this.IntegrityLvlLbl.Location = new System.Drawing.Point(21, 108);
            this.IntegrityLvlLbl.Name = "IntegrityLvlLbl";
            this.IntegrityLvlLbl.Size = new System.Drawing.Size(76, 17);
            this.IntegrityLvlLbl.TabIndex = 24;
            this.IntegrityLvlLbl.Text = "IntegrityLvl";
            this.IntegrityLvlLbl.Click += new System.EventHandler(this.label2_Click);
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
            // 
            // Integrity
            // 
            this.Integrity.HeaderText = "Integrity";
            this.Integrity.Name = "Integrity";
            this.Integrity.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 569);
            this.Controls.Add(this.IntegrityLvl);
            this.Controls.Add(this.IntegrityLvlLbl);
            this.Controls.Add(this.groupsButton);
            this.Controls.Add(this.AslrLbl);
            this.Controls.Add(this.ParentId);
            this.Controls.Add(this.ParentIdLbl);
            this.Controls.Add(this.DisallowStrippedImages);
            this.Controls.Add(this.DisallowStrippedImagesLbl);
            this.Controls.Add(this.HighEntropy);
            this.Controls.Add(this.HighEntropyLbl);
            this.Controls.Add(this.ForceRelocateImages);
            this.Controls.Add(this.forceRelocateImagesLbl);
            this.Controls.Add(this.BottomUpRandomization);
            this.Controls.Add(this.BottomUpRandomizationLbl);
            this.Controls.Add(this.DEP);
            this.Controls.Add(this.DEPLbl);
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
        private System.Windows.Forms.Label DEP;
        private System.Windows.Forms.Label DEPLbl;
        private System.Windows.Forms.Label OwnerName;
        private System.Windows.Forms.Label OwnerNameLbl;
        private System.Windows.Forms.Label DisallowStrippedImages;
        private System.Windows.Forms.Label DisallowStrippedImagesLbl;
        private System.Windows.Forms.Label HighEntropy;
        private System.Windows.Forms.Label HighEntropyLbl;
        private System.Windows.Forms.Label ForceRelocateImages;
        private System.Windows.Forms.Label forceRelocateImagesLbl;
        private System.Windows.Forms.Label BottomUpRandomization;
        private System.Windows.Forms.Label BottomUpRandomizationLbl;
        private System.Windows.Forms.Label ParentId;
        private System.Windows.Forms.Label ParentIdLbl;
        private System.Windows.Forms.Label AslrLbl;
        private System.Windows.Forms.Button groupsButton;
        private System.Windows.Forms.Label IntegrityLvl;
        private System.Windows.Forms.Label IntegrityLvlLbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Integrity;
    }
}

