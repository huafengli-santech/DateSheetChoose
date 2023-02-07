namespace TXTCodeAndDcode
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSecret = new System.Windows.Forms.Button();
            this.tbxBeforePath = new System.Windows.Forms.TextBox();
            this.btnOpenBefore = new System.Windows.Forms.Button();
            this.tbxAfterPath = new System.Windows.Forms.TextBox();
            this.btnOpenAfter = new System.Windows.Forms.Button();
            this.rbxLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSecret
            // 
            this.btnSecret.Location = new System.Drawing.Point(216, 239);
            this.btnSecret.Name = "btnSecret";
            this.btnSecret.Size = new System.Drawing.Size(152, 53);
            this.btnSecret.TabIndex = 0;
            this.btnSecret.Text = "加密";
            this.btnSecret.UseVisualStyleBackColor = true;
            this.btnSecret.Click += new System.EventHandler(this.btnSecret_Click);
            // 
            // tbxBeforePath
            // 
            this.tbxBeforePath.Location = new System.Drawing.Point(12, 12);
            this.tbxBeforePath.Name = "tbxBeforePath";
            this.tbxBeforePath.Size = new System.Drawing.Size(480, 21);
            this.tbxBeforePath.TabIndex = 1;
            // 
            // btnOpenBefore
            // 
            this.btnOpenBefore.Location = new System.Drawing.Point(498, 12);
            this.btnOpenBefore.Name = "btnOpenBefore";
            this.btnOpenBefore.Size = new System.Drawing.Size(109, 23);
            this.btnOpenBefore.TabIndex = 0;
            this.btnOpenBefore.Text = "打开加密文件夹";
            this.btnOpenBefore.UseVisualStyleBackColor = true;
            this.btnOpenBefore.Click += new System.EventHandler(this.btnOpenBefore_Click);
            // 
            // tbxAfterPath
            // 
            this.tbxAfterPath.Location = new System.Drawing.Point(12, 39);
            this.tbxAfterPath.Name = "tbxAfterPath";
            this.tbxAfterPath.Size = new System.Drawing.Size(480, 21);
            this.tbxAfterPath.TabIndex = 2;
            // 
            // btnOpenAfter
            // 
            this.btnOpenAfter.Location = new System.Drawing.Point(498, 39);
            this.btnOpenAfter.Name = "btnOpenAfter";
            this.btnOpenAfter.Size = new System.Drawing.Size(109, 23);
            this.btnOpenAfter.TabIndex = 0;
            this.btnOpenAfter.Text = "加密后文件夹路径";
            this.btnOpenAfter.UseVisualStyleBackColor = true;
            this.btnOpenAfter.Click += new System.EventHandler(this.btnOpenAfter_Click);
            // 
            // rbxLog
            // 
            this.rbxLog.Location = new System.Drawing.Point(12, 66);
            this.rbxLog.Name = "rbxLog";
            this.rbxLog.Size = new System.Drawing.Size(480, 167);
            this.rbxLog.TabIndex = 3;
            this.rbxLog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 304);
            this.Controls.Add(this.rbxLog);
            this.Controls.Add(this.tbxAfterPath);
            this.Controls.Add(this.tbxBeforePath);
            this.Controls.Add(this.btnOpenAfter);
            this.Controls.Add(this.btnOpenBefore);
            this.Controls.Add(this.btnSecret);
            this.Name = "Form1";
            this.Text = "选型软件加密软件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSecret;
        private System.Windows.Forms.TextBox tbxBeforePath;
        private System.Windows.Forms.Button btnOpenBefore;
        private System.Windows.Forms.TextBox tbxAfterPath;
        private System.Windows.Forms.Button btnOpenAfter;
        private System.Windows.Forms.RichTextBox rbxLog;
    }
}

