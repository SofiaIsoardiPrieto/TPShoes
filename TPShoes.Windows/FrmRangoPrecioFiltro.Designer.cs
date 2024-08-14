namespace TPShoes.Windows
{
    partial class FrmRangoPrecioFiltro
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
            MinPricetextBox = new TextBox();
            label2 = new Label();
            MaxPricetextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 11.25F);
            label1.Location = new Point(13, 23);
            label1.Name = "label1";
            label1.Size = new Size(101, 18);
            label1.TabIndex = 0;
            label1.Text = "Precio Mínimo:";
            // 
            // Aceptarbutton
            // 
            Aceptarbutton.BackColor = SystemColors.ButtonHighlight;
            Aceptarbutton.FlatStyle = FlatStyle.Flat;
            Aceptarbutton.Image = Properties.Resources.thumbs_up_36px;
            Aceptarbutton.Location = new Point(54, 98);
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
            Cancelarbutton.Location = new Point(191, 98);
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
            // MinPricetextBox
            // 
            MinPricetextBox.BackColor = SystemColors.InactiveCaption;
            MinPricetextBox.Font = new Font("Candara", 11.25F);
            MinPricetextBox.Location = new Point(120, 19);
            MinPricetextBox.Name = "MinPricetextBox";
            MinPricetextBox.Size = new Size(191, 26);
            MinPricetextBox.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Candara", 11.25F);
            label2.Location = new Point(11, 60);
            label2.Name = "label2";
            label2.Size = new Size(105, 18);
            label2.TabIndex = 0;
            label2.Text = "Precio Máximo:";
            // 
            // MaxPricetextBox
            // 
            MaxPricetextBox.BackColor = SystemColors.InactiveCaption;
            MaxPricetextBox.Font = new Font("Candara", 11.25F);
            MaxPricetextBox.Location = new Point(120, 55);
            MaxPricetextBox.Name = "MaxPricetextBox";
            MaxPricetextBox.Size = new Size(191, 26);
            MaxPricetextBox.TabIndex = 13;
            // 
            // FrmRangoPrecioFiltro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(333, 180);
            Controls.Add(MaxPricetextBox);
            Controls.Add(MinPricetextBox);
            Controls.Add(label8);
            Controls.Add(Cancelarbutton);
            Controls.Add(Aceptarbutton);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmRangoPrecioFiltro";
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
        private TextBox MinPricetextBox;
        private Label label2;
        private TextBox MaxPricetextBox;
    }
}
