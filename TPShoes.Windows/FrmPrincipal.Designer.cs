namespace TPShoes.Windows
{
    partial class FrmPrincipal
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
            Shoesbutton = new Button();
            Brandsbutton = new Button();
            Genresbutton = new Button();
            Coloursbutton = new Button();
            Sportsbutton = new Button();
            Exitbutton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // Shoesbutton
            // 
            Shoesbutton.BackColor = Color.FromArgb(180, 210, 170);
            Shoesbutton.FlatStyle = FlatStyle.Flat;
            Shoesbutton.Font = new Font("Candara", 11.25F);
            Shoesbutton.Location = new Point(22, 52);
            Shoesbutton.Name = "Shoesbutton";
            Shoesbutton.Size = new Size(75, 30);
            Shoesbutton.TabIndex = 0;
            Shoesbutton.Text = "Shoes";
            Shoesbutton.UseVisualStyleBackColor = false;
            Shoesbutton.Click += Shoesbutton_Click;
            // 
            // Brandsbutton
            // 
            Brandsbutton.BackColor = Color.FromArgb(180, 210, 170);
            Brandsbutton.FlatStyle = FlatStyle.Flat;
            Brandsbutton.Font = new Font("Candara", 11.25F);
            Brandsbutton.Location = new Point(103, 52);
            Brandsbutton.Name = "Brandsbutton";
            Brandsbutton.Size = new Size(75, 30);
            Brandsbutton.TabIndex = 1;
            Brandsbutton.Text = "Brands";
            Brandsbutton.UseVisualStyleBackColor = false;
            Brandsbutton.Click += Brandsbutton_Click;
            // 
            // Genresbutton
            // 
            Genresbutton.BackColor = Color.FromArgb(180, 210, 170);
            Genresbutton.FlatStyle = FlatStyle.Flat;
            Genresbutton.Font = new Font("Candara", 11.25F);
            Genresbutton.Location = new Point(184, 52);
            Genresbutton.Name = "Genresbutton";
            Genresbutton.Size = new Size(75, 30);
            Genresbutton.TabIndex = 2;
            Genresbutton.Text = "Genres";
            Genresbutton.UseVisualStyleBackColor = false;
            Genresbutton.Click += Genresbutton_Click;
            // 
            // Coloursbutton
            // 
            Coloursbutton.BackColor = Color.FromArgb(180, 210, 170);
            Coloursbutton.FlatStyle = FlatStyle.Flat;
            Coloursbutton.Font = new Font("Candara", 11.25F);
            Coloursbutton.Location = new Point(265, 52);
            Coloursbutton.Name = "Coloursbutton";
            Coloursbutton.Size = new Size(75, 30);
            Coloursbutton.TabIndex = 3;
            Coloursbutton.Text = "Colours";
            Coloursbutton.UseVisualStyleBackColor = false;
            Coloursbutton.Click += Coloursbutton_Click;
            // 
            // Sportsbutton
            // 
            Sportsbutton.BackColor = Color.FromArgb(180, 210, 170);
            Sportsbutton.FlatStyle = FlatStyle.Flat;
            Sportsbutton.Font = new Font("Candara", 11.25F);
            Sportsbutton.Location = new Point(346, 52);
            Sportsbutton.Name = "Sportsbutton";
            Sportsbutton.Size = new Size(75, 30);
            Sportsbutton.TabIndex = 4;
            Sportsbutton.Text = "Sports";
            Sportsbutton.UseVisualStyleBackColor = false;
            Sportsbutton.Click += Sportsbutton_Click;
            // 
            // Exitbutton
            // 
            Exitbutton.BackColor = Color.White;
            Exitbutton.FlatStyle = FlatStyle.Flat;
            Exitbutton.ForeColor = Color.White;
            Exitbutton.Image = Properties.Resources.cancel_20px;
            Exitbutton.Location = new Point(408, 12);
            Exitbutton.Name = "Exitbutton";
            Exitbutton.Size = new Size(25, 25);
            Exitbutton.TabIndex = 5;
            Exitbutton.TextImageRelation = TextImageRelation.ImageAboveText;
            Exitbutton.UseVisualStyleBackColor = false;
            Exitbutton.Click += Exitbutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 13);
            label1.Name = "label1";
            label1.Size = new Size(263, 29);
            label1.TabIndex = 3;
            label1.Text = "Zapateria \"Los juanetes\"";
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = Color.White;
            ClientSize = new Size(445, 100);
            Controls.Add(label1);
            Controls.Add(Exitbutton);
            Controls.Add(Sportsbutton);
            Controls.Add(Coloursbutton);
            Controls.Add(Genresbutton);
            Controls.Add(Brandsbutton);
            Controls.Add(Shoesbutton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zapateria \"Los juanetes\"";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Shoesbutton;
        private Button Brandsbutton;
        private Button Genresbutton;
        private Button Coloursbutton;
        private Button Sportsbutton;
        private Button Exitbutton;
        private Label label1;
    }
}