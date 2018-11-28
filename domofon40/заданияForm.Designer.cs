namespace domofon40
{
    partial class заданияForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.номерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.работаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.оплаченоColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.материалыColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.зарплатаColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.мастерColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1222, 100);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерColumn,
            this.работаColumn,
            this.оплаченоColumn,
            this.материалыColumn,
            this.зарплатаColumn,
            this.мастерColumn});
            this.dataGridView1.DataSource = this.bindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1222, 480);
            this.dataGridView1.TabIndex = 5;
            // 
            // номерColumn
            // 
            this.номерColumn.DataPropertyName = "номер";
            this.номерColumn.HeaderText = "номер";
            this.номерColumn.Name = "номерColumn";
            this.номерColumn.ReadOnly = true;
            // 
            // работаColumn
            // 
            this.работаColumn.DataPropertyName = "работы";
            this.работаColumn.HeaderText = "работа";
            this.работаColumn.Name = "работаColumn";
            this.работаColumn.ReadOnly = true;
            this.работаColumn.Width = 400;
            // 
            // оплаченоColumn
            // 
            this.оплаченоColumn.DataPropertyName = "стоимость";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "0;#;#";
            this.оплаченоColumn.DefaultCellStyle = dataGridViewCellStyle14;
            this.оплаченоColumn.HeaderText = "оплачено";
            this.оплаченоColumn.Name = "оплаченоColumn";
            // 
            // материалыColumn
            // 
            this.материалыColumn.DataPropertyName = "ст_материалов";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "0;#;#";
            this.материалыColumn.DefaultCellStyle = dataGridViewCellStyle15;
            this.материалыColumn.HeaderText = "стоимость материалов";
            this.материалыColumn.Name = "материалыColumn";
            // 
            // зарплатаColumn
            // 
            this.зарплатаColumn.DataPropertyName = "зарплата";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "0;#;#";
            this.зарплатаColumn.DefaultCellStyle = dataGridViewCellStyle16;
            this.зарплатаColumn.HeaderText = "стоимость работы";
            this.зарплатаColumn.Name = "зарплатаColumn";
            // 
            // мастерColumn
            // 
            this.мастерColumn.DataPropertyName = "сотрудники";
            this.мастерColumn.HeaderText = "мастер";
            this.мастерColumn.Name = "мастерColumn";
            this.мастерColumn.ReadOnly = true;
            this.мастерColumn.Width = 200;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "заполнить номер";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(567, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "записать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // заданияForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 580);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "заданияForm";
            this.Text = "заданияForm";
            this.Load += new System.EventHandler(this.заданияForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn работаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn оплаченоColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn материалыColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn зарплатаColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn мастерColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}