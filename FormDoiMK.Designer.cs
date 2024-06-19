namespace DoHoaC_
{
    partial class FormDoiMK
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
            this.textBoxMKmoi2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxMKmoi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMKcu = new System.Windows.Forms.TextBox();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonLuuMK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ:";
            // 
            // textBoxMKmoi2
            // 
            this.textBoxMKmoi2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMKmoi2.Location = new System.Drawing.Point(345, 203);
            this.textBoxMKmoi2.Name = "textBoxMKmoi2";
            this.textBoxMKmoi2.PasswordChar = '*';
            this.textBoxMKmoi2.Size = new System.Drawing.Size(281, 38);
            this.textBoxMKmoi2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // textBoxMKmoi
            // 
            this.textBoxMKmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMKmoi.Location = new System.Drawing.Point(345, 127);
            this.textBoxMKmoi.Name = "textBoxMKmoi";
            this.textBoxMKmoi.PasswordChar = '*';
            this.textBoxMKmoi.Size = new System.Drawing.Size(281, 38);
            this.textBoxMKmoi.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhập lại mật khẩu mới:";
            // 
            // textBoxMKcu
            // 
            this.textBoxMKcu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMKcu.Location = new System.Drawing.Point(345, 52);
            this.textBoxMKcu.Name = "textBoxMKcu";
            this.textBoxMKcu.PasswordChar = '*';
            this.textBoxMKcu.Size = new System.Drawing.Size(281, 38);
            this.textBoxMKcu.TabIndex = 2;
            // 
            // buttonThoat
            // 
            this.buttonThoat.BackColor = System.Drawing.Color.PowderBlue;
            this.buttonThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.Location = new System.Drawing.Point(442, 289);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(197, 55);
            this.buttonThoat.TabIndex = 3;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = false;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonLuuMK
            // 
            this.buttonLuuMK.BackColor = System.Drawing.Color.PowderBlue;
            this.buttonLuuMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLuuMK.Location = new System.Drawing.Point(117, 289);
            this.buttonLuuMK.Name = "buttonLuuMK";
            this.buttonLuuMK.Size = new System.Drawing.Size(197, 55);
            this.buttonLuuMK.TabIndex = 3;
            this.buttonLuuMK.Text = "Lưu mật khẩu";
            this.buttonLuuMK.UseVisualStyleBackColor = false;
            this.buttonLuuMK.Click += new System.EventHandler(this.buttonLuuMK_Click);
            // 
            // FormDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 391);
            this.Controls.Add(this.buttonLuuMK);
            this.Controls.Add(this.buttonThoat);
            this.Controls.Add(this.textBoxMKcu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMKmoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxMKmoi2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormDoiMK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDoiMK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMKmoi2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxMKmoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMKcu;
        private System.Windows.Forms.Button buttonThoat;
        private System.Windows.Forms.Button buttonLuuMK;
    }
}