namespace RegExVeMorfolojikAnaliz
{
    partial class Form1
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
            btnDosyaEkle = new Button();
            lblDosyaAdi = new Label();
            txtDosyaAdi = new TextBox();
            btnRegexArama = new Button();
            lblRegexAramasi = new Label();
            txtAranacakRegex = new TextBox();
            richTxtMorfolojikAnalizGetir = new RichTextBox();
            btnMorfolojikAnaliz = new Button();
            SuspendLayout();
            // 
            // btnDosyaEkle
            // 
            btnDosyaEkle.BackColor = SystemColors.MenuHighlight;
            btnDosyaEkle.Location = new Point(185, 32);
            btnDosyaEkle.Name = "btnDosyaEkle";
            btnDosyaEkle.Size = new Size(140, 35);
            btnDosyaEkle.TabIndex = 0;
            btnDosyaEkle.Text = "Dosya Ekle ";
            btnDosyaEkle.UseVisualStyleBackColor = false;
            btnDosyaEkle.Click += btnDosyaEkle_Click;
            // 
            // lblDosyaAdi
            // 
            lblDosyaAdi.AutoSize = true;
            lblDosyaAdi.Location = new Point(147, 99);
            lblDosyaAdi.Name = "lblDosyaAdi";
            lblDosyaAdi.Size = new Size(81, 20);
            lblDosyaAdi.TabIndex = 1;
            lblDosyaAdi.Text = "Dosya Adı ";
            // 
            // txtDosyaAdi
            // 
            txtDosyaAdi.Location = new Point(251, 96);
            txtDosyaAdi.Name = "txtDosyaAdi";
            txtDosyaAdi.Size = new Size(283, 27);
            txtDosyaAdi.TabIndex = 2;
            // 
            // btnRegexArama
            // 
            btnRegexArama.BackColor = SystemColors.MenuHighlight;
            btnRegexArama.Location = new Point(691, 150);
            btnRegexArama.Name = "btnRegexArama";
            btnRegexArama.Size = new Size(140, 35);
            btnRegexArama.TabIndex = 3;
            btnRegexArama.Text = "Arama Yap";
            btnRegexArama.UseVisualStyleBackColor = false;
            btnRegexArama.Click += btnRegexArama_Click;
            // 
            // lblRegexAramasi
            // 
            lblRegexAramasi.AutoSize = true;
            lblRegexAramasi.Location = new Point(691, 32);
            lblRegexAramasi.Name = "lblRegexAramasi";
            lblRegexAramasi.Size = new Size(112, 20);
            lblRegexAramasi.TabIndex = 4;
            lblRegexAramasi.Text = "Regex Araması ";
            // 
            // txtAranacakRegex
            // 
            txtAranacakRegex.Location = new Point(646, 92);
            txtAranacakRegex.Name = "txtAranacakRegex";
            txtAranacakRegex.Size = new Size(271, 27);
            txtAranacakRegex.TabIndex = 5;
            // 
            // richTxtMorfolojikAnalizGetir
            // 
            richTxtMorfolojikAnalizGetir.Location = new Point(89, 287);
            richTxtMorfolojikAnalizGetir.Name = "richTxtMorfolojikAnalizGetir";
            richTxtMorfolojikAnalizGetir.Size = new Size(887, 172);
            richTxtMorfolojikAnalizGetir.TabIndex = 6;
            richTxtMorfolojikAnalizGetir.Text = "";
            // 
            // btnMorfolojikAnaliz
            // 
            btnMorfolojikAnaliz.BackColor = SystemColors.MenuHighlight;
            btnMorfolojikAnaliz.Location = new Point(356, 232);
            btnMorfolojikAnaliz.Name = "btnMorfolojikAnaliz";
            btnMorfolojikAnaliz.Size = new Size(392, 30);
            btnMorfolojikAnaliz.TabIndex = 7;
            btnMorfolojikAnaliz.Text = "Morfolojik Analiz Getir";
            btnMorfolojikAnaliz.UseVisualStyleBackColor = false;
            btnMorfolojikAnaliz.Click += btnMorfolojikAnaliz_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1144, 494);
            Controls.Add(btnMorfolojikAnaliz);
            Controls.Add(richTxtMorfolojikAnalizGetir);
            Controls.Add(txtAranacakRegex);
            Controls.Add(lblRegexAramasi);
            Controls.Add(btnRegexArama);
            Controls.Add(txtDosyaAdi);
            Controls.Add(lblDosyaAdi);
            Controls.Add(btnDosyaEkle);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDosyaEkle;
        private Label lblDosyaAdi;
        private TextBox txtDosyaAdi;
        private Button btnRegexArama;
        private Label lblRegexAramasi;
        private TextBox txtAranacakRegex;
        private RichTextBox richTxtMorfolojikAnalizGetir;
        private Button btnMorfolojikAnaliz;
    }
}