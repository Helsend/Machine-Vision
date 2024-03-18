namespace 简单图像处理软件
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
            this.openBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.initalBtn = new System.Windows.Forms.Button();
            this.reflashBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.pictureShow = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShow)).BeginInit();
            this.SuspendLayout();
            // 
            // openBtn
            // 
            this.openBtn.AutoSize = true;
            this.openBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openBtn.Location = new System.Drawing.Point(39, 18);
            this.openBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openBtn.Name = "openBtn";
            this.openBtn.Size = new System.Drawing.Size(160, 60);
            this.openBtn.TabIndex = 0;
            this.openBtn.Text = "打开图片";
            this.openBtn.UseVisualStyleBackColor = true;
            this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveBtn.Location = new System.Drawing.Point(267, 18);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(160, 60);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "保存图片";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // initalBtn
            // 
            this.initalBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.initalBtn.Location = new System.Drawing.Point(717, 18);
            this.initalBtn.Margin = new System.Windows.Forms.Padding(4);
            this.initalBtn.Name = "initalBtn";
            this.initalBtn.Size = new System.Drawing.Size(160, 60);
            this.initalBtn.TabIndex = 3;
            this.initalBtn.Text = "初始化";
            this.initalBtn.UseVisualStyleBackColor = true;
            this.initalBtn.Click += new System.EventHandler(this.initalBtn_Click);
            // 
            // reflashBtn
            // 
            this.reflashBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reflashBtn.Location = new System.Drawing.Point(492, 18);
            this.reflashBtn.Margin = new System.Windows.Forms.Padding(4);
            this.reflashBtn.Name = "reflashBtn";
            this.reflashBtn.Size = new System.Drawing.Size(160, 60);
            this.reflashBtn.TabIndex = 5;
            this.reflashBtn.Text = "复原";
            this.reflashBtn.UseVisualStyleBackColor = true;
            this.reflashBtn.Click += new System.EventHandler(this.reflashBtn_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBox1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 36;
            this.listBox1.Items.AddRange(new object[] {
            "转化为灰度图",
            "反色",
            "图像二值化",
            "高斯滤波",
            "均值滤波",
            "中值滤波",
            "双边滤波",
            "边缘检测",
            "浮雕效果",
            "反转（左右）",
            "反转（上下）",
            "锐化",
            "膨胀",
            "腐蚀",
            "暗部增强",
            "亮部增强",
            "显示直方图",
            "轮廓绘制",
            "绘制轮廓图"});
            this.listBox1.Location = new System.Drawing.Point(0, 99);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(241, 832);
            this.listBox1.TabIndex = 6;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listBox2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 38;
            this.listBox2.Location = new System.Drawing.Point(1468, 99);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4);
            this.listBox2.Name = "listBox2";
            this.listBox2.ScrollAlwaysVisible = true;
            this.listBox2.Size = new System.Drawing.Size(280, 840);
            this.listBox2.TabIndex = 7;
            // 
            // pictureShow
            // 
            this.pictureShow.Location = new System.Drawing.Point(267, 100);
            this.pictureShow.Margin = new System.Windows.Forms.Padding(4);
            this.pictureShow.Name = "pictureShow";
            this.pictureShow.Size = new System.Drawing.Size(1210, 771);
            this.pictureShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureShow.TabIndex = 8;
            this.pictureShow.TabStop = false;
            this.pictureShow.Click += new System.EventHandler(this.pictureShow_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBox1.Location = new System.Drawing.Point(249, 879);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1208, 86);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "以下为通知信息：\r\n";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1461, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 40);
            this.label2.TabIndex = 11;
            this.label2.Text = "已进行处理操作：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1758, 972);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureShow);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.reflashBtn);
            this.Controls.Add(this.initalBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.openBtn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "简单小程序";
            this.Load += new System.EventHandler(this.intrudBtn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureShow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button initalBtn;
        private System.Windows.Forms.Button reflashBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.PictureBox pictureShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}

