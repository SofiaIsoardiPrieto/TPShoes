namespace TPShoes.Windows
{
    partial class FrmSizeShoes
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            splitContainer2 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            EditartoolStripButton = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            SalirtoolStripButton = new ToolStripButton();
            SizeShoedataGridView = new DataGridView();
            ColZise = new DataGridViewTextBoxColumn();
            ColStock = new DataGridViewTextBoxColumn();
            miniToolStrip = new ToolStrip();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SizeShoedataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(SizeShoedataGridView);
            splitContainer2.Size = new Size(330, 383);
            splitContainer2.SplitterDistance = 61;
            splitContainer2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { EditartoolStripButton, toolStripSeparator4, SalirtoolStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(330, 61);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // EditartoolStripButton
            // 
            EditartoolStripButton.Font = new Font("Candara", 11.25F);
            EditartoolStripButton.Image = Properties.Resources.edit_36px;
            EditartoolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            EditartoolStripButton.ImageTransparentColor = Color.Magenta;
            EditartoolStripButton.Name = "EditartoolStripButton";
            EditartoolStripButton.Size = new Size(48, 58);
            EditartoolStripButton.Text = "Editar";
            EditartoolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            EditartoolStripButton.Click += EditartoolStripButton_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 61);
            // 
            // SalirtoolStripButton
            // 
            SalirtoolStripButton.Font = new Font("Candara", 11.25F);
            SalirtoolStripButton.Image = Properties.Resources.Logout_Rounded_36px;
            SalirtoolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            SalirtoolStripButton.ImageTransparentColor = Color.Magenta;
            SalirtoolStripButton.Name = "SalirtoolStripButton";
            SalirtoolStripButton.Size = new Size(40, 58);
            SalirtoolStripButton.Text = "Salir";
            SalirtoolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            SalirtoolStripButton.Click += SalirtoolStripButton_Click;
            // 
            // SizeShoedataGridView
            // 
            SizeShoedataGridView.AllowUserToAddRows = false;
            SizeShoedataGridView.AllowUserToDeleteRows = false;
            SizeShoedataGridView.BackgroundColor = Color.FromArgb(180, 210, 170);
            SizeShoedataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SizeShoedataGridView.Columns.AddRange(new DataGridViewColumn[] { ColZise, ColStock });
            SizeShoedataGridView.Dock = DockStyle.Fill;
            SizeShoedataGridView.GridColor = SystemColors.Menu;
            SizeShoedataGridView.Location = new Point(0, 0);
            SizeShoedataGridView.Name = "SizeShoedataGridView";
            SizeShoedataGridView.ReadOnly = true;
            SizeShoedataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SizeShoedataGridView.Size = new Size(330, 318);
            SizeShoedataGridView.TabIndex = 0;
            // 
            // ColZise
            // 
            ColZise.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new Font("Candara", 11.25F);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(222, 180, 210);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            ColZise.DefaultCellStyle = dataGridViewCellStyle3;
            ColZise.HeaderText = "Size";
            ColZise.Name = "ColZise";
            ColZise.ReadOnly = true;
            // 
            // ColStock
            // 
            ColStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Font = new Font("Candara", 11.25F);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(222, 180, 210);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            ColStock.DefaultCellStyle = dataGridViewCellStyle4;
            ColStock.HeaderText = "Stock";
            ColStock.Name = "ColStock";
            ColStock.ReadOnly = true;
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "Selección de nuevo elemento";
            miniToolStrip.AccessibleRole = AccessibleRole.ButtonDropDown;
            miniToolStrip.AutoSize = false;
            miniToolStrip.CanOverflow = false;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            miniToolStrip.Location = new Point(103, 21);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Size = new Size(665, 61);
            miniToolStrip.TabIndex = 0;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(330, 412);
            splitContainer1.SplitterDistance = 383;
            splitContainer1.TabIndex = 0;
            // 
            // FrmSizes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(330, 412);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmSizes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Shoes";
            Load += frmShoes_Load;
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SizeShoedataGridView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer2;
        private ToolStrip toolStrip1;
        private ToolStripButton EditartoolStripButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton SalirtoolStripButton;
        private DataGridView SizeShoedataGridView;
        private DataGridViewTextBoxColumn ColZise;
        private DataGridViewTextBoxColumn ColStock;
        private ToolStrip miniToolStrip;
        private SplitContainer splitContainer1;
    }
}