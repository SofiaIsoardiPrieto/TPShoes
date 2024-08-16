namespace TPShoes.Windows
{
    partial class FrmColours
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            NuevotoolStripButton = new ToolStripButton();
            EditartoolStripButton = new ToolStripButton();
            BorrartoolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            SalirtoolStripButton = new ToolStripButton();
            ColourdataGridView = new DataGridView();
            ColColour = new DataGridViewTextBoxColumn();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ColourdataGridView).BeginInit();
            SuspendLayout();
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
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Size = new Size(224, 307);
            splitContainer1.SplitterDistance = 249;
            splitContainer1.TabIndex = 0;
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
            splitContainer2.Panel2.Controls.Add(ColourdataGridView);
            splitContainer2.Size = new Size(224, 249);
            splitContainer2.SplitterDistance = 63;
            splitContainer2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { NuevotoolStripButton, EditartoolStripButton, BorrartoolStripButton, toolStripSeparator1, SalirtoolStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(224, 61);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // NuevotoolStripButton
            // 
            NuevotoolStripButton.Font = new Font("Candara", 11.25F);
            NuevotoolStripButton.Image = Properties.Resources.add_list_36px;
            NuevotoolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            NuevotoolStripButton.ImageTransparentColor = Color.Magenta;
            NuevotoolStripButton.Name = "NuevotoolStripButton";
            NuevotoolStripButton.Size = new Size(53, 58);
            NuevotoolStripButton.Text = "Nuevo";
            NuevotoolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            NuevotoolStripButton.Click += NuevotoolStripButton_Click;
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
            // BorrartoolStripButton
            // 
            BorrartoolStripButton.Font = new Font("Candara", 11.25F);
            BorrartoolStripButton.Image = Properties.Resources.delete_file_36px;
            BorrartoolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            BorrartoolStripButton.ImageTransparentColor = Color.Magenta;
            BorrartoolStripButton.Name = "BorrartoolStripButton";
            BorrartoolStripButton.Size = new Size(51, 58);
            BorrartoolStripButton.Text = "Borrar";
            BorrartoolStripButton.TextImageRelation = TextImageRelation.ImageAboveText;
            BorrartoolStripButton.Click += BorrartoolStripButton_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 61);
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
            // ColourdataGridView
            // 
            ColourdataGridView.AllowUserToAddRows = false;
            ColourdataGridView.AllowUserToDeleteRows = false;
            ColourdataGridView.BackgroundColor = Color.FromArgb(180, 210, 170);
            ColourdataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ColourdataGridView.Columns.AddRange(new DataGridViewColumn[] { ColColour });
            ColourdataGridView.Dock = DockStyle.Fill;
            ColourdataGridView.GridColor = SystemColors.Menu;
            ColourdataGridView.Location = new Point(0, 0);
            ColourdataGridView.Name = "ColourdataGridView";
            ColourdataGridView.ReadOnly = true;
            ColourdataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ColourdataGridView.Size = new Size(224, 182);
            ColourdataGridView.TabIndex = 0;
            // 
            // ColColour
            // 
            ColColour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Font = new Font("Candara", 11.25F);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(222, 180, 210);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            ColColour.DefaultCellStyle = dataGridViewCellStyle4;
            ColColour.HeaderText = "Colour";
            ColColour.Name = "ColColour";
            ColColour.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 18);
            label1.Name = "label1";
            label1.Size = new Size(171, 19);
            label1.TabIndex = 5;
            label1.Text = "Zapateria \"Los juanetes\"";
            // 
            // FrmColours
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(224, 307);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmColours";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Colours";
            Load += frmColours_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ColourdataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private DataGridView ColourdataGridView;
        private ToolStrip toolStrip1;
        private ToolStripButton NuevotoolStripButton;
        private ToolStripButton EditartoolStripButton;
        private ToolStripButton BorrartoolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton SalirtoolStripButton;
        private DataGridViewTextBoxColumn ColColour;
        private Label label1;
    }
}