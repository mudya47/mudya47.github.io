namespace StudyCase3_CrudMHS
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
            label5 = new Label();
            btnSubmit = new Button();
            txtNim = new TextBox();
            txtNama = new TextBox();
            txtJurusan = new TextBox();
            txtAngkatan = new TextBox();
            txtIPK = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(37, 20);
            label1.TabIndex = 0;
            label1.Text = "NIM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 71);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 1;
            label2.Text = "Nama";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 116);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 2;
            label3.Text = "Jurusan";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 158);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 3;
            label4.Text = "Angkatan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 201);
            label5.Name = "label5";
            label5.Size = new Size(30, 20);
            label5.TabIndex = 4;
            label5.Text = "IPK";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(124, 267);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 29);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtNim
            // 
            txtNim.Location = new Point(124, 28);
            txtNim.Name = "txtNim";
            txtNim.Size = new Size(125, 27);
            txtNim.TabIndex = 6;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(124, 71);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(125, 27);
            txtNama.TabIndex = 7;
            // 
            // txtJurusan
            // 
            txtJurusan.Location = new Point(124, 113);
            txtJurusan.Name = "txtJurusan";
            txtJurusan.Size = new Size(125, 27);
            txtJurusan.TabIndex = 8;
            // 
            // txtAngkatan
            // 
            txtAngkatan.Location = new Point(124, 155);
            txtAngkatan.Name = "txtAngkatan";
            txtAngkatan.Size = new Size(125, 27);
            txtAngkatan.TabIndex = 9;
            // 
            // txtIPK
            // 
            txtIPK.Location = new Point(124, 198);
            txtIPK.Name = "txtIPK";
            txtIPK.Size = new Size(125, 27);
            txtIPK.TabIndex = 10;
            // 
            // CreateEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(338, 323);
            Controls.Add(txtIPK);
            Controls.Add(txtAngkatan);
            Controls.Add(txtJurusan);
            Controls.Add(txtNama);
            Controls.Add(txtNim);
            Controls.Add(btnSubmit);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateEditForm";
            Text = "CreateEditForm";
            Load += CreateEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSubmit;
        private TextBox txtNim;
        private TextBox txtNama;
        private TextBox txtJurusan;
        private TextBox txtAngkatan;
        private TextBox txtIPK;
    }
}