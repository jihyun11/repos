namespace Notpad
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkCase = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdBtnDown = new System.Windows.Forms.RadioButton();
            this.rdBtnUp = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "찾을 내용";
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(115, 30);
            this.txtWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(276, 25);
            this.txtWord.TabIndex = 1;
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(426, 28);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(86, 29);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "다음 찾기";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(426, 94);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취  소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkCase
            // 
            this.chkCase.AutoSize = true;
            this.chkCase.Location = new System.Drawing.Point(33, 104);
            this.chkCase.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCase.Name = "chkCase";
            this.chkCase.Size = new System.Drawing.Size(130, 19);
            this.chkCase.TabIndex = 4;
            this.chkCase.Text = "대/소문자 구분";
            this.chkCase.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdBtnDown);
            this.groupBox1.Controls.Add(this.rdBtnUp);
            this.groupBox1.Location = new System.Drawing.Point(163, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(229, 64);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "방향";
            // 
            // rdBtnDown
            // 
            this.rdBtnDown.AutoSize = true;
            this.rdBtnDown.Checked = true;
            this.rdBtnDown.Location = new System.Drawing.Point(114, 24);
            this.rdBtnDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdBtnDown.Name = "rdBtnDown";
            this.rdBtnDown.Size = new System.Drawing.Size(73, 19);
            this.rdBtnDown.TabIndex = 1;
            this.rdBtnDown.TabStop = true;
            this.rdBtnDown.Text = "아래쪽";
            this.rdBtnDown.UseVisualStyleBackColor = true;
            // 
            // rdBtnUp
            // 
            this.rdBtnUp.AutoSize = true;
            this.rdBtnUp.Location = new System.Drawing.Point(27, 25);
            this.rdBtnUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdBtnUp.Name = "rdBtnUp";
            this.rdBtnUp.Size = new System.Drawing.Size(58, 19);
            this.rdBtnUp.TabIndex = 0;
            this.rdBtnUp.Text = "위쪽";
            this.rdBtnUp.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 170);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "찾 기";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txtWord;
        public System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.CheckBox chkCase;
        public System.Windows.Forms.RadioButton rdBtnDown;
        public System.Windows.Forms.RadioButton rdBtnUp;
    }
}