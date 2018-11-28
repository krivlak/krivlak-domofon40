namespace domofon40
{
    partial class работы_период
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.наименColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фиоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.должностьColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.операцийColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суммаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.материалыColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.зарплатаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.работаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.мастерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1166, 45);
            this.panel1.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(245, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Подробности";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(57, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Word";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(564, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.наименColumn,
            this.фиоColumn,
            this.должностьColumn,
            this.операцийColumn,
            this.суммаColumn,
            this.материалыColumn,
            this.зарплатаColumn,
            this.работаColumn,
            this.мастерColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 45);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1166, 570);
            this.dataGridView1.TabIndex = 8;
            // 
            // наименColumn
            // 
            this.наименColumn.DataPropertyName = "наимен_работы";
            this.наименColumn.HeaderText = "работа";
            this.наименColumn.Name = "наименColumn";
            this.наименColumn.ReadOnly = true;
            this.наименColumn.Width = 400;
            // 
            // фиоColumn
            // 
            this.фиоColumn.DataPropertyName = "фио_мастера";
            this.фиоColumn.HeaderText = "мастер";
            this.фиоColumn.Name = "фиоColumn";
            this.фиоColumn.ReadOnly = true;
            this.фиоColumn.Width = 120;
            // 
            // должностьColumn
            // 
            this.должностьColumn.DataPropertyName = "должность";
            this.должностьColumn.HeaderText = "должность";
            this.должностьColumn.Name = "должностьColumn";
            this.должностьColumn.ReadOnly = true;
            // 
            // операцийColumn
            // 
            this.операцийColumn.DataPropertyName = "операций";
            this.операцийColumn.HeaderText = "операций";
            this.операцийColumn.Name = "операцийColumn";
            this.операцийColumn.ReadOnly = true;
            this.операцийColumn.Width = 60;
            // 
            // суммаColumn
            // 
            this.суммаColumn.DataPropertyName = "сумма";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0;#;#";
            this.суммаColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.суммаColumn.HeaderText = "сумма";
            this.суммаColumn.Name = "суммаColumn";
            this.суммаColumn.ReadOnly = true;
            this.суммаColumn.Width = 70;
            // 
            // материалыColumn
            // 
            this.материалыColumn.DataPropertyName = "материалы";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0;#;#";
            this.материалыColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.материалыColumn.HeaderText = "материалы";
            this.материалыColumn.Name = "материалыColumn";
            this.материалыColumn.ReadOnly = true;
            this.материалыColumn.Width = 70;
            // 
            // зарплатаColumn
            // 
            this.зарплатаColumn.DataPropertyName = "зарплата";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0;#;#";
            this.зарплатаColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.зарплатаColumn.HeaderText = "работа";
            this.зарплатаColumn.Name = "зарплатаColumn";
            this.зарплатаColumn.ReadOnly = true;
            this.зарплатаColumn.Width = 70;
            // 
            // работаColumn
            // 
            this.работаColumn.DataPropertyName = "работа";
            this.работаColumn.HeaderText = "работа";
            this.работаColumn.Name = "работаColumn";
            this.работаColumn.ReadOnly = true;
            this.работаColumn.Visible = false;
            // 
            // мастерColumn
            // 
            this.мастерColumn.DataPropertyName = "мастер";
            this.мастерColumn.HeaderText = "мастер";
            this.мастерColumn.Name = "мастерColumn";
            this.мастерColumn.ReadOnly = true;
            this.мастерColumn.Visible = false;
            // 
            // работы_период
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 615);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "работы_период";
            this.Text = "работы_период";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.работы_период_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фиоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn должностьColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn операцийColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суммаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn материалыColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn зарплатаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn работаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn мастерColumn;
    }
}