namespace Animation
{
    partial class Form
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExecute = new System.Windows.Forms.Button();
            this.cbWriteMode = new System.Windows.Forms.CheckBox();
            this.cmbAnime = new System.Windows.Forms.ComboBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOutAVI = new System.Windows.Forms.CheckBox();
            this.chkOutCopyright = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(16, 15);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(100, 29);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "実行";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cbWriteMode
            // 
            this.cbWriteMode.AutoSize = true;
            this.cbWriteMode.Location = new System.Drawing.Point(336, 20);
            this.cbWriteMode.Margin = new System.Windows.Forms.Padding(4);
            this.cbWriteMode.Name = "cbWriteMode";
            this.cbWriteMode.Size = new System.Drawing.Size(111, 19);
            this.cbWriteMode.TabIndex = 1;
            this.cbWriteMode.Text = "動画書き出し";
            this.cbWriteMode.UseVisualStyleBackColor = true;
            // 
            // cmbAnime
            // 
            this.cmbAnime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnime.FormattingEnabled = true;
            this.cmbAnime.Location = new System.Drawing.Point(136, 18);
            this.cmbAnime.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAnime.Name = "cmbAnime";
            this.cmbAnime.Size = new System.Drawing.Size(160, 23);
            this.cmbAnime.TabIndex = 2;
            this.cmbAnime.SelectedIndexChanged += new System.EventHandler(this.cmbAnime_SelectedIndexChanged);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(635, 20);
            this.txtLength.Margin = new System.Windows.Forms.Padding(4);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(132, 22);
            this.txtLength.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(777, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "秒";
            // 
            // chkOutAVI
            // 
            this.chkOutAVI.AutoSize = true;
            this.chkOutAVI.Location = new System.Drawing.Point(464, 20);
            this.chkOutAVI.Margin = new System.Windows.Forms.Padding(4);
            this.chkOutAVI.Name = "chkOutAVI";
            this.chkOutAVI.Size = new System.Drawing.Size(123, 19);
            this.chkOutAVI.TabIndex = 5;
            this.chkOutAVI.Text = "AVI形式で出力";
            this.chkOutAVI.UseVisualStyleBackColor = true;
            // 
            // chkOutCopyright
            // 
            this.chkOutCopyright.AutoSize = true;
            this.chkOutCopyright.Location = new System.Drawing.Point(835, 20);
            this.chkOutCopyright.Margin = new System.Windows.Forms.Padding(4);
            this.chkOutCopyright.Name = "chkOutCopyright";
            this.chkOutCopyright.Size = new System.Drawing.Size(119, 19);
            this.chkOutCopyright.TabIndex = 6;
            this.chkOutCopyright.Text = "Copyright出力";
            this.chkOutCopyright.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 911);
            this.Controls.Add(this.chkOutCopyright);
            this.Controls.Add(this.chkOutAVI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.cmbAnime);
            this.Controls.Add(this.cbWriteMode);
            this.Controls.Add(this.btnExecute);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form";
            this.Text = "Animation";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.CheckBox cbWriteMode;
        private System.Windows.Forms.ComboBox cmbAnime;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkOutAVI;
        private System.Windows.Forms.CheckBox chkOutCopyright;
    }
}

