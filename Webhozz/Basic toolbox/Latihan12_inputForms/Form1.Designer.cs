namespace Latihan12_inputForms
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
            label1 = new Label();
            tbName = new TextBox();
            dtpTTL = new DateTimePicker();
            label2 = new Label();
            rbP = new RadioButton();
            rbW = new RadioButton();
            label3 = new Label();
            mtbTel = new MaskedTextBox();
            label4 = new Label();
            rtbAlamat = new RichTextBox();
            label5 = new Label();
            cbPaket = new ComboBox();
            label6 = new Label();
            cbY = new CheckBox();
            cbT = new CheckBox();
            label7 = new Label();
            btnSimpan = new Button();
            lbHobby = new ListBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 19);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "Nama Lengkap";
            // 
            // tbName
            // 
            tbName.Location = new Point(192, 19);
            tbName.Name = "tbName";
            tbName.Size = new Size(248, 27);
            tbName.TabIndex = 1;
            // 
            // dtpTTL
            // 
            dtpTTL.Location = new Point(190, 52);
            dtpTTL.Name = "dtpTTL";
            dtpTTL.Size = new Size(250, 27);
            dtpTTL.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 52);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 3;
            label2.Text = "TTL";
            // 
            // rbP
            // 
            rbP.AutoSize = true;
            rbP.Location = new Point(190, 90);
            rbP.Name = "rbP";
            rbP.Size = new Size(55, 24);
            rbP.TabIndex = 4;
            rbP.TabStop = true;
            rbP.Text = "Pria";
            rbP.UseVisualStyleBackColor = true;
            // 
            // rbW
            // 
            rbW.AutoSize = true;
            rbW.Location = new Point(251, 90);
            rbW.Name = "rbW";
            rbW.Size = new Size(76, 24);
            rbW.TabIndex = 5;
            rbW.TabStop = true;
            rbW.Text = "Wanita";
            rbW.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 94);
            label3.Name = "label3";
            label3.Size = new Size(23, 20);
            label3.TabIndex = 6;
            label3.Text = "JK";
            // 
            // mtbTel
            // 
            mtbTel.Location = new Point(190, 130);
            mtbTel.Name = "mtbTel";
            mtbTel.Size = new Size(250, 27);
            mtbTel.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 137);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 8;
            label4.Text = "No Telp";
            // 
            // rtbAlamat
            // 
            rtbAlamat.Location = new Point(190, 163);
            rtbAlamat.Name = "rtbAlamat";
            rtbAlamat.Size = new Size(250, 120);
            rtbAlamat.TabIndex = 9;
            rtbAlamat.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 182);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 10;
            label5.Text = "Alamat";
            // 
            // cbPaket
            // 
            cbPaket.FormattingEnabled = true;
            cbPaket.Items.AddRange(new object[] { "Basic", "Premium", "VVIP" });
            cbPaket.Location = new Point(192, 316);
            cbPaket.Name = "cbPaket";
            cbPaket.Size = new Size(248, 28);
            cbPaket.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 319);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 12;
            label6.Text = "Paket langganan";
            // 
            // cbY
            // 
            cbY.AutoSize = true;
            cbY.Location = new Point(195, 374);
            cbY.Name = "cbY";
            cbY.Size = new Size(46, 24);
            cbY.TabIndex = 13;
            cbY.Text = "Ya";
            cbY.UseVisualStyleBackColor = true;
            // 
            // cbT
            // 
            cbT.AutoSize = true;
            cbT.Location = new Point(269, 374);
            cbT.Name = "cbT";
            cbT.Size = new Size(67, 24);
            cbT.TabIndex = 14;
            cbT.Text = "Tidak";
            cbT.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 375);
            label7.Name = "label7";
            label7.Size = new Size(139, 20);
            label7.TabIndex = 15;
            label7.Text = "Setuju dengan TnC?";
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(595, 173);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 16;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // lbHobby
            // 
            lbHobby.FormattingEnabled = true;
            lbHobby.Items.AddRange(new object[] { "Mancing", "Naik gunung" });
            lbHobby.Location = new Point(195, 404);
            lbHobby.Name = "lbHobby";
            lbHobby.Size = new Size(150, 104);
            lbHobby.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 404);
            label8.Name = "label8";
            label8.Size = new Size(54, 20);
            label8.TabIndex = 18;
            label8.Text = "Hobby";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(774, 589);
            Controls.Add(label8);
            Controls.Add(lbHobby);
            Controls.Add(btnSimpan);
            Controls.Add(label7);
            Controls.Add(cbT);
            Controls.Add(cbY);
            Controls.Add(label6);
            Controls.Add(cbPaket);
            Controls.Add(label5);
            Controls.Add(rtbAlamat);
            Controls.Add(label4);
            Controls.Add(mtbTel);
            Controls.Add(label3);
            Controls.Add(rbW);
            Controls.Add(rbP);
            Controls.Add(label2);
            Controls.Add(dtpTTL);
            Controls.Add(tbName);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbName;
        private DateTimePicker dtpTTL;
        private Label label2;
        private RadioButton rbP;
        private RadioButton rbW;
        private Label label3;
        private MaskedTextBox mtbTel;
        private Label label4;
        private RichTextBox rtbAlamat;
        private Label label5;
        private ComboBox cbPaket;
        private Label label6;
        private CheckBox cbY;
        private CheckBox cbT;
        private Label label7;
        private Button btnSimpan;
        private ListBox lbHobby;
        private Label label8;
    }
}
