namespace TPShoes.Windows
{
    partial class FrmShoeAE
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
            label1 = new Label();
            Aceptarbutton = new Button();
            Cancelarbutton = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            PricetextBox = new TextBox();
            BrandcomboBox = new ComboBox();
            NuevoBrandbutton = new Button();
            DescripciontextBox = new TextBox();
            ModeltextBox = new TextBox();
            ColourcomboBox = new ComboBox();
            SportcomboBox = new ComboBox();
            GenrecomboBox = new ComboBox();
            NuevoGenrebutton = new Button();
            NuevoSportbutton = new Button();
            NuevoColourbutton = new Button();
            label8 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 11.25F);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(49, 18);
            label1.TabIndex = 0;
            label1.Text = "Brand:";
            // 
            // Aceptarbutton
            // 
            Aceptarbutton.BackColor = SystemColors.ButtonHighlight;
            Aceptarbutton.FlatStyle = FlatStyle.Flat;
            Aceptarbutton.Image = Properties.Resources.thumbs_up_36px;
            Aceptarbutton.Location = new Point(68, 323);
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
            Cancelarbutton.Location = new Point(202, 323);
            Cancelarbutton.Name = "Cancelarbutton";
            Cancelarbutton.Size = new Size(75, 68);
            Cancelarbutton.TabIndex = 12;
            Cancelarbutton.Text = "Cancelar";
            Cancelarbutton.TextImageRelation = TextImageRelation.ImageAboveText;
            Cancelarbutton.UseVisualStyleBackColor = false;
            Cancelarbutton.Click += Cancelarbutton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Candara", 11.25F);
            label2.Location = new Point(14, 103);
            label2.Name = "label2";
            label2.Size = new Size(46, 18);
            label2.TabIndex = 0;
            label2.Text = "Sport:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Candara", 11.25F);
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(52, 18);
            label3.TabIndex = 0;
            label3.Text = "Colour:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Candara", 11.25F);
            label4.Location = new Point(13, 187);
            label4.Name = "label4";
            label4.Size = new Size(52, 18);
            label4.TabIndex = 0;
            label4.Text = "Model:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Candara", 11.25F);
            label5.Location = new Point(180, 186);
            label5.Name = "label5";
            label5.Size = new Size(43, 18);
            label5.TabIndex = 0;
            label5.Text = "Price:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Candara", 11.25F);
            label6.Location = new Point(12, 224);
            label6.Name = "label6";
            label6.Size = new Size(85, 18);
            label6.TabIndex = 0;
            label6.Text = "Descripción:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Candara", 11.25F);
            label7.Location = new Point(12, 60);
            label7.Name = "label7";
            label7.Size = new Size(50, 18);
            label7.TabIndex = 0;
            label7.Text = "Genre:";
            // 
            // PricetextBox
            // 
            PricetextBox.BackColor = SystemColors.InactiveCaption;
            PricetextBox.Font = new Font("Candara", 11.25F);
            PricetextBox.Location = new Point(230, 184);
            PricetextBox.Name = "PricetextBox";
            PricetextBox.Size = new Size(93, 26);
            PricetextBox.TabIndex = 9;
            // 
            // BrandcomboBox
            // 
            BrandcomboBox.BackColor = SystemColors.InactiveCaption;
            BrandcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            BrandcomboBox.Font = new Font("Candara", 11.25F);
            BrandcomboBox.FormattingEnabled = true;
            BrandcomboBox.Location = new Point(69, 18);
            BrandcomboBox.Name = "BrandcomboBox";
            BrandcomboBox.Size = new Size(237, 26);
            BrandcomboBox.TabIndex = 0;
            BrandcomboBox.SelectedIndexChanged += BrandcomboBox_SelectedIndexChanged;
            // 
            // NuevoBrandbutton
            // 
            NuevoBrandbutton.BackColor = SystemColors.ButtonHighlight;
            NuevoBrandbutton.Image = Properties.Resources.plus_math_24px;
            NuevoBrandbutton.Location = new Point(314, 16);
            NuevoBrandbutton.Name = "NuevoBrandbutton";
            NuevoBrandbutton.Size = new Size(30, 30);
            NuevoBrandbutton.TabIndex = 1;
            NuevoBrandbutton.TextImageRelation = TextImageRelation.ImageAboveText;
            NuevoBrandbutton.UseVisualStyleBackColor = false;
            NuevoBrandbutton.Click += NuevoBrandbutton_Click;
            // 
            // DescripciontextBox
            // 
            DescripciontextBox.BackColor = SystemColors.InactiveCaption;
            DescripciontextBox.Font = new Font("Candara", 11.25F);
            DescripciontextBox.Location = new Point(14, 249);
            DescripciontextBox.Multiline = true;
            DescripciontextBox.Name = "DescripciontextBox";
            DescripciontextBox.Size = new Size(330, 68);
            DescripciontextBox.TabIndex = 10;
            // 
            // ModeltextBox
            // 
            ModeltextBox.BackColor = SystemColors.InactiveCaption;
            ModeltextBox.Font = new Font("Candara", 11.25F);
            ModeltextBox.Location = new Point(74, 183);
            ModeltextBox.Name = "ModeltextBox";
            ModeltextBox.Size = new Size(93, 26);
            ModeltextBox.TabIndex = 8;
            // 
            // ColourcomboBox
            // 
            ColourcomboBox.BackColor = SystemColors.InactiveCaption;
            ColourcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ColourcomboBox.Font = new Font("Candara", 11.25F);
            ColourcomboBox.FormattingEnabled = true;
            ColourcomboBox.Location = new Point(68, 142);
            ColourcomboBox.Name = "ColourcomboBox";
            ColourcomboBox.Size = new Size(237, 26);
            ColourcomboBox.TabIndex = 6;
            ColourcomboBox.SelectedIndexChanged += ColourcomboBox_SelectedIndexChanged;
            // 
            // SportcomboBox
            // 
            SportcomboBox.BackColor = SystemColors.InactiveCaption;
            SportcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            SportcomboBox.Font = new Font("Candara", 11.25F);
            SportcomboBox.FormattingEnabled = true;
            SportcomboBox.Location = new Point(69, 101);
            SportcomboBox.Name = "SportcomboBox";
            SportcomboBox.Size = new Size(237, 26);
            SportcomboBox.TabIndex = 4;
            SportcomboBox.SelectedIndexChanged += SportcomboBox_SelectedIndexChanged;
            // 
            // GenrecomboBox
            // 
            GenrecomboBox.BackColor = SystemColors.InactiveCaption;
            GenrecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            GenrecomboBox.Font = new Font("Candara", 11.25F);
            GenrecomboBox.FormattingEnabled = true;
            GenrecomboBox.Location = new Point(69, 57);
            GenrecomboBox.Name = "GenrecomboBox";
            GenrecomboBox.Size = new Size(237, 26);
            GenrecomboBox.TabIndex = 2;
            GenrecomboBox.SelectedIndexChanged += GenrecomboBox_SelectedIndexChanged;
            // 
            // NuevoGenrebutton
            // 
            NuevoGenrebutton.BackColor = SystemColors.ButtonHighlight;
            NuevoGenrebutton.Image = Properties.Resources.plus_math_24px;
            NuevoGenrebutton.Location = new Point(314, 55);
            NuevoGenrebutton.Name = "NuevoGenrebutton";
            NuevoGenrebutton.Size = new Size(30, 30);
            NuevoGenrebutton.TabIndex = 3;
            NuevoGenrebutton.TextImageRelation = TextImageRelation.ImageAboveText;
            NuevoGenrebutton.UseVisualStyleBackColor = false;
            NuevoGenrebutton.Click += NuevoGenrebutton_Click;
            // 
            // NuevoSportbutton
            // 
            NuevoSportbutton.BackColor = SystemColors.ButtonHighlight;
            NuevoSportbutton.Image = Properties.Resources.plus_math_24px;
            NuevoSportbutton.Location = new Point(314, 98);
            NuevoSportbutton.Name = "NuevoSportbutton";
            NuevoSportbutton.Size = new Size(30, 30);
            NuevoSportbutton.TabIndex = 5;
            NuevoSportbutton.TextImageRelation = TextImageRelation.ImageAboveText;
            NuevoSportbutton.UseVisualStyleBackColor = false;
            NuevoSportbutton.Click += NuevoSportbutton_Click;
            // 
            // NuevoColourbutton
            // 
            NuevoColourbutton.BackColor = SystemColors.ButtonHighlight;
            NuevoColourbutton.Image = Properties.Resources.plus_math_24px;
            NuevoColourbutton.Location = new Point(314, 140);
            NuevoColourbutton.Name = "NuevoColourbutton";
            NuevoColourbutton.Size = new Size(30, 30);
            NuevoColourbutton.TabIndex = 7;
            NuevoColourbutton.TextImageRelation = TextImageRelation.ImageAboveText;
            NuevoColourbutton.UseVisualStyleBackColor = false;
            NuevoColourbutton.Click += NuevoColourbutton_Click;
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
            // FrmShoeAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(364, 403);
            Controls.Add(label8);
            Controls.Add(SportcomboBox);
            Controls.Add(GenrecomboBox);
            Controls.Add(ColourcomboBox);
            Controls.Add(BrandcomboBox);
            Controls.Add(ModeltextBox);
            Controls.Add(DescripciontextBox);
            Controls.Add(PricetextBox);
            Controls.Add(Cancelarbutton);
            Controls.Add(NuevoColourbutton);
            Controls.Add(NuevoSportbutton);
            Controls.Add(NuevoGenrebutton);
            Controls.Add(NuevoBrandbutton);
            Controls.Add(Aceptarbutton);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmShoeAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shoe";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Aceptarbutton;
        private Button Cancelarbutton;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox PricetextBox;
        private ComboBox BrandcomboBox;
        private Button NuevoBrandbutton;
        private TextBox DescripciontextBox;
        private TextBox ModeltextBox;
        private ComboBox ColourcomboBox;
        private ComboBox SportcomboBox;
        private ComboBox GenrecomboBox;
        private Button NuevoGenrebutton;
        private Button NuevoSportbutton;
        private Button NuevoColourbutton;
        private Label label8;
        private ErrorProvider errorProvider1;
    }
}
