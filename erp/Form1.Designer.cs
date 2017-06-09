namespace erp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tsexBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exDataGridView1 = new MyContrals.ExDataGridView();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.exDataGridView2 = new MyContrals.ExDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tsexBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "加载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "反射得到属性";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 23);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "打印T_sex";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(282, 23);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 30);
            this.button4.TabIndex = 4;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(458, 23);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 30);
            this.button5.TabIndex = 5;
            this.button5.Text = "加一行";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(552, 23);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 30);
            this.button6.TabIndex = 6;
            this.button6.Text = "保存";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(370, 23);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(84, 30);
            this.button7.TabIndex = 7;
            this.button7.Text = "删除一行";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // tsexBindingSource
            // 
            this.tsexBindingSource.DataSource = typeof(Model.T_sex);
            // 
            // exDataGridView1
            // 
            this.exDataGridView1.AllowUserToAddRows = false;
            this.exDataGridView1.AllowUserToDeleteRows = false;
            this.exDataGridView1.AllowUserToOrderColumns = true;
            this.exDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDataGridView1.Location = new System.Drawing.Point(17, 171);
            this.exDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.exDataGridView1.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.exDataGridView1.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("exDataGridView1.MergeColumnNames")));
            this.exDataGridView1.Name = "exDataGridView1";
            this.exDataGridView1.RowTemplate.Height = 27;
            this.exDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.exDataGridView1.Size = new System.Drawing.Size(619, 233);
            this.exDataGridView1.TabIndex = 0;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(29, 57);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(94, 30);
            this.button8.TabIndex = 9;
            this.button8.Text = "修改";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(128, 59);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(118, 28);
            this.button9.TabIndex = 10;
            this.button9.Text = "多表查询";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // exDataGridView2
            // 
            this.exDataGridView2.AllowUserToAddRows = false;
            this.exDataGridView2.AllowUserToDeleteRows = false;
            this.exDataGridView2.AllowUserToOrderColumns = true;
            this.exDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exDataGridView2.Location = new System.Drawing.Point(17, 423);
            this.exDataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.exDataGridView2.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.exDataGridView2.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("exDataGridView2.MergeColumnNames")));
            this.exDataGridView2.Name = "exDataGridView2";
            this.exDataGridView2.RowTemplate.Height = 27;
            this.exDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.exDataGridView2.Size = new System.Drawing.Size(619, 233);
            this.exDataGridView2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 702);
            this.Controls.Add(this.exDataGridView2);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.exDataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tsexBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exDataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyContrals.ExDataGridView exDataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource tsexBindingSource;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private MyContrals.ExDataGridView exDataGridView2;
    }
}