namespace DoHoaC_
{
    partial class FormDangNhap
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
            this.textBoxTenDN = new System.Windows.Forms.TextBox();
            this.textBoxMatkhau = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DangNhapBT = new System.Windows.Forms.Button();
            this.ThoatBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTenDN
            // 
            this.textBoxTenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenDN.Location = new System.Drawing.Point(288, 103);
            this.textBoxTenDN.Name = "textBoxTenDN";
            this.textBoxTenDN.Size = new System.Drawing.Size(299, 38);
            this.textBoxTenDN.TabIndex = 0;
            // 
            // textBoxMatkhau
            // 
            this.textBoxMatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatkhau.Location = new System.Drawing.Point(288, 185);
            this.textBoxMatkhau.Name = "textBoxMatkhau";
            this.textBoxMatkhau.PasswordChar = '*';
            this.textBoxMatkhau.Size = new System.Drawing.Size(299, 38);
            this.textBoxMatkhau.TabIndex = 1;
            this.textBoxMatkhau.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMatkhau_KeyDown);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(79, 103);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(203, 31);
            this.label.TabIndex = 2;
            this.label.Text = "Tên đăng nhập:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(142, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mật khẩu: ";
            // 
            // DangNhapBT
            // 
            this.DangNhapBT.BackColor = System.Drawing.Color.PowderBlue;
            this.DangNhapBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DangNhapBT.Location = new System.Drawing.Point(170, 251);
            this.DangNhapBT.Name = "DangNhapBT";
            this.DangNhapBT.Size = new System.Drawing.Size(162, 77);
            this.DangNhapBT.TabIndex = 4;
            this.DangNhapBT.Text = "Đăng nhập";
            this.DangNhapBT.UseVisualStyleBackColor = false;
            this.DangNhapBT.Click += new System.EventHandler(this.DangNhapBT_Click);
            // 
            // ThoatBT
            // 
            this.ThoatBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ThoatBT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThoatBT.Location = new System.Drawing.Point(400, 251);
            this.ThoatBT.Name = "ThoatBT";
            this.ThoatBT.Size = new System.Drawing.Size(162, 77);
            this.ThoatBT.TabIndex = 5;
            this.ThoatBT.Text = "Thoát";
            this.ThoatBT.UseVisualStyleBackColor = false;
            this.ThoatBT.Click += new System.EventHandler(this.ThoatBT_Click);
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(747, 391);
            this.Controls.Add(this.ThoatBT);
            this.Controls.Add(this.DangNhapBT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.textBoxMatkhau);
            this.Controls.Add(this.textBoxTenDN);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDangNhap";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDangNhap_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTenDN;
        private System.Windows.Forms.TextBox textBoxMatkhau;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DangNhapBT;
        private System.Windows.Forms.Button ThoatBT;
    }
}