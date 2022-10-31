namespace ARKBreedingStats
{
    partial class SpeciesSelector
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvLastSpecies = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btCancel = new System.Windows.Forms.Button();
            this.cbDisplayUntameable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtVariantFilter = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lvSpeciesInLibrary = new System.Windows.Forms.ListView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvSpeciesList = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLastSpecies
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lvLastSpecies, 3);
            this.lvLastSpecies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLastSpecies.HideSelection = false;
            this.lvLastSpecies.Location = new System.Drawing.Point(4, 103);
            this.lvLastSpecies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvLastSpecies.Name = "lvLastSpecies";
            this.lvLastSpecies.Size = new System.Drawing.Size(934, 218);
            this.lvLastSpecies.TabIndex = 1;
            this.lvLastSpecies.UseCompatibleStateImageBehavior = false;
            this.lvLastSpecies.SelectedIndexChanged += new System.EventHandler(this.lvOftenUsed_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(942, 655);
            this.splitContainer1.SplitterDistance = 325;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lvLastSpecies, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btCancel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbDisplayUntameable, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.BtVariantFilter, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(942, 325);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(334, 4);
            this.btCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btCancel.Name = "btCancel";
            this.tableLayoutPanel2.SetRowSpan(this.btCancel, 2);
            this.btCancel.Size = new System.Drawing.Size(123, 32);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cbDisplayUntameable
            // 
            this.cbDisplayUntameable.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.cbDisplayUntameable, 2);
            this.cbDisplayUntameable.Location = new System.Drawing.Point(4, 4);
            this.cbDisplayUntameable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbDisplayUntameable.Name = "cbDisplayUntameable";
            this.cbDisplayUntameable.Size = new System.Drawing.Size(322, 21);
            this.cbDisplayUntameable.TabIndex = 7;
            this.cbDisplayUntameable.Text = "display non-domesticable species";
            this.cbDisplayUntameable.UseVisualStyleBackColor = true;
            this.cbDisplayUntameable.CheckedChanged += new System.EventHandler(this.cbDisplayUntameable_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "上次使用时间";
            // 
            // BtVariantFilter
            // 
            this.BtVariantFilter.Location = new System.Drawing.Point(4, 33);
            this.BtVariantFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtVariantFilter.Name = "BtVariantFilter";
            this.BtVariantFilter.Size = new System.Drawing.Size(112, 32);
            this.BtVariantFilter.TabIndex = 8;
            this.BtVariantFilter.Text = "Variant Filter";
            this.BtVariantFilter.UseVisualStyleBackColor = true;
            this.BtVariantFilter.Click += new System.EventHandler(this.BtVariantFilter_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 32);
            this.button1.TabIndex = 9;
            this.button1.Text = "Variants to default";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lvSpeciesInLibrary, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(942, 324);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "在库中";
            // 
            // lvSpeciesInLibrary
            // 
            this.lvSpeciesInLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSpeciesInLibrary.HideSelection = false;
            this.lvSpeciesInLibrary.Location = new System.Drawing.Point(4, 32);
            this.lvSpeciesInLibrary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvSpeciesInLibrary.Name = "lvSpeciesInLibrary";
            this.lvSpeciesInLibrary.Size = new System.Drawing.Size(934, 288);
            this.lvSpeciesInLibrary.TabIndex = 4;
            this.lvSpeciesInLibrary.UseCompatibleStateImageBehavior = false;
            this.lvSpeciesInLibrary.SelectedIndexChanged += new System.EventHandler(this.lvSpeciesInLibrary_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvSpeciesList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1284, 655);
            this.splitContainer2.SplitterDistance = 336;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 4;
            // 
            // lvSpeciesList
            // 
            this.lvSpeciesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvSpeciesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSpeciesList.FullRowSelect = true;
            this.lvSpeciesList.GridLines = true;
            this.lvSpeciesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSpeciesList.HideSelection = false;
            this.lvSpeciesList.Location = new System.Drawing.Point(0, 0);
            this.lvSpeciesList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvSpeciesList.MultiSelect = false;
            this.lvSpeciesList.Name = "lvSpeciesList";
            this.lvSpeciesList.ShowItemToolTips = true;
            this.lvSpeciesList.Size = new System.Drawing.Size(336, 655);
            this.lvSpeciesList.TabIndex = 0;
            this.lvSpeciesList.UseCompatibleStateImageBehavior = false;
            this.lvSpeciesList.View = System.Windows.Forms.View.Details;
            this.lvSpeciesList.SelectedIndexChanged += new System.EventHandler(this.lvSpeciesList_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "种类";
            this.columnHeader2.Width = 236;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Variant";
            this.columnHeader3.Width = 108;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "可驯化";
            this.columnHeader4.Width = 59;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mod";
            this.columnHeader5.Width = 74;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 204;
            // 
            // SpeciesSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SpeciesSelector";
            this.Size = new System.Drawing.Size(1284, 655);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvLastSpecies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvSpeciesInLibrary;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.CheckBox cbDisplayUntameable;
        private System.Windows.Forms.ListView lvSpeciesList;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button BtVariantFilter;
        private System.Windows.Forms.Button button1;
    }
}
