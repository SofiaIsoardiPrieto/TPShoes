﻿namespace TPShoes.Windows
{
    partial class FrmGenres
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            toolStrip1 = new ToolStrip();
            NuevotoolStripButton = new ToolStripButton();
            EditartoolStripButton = new ToolStripButton();
            BorrartoolStripButton = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            SalirtoolStripButton = new ToolStripButton();
            GenredataGridView = new DataGridView();
            PaginasTotalestextBox = new TextBox();
            PaginaActualcomboBox = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            Ultimobutton = new Button();
            Anteriorbutton = new Button();
            Siguientebutton = new Button();
            Primerobutton = new Button();
            ColGenre = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GenredataGridView).BeginInit();
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
            splitContainer1.Panel2.Controls.Add(PaginasTotalestextBox);
            splitContainer1.Panel2.Controls.Add(PaginaActualcomboBox);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(Ultimobutton);
            splitContainer1.Panel2.Controls.Add(Anteriorbutton);
            splitContainer1.Panel2.Controls.Add(Siguientebutton);
            splitContainer1.Panel2.Controls.Add(Primerobutton);
            splitContainer1.Size = new Size(493, 306);
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
            splitContainer2.Panel2.Controls.Add(GenredataGridView);
            splitContainer2.Size = new Size(493, 249);
            splitContainer2.SplitterDistance = 63;
            splitContainer2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { NuevotoolStripButton, EditartoolStripButton, BorrartoolStripButton, toolStripSeparator1, SalirtoolStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(493, 61);
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
            // GenredataGridView
            // 
            GenredataGridView.AllowUserToAddRows = false;
            GenredataGridView.AllowUserToDeleteRows = false;
            GenredataGridView.BackgroundColor = Color.FromArgb(180, 210, 170);
            GenredataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GenredataGridView.Columns.AddRange(new DataGridViewColumn[] { ColGenre });
            GenredataGridView.Dock = DockStyle.Fill;
            GenredataGridView.GridColor = SystemColors.Menu;
            GenredataGridView.Location = new Point(0, 0);
            GenredataGridView.Name = "GenredataGridView";
            GenredataGridView.ReadOnly = true;
            GenredataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            GenredataGridView.Size = new Size(493, 182);
            GenredataGridView.TabIndex = 0;
            // 
            // PaginasTotalestextBox
            // 
            PaginasTotalestextBox.Font = new Font("Candara", 11.25F);
            PaginasTotalestextBox.Location = new Point(155, 14);
            PaginasTotalestextBox.Name = "PaginasTotalestextBox";
            PaginasTotalestextBox.Size = new Size(60, 26);
            PaginasTotalestextBox.TabIndex = 1;
            // 
            // PaginaActualcomboBox
            // 
            PaginaActualcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            PaginaActualcomboBox.Font = new Font("Candara", 11.25F);
            PaginaActualcomboBox.FormattingEnabled = true;
            PaginaActualcomboBox.Location = new Point(45, 13);
            PaginaActualcomboBox.Name = "PaginaActualcomboBox";
            PaginaActualcomboBox.Size = new Size(71, 26);
            PaginaActualcomboBox.TabIndex = 0;
            PaginaActualcomboBox.SelectedIndexChanged += PaginaActualcomboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Candara", 11.25F);
            label2.Location = new Point(123, 17);
            label2.Name = "label2";
            label2.Size = new Size(28, 18);
            label2.TabIndex = 1;
            label2.Text = "de:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 11.25F);
            label1.Location = new Point(4, 16);
            label1.Name = "label1";
            label1.Size = new Size(35, 18);
            label1.TabIndex = 1;
            label1.Text = "Pág:";
            // 
            // Ultimobutton
            // 
            Ultimobutton.BackColor = Color.White;
            Ultimobutton.FlatStyle = FlatStyle.Flat;
            Ultimobutton.Image = Properties.Resources.end_36px;
            Ultimobutton.Location = new Point(428, 6);
            Ultimobutton.Name = "Ultimobutton";
            Ultimobutton.Size = new Size(51, 40);
            Ultimobutton.TabIndex = 5;
            Ultimobutton.UseVisualStyleBackColor = false;
            Ultimobutton.Click += Ultimobutton_Click;
            // 
            // Anteriorbutton
            // 
            Anteriorbutton.BackColor = Color.White;
            Anteriorbutton.FlatStyle = FlatStyle.Flat;
            Anteriorbutton.Image = Properties.Resources.rewind_36px;
            Anteriorbutton.Location = new Point(303, 6);
            Anteriorbutton.Name = "Anteriorbutton";
            Anteriorbutton.Size = new Size(51, 40);
            Anteriorbutton.TabIndex = 3;
            Anteriorbutton.UseVisualStyleBackColor = false;
            Anteriorbutton.Click += Anteriorbutton_Click;
            // 
            // Siguientebutton
            // 
            Siguientebutton.BackColor = Color.White;
            Siguientebutton.FlatStyle = FlatStyle.Flat;
            Siguientebutton.Image = Properties.Resources.fast_forward_36px;
            Siguientebutton.Location = new Point(367, 6);
            Siguientebutton.Name = "Siguientebutton";
            Siguientebutton.Size = new Size(51, 40);
            Siguientebutton.TabIndex = 4;
            Siguientebutton.UseVisualStyleBackColor = false;
            Siguientebutton.Click += Siguientebutton_Click;
            // 
            // Primerobutton
            // 
            Primerobutton.BackColor = Color.White;
            Primerobutton.FlatStyle = FlatStyle.Flat;
            Primerobutton.Image = Properties.Resources.skip_to_start_36px;
            Primerobutton.Location = new Point(241, 6);
            Primerobutton.Name = "Primerobutton";
            Primerobutton.Size = new Size(51, 40);
            Primerobutton.TabIndex = 2;
            Primerobutton.TextImageRelation = TextImageRelation.TextBeforeImage;
            Primerobutton.UseVisualStyleBackColor = false;
            Primerobutton.Click += Primerobutton_Click;
            // 
            // ColGenre
            // 
            ColGenre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Font = new Font("Candara", 11.25F);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(222, 180, 210);
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            ColGenre.DefaultCellStyle = dataGridViewCellStyle1;
            ColGenre.HeaderText = "Genre";
            ColGenre.Name = "ColGenre";
            ColGenre.ReadOnly = true;
            // 
            // FrmGenres
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(493, 306);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGenres";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Shoes";
            Load += frmShoes_Load;
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
            ((System.ComponentModel.ISupportInitialize)GenredataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private DataGridView GenredataGridView;
        private Button Ultimobutton;
        private Button Anteriorbutton;
        private Button Siguientebutton;
        private Button Primerobutton;
        private TextBox PaginasTotalestextBox;
        private ComboBox PaginaActualcomboBox;
        private Label label2;
        private Label label1;
        private ToolStrip toolStrip1;
        private ToolStripButton NuevotoolStripButton;
        private ToolStripButton EditartoolStripButton;
        private ToolStripButton BorrartoolStripButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton SalirtoolStripButton;
        private DataGridViewTextBoxColumn ColGenre;
    }
}