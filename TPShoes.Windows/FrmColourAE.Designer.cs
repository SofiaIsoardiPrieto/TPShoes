namespace TPShoes.Windows
{
    partial class FrmColourAE
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
            label8 = new Label();
            errorProvider1 = new ErrorProvider(components);
            ColourtextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 11.25F);
            label1.Location = new Point(13, 23);
            label1.Name = "label1";
            label1.Size = new Size(52, 18);
            label1.TabIndex = 0;
            label1.Text = "Colour:";
            // 
            // Aceptarbutton
            // 
            Aceptarbutton.BackColor = SystemColors.ButtonHighlight;
            Aceptarbutton.FlatStyle = FlatStyle.Flat;
            Aceptarbutton.Image = Properties.Resources.thumbs_up_36px;
            Aceptarbutton.Location = new Point(41, 69);
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
            Cancelarbutton.Location = new Point(157, 69);
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
            // ColourtextBox
            // 
            ColourtextBox.BackColor = SystemColors.InactiveCaption;
            ColourtextBox.Font = new Font("Candara", 11.25F);
            ColourtextBox.Location = new Point(69, 19);
            ColourtextBox.Name = "ColourtextBox";
            ColourtextBox.Size = new Size(191, 26);
            ColourtextBox.TabIndex = 13;
            // 
            // FrmColourAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(283, 149);
            Controls.Add(ColourtextBox);
            Controls.Add(label8);
            Controls.Add(Cancelarbutton);
            Controls.Add(Aceptarbutton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmColourAE";
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
        private Label label8;
        private ErrorProvider errorProvider1;
        private TextBox ColourtextBox;
    }
}
