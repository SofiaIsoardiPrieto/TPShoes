namespace TPShoes.Windows
{
    partial class FrmColourFiltro
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Aceptarbutton = new Button();
            Cancelarbutton = new Button();
            label8 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ColourcomboBox = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // Aceptarbutton
            // 
            Aceptarbutton.BackColor = SystemColors.ButtonHighlight;
            Aceptarbutton.FlatStyle = FlatStyle.Flat;
            Aceptarbutton.Image = Properties.Resources.thumbs_up_36px;
            Aceptarbutton.Location = new Point(69, 69);
            Aceptarbutton.Name = "Aceptarbutton";
            Aceptarbutton.Size = new Size(75, 68);
            Aceptarbutton.TabIndex = 11;
            Aceptarbutton.Text = "Aceptar";
            Aceptarbutton.TextImageRelation = TextImageRelation.ImageAboveText;
            Aceptarbutton.UseVisualStyleBackColor = false;
            Aceptarbutton.Click += Aceptarbutton_Click;
            // 
            // Cancelarbutton
            // 
            Cancelarbutton.BackColor = SystemColors.ButtonHighlight;
            Cancelarbutton.FlatStyle = FlatStyle.Flat;
            Cancelarbutton.Image = Properties.Resources.thumbs_down_36px;
            Cancelarbutton.Location = new Point(185, 69);
            Cancelarbutton.Name = "Cancelarbutton";
            Cancelarbutton.Size = new Size(75, 68);
            Cancelarbutton.TabIndex = 12;
            Cancelarbutton.Text = "Cancelar";
            Cancelarbutton.TextImageRelation = TextImageRelation.ImageAboveText;
            Cancelarbutton.UseVisualStyleBackColor = false;
            Cancelarbutton.Click += Cancelarbutton_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Candara", 11.25F);
            label8.Location = new Point(12, 267);
            label8.Name = "label8";
            label8.Size = new Size(0, 18);
            label8.TabIndex = 4;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // ColourcomboBox
            // 
            ColourcomboBox.BackColor = SystemColors.InactiveCaption;
            ColourcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ColourcomboBox.Font = new Font("Candara", 11.25F);
            ColourcomboBox.FormattingEnabled = true;
            ColourcomboBox.Location = new Point(67, 21);
            ColourcomboBox.Name = "ColourcomboBox";
            ColourcomboBox.Size = new Size(237, 26);
            ColourcomboBox.TabIndex = 14;
            ColourcomboBox.SelectedIndexChanged += ColourcomboBox_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Candara", 11.25F);
            label3.Location = new Point(11, 24);
            label3.Name = "label3";
            label3.Size = new Size(52, 18);
            label3.TabIndex = 13;
            label3.Text = "Colour:";
            // 
            // FrmColourFiltro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(316, 149);
            Controls.Add(ColourcomboBox);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(Cancelarbutton);
            Controls.Add(Aceptarbutton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmColourFiltro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shoe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Aceptarbutton;
        private Button Cancelarbutton;
        private Label label8;
        private ErrorProvider errorProvider1;
        private ComboBox ColourcomboBox;
        private Label label3;
    }
}
