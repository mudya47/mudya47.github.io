﻿namespace StudyCase2_ListCrud
{
    partial class CreateEditForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbNameProduk = new TextBox();
            tbHarga = new TextBox();
            tbStok = new TextBox();
            btnSave = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(150, 26);
            label1.Name = "label1";
            label1.Size = new Size(152, 31);
            label1.TabIndex = 0;
            label1.Text = "Form Product";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 107);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 1;
            label2.Text = "Nama Produk";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 171);
            label3.Name = "label3";
            label3.Size = new Size(47, 20);
            label3.TabIndex = 2;
            label3.Text = "harga";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 232);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 3;
            label4.Text = "Stok";
            // 
            // tbNameProduk
            // 
            tbNameProduk.Location = new Point(160, 100);
            tbNameProduk.Name = "tbNameProduk";
            tbNameProduk.Size = new Size(219, 27);
            tbNameProduk.TabIndex = 4;
            // 
            // tbHarga
            // 
            tbHarga.Location = new Point(160, 171);
            tbHarga.Name = "tbHarga";
            tbHarga.Size = new Size(219, 27);
            tbHarga.TabIndex = 5;
            // 
            // tbStok
            // 
            tbStok.Location = new Point(160, 229);
            tbStok.Name = "tbStok";
            tbStok.Size = new Size(219, 27);
            tbStok.TabIndex = 6;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(62, 334);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(285, 334);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 8;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // CreateEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 395);
            Controls.Add(button2);
            Controls.Add(btnSave);
            Controls.Add(tbStok);
            Controls.Add(tbHarga);
            Controls.Add(tbNameProduk);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateEditForm";
            Text = "CreateEditForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbNameProduk;
        private TextBox tbHarga;
        private TextBox tbStok;
        private Button btnSave;
        private Button button2;
    }
}