namespace TPShoes.Windows
{
    partial class FrmPrincipal
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
            Shoebutton = new Button();
            Brandbutton = new Button();
            Colourbutton = new Button();
            Genrebutton = new Button();
            Sportbutton = new Button();
            SuspendLayout();
            // 
            // Shoebutton
            // 
            Shoebutton.Location = new Point(20, 30);
            Shoebutton.Name = "Shoebutton";
            Shoebutton.Size = new Size(75, 23);
            Shoebutton.TabIndex = 0;
            Shoebutton.Text = "Shoes";
            Shoebutton.UseVisualStyleBackColor = true;
            // 
            // Brandbutton
            // 
            Brandbutton.Location = new Point(120, 30);
            Brandbutton.Name = "Brandbutton";
            Brandbutton.Size = new Size(75, 23);
            Brandbutton.TabIndex = 0;
            Brandbutton.Text = "Brands";
            Brandbutton.UseVisualStyleBackColor = true;
            // 
            // Colourbutton
            // 
            Colourbutton.Location = new Point(220, 30);
            Colourbutton.Name = "Colourbutton";
            Colourbutton.Size = new Size(75, 23);
            Colourbutton.TabIndex = 0;
            Colourbutton.Text = "Colours";
            Colourbutton.UseVisualStyleBackColor = true;
            // 
            // Genrebutton
            // 
            Genrebutton.Location = new Point(320, 30);
            Genrebutton.Name = "Genrebutton";
            Genrebutton.Size = new Size(75, 23);
            Genrebutton.TabIndex = 0;
            Genrebutton.Text = "Genres";
            Genrebutton.UseVisualStyleBackColor = true;
            // 
            // Sportbutton
            // 
            Sportbutton.Location = new Point(420, 30);
            Sportbutton.Name = "Sportbutton";
            Sportbutton.Size = new Size(75, 23);
            Sportbutton.TabIndex = 0;
            Sportbutton.Text = "Sports";
            Sportbutton.UseVisualStyleBackColor = true;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 78);
            Controls.Add(Sportbutton);
            Controls.Add(Genrebutton);
            Controls.Add(Colourbutton);
            Controls.Add(Brandbutton);
            Controls.Add(Shoebutton);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Zapateria \"Los Juanetes\"";
            ResumeLayout(false);
        }

        #endregion

        private Button Shoebutton;
        private Button Brandbutton;
        private Button Colourbutton;
        private Button Genrebutton;
        private Button Sportbutton;
    }
}
