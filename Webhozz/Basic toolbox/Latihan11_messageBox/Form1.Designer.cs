namespace Latihan11_messageBox
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
            buttonOk = new Button();
            buttonOkCancel = new Button();
            buttonYesNo = new Button();
            buttonYesNoCancel = new Button();
            buttonRetryCancel = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(12, 72);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(188, 29);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Menampilkan tombol OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonOkCancel
            // 
            buttonOkCancel.Location = new Point(206, 72);
            buttonOkCancel.Name = "buttonOkCancel";
            buttonOkCancel.Size = new Size(266, 29);
            buttonOkCancel.TabIndex = 1;
            buttonOkCancel.Text = "Menampilkan tombol OK dan Cancel";
            buttonOkCancel.UseVisualStyleBackColor = true;
            buttonOkCancel.Click += buttonOkCancel_Click;
            // 
            // buttonYesNo
            // 
            buttonYesNo.Location = new Point(478, 72);
            buttonYesNo.Name = "buttonYesNo";
            buttonYesNo.Size = new Size(242, 29);
            buttonYesNo.TabIndex = 2;
            buttonYesNo.Text = "Menampilkan tombol Yes dan No";
            buttonYesNo.UseVisualStyleBackColor = true;
            buttonYesNo.Click += buttonYesNo_Click;
            // 
            // buttonYesNoCancel
            // 
            buttonYesNoCancel.Location = new Point(12, 134);
            buttonYesNoCancel.Name = "buttonYesNoCancel";
            buttonYesNoCancel.Size = new Size(289, 29);
            buttonYesNoCancel.TabIndex = 3;
            buttonYesNoCancel.Text = "Menampilkan tombol Yes, No dan Cancel";
            buttonYesNoCancel.UseVisualStyleBackColor = true;
            buttonYesNoCancel.Click += buttonYesNoCancel_Click;
            // 
            // buttonRetryCancel
            // 
            buttonRetryCancel.Location = new Point(431, 134);
            buttonRetryCancel.Name = "buttonRetryCancel";
            buttonRetryCancel.Size = new Size(289, 29);
            buttonRetryCancel.TabIndex = 4;
            buttonRetryCancel.Text = "Menampilkan tombol Retry dan Cancel";
            buttonRetryCancel.UseVisualStyleBackColor = true;
            buttonRetryCancel.Click += buttonRetryCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 22);
            label1.Name = "label1";
            label1.Size = new Size(148, 31);
            label1.TabIndex = 5;
            label1.Text = "Message Box";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 203);
            Controls.Add(label1);
            Controls.Add(buttonRetryCancel);
            Controls.Add(buttonYesNoCancel);
            Controls.Add(buttonYesNo);
            Controls.Add(buttonOkCancel);
            Controls.Add(buttonOk);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOk;
        private Button buttonOkCancel;
        private Button buttonYesNo;
        private Button buttonYesNoCancel;
        private Button buttonRetryCancel;
        private Label label1;
    }
}
