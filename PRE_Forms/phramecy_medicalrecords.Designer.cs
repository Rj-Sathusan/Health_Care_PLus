namespace Health_Care
{
    partial class phramecy_medicalrecords
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
            this.components = new System.ComponentModel.Container();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.grid_view = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabResults = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_box = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid_view)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.ButtonSpecs.FormClose.Image = global::Health_Care.Properties.Resources.mc_red;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImagePressed = global::Health_Care.Properties.Resources.sign_error_icon;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImageTracking = global::Health_Care.Properties.Resources.sign_error_icon;
            this.kryptonPalette1.ButtonSpecs.FormMax.AllowInheritImage = false;
            this.kryptonPalette1.ButtonSpecs.FormMax.Image = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageCheckedNormal = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageCheckedPressed = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageCheckedTracking = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageNormal = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImagePressed = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageTracking = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMin.AllowInheritImage = false;
            this.kryptonPalette1.ButtonSpecs.FormMin.Image = global::Health_Care.Properties.Resources.mc_green;
            this.kryptonPalette1.ButtonSpecs.FormRestore.Image = global::Health_Care.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateNormal.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Rounding = 20;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.OverrideDefault.Border.Width = 1;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Border.Rounding = 20;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateCommon.Border.Width = 1;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Rounding = 20;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateNormal.Border.Width = 1;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(136)))), ((int)(((byte)(187)))));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Rounding = 20;
            this.kryptonPalette1.ButtonStyles.ButtonStandalone.StateTracking.Border.Width = 1;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Rounding = 12;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(11, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "+  HealthCare Plus";
            // 
            // grid_view
            // 
            this.grid_view.AllowUserToAddRows = false;
            this.grid_view.AllowUserToDeleteRows = false;
            this.grid_view.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid_view.BackgroundColor = System.Drawing.Color.White;
            this.grid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.PID,
            this.Name,
            this.Column5,
            this.Diagnosis,
            this.Prescription,
            this.LabResults});
            this.grid_view.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.grid_view.Location = new System.Drawing.Point(-1, 111);
            this.grid_view.Name = "grid_view";
            this.grid_view.ReadOnly = true;
            this.grid_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid_view.Size = new System.Drawing.Size(959, 565);
            this.grid_view.TabIndex = 8;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // PID
            // 
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            this.PID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PID.Visible = false;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "NIC";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Diagnosis
            // 
            this.Diagnosis.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Diagnosis.HeaderText = "Diagnosis";
            this.Diagnosis.Name = "Diagnosis";
            this.Diagnosis.ReadOnly = true;
            this.Diagnosis.Width = 98;
            // 
            // Prescription
            // 
            this.Prescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prescription.HeaderText = "Prescription";
            this.Prescription.Name = "Prescription";
            this.Prescription.ReadOnly = true;
            // 
            // LabResults
            // 
            this.LabResults.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LabResults.HeaderText = "LabResults";
            this.LabResults.Name = "LabResults";
            this.LabResults.ReadOnly = true;
            this.LabResults.Width = 106;
            // 
            // search_box
            // 
            this.search_box.Location = new System.Drawing.Point(12, 74);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(340, 31);
            this.search_box.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.search_box.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.search_box.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.search_box.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.search_box.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.search_box.StateCommon.Border.Rounding = 20;
            this.search_box.StateCommon.Border.Width = 1;
            this.search_box.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.search_box.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_box.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.search_box.TabIndex = 30;
            this.search_box.TextChanged += new System.EventHandler(this.search_box_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(6, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Search";
            // 
            // medicalrecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(956, 668);
            this.Controls.Add(this.search_box);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grid_view);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.grid_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grid_view;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox search_box;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabResults;

    }
}